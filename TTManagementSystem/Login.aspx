<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TTManagementSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Style/LoginStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login" runat="server">
            <h1 class="HeadLogin">Login</h1>
            <p class="radio">
                <asp:RadioButton ID="RadioButtonC" Text="Use Credentials" Checked="True" GroupName="RadioGroup1" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged" runat="server" />
                <asp:RadioButton ID="RadioButtonF" Text="Use Finger Print" GroupName="RadioGroup1" AutoPostBack="true" OnCheckedChanged="RadioButton_CheckedChanged"  runat="server" />
            </p>
            <asp:Panel ID="Credential" runat="server" >
            <table class="tblLogin">
                <tr>
                    <td>
                        <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label> </td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername" 
                            ErrorMessage="Username is required." style="color: #FF0000"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox> 
                     <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" 
                            ErrorMessage="Password is required." style="color: #FF0000"></asp:RequiredFieldValidator>
                     </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                         <asp:Button ID="btnLogin" runat="server" Text="Login" Width="115px" Onclick="btnLogin_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                         <asp:Label ID="lblInvalid" runat="server" style="color: #FF0000" Text="" Visible="False"></asp:Label>&nbsp;
                    </td>
                </tr>
            </table>
                <asp:LinkButton ID="btn_fgPassword" runat="server" OnClick="btn_fgPassword_Click">Forgot Password?</asp:LinkButton>
                </asp:Panel>
            <asp:Panel ID="FingerPrint" runat="server" Visible="false">
                <asp:Panel ID="Connected" runat="server" Visible="false">
                    <p>Device Status: <em style="color: green">Connected</em></p>
                    <p style="margin: 20px auto;">Tap your finger and press Scan!</p>
                    <asp:Button ID="btnScan" runat="server" Text="Scan" Width="80px" OnClick="btnScan_Click" />
                    <p>
                    <asp:Label ID="foundUid" runat="server" ForeColor="Red" Text="" Visible="false"></asp:Label>
                        </p>
               </asp:Panel>
                <asp:Panel ID="notConnected" runat="server" Visible="false">
                    <p>Device Status: <em style="color:red">Not Connected</em></p>
                    <p style="margin: 20px auto;">Connect your Device and Try Again!</p>
                </asp:Panel>
                
            </asp:Panel>
        </div>
    </form>
</body>
</html>
