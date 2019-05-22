using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Win.App.Client.SQLite
{
    public class SqliteTools<T> where T : new()
    {
        public int InsertTool(T t, SqliteConnection connection, string tableName)
        {
            int res;
            try
            {
                SqliteCommand command = new SqliteCommand();
                PropertyInfo[] propertyInfos = t.GetType().GetProperties();

                string insertCommentText = "INSERT INTO " + tableName + "(";

                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    if (i == propertyInfos.Length - 1)
                    {
                        insertCommentText += propertyInfos[i].Name + ")";
                    }
                    else
                    {
                        insertCommentText += propertyInfos[i].Name + ",";
                    }
                }

                insertCommentText += " VALUES(";

                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    if (i == propertyInfos.Length - 1)
                    {
                        insertCommentText += "@" + propertyInfos[i].Name + ");";
                    }
                    else
                    {
                        insertCommentText += "@" + propertyInfos[i].Name + ",";
                    }

                    object value = propertyInfos[i].GetValue(t, null);
                    if (value == null)
                    {

                        value = DBNull.Value;
                    }
                    else
                    {
                        value = propertyInfos[i].GetValue(t, null);
                    }
                    string name = "@" + propertyInfos[i].Name;
                    command.Parameters.AddWithValue(name, value);
                }

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

        public int UpdateTool(T t, SqliteConnection connection, string tableName,string where)
        {
            int res;
            try
            {
                PropertyInfo[] propertyInfos = t.GetType().GetProperties();

                string updateCommandText = "UPDATE " + tableName + " ";

                for (int i = 0; i < propertyInfos.Length; i++)
                {
                    if (i == propertyInfos.Length - 1)
                    {
                        updateCommandText += propertyInfos[i].Name + " = @" + propertyInfos[i].Name;
                    }
                    else
                    {
                        updateCommandText += propertyInfos[i].Name + " = @" + propertyInfos[i].Name + ",";
                    }
                }
                updateCommandText += " WHERE Name = @Name";
                SqliteCommand command = new SqliteCommand(updateCommandText, connection);
                command.Parameters.AddWithValue("@Name", where);
                res = command.ExecuteNonQuery();



            }
            catch (Exception)
            {
                res = 0;
            }

            return res;
        }

        public int DeleteTool(SqliteConnection connection, string tableName, string where)
        {
            int res;
            try
            {
                string updateCommandText = "DELETE FROM " + tableName + " WHERE Name = @Name";
                SqliteCommand command = new SqliteCommand(updateCommandText, connection);
                command.Parameters.AddWithValue("@Name", where);

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
