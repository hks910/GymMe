using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GymMe.Factory
{
    public class MsUserFactory
    {
        public static MsUser Create(String userName, String userEmail, 
            DateTime userDOB, String userGender, String userRole)
        {
            MsUser user  = new MsUser();

            user.UserName = userName;
            user.UserEmail = userEmail;
            user.UserDOB = userDOB;
            user.UserGender = userGender;
            user.UserRole = userRole;

            return user;
           
        }
    }
}