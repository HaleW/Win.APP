using System;
using System.Collections.Generic;
using System.Text;

namespace Win.App.Server.Config
{
    /// <summary>
    /// 从Config.json中获取数据库的相关配置
    /// </summary>
    public class DatabaseConfig
    {
        // <summary>
        /// 从Config.json中获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        public static string ConnectionString => ConfigHelper.Configuration?["mysql:ConnectionString"];
    }
}
