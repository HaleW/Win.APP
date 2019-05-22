using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Win.App.Client.SQLite
{
    public class SqliteInitialize
    {
        public void InitializeDatabase(string tableName)
        {
            using (SqliteConnection connection = new SqliteConnection("Filename=" + tableName + ".db"))
            {
                connection.Open();
                string tableCommand = @"CREATE TABLE IF NOT EXISTS " + tableName + " (" +
                                        "Name TEXT NOT NULL," +
                                        "Url TEXT NOT NULL," +
                                        "LogoUrl TEXT NOT NULL," +
                                        "Img TEXT," +
                                        "DescribeEN TEXT," +
                                        "DescribeCN TEXT," +
                                        "DownloadUrl32 TEXT," +
                                        "DownloadUrl64 TEXT," +
                                        "ReleaseDate NUMERIC," +
                                        "Version TEXT," +
                                        "Score REAL," +
                                        "Type TEXT," +
                                        "PRIMARY KEY(Name))";

                SqliteCommand createTable = new SqliteCommand(tableCommand, connection);
                createTable.ExecuteReader();
            }
        }
    }
}
