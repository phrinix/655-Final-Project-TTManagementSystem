using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;

namespace TTManagementSystem
{
    public static class TestConnection
    {
        static private string OracelUser = "ols655_201a28";
        static private string OracelPass = "28182105";
        public static void Test()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1};", OracelUser, OracelPass));
            conn.Open(); // Try to connect using given username/password - if can't connect, an exception is thrown
            conn.Close();
        }
        public static string oracelUser { get { return OracelUser; } }
        public static string oracelPass { get { return OracelPass; } }
    }
}