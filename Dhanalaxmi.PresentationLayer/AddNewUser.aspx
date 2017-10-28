<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="AddNewUser.aspx.cs" Inherits="Dhanalaxmi.PresentationLayer.AddNewUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <center>
    <asp:Table ID="tblNewUser" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <b>LoginID</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLoginID" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtLoginID" ErrorMessage="LoginID is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>New-Password</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtPswd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPswd"  ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>Confirm New-Password</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtreenterPswd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtreenterPswd"  Display="Dynamic" ErrorMessage="Re-entering password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                   <asp:CompareValidator ID="ComaparePswd" runat="server" ForeColor="Red" ErrorMessage="Passwords doesnot match" 
                     ControlToValidate="txtreenterPswd" ControlToCompare="txtPswd" Operator="Equal" Display="Dynamic"
                    ></asp:CompareValidator>
           
            </asp:TableCell>
              

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <b>Select Secret Question</b>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="drpQues" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpQues_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="-1">
                        ---Select your secret question---
                    </asp:ListItem>
                    <asp:ListItem Value="1">
                        Favourite pet
                    </asp:ListItem>
                    <asp:ListItem Value="2">
                        Mother's Maiden Name
                    </asp:ListItem>
                    <asp:ListItem Value="3">
                        First School
                    </asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ErrorMessage="Select Secret Ques" ForeColor="Red" 
                    ControlToValidate="drpQues" InitialValue="-1"></asp:RequiredFieldValidator>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>

            <asp:TableCell>
                <asp:Label ID="lblAns" runat="server" Text="Answer" Visible="false"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtAns" runat="server" Visible="false"></asp:TextBox>
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
            </asp:TableCell>
            

        </asp:TableRow>
     </asp:Table>
        </center>

    
    
</asp:Content>
