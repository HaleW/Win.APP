# -*- coding: utf-8 -*-

# Define here the models for your scraped items
#
# See documentation in:
# https://doc.scrapy.org/en/latest/topics/items.html

import scrapy
from scrapy import Field


class AppItem(scrapy.Item):
    name = Field()
    url = Field()
    logo_url = Field()
    download_url_32 = Field()
    download_url_64 = Field()
    describe_cn = Field()
    describe_en = Field()
    release_date = Field()
    version = Field()
