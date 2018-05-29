<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="StudentAdd.aspx.cs" Inherits="Admin_StudentDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Congrats You have Added a new Student!!!")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="position:relative; top: -11px; left: -6px; height: 1500px; width: 1368px; background-image: url('../Textures/textureforclient7.JPG');">
        <fieldset style="height: 506px">
            <legend><asp:Label ID="label1" runat="server" Text="Personal Details" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="Maroon"></asp:Label></legend>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label2" runat="server" Text="Name :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" BackColor="#99FFCC" Font-Bold="True" Font-Size="15pt" Height="20px" Width="370px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="Student"></asp:RequiredFieldValidator>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label3" runat="server" Text="Email :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>&nbsp;<asp:TextBox ID="TextBox2" runat="server" BackColor="#99FFCC" Font-Bold="True" Font-Size="15pt" Height="20px" Width="370px"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="Student"></asp:RequiredFieldValidator>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label4" runat="server" Text="Password :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>&nbsp;<asp:TextBox ID="TextBox3" runat="server" BackColor="#99FFCC" Font-Bold="True" Font-Size="15pt" Height="20px" TextMode="Password" Width="370px"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="Student"></asp:RequiredFieldValidator>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label5" runat="server" Text="Address :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server" BackColor="#99FFCC" Font-Bold="True" Font-Size="15pt" Height="108px" TextMode="MultiLine" Width="370px"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="Student"></asp:RequiredFieldValidator>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label6" runat="server" Text="Country :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>&nbsp;<asp:TextBox ID="TextBox5" runat="server" BackColor="#99FFCC" Font-Bold="True" Font-Size="15pt" Height="20px" Width="370px"></asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="Student"></asp:RequiredFieldValidator>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label7" runat="server" Text="CV :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>&nbsp;<asp:FileUpload ID="FileUpload1" runat="server" BackColor="#99FFCC" Height="25px" Width="385px" />
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload1" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="Student"></asp:RequiredFieldValidator>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label8" runat="server" Text="Image :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>&nbsp;<asp:FileUpload ID="FileUpload2" runat="server" BackColor="#99FFCC" Height="26px" Width="385px" />
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload2" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="Student"></asp:RequiredFieldValidator>
        </fieldset>
        <fieldset style="height: 216px">
            <legend><asp:Label ID="label9" runat="server" Text="Official Details" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="Maroon"></asp:Label>&nbsp;</legend>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label10" runat="server" Text="Select Course :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>&nbsp;
            <asp:DropDownList ID="DropDownList1" runat="server" BackColor="#99FFCC" Font-Bold="True" Font-Names="Arial Black" Font-Size="10pt" Height="16pt" Width="281px">
            </asp:DropDownList>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="DropDownList1" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="Student"></asp:RequiredFieldValidator>
            <br />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label11" runat="server" Text="Initial Fees :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>&nbsp;
            <asp:TextBox ID="TextBox6" runat="server" BackColor="#99FFCC" Font-Bold="True" Font-Size="15pt" Height="20px" Width="370px">0</asp:TextBox>
&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBox6" Display="Dynamic" ErrorMessage="Required Field" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" ForeColor="#009900" ValidationGroup="Student"></asp:RequiredFieldValidator>
        </fieldset>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" BackColor="#000099" Font-Bold="True" Font-Names="Franklin Gothic Medium" Font-Size="15pt" ForeColor="Yellow" OnClick="Button1_Click" OnClientClick="Confirm()" Text="Add" ValidationGroup="InsertBatch" Width="150px" Height="43px" />

        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="label12" runat="server" Text="Initial Fees :" Font-Bold="True" Font-Names="Algerian" Font-Size="18pt" Font-Underline="True" ForeColor="#000066"></asp:Label>

    </div>
</asp:Content>

