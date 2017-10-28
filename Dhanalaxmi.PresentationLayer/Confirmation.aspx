<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="Dhanalaxmi.PresentationLayer.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <asp:Label ID="lblConfirmStatus" runat="server" Text="Label"></asp:Label><br /><br /><br />
    <asp:Button ID="btnSubmitPO" runat="server" Text="Submit Another PO" OnClick="btnSubmitPO_Click" />
    <asp:Button ID="btnCheckInventory" runat="server" Text="Check Inventory" OnClick="btnCheckInventory_Click" /><br />

    <fieldset>
        <legend>PO ItemDetails</legend>
        <asp:Table ID="tblItemDetails" runat="server">
            <asp:TableRow>
                <asp:TableCell >
                    Purchase Order No:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:Label ID="lblPONumber1" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>

            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                      Product Code:
                </asp:TableCell>

                <asp:TableCell>
                    <asp:DropDownList ID="ddlProductList" OnSelectedIndexChanged="ddlProductList_SelectedIndexChanged" runat="server" AutoPostBack="True"></asp:DropDownList>
                </asp:TableCell>

            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                      Description:
                </asp:TableCell>

                <asp:TableCell>
                    <asp:Label ID="lblDesc" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>

            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                      UnitsInStock:
                </asp:TableCell>

                <asp:TableCell>
                    <asp:Label ID="lblStock" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>

            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell>
                      No Of Items Ordered:
                </asp:TableCell>

                <asp:TableCell>
                    <asp:Label ID="lblItemOrdered" runat="server" Text="Label"></asp:Label>
                </asp:TableCell>

            </asp:TableRow>
        </asp:Table>
        <asp:Button ID="btnOrderItems" runat="server" Text="Order Items" Visible="false" OnClick="btnOrderItems_Click"></asp:Button>
    </fieldset>
    </center>
</asp:Content>
