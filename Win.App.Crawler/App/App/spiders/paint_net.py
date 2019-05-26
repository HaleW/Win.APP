# -*- coding: utf-8 -*-

import scrapy
from App.Tools.date import full_month_dir
from App.items import AppItem


class PaintNetSpider(scrapy.Spider):
    name = 'paint.net'

    def start_requests(self):
        url = 'https://getpaint.net/'
        yield scrapy.Request(url=url, callback=self.parse)

    def parse(self, response):
        url = response.url
        name = 'Paint.NET'
        logo_url = url + response.xpath('//*[@id="table3"]//table//img/@src').extract_first()
        describe_1 = response.xpath('//*[@id="table7"]//h5[6]//text()').extract()[1:]
        describe_2 = response.xpath('//*[@id="table7"]//h5[7]//text()').extract()
       
        describe_en = describe_1 + describe_2
        describe_cn = ''

        item = AppItem()
        item['name'] = name
        item['url'] = url
        item['logo_url'] = logo_url
        item['describe_en'] = describe_en
        item['describe_cn'] = describe_cn
        
        download_page_url = 'https://www.dotpdn.com/downloads/pdn.html'
        yield scrapy.Request(url=download_page_url, callback=self.parse_download_url, meta={'item': item})

    def parse_download_url(self, response):
        item = response.meta['item']
        url = response.url
        
        download_url_64 = url + response.xpath('//table//tr[3]//table//table//tr[1]/td/font[2]/b/a/@href').extract_first()[2:]
        download_url_32 = ''

        item['download_url_64'] = download_url_64
        item['download_url_32'] = download_url_32
        
        version_page_url = 'https://www.getpaint.net/download.html'
        yield scrapy.Request(url=version_page_url, callback=self.parse_version, meta={'item': item})

    def parse_version(self, response):
        item = response.meta['item']

        version = response.xpath('//*[@id="table8"]//tr[2]/td[1]/p/font/strong/text()').extract_first()
        date = response.xpath('//*[@id="table8"]//tr[2]/td[2]/p/font/text()').extract()
        temp = str(date[0]).split(' ')
        release_date = date[1] + '-' + full_month_dir[temp[0]] + '-' + temp[1]

        item['version'] = version
        item['release_date'] = release_date

        yield item
