using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccessLayer;

namespace BLL_Layer
{

    public class OrderFormBLL
    {

        OrderFormDLL ObjDAL = new OrderFormDLL();
        DataSet dsBLL = new DataSet();
        DataTable dtBLL = new DataTable();

        public DataTable getSuppliers()
        {
            dtBLL = ObjDAL.getSuppliers();
            return dtBLL;
        }

        public DataTable getProductDesc(int PurchaseOrder)
        {
            dtBLL = ObjDAL.getProductDesc(PurchaseOrder);
            return dtBLL;
        }


    }
}