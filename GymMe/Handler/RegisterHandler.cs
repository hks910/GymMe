using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class RegisterHandler
    {
      
        private MsUserRepository userRepository = new MsUserRepository();
        public string RegisterUser(string username, string email, string gender, string password, string confirmation, DateTime dob)
        {
            string errorMessage = ValidateInput(username, email, gender, password, confirmation, dob);
            if (errorMessage != string.Empty)
            {
                return errorMessage;
            }

            string role = "Guest";

            userRepository.InsertUser(username, email, gender, role, password, dob);

            return "Successfully Registered";
        }

        private string ValidateInput(String username, String email,
            String gender, String password, String confirmation, DateTime dob)
        {
            var searchUserName = userRepository.getUserByUsername(username);

            if (string.IsNullOrEmpty(username))
            {
                return "Username cannot be empty!";
            }
            else if (searchUserName != null)
            {
                return "Username Already Exists!";
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
                return "Email must ends with .com!";
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
            else if (string.IsNullOrEmpty(dob.ToString()))
            {
                return "Date Of Birth cannot be empty!";
            }

            return string.Empty;
        }

    }
}