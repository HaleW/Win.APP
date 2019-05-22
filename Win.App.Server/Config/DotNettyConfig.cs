using System;
using System.Collections.Generic;
using System.Text;

namespace Win.App.Server.Config
{
    /// <summary>
    /// 从Config.json中获取相关的DotNetty的设置
    /// </summary>
    public class DotNettyConfig
    {
        /// <summary>
        /// 从Config.json中获取ssl的bool类型值
        /// </summary>
        public static bool IsSsl
        {
            get
            {
                string ssl = ConfigHelper.Configuration["tcp:ssl"];

                return !string.IsNullOrEmpty(ssl) && bool.Parse(ssl);
            }
        }

        /// <summary>
        /// 从Config.json中获取libuv的bool类型值
        /// </summary>
        public static bool UseLibuv
        {
            get
            {
                string libuv = ConfigHelper.Configuration["tcp:libuv"];

                return !string.IsNullOrEmpty(libuv) && bool.Parse(libuv);
            }
        }

        /// <summary>
        /// 从Config.json中获取端口号
        /// </summary>
        public static int Port => int.Parse(ConfigHelper.Configuration["tcp:port"]);
    }
}
