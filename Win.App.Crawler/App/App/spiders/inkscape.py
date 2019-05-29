# -*- coding: utf-8 -*-
import scrapy
from App.items import AppItem
from App.Tools.date import short_month_dir


class InkscapeSpider(scrapy.Spider):
    name = 'inkscape'

    def start_requests(self):
        url = 'http://inkscape.org'
        yield scrapy.Request(url=url, callback=self.parse)

    def parse(self, response):
        url = response.url

        name = response.xpath('//*[@id="logo"]/h1/a/text()').extract_first()

        logo_url = response.xpath('//*[@id="logo"]/a/img/@src').extract_first()

        describe_en = response.xpath('//*[@id="overview"]/div/p[1]/text()').extract_first()

        version_temp = response.xpath('//*[@id="overview"]/div/p[2]/span/text()').extract_first()
        version = version_temp.split(':')[1][1:]

        item = AppItem()

        item['name'] = name
        item['url'] = url
        item['logo_url'] = logo_url
        item['describe_en'] = describe_en
        item['version'] = version

        describe_cn_url = url+'zh/'
        yield scrapy.Request(url=describe_cn_url, callback=self.parse_describe_cn, meta={'item': item})

    def parse_describe_cn(self, response):
        item = response.meta['item']
        describe_cn = response.xpath(
            '//*[@id="banners"]/div[1]/div/p[1]/text()').extract_first()

        item['describe_cn'] = describe_cn

        download_page_url = response.url + 'release/' + item['version'] + '/platforms/'

        yield scrapy.Request(url=download_page_url, callback=self.parse_download, meta={'item': item})

    def parse_download(self, response):
        item = response.meta['item']

        download_url_32 = response.xpath('//*[@id="content"]/div/table//tr[8]/td[3]/a/@href').extract_first()

        download_url_64 = response.xpath('//*[@id="content"]/div/table//tr[12]/td[3]/a/@href').extract_first()

        release_date_temp = response.xpath('//*[@id="content"]/div/table//tr[12]/td[2]/text()').extract_first()
        date_list = release_date_temp.split(', ')
        month_day = date_list[0].split('. ')

        year = date_list[1]
        month = short_month_dir[month_day[0]]
        day = month_day[1]

        release_date = year + '-' + month + '-' + day

        item['download_url_32'] = item['url'] + download_url_32
        item['download_url_64'] = item['url'] + download_url_64
        item['release_date'] = release_date

        yield item
