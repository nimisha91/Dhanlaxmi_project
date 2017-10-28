using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CommonConnection;

namespace DataAccessLayer
{
    public class OrderFormDLL
    {

        DataSet dsDAL = new DataSet();
        Connection conn = new Connection();

        public DataTable getSuppliers()
        {
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlDataAdapter cmd = new SqlDataAdapter("spGetSuppliers", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Fill(dsDAL);
            con.Close();
            return dsDAL.Tables[0];
        }

        public DataTable getProductDesc(int PurchaseOrder)
        {
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlDataAdapter cmd = new SqlDataAdapter("spGetProductDesc", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@PONumber", PurchaseOrder).Direction = ParameterDirection.Input;
            con.Open();
            cmd.Fill(dsDAL);
            con.Close();
            return dsDAL.Tables[0];
        }

    }
}