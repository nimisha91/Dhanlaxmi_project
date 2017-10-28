<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="Dhanalaxmi.PresentationLayer.PurchaseOrder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

    <script type="text/javascript">
        function Calculate(row) {
            var rowData = row.parentNode.parentNode;
            var rowIndex = rowData.rowIndex;
            var ri = parseInt(rowIndex);
            var grid = document.getElementById("<%=gvItemDetails.ClientID%>");
            var unit1 = grid.rows[ri].cells[2].children[0];
            var unitrate = unit1.value;
            var qty = grid.rows[ri].cells[3].children[0];
            var quantity = qty.value;

            var amount = unitrate * quantity;
            grid.rows[ri].cells[4].children[0].innerText = amount;
            
        }

        //function ValidateChkItems() {
        //    var chk = document.getElementById("chkItems");
        //    if (!chk.checked) {
        //        alert("Select atlest one Item.");
        //    }
        //}
    </script>

    <div style="font-family:Arial">
        <asp:Table runat="server" Height="399px" Width="731px">
            <asp:TableRow>
                <asp:TableCell>
                    <fieldset style="width: 280px; height:300px" >
            <legend >Client Details</legend>
            Client :&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="drpClients" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpClients_SelectedIndexChanged"></asp:DropDownList>
            <br />
            <br />
            Phone  :&nbsp;&nbsp;
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqValidatorPhone" runat="server" ValidationGroup="Group1"
                ErrorMessage="This field is Mandotory" ControlToValidate="txtPhone"  Display="Dynamic"
                 ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexpPhone" runat="server"  ValidationGroup="Group1"
                ErrorMessage="Phone Number must be of 10 digits" ControlToValidate="txtPhone" Display="Dynamic" ForeColor="Red"
                ValidationExpression="[0-9]{10}" ></asp:RegularExpressionValidator>
            <br />
            <br />
            E-Mail :&nbsp;&nbsp;
            <asp:TextBox ID="txtEmail"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="ReqValidatorEmail" runat="server" 
                ErrorMessage="This field is Mandotory" ControlToValidate="txtEmail" Display="Dynamic" 
                ValidationGroup="Group1" ForeColor ="Red" ></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexpEmail" runat="server"  ValidationGroup="Group1"
                ErrorMessage="Not A Valid EmailID" ControlToValidate="txtEmail" Display="Dynamic" ForeColor="Red"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ></asp:RegularExpressionValidator>
            
            
            <br />
            <br />
            Address :&nbsp;
            <asp:TextBox  ID="taAddress" TextMode="MultiLine"  runat="server"></asp:TextBox>
                        <br />
             Excise Reg. No :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtExciseNo" runat="server"></asp:TextBox>
                        <br />
             TIN NO :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTin_No" runat="server"></asp:TextBox>
                        <br />
                    CST NO :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCst_no" runat="server"></asp:TextBox>
                        <br />
                    PAN NO :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPan_no" runat="server"></asp:TextBox>


        </fieldset>
                </asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell></asp:TableCell>
                <asp:TableCell></asp:TableCell>
                
               
                <asp:TableCell>
                    <fieldset style="width:100%; height:500px" >
            <legend>Select Items</legend>
            
            <asp:CheckBoxList ID="chkItems" runat="server" RepeatLayout="Table" Visible="true" ></asp:CheckBoxList>
            
            <asp:Button ID="btnItems" runat="server" Text="Add Details" OnClick="btnItems_Click" />
            <asp:GridView ID ="gvItemDetails"  runat="server" Visible="true" AutoGenerateColumns="false" >
                <Columns>
         <%--   <asp:BoundField DataField="ProductCode" HeaderText="Product Code" ApplyFormatInEditMode="true">
            </asp:BoundField>--%>
            <asp:TemplateField HeaderText="ProductCode">
                <ItemTemplate>
                    <asp:Label ID="lblcode" runat="server" Text='<%# Bind("ProductCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Desc">
                <ItemTemplate>
                    <asp:Label ID="lblDesc" runat="server" Text='<%# Bind("ProductDesc") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Rate">
                <ItemTemplate>
                    <%--<input id="txtUnitRate" type="text" value='<%# Bind("UnitsRate") %>' runat="server" />--%>
                    <asp:TextBox ID="txtUnitRate" runat="server" Text='<%# Bind("UnitsRate") %>' ReadOnly="true"  ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <%--<input id="txtQuantity" type="text" value='<%# Bind("Quantity") %>' onkeyup="multiply();" runat="server" />--%>
                    <asp:TextBox ID="txtQuantity"  Text='<%# Bind("Quantity") %>' runat="server" onblur="Calculate(this)" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Amount">
                <ItemTemplate>
                    <asp:Label ID="lblAmount" runat="server" Text='<%# Bind("Amount") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
            </asp:GridView>
        </fieldset>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow></asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <fieldset style="width: 335px; height:150px">
            <legend>Order Details</legend>
            <br />
            PO Number&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPOnumber" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="reqPOnumber" ControlToValidate="txtPOnumber"  ValidationGroup="Group1"
                runat="server" Display="Dynamic" ErrorMessage="PO Number is mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            PO Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtPODate" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="POCalender" runat="server" PopupButtonID="txtPODate"
                TargetControlID="txtPODate" Format ="dd-MM-yyyy" Enabled="True">
            </asp:CalendarExtender>
            <asp:RequiredFieldValidator ID="reqPODate" ControlToValidate="txtPODate"  ValidationGroup="Group1"
                runat="server" Display="Dynamic" ErrorMessage="PO Date is mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
            Dispatch Date :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDispatchDate" runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="PODispatchDate" runat="server" PopupButtonID="txtDispatchDate"
                TargetControlID="txtDispatchDate" Format ="dd-MM-yyyy" Enabled="True">
            </asp:CalendarExtender>
            <asp:RequiredFieldValidator ID="reqDispatchDate" ControlToValidate="txtDispatchDate"  ValidationGroup="Group1"
                runat="server" Display="Dynamic" ErrorMessage="PO Dispatch Date is mandatory" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </fieldset>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>

    <div>
        
        <asp:Button ID="btnSubmit" Text="Save" runat="server" ValidationGroup="Group1" OnClick="btnSubmit_Click" />
        <br />
    </div>


</asp:Content>
