using System;
using Win.App.UWP.Tools;

namespace Win.App.UWP.Model
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
        /// 应用图片
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// 应用描述
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 应用下载URL
        /// </summary>
        public string DownloadUrl { get; set; }

        /// <summary>
        /// 应用版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 应用发布时间
        /// </summary>
        public DateTime ReleaseDateTime { get; set; }

        /// <summary>
        /// 应用下载次数
        /// </summary>
        public int DownloadCount { get; set; }

        /// <summary>
        /// 应用评分
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// 应用类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 应用下载状态
        /// </summary>
        public DownloadState DownloadState { get; set; }

        /// <summary>
        /// 下载错误消息
        /// </summary>
        public string DownloadErrorMsg { get; set; }
    }
}
