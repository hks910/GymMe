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

            // Validasi Username dan Password
            if (string.IsNullOrEmpty(username))
            {
                return "Username cannot be empty!";
            }
            else if (username.Length < 5 || username.Length > 15)
            {
                return "Username must be between 5 and 15 characters long!";
            }
            else if (string.IsNullOrEmpty(password))
            {
                return "Password cannot be empty!";
            }
            else if (user == null)
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