using GymMe.Handler;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;


namespace GymMe.Controller
{
    public class ProfileController
    {

        ProfileHandler handler = new ProfileHandler();

        public string UpdateProfile(int id, string username, string email, string gender,DateTime dob)
        {

            string errorMessage = ValidateInput(username, email, gender, dob);
            if (errorMessage != string.Empty)
            {
                return errorMessage;
            }

            return handler.UpdateProfile(id,username, email, gender, dob);
        }

        public string UpdatePassword(int id, string oldPassword, string newPassword)
        {
            string userPassword = handler.getPasswordById(id);
            string errorMessage = ValidateInput(userPassword,oldPassword,newPassword);
            if (errorMessage != string.Empty)
            {
                return errorMessage;
            }

            return handler.UpdatePassword(id,newPassword);
        }


        private string ValidateInput(string username, string email, string gender,DateTime dob)
        {
            if (string.IsNullOrEmpty(username))
            {
                return "Username cannot be empty!";
            }
            else if (username.Length < 5 || username.Length > 15)
            {
                return "Username must be between 5 and 15 characters long!";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(username, @"^[a-zA-Z\s]+$"))
            {
                return "Username can only contain alphabets and spaces!";
            }
            else if (string.IsNullOrEmpty(email))
            {
                return "Email cannot be empty!";
            }
            else if (!email.EndsWith(".com"))
            {
                return "Email must end with .com!";
            }
            else if (string.IsNullOrEmpty(gender))
            {
                return "Gender must be chosen!";
            }
            else if (dob == default(DateTime))
            {
                return "Date Of Birth cannot be empty!";
            }

            return string.Empty;
        }

        private string ValidateInput(string userPassword,string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword))
            {
                return "Password cannot be empty!";
            }
            else if (!oldPassword.Equals(userPassword))
            {
                return "Old Password must be same with the current password!";
            }
            else if (string.IsNullOrEmpty(newPassword))
            {
                return "Password cannot be empty!";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]+$"))
            {
                return "New Password must be alphanumeric!";
            }

            return string.Empty;
        }
    }
}