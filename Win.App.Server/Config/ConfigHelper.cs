using Microsoft.Extensions.Configuration;

namespace Win.App.Server.Config
{
    /// <summary>
    /// 读取Settings.json文件
    /// </summary>
    public static class ConfigHelper
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        static ConfigHelper()
        {
            Configuration = new ConfigurationBuilder().AddJsonFile(@"Config/Config.json").Build();
        }

        /// <summary>
        /// 读取到的Settings.json文件中的配置信息
        /// </summary>
        public static IConfigurationRoot Configuration { get; }
    }
}
