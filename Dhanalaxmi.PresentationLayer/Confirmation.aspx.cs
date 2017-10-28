using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL_Layer;

namespace Dhanalaxmi.PresentationLayer
{
    public partial class Confirmation : System.Web.UI.Page
    {
        ConfirmationBLL bllObj = new ConfirmationBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Collections.Specialized.NameValueCollection previousform = Request.Form;
            //lblPONumber1.Text= previousform["txtPONumber"];

            if (!IsPostBack)
            {
                string PONumber = Request.QueryString["PONumber"];
                lblConfirmStatus.Text = "PO Number:=" + PONumber + " Submitted successfully!";
                lblConfirmStatus.ForeColor = System.Drawing.Color.Green;

                lblPONumber1.Text = PONumber;
                DataTable dtProducts = new DataTable();
                dtProducts = bllObj.LoadProductCode(Convert.ToInt32(PONumber));

                ddlProductList.DataSource = dtProducts;

                ddlProductList.DataTextField = "ProductCode";
                ddlProductList.DataValueField = "ProductCode";
                ddlProductList.DataBind();
                ddlProductList.Items.Insert(0, new ListItem("----Product Codes----", "0"));


            }
        }
      

        protected void btnSubmitPO_Click(object sender, EventArgs e)
        {
            Response.Redirect("PurchaseOrder.aspx");
        }

        protected void btnCheckInventory_Click(object sender, EventArgs e)
        {
            Response.Redirect("Inventory.aspx");
        }

        protected void ddlProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PONumber =Convert.ToInt32(lblPONumber1.Text);
            DataTable dtItemdetails = new DataTable();
            dtItemdetails = bllObj.getProductDescription(Convert.ToInt32(ddlProductList.SelectedValue));
            lblDesc.Text = dtItemdetails.Rows[0][0].ToString();
            lblStock.Text = dtItemdetails.Rows[0][1].ToString();
            DataTable dt = new DataTable();
            dt=bllObj.getQty(PONumber, Convert.ToInt32(ddlProductList.SelectedValue));
            lblItemOrdered.Text = dt.Rows[0][1].ToString();

            int unitsInStock = Convert.ToInt16(lblStock.Text);
            int ItemsOrdered = Convert.ToInt16(lblItemOrdered.Text);

           
            if (unitsInStock <= ItemsOrdered)
            {
                btnOrderItems.Visible = true;
            }
        




    }

        protected void btnOrderItems_Click(object sender, EventArgs e)
        {
            Response.Redirect("OrderForm.aspx?PurchaseOrder="+ Convert.ToInt32(lblPONumber1.Text));
        }
    }
}