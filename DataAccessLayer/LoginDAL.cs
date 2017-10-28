using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CommonConnection;

namespace DataAccessLayer
{
    public class LoginDAL
    {
        Connection con = new Connection();

        public DataTable CheckUser(string user,string pswd)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(con.getConnection());
            SqlDataAdapter cmd=new SqlDataAdapter("select * from Login where username='"+user+"' and password='"+pswd+"'",conn);
            conn.Open();
            cmd.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }
    }
}