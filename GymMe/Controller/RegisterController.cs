using GymMe.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controller
{
    public class RegisterController
    {

        RegisterHandler handler = new RegisterHandler();

        public string RegisterUser(string username, string email, string gender, string password, string confirmation, DateTime dob)
        {
            string errorMessage = ValidateInput(username, email, gender, password, confirmation, dob);
            if (errorMessage != string.Empty)
            {
                return errorMessage;
            }

            return handler.RegisterUser(username, email, gender, password, dob);
        }

        private string ValidateInput(string username, string email, string gender, string password, string confirmation, DateTime dob)
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
            else if (string.IsNullOrEmpty(password))
            {
                return "Password cannot be empty!";
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"^[a-zA-Z0-9]+$"))
            {
                return "Password must be alphanumeric!";
            }
            else if (!confirmation.Equals(password))
            {
                return "Password and confirmation do not match!";
            }
            else if (dob == default(DateTime))
            {
                return "Date Of Birth cannot be empty!";
            }

            return string.Empty;
        }
    }
}