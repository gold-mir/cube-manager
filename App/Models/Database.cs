using System;
using MySql.Data.MySqlClient;
using CubeHelper;

namespace CubeHelper.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            return new MySqlConnection(DBConfiguration.ConnectionString);
        }
    }
}
