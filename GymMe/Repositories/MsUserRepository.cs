using GymMe.Factory;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace GymMe.Repositories
{
    public class MsUserRepository
    {

        Database1Entities1 db = DatabaseSingleton.getInstance();


        //ini buat get all repo
        public List<MsUser> getMsUsers()
        {
            return(from x in db.MsUsers select x).ToList();
        }

        // buat dapetin user pakai id nya 
        public MsUser getUserbyId(int id)
        {
            return (from x in db.MsUsers where x.Equals(id) select x).FirstOrDefault();
        }


        //search Username
        public MsUser getUserByUsername(string username)
        {
            var user = db.MsUsers.FirstOrDefault(x => x.UserName == username);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }


        // cari role ketika mau update role
        public String getUserRole (int id)
        {

            return (from x in db.MsUsers where x.Equals(id) select x.UserRole).FirstOrDefault();
        }
        // cari password dan dipake ketika mau update password
        public string getPassword(int id)
        {
            return (from x in db.MsUsers where x.Equals(id) select x.UserPassword).FirstOrDefault();
        }

        //nanti kalau user login pas mau add panggil function aja abis lewat logic login
        public void InsertUser(String userName, String userEmail,
            String userGender, String userRole, String userPassword, DateTime userDOB)
        {
            MsUser user = MsUserFactory.Create(userName, userEmail,
            userGender, userRole, userPassword, userDOB);
            db.MsUsers.Add(user);
            db.SaveChanges();

        }

        //ini buat update, nanti abis lewat logic langsung panggil aja
        public void UpdateUser(int id, String userName, String userEmail,
            DateTime userDOB, String userGender, String userRole, String userPassword)
        {

            MsUser user = db.MsUsers.Find(id);
            user.UserName = userName;
            user.UserEmail = userEmail;
            user.UserDOB = userDOB;
            user.UserGender = userGender;
            user.UserRole = userRole;
            user.UserPassword = userPassword;

            db.SaveChanges();

        }
        // mengembalikan objek user yang dicari atau tuju ketika password dan username nya benar
        public MsUser login (String userName, String userPassword)
        {
            return (from x in db.MsUsers where x.UserName.Equals(userName) && x.UserPassword.Equals(userPassword) select x).FirstOrDefault();

        }

    //function update password
     public bool updatePassword (int id, String newPassword)
        {
            MsUser user = db.MsUsers.Find(id);  
            if(user != null)
            {
                user.UserPassword = newPassword;
                db.SaveChanges();
                return true;
            }
            return false;

        }


    }
}