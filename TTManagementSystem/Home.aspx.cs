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

    public partial class Home : BasePage
    {
        public int i = 0;
        public string userRoll;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoginInfo login = (LoginInfo)Session["login"];
                userRoll = login.userRole;
                lbxLocations.DataSource = LocationDAO.locations(login.userRole, login.UserName);
                lbxLocations.DataTextField = "loc";
                lbxLocations.DataValueField = "loc";
                lbxLocations.DataBind();
                ddlRoom.DataSource = LocationDAO.locations("Room", "");
                ddlRoom.DataTextField = "loc";
                ddlRoom.DataValueField = "loc";
                ddlRoom.DataBind();
                txbSubject.Attributes.Add("MaxLength", "20");
                
            }
        }

        protected void lbxLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoginInfo login = (LoginInfo)Session["login"];
            List<Ticket> tickets = TicketDAO.ticket(login.userRole, lbxLocations.SelectedValue, login.UserName);
            ticketRepeat.DataSource = tickets;
            ticketRepeat.DataBind();


            if (tickets.Count == 0)
            {
                lblNoRoomSelected.Visible = true;
                lblNoRoomSelected.Text = "No tickets available to view for this Room";
            }
            else
            {
                lblNoRoomSelected.Visible = false;
            }
            
        }

        protected void ticketRepeat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string ticketno = (e.Item.FindControl("hfTicket") as HiddenField).Value;
                Repeater commentRepeater = e.Item.FindControl("commentRepeater") as Repeater;
                commentRepeater.DataSource = CommentDAO.comment(ticketno);
                commentRepeater.DataBind();
                if (userRoll == "CLIENT")
                {
                    var Status = (e.Item.FindControl("ddlStatus") as DropDownList).Visible = false;
                }
               
            }
            
        }
        protected void ticketRepeat_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "btnClick")
            {
                LoginInfo login = (LoginInfo)Session["login"];
                string ticketno = (e.Item.FindControl("hfTicket") as HiddenField).Value;
                var Description = (e.Item.FindControl("txtUpdate") as TextBox);
                var Status = (e.Item.FindControl("ddlStatus") as DropDownList);
                if (userRoll != "CLIENT")
                {
                    AddUpdateDAO.UpdateTicket(login.UserName, ticketno, Status.SelectedItem.Value, Description.Text);
                    
                }
                else
                {
                    AddUpdateDAO.UpdateTicket(login.UserName, ticketno, "OPEN", Description.Text);
                }
                Response.Write("Ticket Updated");
                Response.Redirect("~/Home.aspx");


            }
        }

        protected void btnAdd_OnClientClick(object sender, EventArgs e)
        {
            LoginInfo login = (LoginInfo)Session["login"];
            string user_id = login.UserName;
            string room = ddlRoom.SelectedItem.Text;
            string severity = ddlSeverity.SelectedItem.Text;
            string subj = txbSubject.Text;
            string descript = txbDescription.Text;
            AddUpdateDAO.AddTicket(user_id, room, severity, subj, descript);
            Response.Write("Ticket created");
            Response.Redirect("~/Home.aspx");
        }
    }
}




/*--TESTING--
INSERT INTO TICKET_PROP(TICKET_ID, STATUS, SEVERITY, SUBJECT, ROOM_NO) VALUES (TICKET_ID_SEQUENCE.NEXTVAL, 'OPEN', 'LOW', 'Internet connection issue', 'A1200');
INSERT INTO TICKET_PROP(TICKET_ID, STATUS, SEVERITY, SUBJECT, ROOM_NO) VALUES (TICKET_ID_SEQUENCE.NEXTVAL, 'INPROGRESS', 'HIGH', 'Outlook email issue', 'A1250');
--TESTING--
INSERT INTO COMMENTS(TICKET_ID, TIME_STAMP, DESCRIPTION, UNAME) VALUES (100, CURRENT_TIMESTAMP, 'My computer cannot connect to internet or wifi.', 'VP367');
INSERT INTO COMMENTS(TICKET_ID, TIME_STAMP, DESCRIPTION, UNAME) VALUES (101, CURRENT_TIMESTAMP, 'My emails from last week are not showing in my inbox nor in deleted emails', 'PSINGH02');
INSERT INTO COMMENTS(TICKET_ID, TIME_STAMP, DESCRIPTION, UNAME) VALUES (100, CURRENT_TIMESTAMP, 'My computer is not turnng on anymore.', 'VP367');
*/