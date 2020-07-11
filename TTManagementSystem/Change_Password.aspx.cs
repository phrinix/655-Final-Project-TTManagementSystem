using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OracleClient;

namespace TTManagementSystem
{
    public partial class Change_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            userLB.Text = Session["username"].ToString();

        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            if (txtChangePass.Text == txtReenterPass.Text)
            {

                OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                string sql = "UPDATE user_t SET U_PASSWORD = :pass WHERE uname = :username";
                cmd.Parameters.AddWithValue("username", userLB.Text);
                cmd.Parameters.AddWithValue("pass", txtChangePass.Text);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                errorLB.Visible = true;
                
            }
        }
    }
}