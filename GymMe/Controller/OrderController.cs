using GymMe.Handler;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace GymMe.Controller
{
    public class OrderController
    {
        OrderHandler orderHandler = new OrderHandler();
        public string checkQuantity(int quantity)
        {
            if (quantity <= 0)
            {
                return "Quantity must be greater than 0";
            }
            else if(quantity == null)
            {
                return "Quantity must be filled";
            }

            return "true";
        }

        public Boolean checkQuantityNull(string text)
        {
           if(text == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void updateCart(int UserId, int supId, int quantity)
        {
            orderHandler.updateCart(UserId, supId, quantity);
        }

        public List<MsCart> getCartById(int UserId)
        {


            List<MsCart> cartItems = orderHandler.getCartbyUserId(UserId);
            return cartItems;
        }

        public List<MsSupplement> getSupplements()
        {
            List<MsSupplement> suppItems = orderHandler.getAllSupplementList();
            return suppItems;
        }

        public string doTransaction(int UserID)
        {
            if (orderHandler.doTransaction(UserID))
            {
                return "Checkout Successfull and Your Transaction already generated";
            }
            return "Cart failed to checkout";
        }

        public string deleteAllCartByID(int UserId)
        {
            
            if(orderHandler.deleteAllCartByID(UserId) == false)
            {
                return "Cannot clear cart.";
            }
            return "Cart cleard successfully";
        }


    }
}