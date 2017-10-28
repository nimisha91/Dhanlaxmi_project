using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonConnection
{
    public class Connection
    {

        public string getConnection()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["DhanalaxmiConnection"].ConnectionString;
        }

        public const string AddNewUser = "dbo.spLogin";
    }
}