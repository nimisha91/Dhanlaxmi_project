using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using CommonConnection;

namespace DataAccessLayer
{
    public class ConfirmationDAL
    {
        Connection conn = new Connection();
        

        public DataTable LoadProductCode(int PurchaseOrder)
        {

       
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlCommand cmd = new SqlCommand("spGetProductCodes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PONumber", PurchaseOrder);
            con.Open();
            DataTable dtProductCode = new DataTable();
            dtProductCode.Columns.Add("ProductCode");

            SqlDataReader rdr=cmd.ExecuteReader();
            
            while (rdr.Read())
            {

               DataRow dr= dtProductCode.NewRow();
                dr["ProductCode"] =Convert.ToInt32(rdr["ProductCode"]);
                dtProductCode.Rows.Add(dr);

            }
            
            con.Close();

            return dtProductCode;


        }

        public DataTable getProductDescription(int ProductCode)
        {
            DataTable dtItemDetails = new DataTable();
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlDataAdapter cmd = new SqlDataAdapter("spGetProductDescription", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@ProductCode", ProductCode);
            cmd.Fill(dtItemDetails);

            return dtItemDetails;
        }

        public DataTable getQty(int PONumber,int ProductCode)
        {
            DataTable dtItemDetails = new DataTable();
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlDataAdapter cmd = new SqlDataAdapter("spGetQty", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@PONumber", PONumber);
            cmd.SelectCommand.Parameters.AddWithValue("@ProductCode", ProductCode);
            cmd.Fill(dtItemDetails);

            return dtItemDetails;
        }
    }
}