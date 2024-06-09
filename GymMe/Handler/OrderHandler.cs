using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class OrderHandler
    {
        public void updateCart(int  userid, int supplementId, int quantity)
        {
            MsCartRepository msCartRepository = new MsCartRepository();
            msCartRepository.updateCart(userid, supplementId, quantity);

        }

        public List<MsCart> getCartbyUserId (int id)
        {
            MsCartRepository msCartRepository = new MsCartRepository();
            List<MsCart> cart = new List<MsCart>();
            cart = msCartRepository.getCartbyUserID(id);
            return cart;
        }

        public List<MsSupplement> getAllSupplementList() 
        {
            MsSupplementRepository msSupplementRepository = new MsSupplementRepository();
            
           return (msSupplementRepository.getAllSupplement());

        
         }

        public Boolean deleteAllCartByID(int id)
        {
            
            MsCartRepository msCartRepository=new MsCartRepository();
            var cart = msCartRepository.getCartbyUserID(id);
            if ( cart.Count == 0)
            {
                return false;
            }
                msCartRepository.deleteAllCart(id);
                return true;
        }

        public Boolean doTransaction(int userId)
        {
            MsCartRepository msCartRepository = new MsCartRepository();
            List<MsCart> cart = msCartRepository.getCartbyUserID(userId);

            if (cart == null || cart.Count == 0)
            {
                return false;
            }

            CreateTransactionHandler createTransaction = new CreateTransactionHandler();
            createTransaction.createTransactionHeader(cart.FirstOrDefault());



            foreach (var item in cart)
            {
                if (cart != null)
                {
                    MsCartRepository repository = new MsCartRepository();
                    createTransaction.createTransactionDetail(item);
                    repository.deleteCart(item);
                }

            }
            return true;
        }
    }
}
