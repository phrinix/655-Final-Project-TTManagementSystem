using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TTManagementSystem
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string userRoll;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo login = (LoginInfo)Session["login"];
            lblName.Text = login.Name;
            userRoll = login.userRole;
        }
       
    }
}