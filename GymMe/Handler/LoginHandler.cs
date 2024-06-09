using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace GymMe.Handler
{
    public class LoginHandler
    {

        MsUserRepository userRepository = new MsUserRepository();

        public string ValidateLogin(string username, string password, out MsUser user)
        {
            user = userRepository.getUserByUsername(username);

            user = userRepository.getUserByUsername(username);

            if (user == null)
            {
                return "User not found !!";
            }
            else if (!password.Equals(user.UserPassword))
            {
                return "Wrong Password";
            }

            return string.Empty; // No error
        }

        public int getUserId(string username)
        {
            MsUser user = userRepository.getUserByUsername(username);
            int userId = user.UserID;
            return userId;
        }
    }   
}