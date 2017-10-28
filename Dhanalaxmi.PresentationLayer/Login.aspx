<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dhanalaxmi.PresentationLayer.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center><div>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
&nbsp;:&nbsp;&nbsp;
        <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="Username Is Mandatory" ForeColor="Red" ControlToValidate="txtUser" ValidationGroup="Login"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Password" ></asp:Label>
&nbsp;:&nbsp;
        <asp:TextBox ID="txtPswd" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="Pswd is mandatory" ForeColor="Red" ControlToValidate="txtPswd" ValidationGroup="Login"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" ValidationGroup="Login" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnnewUser" runat="server" OnClick="btnnewUser_Click" Text="Add New User" />
    </div>
    </center>
        
        
</asp:Content>
