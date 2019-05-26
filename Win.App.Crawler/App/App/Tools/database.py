from datetime import datetime
import pymysql.cursors


def connect():
    connect = pymysql.connect(
            host='127.0.0.1',
            port=3306,
            db='Win.App',
            user='wsl',
            passwd='1213',
            charset='utf8',
            use_unicode=True)

    return connect


def save_data(item, connect):
    try:
        cursor = connect.cursor()

        cursor.execute(insert(item)['sql'], insert(item)['data'])
        connect.commit()
    except Exception as err:
        print(str(err))
        try:
            cursor.execute(update(item)['sql'], update(item)['data'])
            connect.commit()
        except Exception as err:
            print(str(err))
            connect.rollback()


def insert(item):
    insert_sql = '''insert into AppInfo(
                `Name`,
                `Url`,
                `LogoUrl`,
                `DescribeCN`,
                `DescribeEN`,
                `DownloadUrl32`,
                `DownloadUrl64`,
                `ReleaseDate`,
                `Version`)
                values(%s, %s, %s, %s, %s, %s, %s, %s, %s)'''

    insert_data = (
        item['name'],
        item['url'],
        item['logo_url'],
        item['describe_cn'],
        item['describe_en'],
        item['download_url_32'],
        item['download_url_64'],
        datetime.strptime(item['release_date'], '%Y-%m-%d'),
        item['version'])

    return {'sql': insert_sql, 'data': insert_data}


def update(item):
    update_sql = '''update AppInfo set `Url` = %s,
                `LogoUrl` = %s,
                `DescribeCN` = %s,
                `DescribeEN` = %s,
                `DownloadUrl32` = %s,
                `DownloadUrl64` = %s,
                `ReleaseDate` = %s,
                `Version` = %s where `Name` = %s'''

    update_data = (
        item['url'],
        item['logo_url'],
        item['describe_cn'],
        item['describe_en'],
        item['download_url_32'],
        item['download_url_64'],
        datetime.strptime(item['release_date'], '%Y-%m-%d'),
        item['version'],
        item['name'])

    return {'sql': update_sql, 'data': update_data}
