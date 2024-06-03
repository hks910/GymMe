using GymMe.Models;
using System;

namespace GymMe.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader Create(int userID, DateTime transactionDate, string status)
        {
            TransactionHeader transactionHeader = new TransactionHeader();

            transactionHeader.UserID = userID;
            transactionHeader.TransactionDate = transactionDate;
            transactionHeader.Status = status;

            return transactionHeader;
        }
    }
}
