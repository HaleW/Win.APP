using System.Collections.Generic;
using System.Data;
using Win.App.Server.Database.Entity;
using Win.App.Server.Database.Helper;

namespace Win.App.Server.Database.DAL
{
    /// <summary>
    /// AppInfo数据访问
    /// </summary>
    public class AppInfoDAL
    {
        /// <summary>
        /// 通过应用名查询应用信息
        /// </summary>
        /// <param name="name">应用名</param>
        /// <returns>应用信息</returns>
        public static List<AppInfo> SelectAppByName(string name)
        {
            string sql = "select * from AppInfo where Name = '" + name + "'";
            DatabaseHelper helper = new DatabaseHelper();
            DataTypeConvertHelper<AppInfo> convertHelper = new DataTypeConvertHelper<AppInfo>();
            DataTable dt = helper.ExecuteDataTable(sql);
            List<AppInfo> appInfos = convertHelper.DataTableToEntity(dt);

            return appInfos;
        }
    }
}
