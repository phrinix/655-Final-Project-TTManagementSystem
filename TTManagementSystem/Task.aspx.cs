using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TTManagementSystem
{
    public partial class Task : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoginInfo login = (LoginInfo)Session["login"];
                List<TaskInfo> task = TaskDAO.GetTask(login.UserName);
                TaskRepeater.DataSource = task;
                TaskRepeater.DataBind();

                if (task.Count == 0)
                {
                    lblNoTask.Text = "No Task has been assigned by or to You!";
                }
                else
                {
                    lblNoTask.Text = "Following are tasks assigned by or to You!";
                }
            }
                ddlAssignTo.DataSource = TaskDAO.userList();
                ddlAssignTo.DataTextField = "FullName";
                ddlAssignTo.DataValueField = "UserName";
                ddlAssignTo.DataBind();
            
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {   LoginInfo login = (LoginInfo)Session["login"];
                TaskDAO.createTask(login.UserName, ddlAssignTo.SelectedItem.Value, txbDescription.Text);
                Response.Write("Task Created");
                Response.Redirect("~/Task.aspx");
            }
        }

        protected void TaskRepeat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btnClick")
            {
                LoginInfo login = (LoginInfo)Session["login"];
                string taskID = (e.Item.FindControl("hfTask") as HiddenField).Value;
                var Status = (e.Item.FindControl("ddlStatus") as DropDownList);
                TaskDAO.updateTask(taskID, Status.SelectedItem.Value);
                Response.Write("Task Updated");
                Response.Redirect("~/Task.aspx");


            }
        }

    }
}