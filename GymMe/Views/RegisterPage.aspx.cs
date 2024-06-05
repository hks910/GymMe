using GymMe.Controller;
using GymMe.Factory;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class RegisterPage : System.Web.UI.Page
    {

       RegisterController controller = new RegisterController();
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.Text = "";

            // Validate if Register Page only accessible to guests
            if (Session["user"] != null)
            {
                var user = (MsUser)Session["user"];
                if (user.UserRole != "Guest")
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

            }

        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxt.Text;
            string email = EmailTxt.Text;
            string gender = "";
            if (radioFemale.Checked)
            {
                gender = "Female";
            }
            else if (radioMale.Checked)
            {
                gender = "Male";
            }
            string password = PasswordTxt.Text;
            string confirmation = ConfirmationTxt.Text;
            DateTime DOB;
            DateTime.TryParse(DOBTxt.Text, out DOB);

            string result = controller.RegisterUser(username,email,gender,password, confirmation,DOB);

            if (result == "Successfully Registered")
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Green;
                ErrorLbl.Text = result;
                // Automatically redirect to Login Page in 2 seconds
                Response.AddHeader("refresh", "2;LoginPage.aspx");
            }
            else
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Red;
                ErrorLbl.Text = result;
            }

           
        }

        protected void radioMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radioFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}