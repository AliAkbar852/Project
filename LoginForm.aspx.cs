using System;
using BussinessLogicLayer;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppProps;
using System.Data;

namespace Project
{
	public partial class LoginForm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["userEmail"] != null)
            {
                Response.Redirect("Dashboard.aspx"); 
            }
        }
		

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Email = TxtEmail.Text.Trim();
            user.Password = TxtPassword.Text.Trim();

            BLL logic = new BLL();
            DataTable dt = logic.ValidateUser(user);

            if (dt.Rows.Count > 0)
            {
                Session["userEmail"] = TxtEmail.Text.Trim();
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                LblError.Text = "Invalid email or password!";
            }

        }
        protected void BtnSingUp_Click1(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }
    }
}