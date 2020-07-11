using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
namespace TTManagementSystem
{
    public partial class Reset_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void data_check_Click(object sender, EventArgs e)
        {
            string sql = "Select UNAME, A1, A2 FROM USER_T";

            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
            conn.Open();
            OracleCommand cmd = new OracleCommand(sql,conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

            string username, ans1, ans2;
            string userTxt = Reset_txtUsername.Text;
            string a1Txt = txtSecurityAns1.Text;
            string a2Txt = txtSecurityAns2.Text;
               
            for(int i =0; i < dt.Rows.Count; i++ )
            {
                username = Convert.ToString(dt.Rows[i]["UNAME"]);
                ans1 = Convert.ToString(dt.Rows[i]["A1"]);
                ans2 = Convert.ToString(dt.Rows[i]["A2"]);

                if (String.Equals(userTxt,username))
                {
                    if(String.Equals(ans1,a1Txt) && String.Equals(ans2,a2Txt))
                    {
                        Session["username"] = userTxt;
                        Response.Redirect("~/Change_Password.aspx");
                    }
                    else{
                        InvalidLB.Visible= true;
                    }
                }
                if((i+1) == dt.Rows.Count && (!(String.Equals(userTxt,username))))
                {
                    InvalidLB.Visible = true;
                }
            }
        }
    }
}