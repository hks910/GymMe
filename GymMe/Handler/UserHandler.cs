using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class UserHandler
    {
        private MsUserRepository userRepository = new MsUserRepository();

        public List<MsUser> GetUsers()
        {
            return userRepository.getMsUsers();
        }

        public MsUser GetUserById(int id)
        {
            return userRepository.getUserbyId(id);
        }
    }
}