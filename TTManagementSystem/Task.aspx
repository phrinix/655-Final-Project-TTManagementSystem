<%@ Page Title="Task" Language="C#" AutoEventWireup="true" CodeBehind="Task.aspx.cs" MasterPageFile="~/Site.Master" Inherits="TTManagementSystem.Task" %>

<asp:Content runat="server" ID="head" ContentPlaceHolderID="head" >
    <meta name="viewport" content="width=device-width, initial-scale=1" />
      <link rel="stylesheet" href="Style/bootstrap.min.css" />
    <link href="Style/Task.css" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script> 
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    </asp:Content>
<asp:Content runat="server" ID="body" ContentPlaceHolderID="ContentPlaceHolder1" >
    <div class="content" aria-expanded="false">
        <section class="assign">
            <div class="panel-group assign" id="accordion1">
            <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="collapsed Assign" data-toggle="collapse" data-parent="#accordion" href="#collapseAdd" aria-expanded="true" aria-live="off">
                                    <span aria-expanded="false">Assign New Task</span>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseAdd" class="panel-collapse collapse" aria-expanded="true" style="height: 0px;">
                            <div class="panel-body BodyAdd">
                                
                                <p id="lblRoom">Assign To: </p>
                                <span>
                                    <asp:DropDownList ID="ddlAssignTo" cssclass="ddlAssignTo" runat="server" AppendDataBoundItems="True" AutoPostBack="False" TabIndex="4">
                                    </asp:DropDownList>
                                </span>
                                <p class="description">Description:</p>
                                <span> <asp:TextBox ID="txbDescription" CssClass="txbdescription" TextMode="MultiLine" runat="server"></asp:TextBox>
                                </span>
                                <span class ="btnAssign"><asp:Button ID="btnAssign" runat="server" Width="100px" Height="30px" Text="ASSIGN" OnClick="btnAssign_Click"/></span>
                            </div>
                        </div>
                    </div>
                </div>
        </section> 
    <section class ="Task">
                <div class="panel-group" id="accordion">
                    <asp:Label ID="lblNoTask" class="lblNoTask" runat="server" Text="" ></asp:Label>
                    <asp:Repeater ID="TaskRepeater" runat="server" OnItemCommand="TaskRepeat_ItemCommand">
                  <ItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading <%#Eval("Status") %>">
                            <h4 class="panel-title">
                                <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse<%# Container.ItemIndex%>" aria-expanded="false">
                                    <span class ="Task1">Time: <asp:Label ID="Label1" runat="server" Text='<%#Eval("Time") %>'></asp:Label></span>
                                    <span class ="Task1">Status: <asp:Label ID="Label2" runat="server" Text='<%#Eval("Status") %>'></asp:Label></span>
                                    <span class ="Task2">Assigned By: <asp:Label ID="Label3" runat="server" Text='<%#Eval("AssignBy") %>'></asp:Label></span>
                                    <span class ="Task2">Assigned To: <asp:Label ID="Label4" runat="server" Text='<%#Eval("AssignTo") %>'></asp:Label></span>
                                </a>
                            </h4>
                        </div>
                        <div id="collapse<%# Container.ItemIndex%>" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                            <div class="panel-body">
                                <asp:HiddenField ID="hfTask" runat="server" Value='<%#Eval("taskID") %>' />
                                <span class ="description"> <asp:Label ID="Label7" runat="server" Text='<%#Eval("Description") %>'></asp:Label><hr /> </span>

                                <span> Status: <asp:DropDownList ID="ddlStatus" runat="server">
                                            <asp:ListItem Value="INPROGRESS">INPROGRESS</asp:ListItem>
                                            <asp:ListItem Value="CLOSED">CLOSED</asp:ListItem>
                                            <asp:ListItem Value="OPEN">OPEN</asp:ListItem>
                                                       </asp:DropDownList></span>
                                        <span class ="">
                         <asp:Button ID="btnUpd" runat="server" Width="100px" Height="30px" Text="UPDATE" UseSubmitBehavior="false" CommandName="btnClick"/></span>
                            </div>
                        </div>
                    </div>
                  </ItemTemplate>
                 </asp:Repeater>
              </div> 
        </section>
        </div>
</asp:Content>