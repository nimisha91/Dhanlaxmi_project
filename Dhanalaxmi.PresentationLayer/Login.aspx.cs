using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL_Layer;

namespace Dhanalaxmi.PresentationLayer
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        LoginBLL lobj = new LoginBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dtLogin = new DataTable();
            string user = txtUser.Text;
            string pswd = txtPswd.Text;
            dtLogin=lobj.CheckUser(user, pswd);
            if(dtLogin.Rows.Count==0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('Not a Registered User! Click AddNewUser to Register.')", true);
                txtUser.Text = string.Empty;
                txtUser.Focus();
                
            }
            else
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnnewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewUser.aspx");
        }
    }
}