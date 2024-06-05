using GymMe.Models;
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
        Database1Entities1 db = new Database1Entities1 ();
        protected void Page_Load(object sender, EventArgs e)
        {
                       
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
                    user = (from x in db.MsUsers where x.UserID == id select x).FirstOrDefault();
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
                    RoleLbl.Text = "Current Role : [Admin]";
             
                }
                else if (user.UserRole == "Customer")
                {
                    AdminNavbar.Visible = false;
                    CustomerNavBar.Visible = true;
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