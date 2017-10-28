using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DataAccessLayer;

namespace BLL_Layer
{
    public class LoginBLL
    {
        LoginDAL dObj = new LoginDAL();
        DataTable dtLogin = new DataTable();

        public DataTable CheckUser(string user,string pswd)
        {
            dtLogin = dObj.CheckUser(user, pswd);
            return dtLogin;
        }

    }
}