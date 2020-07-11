<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change_Password.aspx.cs" Inherits="TTManagementSystem.Change_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 476px">
    
        <asp:Label ID="userLB" runat="server" ForeColor="#0033CC"></asp:Label>
        <br />
    
        <br />
        New Password:
        <asp:TextBox ID="txtChangePass" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        Re-enter Password:
        <asp:TextBox ID="txtReenterPass" runat="server" TextMode="Password"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <br />
&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="errorLB" runat="server" ForeColor="Red" style="text-align: left" Text="Password does not match. Please Try again!" Visible="False"></asp:Label>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnChangePass" runat="server" Height="47px" OnClick="btnChangePass_Click" Text="Confirm" Width="113px" />
        <br />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    </div>
    </form>
</body>
</html>
