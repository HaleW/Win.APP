# -*- coding: utf-8 -*-

import scrapy
from App.items import AppItem


class GimpSpider(scrapy.Spider):
    name = 'gimp'

    def start_requests(self):
        url = 'https://gimp.org/'
        yield scrapy.Request(url=url, callback=self.parse)

    def parse(self, response):
        url = response.url
        name = response.xpath('//*[@id="banner"]/div/div/h1/a/text()').extract_first()
        logo_url = url + response.xpath('//*[@id="WilberLogo"]/@src').extract_first()
        describe_en = response.xpath('//*[@id="introduction"]/div/div/div[1]//*//text()').extract()
        
        item = AppItem()
        item['name'] = name
        item['url'] = url
        item['logo_url'] = logo_url
        item['describe_en'] = describe_en
        item['describe_cn'] = ''

        download_page_url = 'https://www.gimp.org/downloads/'
        yield scrapy.Request(url=download_page_url, callback=self.parse_download, meta={'item': item})

    def parse_download(self, response):
        item = response.meta['item']

        download_url_64 = 'https:' + response.xpath('//*[@id="win-download-link"]/@href').extract_first()
        version = response.xpath('//*[@id="pushPage"]/section/div/div/div/p/b/text()').extract_first()
        release_date = response.xpath('//*[@id="pushPage"]/section/div/div/div/p/text()[2]').extract_first()[2:-2]

        item['download_url_32'] = ''
        item['download_url_64'] = download_url_64
        item['version'] = version
        item['release_date'] = release_date

        yield item
