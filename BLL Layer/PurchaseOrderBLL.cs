using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccessLayer;

namespace BLL_Layer
{
    public class PurchaseOrderBLL
    {
        
        PurchaseOrderDAL poObjDAL = new PurchaseOrderDAL();
        DataSet dsBLL = new DataSet();
        DataTable dtBLL = new DataTable();

        public DataTable getClients()
        {
            
            dtBLL = poObjDAL.getClients();
            return dtBLL;
        }

        public DataTable getClientDetails(int ClientID)
        {
            dtBLL = poObjDAL.getClientDetails(ClientID);
            return dtBLL;
        }

        public DataTable getAllItems()
        {
            dtBLL = poObjDAL.getAllItems();
            return dtBLL;
        }

        public DataTable getItemDetails(int ProductCode)
        {
            dtBLL = poObjDAL.getItemDetails(ProductCode);
            return dtBLL;
        }

        public int InsertPurchaseOrder(int PONumber, DateTime PODate, DateTime DispatchDate, int clientID)
        {
            int OrderID = poObjDAL.InsertPurchaseOrder(PONumber, PODate, DispatchDate, clientID);
            return OrderID;
        }

        public int InsertPurchaseOrderItemDetails(int OrderID, int ProductCode, int Qty, int Amount)
        {
            int Rowsinserted = poObjDAL.InsertPurchaseOrderItemDetails(OrderID, ProductCode, Qty, Amount);
            return Rowsinserted;
        }

    }
}