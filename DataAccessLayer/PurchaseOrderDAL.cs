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
    public class PurchaseOrderDAL
    {
        DataSet dsDAL = new DataSet();
        Connection conn = new Connection();
        public DataTable getClients()
        {
            
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlDataAdapter cmd = new SqlDataAdapter("spGetClients",con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Fill(dsDAL);
            con.Close();
            return dsDAL.Tables[0];
        }

        public DataTable getClientDetails(int ClientID)
        {
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlDataAdapter cmd = new SqlDataAdapter("GetClientDetails", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@clientid", ClientID).Direction = ParameterDirection.Input;
            con.Open();
            cmd.Fill(dsDAL);
            con.Close();
            return dsDAL.Tables[0];
        }

        public DataTable getAllItems()
        {
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlDataAdapter cmd = new SqlDataAdapter("spgetAllItems", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Fill(dsDAL);
            con.Close();
            return dsDAL.Tables[0];
        }

        public DataTable getItemDetails(int ProductCode)
        {
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlDataAdapter cmd = new SqlDataAdapter("spgetItemDetails", con);
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            cmd.SelectCommand.Parameters.AddWithValue("@productcode", ProductCode).Direction = ParameterDirection.Input;
            con.Open();
            cmd.Fill(dsDAL);
            con.Close();
            return dsDAL.Tables[0];
        }

        public int InsertPurchaseOrder(int PONumber, DateTime PODate, DateTime DispatchDate, int clientID)
        {
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlCommand cmd = new SqlCommand("spInsertPO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@POnumber", PONumber);
            cmd.Parameters.AddWithValue("@PODate",PODate);
            cmd.Parameters.AddWithValue("@DispatchDate",DispatchDate);
            cmd.Parameters.AddWithValue("@clientID", clientID);

            SqlParameter sqlParam = new SqlParameter();
            sqlParam.ParameterName = "@OrderID";
            sqlParam.SqlDbType =SqlDbType.Int;
            sqlParam.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(sqlParam);

            con.Open();
            cmd.ExecuteNonQuery();
            int OrderID=(int)sqlParam.Value;
            con.Close();

            return OrderID;


        }

        public int InsertPurchaseOrderItemDetails(int OrderID, int ProductCode, int Qty, int Amount)
        {
            SqlConnection con = new SqlConnection(conn.getConnection());
            SqlCommand cmd = new SqlCommand("spInsertPOItemDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductCode", ProductCode);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Amount", Amount);
            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            con.Open();
            int rowsinserted = cmd.ExecuteNonQuery();
            con.Close();

            return rowsinserted;


        }

    }
}