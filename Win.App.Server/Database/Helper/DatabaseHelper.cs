using MySql.Data.MySqlClient;
using System.Data;
using Win.App.Server.Config;

namespace Win.App.Server.Database.Helper
{
    /// <summary>
    /// 数据库连接类
    /// </summary>
    public class DatabaseHelper
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private static readonly string ConnectionString = DatabaseConfig.ConnectionString;

        /// <summary>
        /// 传入SQL语句返回首行首列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>object</returns>
        public object ExecuteScalar(string sql)
        {
            try
            {
                MySqlConnection sqlConnection = new MySqlConnection(ConnectionString);
                sqlConnection.Open();
                MySqlCommand command = new MySqlCommand(sql, sqlConnection);

                sqlConnection.Close();

                return command.ExecuteScalar();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 传入SQL语句返回受影响的行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>int</returns>
        public int ExecuteNonQuery(string sql)
        {
            try
            {
                MySqlConnection sqlConnection = new MySqlConnection(ConnectionString);
                sqlConnection.Open();
                MySqlCommand command = new MySqlCommand(sql, sqlConnection);

                return command.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// 传入SQL语句返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string sql)
        {
            try
            {
                MySqlConnection sqlConnection = new MySqlConnection(ConnectionString);
                sqlConnection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, sqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                sqlConnection.Close();

                return dt;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 传入SQL语句和SqlParameter返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="parameters">SqlParameter</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteDataTable(string sql, MySqlParameter[] parameters)
        {
            try
            {
                MySqlConnection sqlConnection = new MySqlConnection(ConnectionString);
                sqlConnection.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, sqlConnection);
                adapter.SelectCommand.CommandType = CommandType.Text;
                adapter.SelectCommand.Parameters.AddRange(parameters);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
            catch
            {
                return null;
            }
        }
    }
}
