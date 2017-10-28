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
    public partial class AddNewUser : System.Web.UI.Page
    {

        AddNewUserBLL addobj = new AddNewUserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string userID=txtLoginID.Text;
            string pswd = txtPswd.Text;
            string pswd2 = txtreenterPswd.Text;
            string ques = drpQues.SelectedItem.Text;
            string ques1 = ques.Trim();
            string ans = txtAns.Text;

            int i=addobj.InsertUser(userID,pswd,pswd2,ques1,ans);
            
            if(i>0)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "msg", "alert('User Added Successfully!');window.location('Login.aspx');", true);
                Response.Write("<script type=\"text/javascript\">alert('User Added Successfully!');location.href='Login.aspx'</script>");
                //Response.Redirect("Login.aspx");
            }



            
        }
        public void drpQues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpQues.SelectedValue != "-1")
            {
                lblAns.Visible = true;
                txtAns.Visible = true;
            }
        }
    }
}