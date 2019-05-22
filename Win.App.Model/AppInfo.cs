using System;
using System.Collections.Generic;
using System.Text;

namespace Win.App.Model
{
    /// <summary>
    /// 应用信息实体类
    /// </summary>
    public class AppInfo
    {
        /// <summary>
        /// 应用名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 应用Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 应用LogoUrl
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// 应用图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 应用描述EN
        /// </summary>
        public string DescribeEN { get; set; }

        /// <summary>
        /// 应用描述CN
        /// </summary>
        public string DescribeCN { get; set; }

        /// <summary>
        /// 应用下载URL 32bit
        /// </summary>
        public string DownloadUrl32 { get; set; }

        /// <summary>
        /// 应用下载URL 64bit
        /// </summary>
        public string DownloadUrl64 { get; set; }

        /// <summary>
        /// 应用版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 应用发布时间
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// 应用评分
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// 应用类型
        /// </summary>
        public string Type { get; set; }
    }
}