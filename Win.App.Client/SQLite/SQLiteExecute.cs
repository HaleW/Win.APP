using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Win.App.Model;

namespace Win.App.Client.SQLite
{
    public class SqliteExecute<T, W> where T : new()
    {
        public int InsertData(string tableName, T t)
        {
            using (SqliteConnection connection = new SqliteConnection("Filename=" + tableName + ".db"))
            {
                connection.Open();
                SqliteTools<T, W> tools = new SqliteTools<T, W>();

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
                SqliteTools<T, W> tools = new SqliteTools<T, W>();
                List<T> t = tools.SelectTool(connection, tableName);

                connection.Close();

                return t;
            }
        }

        public int UpdateData(string tableName, W where, T t)
        {
            using (SqliteConnection connection = new SqliteConnection("Filename=" + tableName + ".db"))
            {
                connection.Open();
                SqliteTools<T, W> tools = new SqliteTools<T, W>();
                int res = tools.UpdateTool(t, connection, tableName, where);
                connection.Close();

                return res;
            }
        }

        public int DeleteData(string tableName, W where, string whereOfName)
        {
            using (SqliteConnection connection = new SqliteConnection("Filename=" + tableName + ".db"))
            {
                connection.Open();

                SqliteTools<T, W> tools = new SqliteTools<T, W>();

                int res = tools.DeleteTool(connection, tableName, where, whereOfName);

                connection.Close();

                return res;
            }
        }
    }
}
