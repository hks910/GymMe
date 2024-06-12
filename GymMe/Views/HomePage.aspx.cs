using GymMe.Controller;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace GymMe.Views
{
    public partial class HomePage : System.Web.UI.Page
    {
        UserController UserController = new UserController ();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<MsUser> list = UserController.GetUsers();
                UserList.DataSource = list;
                UserList.DataBind();
            }

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else // Jika Ada Cookie
            {
                //Ini klo misalnya ada cookienya, tp sessionnya null
                MsUser user;
                if (Session["user"] == null)
                {
                    var id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    user = UserController.GetUserById(id);
                    Session["user"] = user;
                }
                else
                {
                    // kalau sessionnya tidak null
                    user = (MsUser)Session["user"];
                }

                if (user.UserRole == "Admin")
                {
                    AdminNavbar.Visible = true;
                    CustomerNavBar.Visible = false;
                    CustomerContent.Visible = false;
                    Label1.Text = "Current Role : [Admin]";
                    List<MsUser> list = UserController.GetUsers();
                    UserList.DataSource = list;
                    UserList.DataBind();
             
                }
                else if (user.UserRole == "Customer")
                {
                    AdminNavbar.Visible = false;
                    CustomerNavBar.Visible = true;
                    CustomerContent.Visible = true;
                    AdminContent.Visible = false;
                    RoleLbl.Text = "Current Role : [Customer]";
                }
                else if (user.UserRole == "Guest") // Klo Guest ...
                {
                    Response.Redirect("~/Views/LoginPage.aspx");
                }

            }
        }
    }
}