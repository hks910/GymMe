using GymMe.Handler;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Controller
{
    public class UserController
    {

        UserHandler handler = new UserHandler();

        public List<MsUser> GetUsers()
        { 
            return handler.GetUsers();
        }

        public MsUser GetUserById(int id)
        {
            return handler.GetUserById(id);
        }

    }
}