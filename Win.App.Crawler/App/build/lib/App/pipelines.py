# -*- coding: utf-8 -*-

from datetime import datetime
import re
from App.Tools.database import save_data, connect


class AppPipeline(object):
    def __init__(self):
        self.connect = connect()

    def process_item(self, item, spider):
        self.progress_describe(item)

        save_data(item, self.connect)

        print(item)

        return item

    def progress_describe(self, item):
        describe = [item['describe_en'], item['describe_cn']]

        for i in range(len(describe)):
            result = ''
            for j in range(len(describe[i])):
                result += re.sub(r'\xa0|\s{2:}', '', describe[i][j])

            if i == 0:
                item['describe_en'] = result
            elif i == 1:
                item['describe_cn'] = result

    def close_spider(self, spider):
        self.connect.close()
