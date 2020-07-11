using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace TTManagementSystem
{

    public class LoginInfoDAO
    {
        public static LoginInfo LoginTest(string UserName, string Password)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}",TestConnection.oracelUser,TestConnection.oracelPass));
            OracleCommand cmd = new OracleCommand("SELECT uname, u_password, firstname, u_status,dep_id FROM user_t", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            LoginInfo client;

            foreach (DataRow dr in dt.Rows)
            {
                if (UserName.ToUpper() == Convert.ToString(dr["uname"]) & Password == Convert.ToString(dr["u_password"]))
                {
                    client = new LoginInfo(Convert.ToString(dr["uname"]), Convert.ToString(dr["u_password"]), Convert.ToString(dr["firstname"]), Convert.ToString(dr["u_status"]));
                    return client;
                }
            }
            return null;
        }
        public static LoginInfo FingurePrintLogin(string UserID)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            OracleCommand cmd = new OracleCommand("SELECT u_id, uname, u_password, firstname, u_status, dep_id FROM user_t", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            LoginInfo client;

            foreach (DataRow dr in dt.Rows)
            {
                if (UserID.ToUpper() == Convert.ToString(dr["u_id"]))
                {
                    client = new LoginInfo(Convert.ToString(dr["uname"]), Convert.ToString(dr["u_password"]), Convert.ToString(dr["firstname"]), Convert.ToString(dr["u_status"]));
                    return client;
                }
            }
            return null;
        }
    }
}