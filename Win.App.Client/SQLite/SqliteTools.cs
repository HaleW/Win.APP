using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Win.App.Client.SQLite
{
    public class SqliteTools<T,W> where T : new()
    {
        public int InsertTool(T t, SqliteConnection connection, string tableName)
        {
            int res;
            try
            {
                SqliteCommand command = new SqliteCommand();
                PropertyInfo[] propertyInfos = t.GetType().GetProperties();

                string insertCommentText = "INSERT INTO " + tableName + "(";
                string tempValues = "";
                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    string name = propertyInfos[i].Name;
                    var value = propertyInfos[i].GetValue(t);

                    if (i == propertyInfos.Length - 1)
                    {
                        insertCommentText += name + ")";
                        tempValues += "@" + name + ")";
                    }
                    else
                    {
                        insertCommentText += name + ",";
                        tempValues += "@" + name + ",";
                    }

                    if (value == null)
                    {
                        value = DBNull.Value;
                    }
                    else
                    {
                        value = propertyInfos[i].GetValue(t, null);
                    }

                    command.Parameters.AddWithValue("@" + name, value);
                }

                insertCommentText += " VALUES(" + tempValues;

                command.CommandText = insertCommentText;
                command.Connection = connection;
                res = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }

        public List<T> SelectTool(SqliteConnection connection, string tableName)
        {
            List<T> ts = new List<T>();
            try
            {
                string selectCommandText = "SELECT * FROM " + tableName;
                SqliteCommand selectCommand = new SqliteCommand(selectCommandText, connection);
                SqliteDataReader dataReader = selectCommand.ExecuteReader();


                while (dataReader.Read())
                {
                    T t = new T();
                    PropertyInfo[] propertyInfos = t.GetType().GetProperties();

                    foreach (PropertyInfo info in propertyInfos)
                    {
                        object value = dataReader[info.Name];
                        if (value == DBNull.Value)
                        {
                            value = null;
                        }
                        else
                        {
                            switch (info.PropertyType.Name)
                            {
                                case "DateTime":
                                    value = DateTime.Parse(value.ToString());
                                    break;
                                default:
                                    break;
                            }
                        }

                        info.SetValue(t, value);
                    }
                    ts.Add(t);
                }
            }
            catch (Exception)
            {
                ts = null;
            }

            return ts;
        }

        public int UpdateTool(T t, SqliteConnection connection, string tableName, W where)
        {
            int res;
            try
            {
                PropertyInfo[] propertyInfos = t.GetType().GetProperties();
                SqliteCommand command = new SqliteCommand();
                string updateCommandText = "UPDATE " + tableName + " SET ";

                string whereKey = null;

                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    string name = propertyInfos[i].Name;
                    var value = propertyInfos[i].GetValue(t);

                    if (where.Equals(value))
                    {
                        whereKey = propertyInfos[i].Name;
                    }
                    else
                    {
                        if (i == propertyInfos.Length - 1)
                        {
                            updateCommandText += name + "=@" + name;
                        }
                        else
                        {
                            updateCommandText += name + "=@" + name + ", ";
                        }

                        command.Parameters.AddWithValue("@" + name, value);
                    }
                }

                if (whereKey == null)
                {
                    return 0;
                }

                updateCommandText += " WHERE " + whereKey + "=@" + whereKey;
                command.Parameters.AddWithValue("@" + whereKey, where);

                command.CommandText = updateCommandText;
                command.Connection = connection;

                res = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                res = 0;
            }

            return res;
        }

        public int DeleteTool(SqliteConnection connection, string tableName, W where, string whereOfName)
        {
            int res;
            try
            {
                string updateCommandText = "DELETE FROM " + tableName + " WHERE "+whereOfName+"=@"+whereOfName;
                SqliteCommand command = new SqliteCommand(updateCommandText, connection);
                command.Parameters.AddWithValue("@"+whereOfName, where);

                res = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }
    }
}
