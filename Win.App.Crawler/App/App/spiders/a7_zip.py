# -*- coding: utf-8 -*-

import scrapy

from App.items import AppItem


class A7ZipSpider(scrapy.Spider):
    name = '7-zip'

    def start_requests(self):
        url = 'https://7-zip.org/'
        yield scrapy.Request(url=url,callback=self.parse)

    def parse(self, response):
        url = response.url
        name = response.xpath('//table//td[2]//td/h1/text()').extract_first()
        logo_url = url[:-1] + response.xpath('//table//table[1]//img/@src').extract_first()
        describe_1 = response.xpath('//table//td[2]//td//p[1]//text()').extract()
        describe_2 = response.xpath('//table//td[2]//td//p[3]//text()').extract()
        describe_3 = response.xpath('//table//td[2]//td//p[4]//text()').extract()
        describe_en = describe_1 + describe_2 + describe_3
        download_url_64 = url + response.xpath('//table//td[2]//table[1]//tr[3]/td[1]/a/@href').extract_first()
        download_url_32 = url + response.xpath('//table//td[2]//table[1]//tr[2]/td[1]/a/@href').extract_first()
        version = response.xpath('//table//td[2]//td[2]/table[1]//td[1]/text()').extract_first()[6:]
        release_date = response.xpath('//table//td[2]//td[2]/table[1]//td[2]/text()').extract_first()

        item = AppItem()
        item['name'] = name
        item['url'] = url
        item['logo_url'] = logo_url
        item['describe_en'] = describe_en
        item['download_url_64'] = download_url_64
        item['download_url_32'] = download_url_32
        item['version'] = version
        item['release_date'] = release_date

        url_cn = 'https://sparanoid.com/lab/7z/'
        yield scrapy.Request(url=url_cn, callback=self.parse_cn, meta={'item': item})

    def parse_cn(self, response):
        item = response.meta['item']

        describe_1 = response.xpath('//table//td[2]//td//p[1]//text()').extract()
        describe_2 = response.xpath('//table//td[2]//td//p[3]//text()').extract()
        describe_3 = response.xpath('//table//td[2]//td//p[4]//text()').extract()
        describe_cn = describe_1 + describe_2 + describe_3

        item['describe_cn'] = describe_cn

        yield item
