<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TTManagementSystem.Home" %>



<asp:Content runat="server" ID="head" ContentPlaceHolderID="head" >
      <meta name="viewport" content="width=device-width, initial-scale=1" />
      <link rel="stylesheet" href="Style/bootstrap.min.css" />
      <link rel="stylesheet" href="Style/Home.css" />
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script> 
      <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content runat="server" ID="body" ContentPlaceHolderID="ContentPlaceHolder1" >
    <div class="content" aria-expanded="false">
        <section class ="location">
            <asp:ListBox ID="lbxLocations" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lbxLocations_SelectedIndexChanged"  
                 Height="484px" Width="195px"></asp:ListBox>
        </section> 
        <section class="add">
            <div class="panel-group add" id="accordion1">
            <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a class="collapsed Add" data-toggle="collapse" data-parent="#accordion" href="#collapseAdd" aria-expanded="true" aria-live="off">
                                    <span aria-expanded="false">Add NEW Ticket</span>
                                </a>
                            </h4>
                        </div>
                        <div id="collapseAdd" class="panel-collapse collapse" aria-expanded="true" style="height: 0px;">
                            <div class="panel-body BodyAdd">
                                
                                <p id="lblRoom">Room:</p>
                                <span>
                                    <asp:DropDownList ID="ddlRoom" cssclass="ddlRoom" runat="server" AppendDataBoundItems="True" AutoPostBack="False" TabIndex="4">
                                            <asp:ListItem Value="0">(Choose)</asp:ListItem>                                       
                                    </asp:DropDownList>
                                </span>
                                <p id="lblSeverity">Severity:</p>
                                <span >
                                    <asp:DropDownList ID="ddlSeverity" CssClass="ddlSeverity" runat="server" AppendDataBoundItems="True" AutoPostBack="False">
                                        <asp:ListItem Value="0">(Choose)</asp:ListItem>
                                        <asp:ListItem Value="1">Low</asp:ListItem>
                                        <asp:ListItem value="2">Medium</asp:ListItem>
                                        <asp:ListItem value="3">High</asp:ListItem>
                                    </asp:DropDownList> </span>
                                <p class="subject">Subject:</p>
                                <span> <asp:TextBox ID="txbSubject" CssClass="txbsubject" TextMode="SingleLine" runat="server" MaxLength="100"></asp:TextBox></span>
                                <p class="description">Description:</p>
                                <span> <asp:TextBox ID="txbDescription" CssClass="txbdescription" TextMode="MultiLine" runat="server"></asp:TextBox></span>
                                <span class ="btnadd"><asp:Button ID="btnAdd" runat="server" Width="100px" Height="30px" Text="ADD" OnClick="btnAdd_OnClientClick" /></span>
                            </div>
                        </div>
                    </div>
                </div>
        </section> 
        <section class ="comment">
            
                <div class="panel-group" id="accordion">
                    
                    <asp:Label ID="lblNoRoomSelected" class="lblNoRoomSelected" runat="server" Text="Please Select room to see tickets" ></asp:Label>
                 <asp:Repeater ID="ticketRepeat" runat="server" OnItemDataBound="ticketRepeat_ItemDataBound" OnItemCommand="ticketRepeat_ItemCommand">
                  <ItemTemplate>
                    <div class="panel panel-default">
                        <div class="panel-heading <%#Eval("Status") %>">
                            <h4 class="panel-title">
                                <a class="collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapse<%# Container.ItemIndex%>" aria-expanded="false">
                                    
                                    <span class ="TicketTitle1">Ticket: <asp:Label ID="Label1" runat="server" Text='<%#Eval("Number") %>'></asp:Label></span>
                                    <span class ="TicketTitle1">Subject: <asp:Label ID="Label8" runat="server" Text='<%#Eval("Subject") %>'></asp:Label></span>
                                    <span class ="TicketTitle2">Status:<asp:Label ID="Label3" runat="server" Text='<%#Eval("Status") %>'></asp:Label></span>
                                    <span class ="TicketTitle2">Severty:<asp:Label ID="Label4" runat="server" Text='<%#Eval("Severty") %>'></asp:Label></span>
                                </a>
                            </h4>
                        </div>
                        <div id="collapse<%# Container.ItemIndex%>" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                            <div class="panel-body">
                                <asp:HiddenField ID="hfTicket" runat="server" Value='<%#Eval("Number") %>' />
                                <asp:Repeater ID="commentRepeater" runat="server">
                                    <ItemTemplate>
                                        <span class ="descriptionTitle"> <asp:Label ID="Label5" runat="server" Text='<%#Eval("uname") %>'></asp:Label> </span>
                                        <span class ="descriptionTitle"> <asp:Label ID="Label6" runat="server" Text='<%#Eval("time_stamp") %>'></asp:Label> </span>
                                        <span><br /><br /></span>
                                        <span class ="description"> <asp:Label ID="Label7" runat="server" Text='<%#Eval("description") %>'></asp:Label><hr /> </span>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <span> Status: <asp:DropDownList ID="ddlStatus" runat="server">
                                            <asp:ListItem Value="INPROGRESS">INPROGRESS</asp:ListItem>
                                            <asp:ListItem Value="ESCALATE">ESCALATE</asp:ListItem>
                                            <asp:ListItem Value="CLOSED">CLOSED</asp:ListItem>
                                            <asp:ListItem Value="OPEN">OPEN</asp:ListItem>
                                                       </asp:DropDownList></span>
                                
                                        <span> <asp:TextBox ID="txtUpdate" CssClass="txbdescription" TextMode="MultiLine" runat="server"></asp:TextBox></span>
                                        <span class =""><asp:Button ID="btnUpdate" runat="server" Width="100px" Height="30px" Text="UPDATE" UseSubmitBehavior="false" CommandName="btnClick"  /></span>
                            </div>
                        </div>
                    </div>
                  </ItemTemplate>
                 </asp:Repeater>

                </div> 
            </section>
    </div> 
</asp:Content>