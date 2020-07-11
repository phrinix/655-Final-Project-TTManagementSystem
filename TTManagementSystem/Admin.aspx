<%@ Page Title="Admin Page" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"  CodeBehind="Admin.aspx.cs" Inherits="TTManagementSystem.Admin" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head" >
    <meta name="viewport" content="width=device-width, initial-scale=1" />
      <link rel="stylesheet" href="Style/bootstrap.min.css" />
    <link href="Style/Admin.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script> 
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    </asp:Content>
<asp:Content runat="server" ID="body" ContentPlaceHolderID="ContentPlaceHolder1" >
    <div class="admin" runat="server">
            <p class="radio">
                <asp:RadioButton ID="rbChangeP" Text="UPDATE Password" Checked="True" GroupName="RadioGroup1" AutoPostBack="true" OnCheckedChanged="rbChangeP_CheckedChanged" runat="server" />
                <asp:RadioButton ID="rbRegisterF" Text="UPDATE Finger Print" GroupName="RadioGroup1" AutoPostBack="true" OnCheckedChanged="rbChangeP_CheckedChanged"  runat="server" />
            </p>
        <asp:Panel ID="PPass" runat="server">
        <div>
            <table class="tblPass">
                <tr>
                    <td>UserName: </td>
                    <td>
                        <asp:TextBox ID="txbUsername" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUname" runat="server" ControlToValidate="txbUsername"
                            ErrorMessage="Username is required." style="color: #FF0000"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>New Password: </td>
                    <td>
                        <asp:TextBox ID="txbPassword" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfVPass" runat="server" ControlToValidate="txbPassword"
                            ErrorMessage="Password is required." style="color: #FF0000"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                         <asp:Button ID="btnUpdate" runat="server" Text="UPDATE" Width="115px" OnClick="btnUpdate_Click" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                         <asp:Label ID="lblInvalid" runat="server" style="color: #FF0000" Text="" Visible="False"></asp:Label>&nbsp;
                    </td>
                </tr>
                </table>
        </div>
            </asp:Panel>
        <asp:Panel ID="PFinger" runat="server" Visible="false">
                <asp:Panel ID="Connected" runat="server" Visible="false">
                    <p>Device Status: <em style="color: green">Connected</em></p>
                    <p>Enter UserName: <asp:TextBox ID="txbUser" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvUser" runat="server" ControlToValidate="txbUser"
                            ErrorMessage="Username is required." style="color: #FF0000"></asp:RequiredFieldValidator>
                    </p>
                    <p style="margin: 20px auto;">Tap your finger 3 Times and press Scan!</p>
                    <asp:Button ID="btnRegister" runat="server" Text="Register" Width="80px" OnClick="btnRegister_Click" />
                    <p>
                    <asp:Label ID="lblResult" runat="server" ForeColor="Red" Text="" Visible="false"></asp:Label>
                        </p>
               </asp:Panel>
                <asp:Panel ID="notConnected" runat="server" Visible="false">
                    <p>Device Status: <em style="color:red">Not Connected</em></p>
                    <p style="margin: 20px auto;">Connect your Device and Try Again!</p>
                </asp:Panel>
        </asp:Panel>
    </div>
</asp:Content>
