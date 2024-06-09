using GymMe.Factory;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Caching;

namespace GymMe.Repositories
{
    public class MsCartRepository
    {
        Database1Entities1 db = DatabaseSingleton.getInstance();

        // nge insert cart nya
        public void insertCart(int userId, int supplementId, int quantity)
        {
            MsCart cart = MsCartFactory.Create(userId, supplementId, quantity);
            db.MsCarts.Add(cart);
            db.SaveChanges();
        }

        public List<MsCart> getCartbyUserID(int userId)
        {
            return (from x in db.MsCarts where x.UserID == userId select x).ToList();
        }

        public void deleteCart(MsCart cart)
        {
            db.MsCarts.Remove(cart);
            db.SaveChanges();
        }

        public void deleteAllCart(int userId)
        {
            
            var cartItems = db.MsCarts.Where(cart => cart.UserID == userId).ToList();

            if (cartItems.Any())
            {
                db.MsCarts.RemoveRange(cartItems);
                db.SaveChanges();
            }
        }

        public void updateCart(int userId, int supplementId, int addition)
        {
            MsCart cart = db.MsCarts.FirstOrDefault(c => c.UserID == userId && c.SupplementID == supplementId);
            if (cart != null)
            {
                cart.Quantity += addition;
                db.SaveChanges();
            }
            else
            {
                insertCart(userId, supplementId, addition);
            }
          

        }

    }
}