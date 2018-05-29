<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="BatchViewDetails.aspx.cs" Inherits="Admin_BatchViewDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="position:relative; top: -11px; left: -6px; height: 1500px; width: 1368px; background-image: url('../Textures/textureforclient7.JPG');">
        <asp:ScriptManager ID="script1" runat="server"></asp:ScriptManager>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="25pt" Font-Underline="True" ForeColor="#820000" Text="Batch ID :"></asp:Label>
&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="25pt" Font-Underline="True" ForeColor="#820000" Text="Batch ID :"></asp:Label>
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="stud_code" BackColor="#FFFDB0" CellPadding="15" CellSpacing="2" Font-Bold="True" Font-Names="Bernard MT Condensed" Font-Size="20pt" ForeColor="#009933" Width="1366px" AllowPaging="True" OnPageIndexChanging="Course_PageIndexChanging" onrowediting="GridView1_RowEditing" onrowdeleting="GridView1_RowDeleting" onrowcancelingedit="GridView1_RowCancelingEdit" onrowupdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="stud_code" HeaderText="Student Id" SortExpression="stud_code" Visible="false" />
                <asp:TemplateField HeaderText="Student ID">
                    <ItemTemplate>
                        <asp:Label ID="pname1" runat="server" Text='<%# Bind("stud_code") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="pname2" runat="server" Text='<%# Bind("stud_name") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Attended">
                    <ItemTemplate>
                        <asp:Label ID="pname3" runat="server" Text='<%# Bind("stud_lastatt") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textbox1" runat="server" Text='<%# Bind("stud_lastatt") %>' ></asp:TextBox>
                        <asp:CalendarExtender ID="cd1" runat="server" TargetControlID="textbox1" Format="dd/MM/yyyy" Enabled="true"></asp:CalendarExtender>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total Days Present">
                    <ItemTemplate>
                        <asp:Label ID="pname4" runat="server" Text='<%# Bind("stud_attcount") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="textbox2" runat="server" Text='<%# Bind("stud_attcount") %>' ></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                      <asp:CommandField ShowEditButton="true" ItemStyle-ForeColor="#000099"/>
                <asp:CommandField ShowDeleteButton="true" ItemStyle-ForeColor="#000099" />
            </Columns>
            <HeaderStyle BackColor="#FFFF99" BorderStyle="None" Font-Bold="True" Font-Names="Algerian" Font-Size="20pt" Font-Underline="True" ForeColor="#0066FF" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
        </asp:GridView>
    </div>
</asp:Content>

