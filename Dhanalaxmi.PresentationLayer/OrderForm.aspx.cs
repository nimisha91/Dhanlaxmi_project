using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_Layer;
using System.Data;

namespace Dhanalaxmi.PresentationLayer
{
    public partial class OrderForm : System.Web.UI.Page
    {
        OrderFormBLL objBLL = new OrderFormBLL();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            

            if (!IsPostBack)
            {

                dt = objBLL.getSuppliers();

                ddlSupplierList.DataSource = dt;
                ddlSupplierList.DataTextField = "SupplierName";
                ddlSupplierList.DataValueField = "SupplierID";
                ddlSupplierList.DataBind();
                ddlSupplierList.Items.Insert(0, new ListItem("----Select Supplier----", "0"));

                dt.Clear();

                int PurchaseOrder = Convert.ToInt32(Request.QueryString["PurchaseOrder"]);

                dt = objBLL.getProductDesc(PurchaseOrder);

                ddlProdDesc.DataSource = dt;
                ddlProdDesc.DataTextField = "ProductDesc";
                ddlProdDesc.DataValueField = "ProductCode";
                ddlProdDesc.DataBind();
                ddlProdDesc.Items.Insert(0, new ListItem("----Select Product----", "0"));


            }
        }


        protected void btnOrder_Click(object sender, EventArgs e)
        {

        }

        protected void ddlSupplierList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlProdDesc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}