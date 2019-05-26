using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace Win.App.Server.Database.Helper
{
    /// <summary>
    /// 数据形式转换类
    /// </summary>
    public class DataTypeConvertHelper<T> where T : new()
    {/// <summary>
     /// DataTable转List<Entity>
     /// </summary>
     /// <param name="dt">DataTable</param>
     /// <returns>List<Entity></returns>
        public List<T> DataTableToEntity(DataTable dt)
        {
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            List<T> entitys = new List<T>();

            foreach (DataRow dr in dt?.Rows)
            {
                T entity = new T();

                for (int i = 0; i < dr.Table.Columns.Count; i++)
                {
                    PropertyInfo propertyInfo = entity.GetType().GetProperty(dr.Table.Columns[i].ColumnName);
                    if (propertyInfo != null)
                    {
                        if(dr[i] == DBNull.Value)
                        {
                            switch (propertyInfo.PropertyType.Name)
                            {
                                case "String":
                                    dr[i] = "";
                                    break;
                                case "Double":
                                    dr[i] = 0;
                                    break;
                                default:
                                    var a = propertyInfo.GetType().Name;
                                    var b = propertyInfo;
                                    break;
                            }
                        }
                        propertyInfo.SetValue(entity, dr[i], null);
                    }
                }
                entitys.Add(entity);
            }

            return entitys;
        }

        /// <summary>
        /// DataRow转Entity
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>Entity</returns>
        public T DataRowToEntity(DataRow dr)
        {
            if (dr == null)
            {
                return default;
            }

            T entity = new T();

            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                PropertyInfo propertyInfo = entity.GetType().GetProperty(dr.Table.Columns[i].ColumnName);

                if (propertyInfo != null && dr[i] != DBNull.Value)
                {
                    propertyInfo.SetValue(entity, dr[i], null);
                }
            }

            return entity;
        }
    }
}
