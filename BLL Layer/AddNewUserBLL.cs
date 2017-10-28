using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccessLayer;

namespace BLL_Layer
{
    public class AddNewUserBLL
    {
        AddNewUserDAL dataobj = new AddNewUserDAL();
        DataSet dsNewUser = new DataSet();

        public DataSet GetAllEmployee()
        {
            dsNewUser = dataobj.GetAllEmployee();
            return dsNewUser;
        }

        public int InsertUser(string userID, string pswd, string pswd2, string ques, string ans)
        {
            int i=dataobj.InsertUser(userID, pswd, pswd2, ques, ans);
            return i;
        }
    }

    
}