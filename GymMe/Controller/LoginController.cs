using GymMe.Handler;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controller
{
    public class LoginController
    {
        private LoginHandler handler = new LoginHandler();

        public string LoginUser(string username, string password, bool isRemember, out MsUser user)
        {
            string error = handler.ValidateLogin(username, password, out user);

            if (string.IsNullOrEmpty(error) && user != null)
            {
                // Set session and cookies if needed
                HttpContext.Current.Session["user"] = user;

                if (isRemember)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Value = user.UserID.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }

            return error;
        }
    }
}