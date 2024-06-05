using GymMe.Controller;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class LoginPage : System.Web.UI.Page
    {
      
        private LoginController controller = new LoginController();
        protected void Page_Load(object sender, EventArgs e)
        {

            ErrorLbl.Text = "";

            // Validate if Login Page only accessible to guests
            if (Session["user"] != null)
            {
                var user = (MsUser)Session["user"];
                if (user.UserRole != "Guest")
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

            }
        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {

            string username = UsernameTxt.Text;
            string password = PasswordTxt.Text;
            bool isRemember = CheckBoxBtn.Checked;

            MsUser user;
            string error = controller.LoginUser(username, password, isRemember, out user);

            if (string.IsNullOrEmpty(error))
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Red;
                ErrorLbl.Text = error;
            }


        }

        protected void RegisterLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }
    }
}