using System.Collections.Generic;
using Win.App.Server.Database.DAL;
using Win.App.Server.Database.Entity;

namespace Win.App.Server.Database.BLL
{
    /// <summary>
    /// AppInfo业务逻辑
    /// </summary>
    public class AppInfoBLL
    {
        /// <summary>
        /// 通过应用名查询应用信息
        /// </summary>
        /// <param name="name">应用名</param>
        /// <returns>应用信息</returns>
        public static List<AppInfo> SelectAppByName(string name)
        {
            return AppInfoDAL.SelectAppByName(name);
        }
    }
}
