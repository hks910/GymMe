using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class ProfileHandler
    {
        private MsUserRepository userRepository = new MsUserRepository();

        public string UpdateProfile(int id, string username, string email, string gender, DateTime dob)
        {
            var searchUserName = userRepository.getUserByUsername(username);
            if (searchUserName != null)
            {
                return "Username Already Exists!";
            }
            userRepository.UpdateUser(id ,username, email, gender, dob);

            return "Successfully Updated";

        }

        public string UpdatePassword(int id, string newPassword)
        {

            userRepository.updatePassword(id, newPassword);

            return "Successfully Updated Password";

        }

        public string getPasswordById(int id)
        {
            string pass = userRepository.getPassword(id);
            return pass;
        }
    }
}