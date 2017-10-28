<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderForm.aspx.cs" Inherits="Dhanalaxmi.PresentationLayer.OrderForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
       <fieldset>
        <legend>Order Items</legend>

           <asp:Table ID="tblOrderItem" runat="server">
            <asp:TableRow>
                <asp:TableCell >
                    Supplier:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList ID="ddlSupplierList" OnSelectedIndexChanged="ddlSupplierList_SelectedIndexChanged" runat="server"></asp:DropDownList>
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                      Item:
                </asp:TableCell>

                <asp:TableCell>
                    <asp:DropDownList ID="ddlProdDesc" OnSelectedIndexChanged="ddlProdDesc_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                </asp:TableCell>

            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                      Quantity:
                </asp:TableCell>

                <asp:TableCell>
                    <asp:TextBox ID="txtQty" runat="server" ></asp:TextBox>
                </asp:TableCell>

            </asp:TableRow>
             
         </asp:Table>

           <asp:Button ID="btnOrder" runat="server" Text="Place Order" Visible="true" OnClick="btnOrder_Click"></asp:Button>

       </fieldset>
    </center>
</asp:Content>
