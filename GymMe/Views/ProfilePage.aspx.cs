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
    public partial class ProfilePage : System.Web.UI.Page
    {

       ProfileController controller = new ProfileController();
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.Text = "";
            var user = (MsUser)Session["user"];

            if (!IsPostBack && Session["user"] != null)
            {
                UsernameTxt.Text = user.UserName;
                EmailTxt.Text = user.UserEmail;
                if (user.UserGender == "Male")
                {
                    radioMale.Checked = true;
                }
                else
                {
                    radioFemale.Checked = true;
                }
                DOBTxt.Text = user.UserDOB.ToString("yyyy-MM-dd");
                if (user.UserRole == "Admin")
                {
                    AdminNavbar.Visible = true;
                    CustomerNavBar.Visible = false;
                }
                else if (user.UserRole == "Customer")
                {
                    AdminNavbar.Visible = false;
                    CustomerNavBar.Visible = true;
                }
            }
            if (Session["user"] != null)
            {
                if (user.UserRole != "Customer")
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

            }
            else
            {
                    Response.Redirect("~/Views/HomePage.aspx");

            }

        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            var user = (MsUser)Session["user"];
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
            DateTime DOB;
            DateTime.TryParse(DOBTxt.Text, out DOB);

            string result = controller.UpdateProfile(user.UserID,username,email,gender,DOB);

            if (result == "Successfully Updated")
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Green;
                ErrorLbl.Text = result;
            }
            else
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Red;
                ErrorLbl.Text = result;
            }

           
        }

        protected void UpdatePassBtn_Click(object sender, EventArgs e)
        {
            var user = (MsUser)Session["user"];
            string oldPassword = OldPasswordTxt.Text;
            string newPassword = NewPasswordTxt.Text;

            string result = controller.UpdatePassword(user.UserID, oldPassword, newPassword);

            if (result == "Successfully Updated Password")
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Green;
                ErrorLbl.Text = result;
            }
            else
            {
                PassErrorLbl.ForeColor = System.Drawing.Color.Red;
                PassErrorLbl.Text = result;
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