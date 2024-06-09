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
    public partial class WebForm1 : System.Web.UI.Page
    {
        MsUserRepository UserRepository = new MsUserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                        user = UserRepository.getUserbyId(id);
                        Session["user"] = user;
                    }
                    else
                    {
                        // kalau sessionnya tidak null
                        user = (MsUser)Session["user"];
                    }

                }
            }
        }
    }
}