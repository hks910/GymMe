using GymMe.Factory;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
    public class TransactionDetailRepository
    {
        Database1Entities1 db = DatabaseSingleton.getInstance();

        //create transaction detail
        public void createTransactionDetail(int transactionId, int supplementId, int quantity)
        {
            TransactionDetail transactionDetail = TransactionDetailFactory.Create(transactionId, supplementId, quantity);
            db.TransactionDetails.Add(transactionDetail);
            db.SaveChanges();
        }

        //mau liat list transaction detail di sebuah transaction id

        public List<TransactionDetail> getAllTransactiondetailbyTransactionID(int transactionId)
        {
            return(from x in db.TransactionDetails where x.TransactionID.Equals(transactionId) select x).ToList();
        }


    }
}