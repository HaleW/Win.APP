using System.Collections.Generic;
using Win.App.Model;
using Win.App.Server.Database.DAL;

namespace Win.App.Server.Database.BLL
{
    /// <summary>
    /// AppInfo业务逻辑
    /// </summary>
    public class AppInfoBLL
    {
        /// <summary>
        /// 查询所有应用信息
        /// </summary>
        /// <returns>应用信息列表</returns>
        public List<AppInfo> SelectAllApp()
        {
            return AppInfoDAL.SelectAllApp();
        }
    }
}
