using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Win.App.Model;

namespace Win.App.Client.SQLite
{
    public class SqliteExecute<T>where T:new()
    {
        public int InsertData(string tableName, T t)
        {
            using (SqliteConnection connection = new SqliteConnection("Filename=" + tableName + ".db"))
            {
                connection.Open();
                SqliteTools<T> tools = new SqliteTools<T>();

                int res = tools.InsertTool(t, connection, tableName);

                connection.Close();
                return res;
            }
        }

        public List<T> SelectData(string tableName)
        {
            using (SqliteConnection connection = new SqliteConnection("Filename=" + tableName + ".db"))
            {
                connection.Open();
                SqliteTools<T> tools = new SqliteTools<T>();
                List<T> t = tools.SelectTool(connection, tableName);

                connection.Close();

                return t;
            }
        }

        public int UpdateData(string tableName, string where, T t)
        {
            using (SqliteConnection connection = new SqliteConnection("Filename=" + tableName + ".db"))
            {
                connection.Open();
                SqliteTools<T> tools = new SqliteTools<T>();
                int res = tools.UpdateTool(t,connection,tableName,where);
                connection.Close();

                return res;
            }
        }

        public int DeleteData(string tableName, string where)
        {
            using (SqliteConnection connection = new SqliteConnection("Filename=" + tableName + ".db"))
            {
                connection.Open();

                SqliteTools<T> tools = new SqliteTools<T>();

                int res = tools.DeleteTool(connection, tableName, where);

                connection.Close();

                return res;
            }
        }
    }
}
