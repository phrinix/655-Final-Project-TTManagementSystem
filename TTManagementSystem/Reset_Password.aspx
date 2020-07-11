<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset_Password.aspx.cs" Inherits="TTManagementSystem.Reset_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

.login {
    position:relative;
    margin: 10% auto;
    border: 2px solid green;
    background-color:wheat;
    width:400px;
    height:200px;
}
.tblLogin {
width:300px;
margin: 10% auto;
}

table {
    border-collapse:collapse;
    border-spacing:0;
}

tr, td {
    padding:5px;
}

input, select {
    vertical-align:middle;
}
        .auto-style1 {
            font-size: 100%;
            vertical-align: baseline;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin: 0;
            padding: 0;
            background:;
        }
    </style>
</head>
<body style="height: 561px">
    <form id="form1" runat="server">
        <div class="auto-style1" runat="server" style="outline: 0;">
            <br />
            <br />
            Username:
            <asp:TextBox ID="Reset_txtUsername" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Security Questions:"></asp:Label>
            <br />
            <br />
            1)
            <asp:Label ID="Label2" runat="server" Text="What is your mother's maiden name?"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSecurityAns1" runat="server"></asp:TextBox>
            <br />
            <br />
            2)
            <asp:Label ID="Label3" runat="server" Text="What is your paternal grandmother's name?"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSecurityAns2" runat="server"></asp:TextBox>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="data_check" runat="server" OnClick="data_check_Click" Text="Submit" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="InvalidLB" runat="server" Text="Incorrect Data! Please Try Again!" Visible="False"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;
            <asp:Label ID="userLB" runat="server" Text="Username not found!" Visible="False"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
