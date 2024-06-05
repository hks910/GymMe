using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // mengambil semua cookie lalu di clear
            string[] cookies = Request.Cookies.AllKeys;

            foreach (string cookie in cookies)
            {
                // dikurangin jadi hari sebelumnya
                Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }

            Session.Remove("user");
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}