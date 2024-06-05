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

        public string RegisterUser(String userName, String userEmail,
             String userGender, String userPassword, String confirmation, DateTime userDOB)
        {
            return handler.RegisterUser(userName, userEmail, userGender, userPassword, confirmation, userDOB);
        }
    }
}