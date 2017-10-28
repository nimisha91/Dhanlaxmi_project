using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;
using System.Data;

namespace BLL_Layer
{
    public class ConfirmationBLL
    {
        ConfirmationDAL dalObj = new ConfirmationDAL();

        public DataTable LoadProductCode(int PurchaseOder)
        {
            DataTable dt=dalObj.LoadProductCode(PurchaseOder);
            return dt;
        }

        public DataTable getProductDescription(int ProductCode)
        {
            DataTable dt = new DataTable();
            dt = dalObj.getProductDescription(ProductCode);
            return dt;
        }

        public DataTable getQty(int PONumber,int ProductCode)
        {
            DataTable dt = new DataTable();
            dt = dalObj.getQty(PONumber, ProductCode);
            return dt;
        }
    }
}