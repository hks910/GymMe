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

        public string RegisterUser(string username, string email, string gender, string password, DateTime dob)
        {
            var searchUserName = userRepository.getUserByUsername(username);
            if (searchUserName != null)
            {
                return "Username Already Exists!";
            }

            string role = "Guest";
            userRepository.InsertUser(username, email, gender, role, password, dob);

            return "Successfully Registered";

        }
    }
}