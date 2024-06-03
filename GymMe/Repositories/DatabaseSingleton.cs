using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
    public class DatabaseSingleton
    {
        private static Database1Entities1 db = null;

        public static Database1Entities1 getInstance()
        {
            if (db == null)
            {
                db = new Database1Entities1();
            }
            return db;
        }
    }
}