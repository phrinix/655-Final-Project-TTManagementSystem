using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace TTManagementSystem
{
    public class UpdateUserDAO
    {
        public static string UpdateUser(string UserName, string Pass)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            OracleCommand cmd = new OracleCommand("SELECT uname FROM user_t", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                if (UserName.ToUpper() == Convert.ToString(dr["uname"]))
                {
                    conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
                    conn.Open();
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandType = CommandType.Text;
                    string sql = "UPDATE user_t SET U_PASSWORD = :upass WHERE uname = :UserName";
                    cmd2.Parameters.AddWithValue("upass", Pass);
                    cmd2.Parameters.AddWithValue("UserName", UserName);
                    cmd2.CommandText = sql;
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    return Convert.ToString(dr["uname"]);
                }
            }
            return null;
        }
        public static string UpdateUserF(string User, string fingerPrintTemplate )
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            OracleCommand cmd = new OracleCommand("SELECT uname FROM user_t", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                if (User.ToUpper() == Convert.ToString(dr["uname"]))
                {

                    conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
                    conn.Open();
                    OracleCommand cmd2 = new OracleCommand();
                    cmd2.Connection = conn;
                    cmd2.CommandType = CommandType.Text;
                    string sql = "UPDATE user_t SET F_ID = :ftemp WHERE uname = :UserName";
                    cmd2.Parameters.AddWithValue("ftemp", fingerPrintTemplate);
                    cmd2.Parameters.AddWithValue("UserName", User);
                    cmd2.CommandText = sql;
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    return Convert.ToString(dr["uname"]);
                }
            }
            return null;
        }
    }
}