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
    
    public partial class Login : System.Web.UI.Page
    {
        Thread captureThread = new Thread(new ThreadStart(connectDevice.DoCapture));
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    TestConnection.Test();
                }
                catch (Exception)
                {
                    lblInvalid.Text = "Server Connection Error! Try Again Later";
                    lblInvalid.Visible = true;
                }
                try
                {
                    LoginInfo loginInfo = LoginInfoDAO.LoginTest(txtUsername.Text, txtPassword.Text);
                    if (loginInfo != null)
                    {
                        Session.Add("login", loginInfo);
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        lblInvalid.Text = "Invalid UserName and/or Password.";
                        lblInvalid.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblInvalid.Text = "Error! Contact IT";
                    lblInvalid.Visible = true;
                }
            }
        }
        
        protected void btn_fgPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reset_Password.aspx");
        }
        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            
            if (RadioButtonF.Checked == true)
            {
                connectDevice.connect();
                Credential.Visible = false;
                FingerPrint.Visible = true;
                if (connectDevice.DeviceConnected == 1)
                {
                    foundUid.Visible = false;
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
                FingerPrint.Visible = false;
                Credential.Visible = true;
                if (connectDevice.DeviceConnected == 1)
                {
                    captureThread.Abort();
                    connectDevice.bIsTimeToDie = true;
                    connectDevice.DisconnectDevice();
                }
                
            }
        }

        protected void btnScan_Click(object sender, EventArgs e)
        {
                if (connectDevice.foundUserid == 0)
                {
                    foundUid.Text = "User not Found! Try Again or Try Credentials!";
                    foundUid.Visible = true;
                    connectDevice.foundUserid = 2;
                }
                else if (connectDevice.foundUserid == 1)
                {
                    connectDevice.foundUserid = 2;
                    foundUid.Visible = false;
                    LoginInfo loginInfo = LoginInfoDAO.FingurePrintLogin(connectDevice.userid);
                    if (loginInfo != null)
                    {
                        Session.Add("login", loginInfo);
                        if (connectDevice.DeviceConnected == 1)
                        {
                            captureThread.Abort();
                            connectDevice.bIsTimeToDie = true;
                            connectDevice.DisconnectDevice();
                        }
                        Response.Redirect("~/Home.aspx");
                    }
                }
                else if(connectDevice.foundUserid == 2)
                {
                    foundUid.Text = "Nothing got Scaned! Scan again.";
                    foundUid.Visible = true;
                }
        }
    }
}