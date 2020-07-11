using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using libzkfpcsharp;
using System.Threading;

namespace TTManagementSystem
{
    public partial class Admin :BasePage
    {

        Thread captureThread = new Thread(new ThreadStart(connectDevice.DoCapture));
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginInfo login = (LoginInfo)Session["login"];
            if (login.userRole != "ADMIN")
            {
                Response.Redirect("SignOut.aspx");
            }
            connectDevice.FingerTap = 1;

        }

        
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                if (txbPassword.Text != "" & txbUsername.Text != "")
                {
                    string status = UpdateUserDAO.UpdateUser(txbUsername.Text.ToUpper(), txbPassword.Text);
                    if (status == null)
                    {
                        lblInvalid.ForeColor = System.Drawing.Color.Red;
                        lblInvalid.Text = "No UserName found";
                        lblInvalid.Visible = true;
                    }
                    else
                    {
                        lblInvalid.Text = "Password Updated for user";
                        lblInvalid.Visible = true;
                        lblInvalid.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
        }

        protected void rbChangeP_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rbRegisterF.Checked == true)
            {
                connectDevice.connect();
                PPass.Visible = false;
                PFinger.Visible = true;
                if (connectDevice.DeviceConnected == 1)
                {
                    lblResult.Visible = false;
                    notConnected.Visible = false;
                    Connected.Visible = true;
                    captureThread.IsBackground = true;
                    connectDevice.bIsTimeToDie = false;
                    captureThread.Start();
                }
                else
                {
                    Connected.Visible = false;
                    notConnected.Visible = true;

                }
            }
            else
            {
                PFinger.Visible = false;
                PPass.Visible = true;
                if (connectDevice.DeviceConnected == 1)
                {
                    captureThread.Abort();
                    connectDevice.bIsTimeToDie = true;
                    connectDevice.DisconnectDevice();
                }

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (connectDevice.fingerPrintTemplate == string.Empty)
            {
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Text = "Number of Times Scanned: " + connectDevice.RegisterCount + "/3";
                lblResult.Visible = true;
            }
            else
            {
                if(IsValid)
                {
                    if(UpdateUserDAO.UpdateUserF(txbUser.Text.ToUpper(), connectDevice.fingerPrintTemplate) == null)
                    {
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "UserName was not found";
                        lblResult.Visible = true;
                        if (connectDevice.DeviceConnected == 1)
                        {
                            connectDevice.bIsTimeToDie = true;
                            connectDevice.DisconnectDevice();
                            connectDevice.connect();
                            captureThread.IsBackground = true;
                            connectDevice.bIsTimeToDie = false;
                            captureThread.Start();
                        }
                        
                    }
                    else
                    {
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = "Finger Print Registered!";
                        lblResult.Visible = true;
                        if (connectDevice.DeviceConnected == 1)
                        {
                            connectDevice.bIsTimeToDie = true;
                            connectDevice.DisconnectDevice();
                            connectDevice.connect();
                            captureThread.IsBackground = true;
                            connectDevice.bIsTimeToDie = false;
                            captureThread.Start();
                        }
                    }
                }
            }
            
        }
       
    }
}