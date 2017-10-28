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
    public class AddNewUserDAL
    {
        Connection clsCommon = new Connection();
        DataSet dsNewUser = new DataSet();

        public DataSet GetAllEmployee()
        {
            SqlConnection con = new SqlConnection(clsCommon.getConnection());
            SqlDataAdapter cmd = new SqlDataAdapter("select * from tbAddNewUser",con);
            con.Open();
            cmd.Fill(dsNewUser);
            con.Close();
            return dsNewUser;
            
        }

        public int InsertUser(string userID, string pswd, string pswd2, string ques, string ans)
        {
            SqlConnection conn = new SqlConnection(clsCommon.getConnection());
            SqlCommand cmd = new SqlCommand(Connection.AddNewUser, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userID", userID).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@password1", pswd).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@password2", pswd2).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@Ques", ques).Direction = ParameterDirection.Input;
            cmd.Parameters.AddWithValue("@ans", ans).Direction = ParameterDirection.Input;

            conn.Open();
            int i=cmd.ExecuteNonQuery();
            conn.Close();
            return i;

        }


    }
}