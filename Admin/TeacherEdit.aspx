<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="TeacherEdit.aspx.cs" Inherits="Admin_TeacherEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="position:relative; top: -11px; left: -6px; height: 1500px; width: 1368px; background-image: url('../Textures/textureforclient7.JPG');">
        <script type = "text/javascript">
            function Confirm() {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("Congrats You have Updated Teacher Details!!!")) {
                    confirm_value.value = "Yes";
                } else {
                    confirm_value.value = "No";
                }
                document.forms[0].appendChild(confirm_value);
            }
    </script>
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="25pt" Font-Underline="True" ForeColor="#820000" Text="Name :"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Names="Algerian" Font-Size="15pt" ForeColor="#FF3300" Width="469px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="InsertTeacher"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="25pt" Font-Underline="True" ForeColor="#820000" Text="Age :"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Names="Algerian" Font-Size="15pt" ForeColor="#FF3300" Width="469px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="InsertTeacher"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="25pt" Font-Underline="True" ForeColor="#820000" Text="Sex :"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton1" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="20pt" ForeColor="#CC0000" GroupName="Sex" Text="Male" />
&nbsp;&nbsp;
        <asp:RadioButton ID="RadioButton2" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="20pt" ForeColor="#CC0000" GroupName="Sex" Text="Female" />
&nbsp;&nbsp;
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="25pt" Font-Underline="True" ForeColor="#820000" Text="Address :"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" BackColor="#CCFFCC" Font-Bold="True" Font-Names="Algerian" Font-Size="15pt" ForeColor="#FF3300" Width="469px" Height="120px" TextMode="MultiLine"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="InsertTeacher"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="25pt" Font-Underline="True" ForeColor="#820000" Text="Qualification :"></asp:Label>
&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#CCFFFF" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Height="35px" Width="387px">
            <asp:ListItem>Graduate</asp:ListItem>
            <asp:ListItem>PostGraduate</asp:ListItem>
            <asp:ListItem>BTech</asp:ListItem>
            <asp:ListItem>BSc</asp:ListItem>
            <asp:ListItem>BA</asp:ListItem>
            <asp:ListItem>MTech</asp:ListItem>
            <asp:ListItem>MSc</asp:ListItem>
            <asp:ListItem>MA</asp:ListItem>
            <asp:ListItem>Phd</asp:ListItem>
            <asp:ListItem>HS</asp:ListItem>
        </asp:DropDownList>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="InsertTeacher"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Algerian" Font-Size="25pt" Font-Underline="True" ForeColor="#820000" Text="Cv Upload :"></asp:Label>
&nbsp;
        <asp:FileUpload ID="FileUpload1" runat="server" BackColor="#99FFCC" Font-Bold="True" Font-Size="15pt" Width="462px" />
&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="InsertTeacher"></asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" BackColor="#000099" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="20pt" ForeColor="Yellow" OnClick="Button1_Click" OnClientClick="Confirm()" Text="Update" ValidationGroup="InsertTeacher" />

    </div>
</asp:Content>

