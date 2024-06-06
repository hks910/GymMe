using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}