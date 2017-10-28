using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using BLL_Layer;
using System.Globalization;

namespace Dhanalaxmi.PresentationLayer
{
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        PurchaseOrderBLL poObjBLL = new PurchaseOrderBLL();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                dt=poObjBLL.getClients();
                
                drpClients.DataSource = dt;
                drpClients.DataTextField = "ClientName";
                drpClients.DataValueField = "ClientID";
                drpClients.DataBind();
                drpClients.Items.Insert(0, new ListItem("----Select CLient----", "0"));

                dt.Clear();
                dt = poObjBLL.getAllItems();
                foreach(DataRow dr in dt.Rows)
                {
                    ListItem list = new ListItem  (dr["ProductDesc"].ToString());
                    chkItems.Items.Add(list);
                }
                chkItems.DataSource = dt;
                chkItems.DataTextField = "ProductDesc";
                chkItems.DataValueField = "ProductCode";
                chkItems.DataBind();





            }

        }

        protected void drpClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ClientID = Convert.ToInt16(drpClients.SelectedValue.ToString());
            dt=poObjBLL.getClientDetails(ClientID);
            txtPhone.Text = dt.Rows[0][2].ToString();
            txtEmail.Text = dt.Rows[0][3].ToString();
            taAddress.Text = dt.Rows[0][4].ToString();
        }

        protected void btnItems_Click(object sender, EventArgs e)
        {
            DataTable dtMain = new DataTable();
            DataSet dssub = new DataSet();
            int rowCount = gvItemDetails.Rows.Count;
            if(rowCount>0)
            {
                
                

                foreach (GridViewRow row in gvItemDetails.Rows)
                {
                    

                    DataColumn[] col = {new DataColumn("ProductCode"),
                                     new DataColumn("ProductDesc"),
                                     new DataColumn("UnitsRate"),
                                     new DataColumn("Quantity"),
                                     new DataColumn("Amount")};

                    if (dtMain.Columns.Count == 0)
                    {
                        dtMain.Columns.AddRange(col);
                    }
                    //DataTable dtsub = new DataTable();
                    DataRow dr = dtMain.NewRow();


                    Label lbcode = (Label)row.FindControl("lblcode");
                    Label lbDesc = (Label)row.FindControl("lblDesc");
                    TextBox tbunits = (TextBox)row.FindControl("txtUnitRate");
                    TextBox tbQty = (TextBox)row.FindControl("txtQuantity");
                    Label lbamt = (Label)row.FindControl("lblAmount");
                    int units = Convert.ToInt16(tbunits.Text.ToString());
                    int qty = Convert.ToInt16(tbQty.Text.ToString());
                    int amt = units * qty;
                    lbamt.Text = amt.ToString();
                    dr[0] = lbcode.Text;
                    dr[1] = lbDesc.Text;
                    dr[2] = tbunits.Text;
                    dr[3] = tbQty.Text;
                    dr[4] = lbamt.Text;

                    dtMain.Rows.Add(dr);
                   // dssub.Tables.Add(dtMain);
                    //dtMain.Clear();
                }
                dssub.Tables.Add(dtMain);

                if (ViewState["dsMain"]==null)
                    {
                        ViewState["dsMain"] = dssub;
                    }
                    else if(ViewState["dsMain"]!=null)
                    {
                        //DataSet dstemp = (DataSet)ViewState["dsMain"];
                        
                        
                        //int length1 = dstemp.Tables[0].Rows.Count;
                        //int j = 0;
                        //while(j<length1)
                        //{
                        //    DataRow dr1 = dtMain.NewRow();
                        //    dr1[0] = dstemp.Tables[0].Rows[j][0].ToString();
                        //    dr1[1] = dstemp.Tables[0].Rows[j][1].ToString();
                        //    dr1[2] = dstemp.Tables[0].Rows[j][2].ToString();
                        //    dr1[3] = dstemp.Tables[0].Rows[j][3].ToString();
                        //    dr1[4] = dstemp.Tables[0].Rows[j][4].ToString();

                        //    dtMain.Rows.Add(dr1);
                        //    j = j + 1;
                        //}
                        //dssub.Tables.Clear();
                        //dssub.Tables.Add(dtMain);
                        ViewState["dsMain"] = dssub;

                    }
                
                DataSet dsfinal = (DataSet)ViewState["dsMain"];
                //ds.Tables.Add(dt);
                ViewState["dsItemDetailsMain"] = dsfinal;
            }

            DataTable dtItemDetails = new DataTable();
            DataSet dsItemDetails = new DataSet();

            DataColumn[] columns = {new DataColumn("ProductCode"),
                                     new DataColumn("ProductDesc"),
                                     new DataColumn("UnitsRate"),
                                     new DataColumn("Quantity"),
                                     new DataColumn("Amount")};

            if (dtItemDetails.Columns.Count == 0)
            {
                dtItemDetails.Columns.AddRange(columns);
            }

            for (int i = 0; i < chkItems.Items.Count; i++)
            {
                if (chkItems.Items[i].Selected)
                {
                    DataTable dtTemp = new DataTable();
                    dtTemp = poObjBLL.getItemDetails(Convert.ToInt32(chkItems.Items[i].Value));
                    DataRow dr1 = dtItemDetails.NewRow();
                    dr1[0] = dtTemp.Rows[0][0].ToString();
                    dr1[1] = dtTemp.Rows[0][1].ToString();
                    dr1[2] = dtTemp.Rows[0][2].ToString();
                    dr1[3] = "";
                    dr1[4] = "";

                    dtTemp.Clear();

                    dtItemDetails.Rows.Add(dr1);
                }
            }

            if (ViewState["dsItemDetailsMain"] == null)
            {
                ViewState["dtItemDetails"] = dtItemDetails;
                dsItemDetails.Tables.Add(dtItemDetails);
                gvItemDetails.DataSource = dsItemDetails;
                gvItemDetails.DataBind();
                ViewState["dsItemDetailsMain"] = dsItemDetails;
                ViewState["dsItemDetails"] = dsItemDetails;
                chkItems.ClearSelection();

            }

            else if (ViewState["dsItemDetailsMain"] != null)
            {
                DataSet dsViewState = (DataSet)ViewState["dsItemDetailsMain"];

                int length = dsViewState.Tables[0].Rows.Count;
                int k = 0;

                while (k < length)
                {
                    DataRow dr1 = dtItemDetails.NewRow();
                    dr1[0] = dsViewState.Tables[0].Rows[k][0].ToString();
                    dr1[1] = dsViewState.Tables[0].Rows[k][1].ToString();
                    dr1[2] = dsViewState.Tables[0].Rows[k][2].ToString();
                    dr1[3] = dsViewState.Tables[0].Rows[k][3].ToString();
                    dr1[4] = dsViewState.Tables[0].Rows[k][4].ToString();

                    dtItemDetails.Rows.Add(dr1);
                    k = k + 1;

                }

                ViewState["dtItemDetails"] = dtItemDetails;
                dsItemDetails.Tables.Add(dtItemDetails);
                gvItemDetails.DataSource = dsItemDetails;
                gvItemDetails.DataBind();
                //ViewState["gridview"] = gvItemDetails;
                ViewState["dsItemDetailsMain"] = dsItemDetails;
                ViewState["dsItemDetails"] = dsItemDetails;
                chkItems.ClearSelection();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            // Client Details
            int clientID = Convert.ToInt16(drpClients.SelectedValue.ToString());
            long Phone = Convert.ToInt64(txtPhone.Text);
            string Email = txtEmail.Text;
            string Address = taAddress.Text;
            string ExciseNo = txtExciseNo.Text;
            string Tin = txtTin_No.Text;
            string CST = txtCst_no.Text;
            string PanNo = txtPan_no.Text;


            //PO Details
            int POnumber = Convert.ToInt32(txtPOnumber.Text);

            System.Globalization.CultureInfo culture =
              new System.Globalization.CultureInfo("es-ES");

            DateTime PODate =Convert.ToDateTime(txtPODate.Text, culture);
            DateTime DispatchDate =Convert.ToDateTime(txtDispatchDate.Text, culture);

             int OrderID=poObjBLL.InsertPurchaseOrder(POnumber, PODate, DispatchDate,clientID);

            //Item Details
            int i = 0;
            int rowsinserted=0;



            foreach (GridViewRow row in gvItemDetails.Rows)
            {
                    int ProductCode = Convert.ToInt32(((Label)row.Cells[i].FindControl("lblcode")).Text);
                    string description = ((Label)row.Cells[i].FindControl("lblDesc")).Text;
                    int unitRate = Convert.ToInt16(((TextBox)row.Cells[i].FindControl("txtUnitRate")).Text);
                    int Qty = Convert.ToInt16(((TextBox)row.Cells[i].FindControl("txtQuantity")).Text);
                    int Amount = unitRate * Qty;

                    rowsinserted=poObjBLL.InsertPurchaseOrderItemDetails(OrderID, ProductCode,Qty,Amount);
                    i++;
            }

            if (rowsinserted>0)
            {
                //Server.Execute("Confirmation.aspx");
                Response.Redirect("Confirmation.aspx?PONumber=" + POnumber);
            }


            


        }
    }
}