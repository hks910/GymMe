using GymMe.Factory;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Util;

namespace GymMe.Handler
{
    public class CreateTransactionHandler
    {
       TransactionHeader header = new TransactionHeader();

        public void createTransactionHeader(MsCart cart)
        {

            TransactionHeaderRepository TransactionHeaderRepository = new TransactionHeaderRepository();
            if (cart == null)
            {
                return; 
            }
            else
            {
                int userId = cart.UserID;
                DateTime transactionDate = DateTime.Now;
                String status = "Unhandled";
                header = TransactionHeaderRepository.createTransactionHeader(userId, transactionDate, status);

            }



        }

        public void createTransactionDetail(MsCart cart)
        {
            if (cart == null)
            {
                return;
            }
            else
            {
                int supplementId = cart.SupplementID;
                int quantity = cart.Quantity;
                TransactionDetailRepository transactionDetailRepository = new TransactionDetailRepository();
                transactionDetailRepository.createTransactionDetail(header.TransactionId, supplementId, quantity);
            }
 
        }
    }
}