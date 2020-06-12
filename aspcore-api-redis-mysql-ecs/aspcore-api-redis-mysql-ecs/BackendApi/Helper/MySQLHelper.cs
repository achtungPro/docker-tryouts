using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Helper
{
    public class MySQLHelper
    {
        public MySqlConnection GetConnection(string hostname, string rootPassword)
        {
            string mysqlConnectionString = "server={0};port=3306;database=test;user=root;password={1}";
            return new MySqlConnection(string.Format(mysqlConnectionString,hostname,rootPassword));
        }

        public void AddRandomValues(string hostname, string rootPassword)
        {
            using (MySqlConnection conn = GetConnection(hostname,rootPassword))
            {
                conn.Open();

                var cmd = new MySqlCommand();
                cmd.Connection = conn;
                              
                cmd.CommandText = @"CREATE TABLE IF NOT EXISTS TEST_DB(id INTEGER PRIMARY KEY AUTO_INCREMENT,
                    value TEXT)";
                cmd.ExecuteNonQuery();

                for(int loopIndex=0;loopIndex<5;loopIndex++)
                {
                    cmd.CommandText = "INSERT INTO TEST_DB(value) VALUES('"+Guid.NewGuid().ToString()+"')";
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        public List<string> GetAllValues(string hostname, string rootPassword)
        {
            List<string> data = new List<string>();
            using (MySqlConnection conn = GetConnection(hostname, rootPassword))
            {
                conn.Open();

                var cmd = new MySqlCommand("select value from TEST_DB", conn);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    data.Add(rdr.GetString(0));

                }

                conn.Close();
            }
            return data;
        }
    }
}
