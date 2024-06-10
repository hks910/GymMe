using GymMe.Factory;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{

    public class TransactionHeaderRepository
    {
        public static Database1Entities1 db = DatabaseSingleton.getInstance();

        //Buat bikin transaksi header baru 
        public TransactionHeader createTransactionHeader(int userId, DateTime transactionDate, String status)
        {
            TransactionHeader transactionHeader = TransactionHeaderFactory.Create(userId, transactionDate, status);
            db.TransactionDetail.Add(transactionHeader);
            db.SaveChanges();
            return transactionHeader;
        }

        //Buat get ambil semua transaction

        public static List<TransactionHeader> getTransaction()
        {
            return (from x in db.TransactionDetail select x).ToList();
        }

        public static List<TransactionHeader> GetTransactions()
        {
            Database1Entities1 db = new Database1Entities1();
            return db.TransactionDetail.ToList();
        }

        //Buat view/get unhandled Transaction untuk role ADMIN
        public static List<TransactionHeader> getUnhandledTransactionHeader()
        {
            return (from x in db.TransactionDetail where x.Status.Equals("Unhandled") select x).ToList();
        }

        //Buat kasih list ke ADMIN 
        public static List<TransactionHeader> getHandledTransactionHeader()
        {
            return (from x in db.TransactionDetail where x.Status.Equals("Handled") select x).ToList();
        }

        //ketika admin mau change status dari unhandled ke handled
        public static void handlingTransaction(int id)
        {
            TransactionHeader transactionHeader = db.TransactionDetail.Find(id);
            transactionHeader.Status = "Handled";
            db.SaveChanges();
        }



        //ketika USER mau liat history transaction dia sendiri, maka harus ambil user id dia dulu,
        //nanti di repo transactionDetail baru bisa get all punya dia (atur logic nya di handler ya sebi)

 

        //ambil object untuk liat list transaksi header untuk user ini sendiri

        public static List<TransactionHeader> getTransactionHeadersbyUserId (int userId)
        {
            return (from x in db.TransactionDetail where x.UserID.Equals(userId) select x).ToList();
        }

        //ambil transactionID oleh user ini bisa dipake buat ke transaction detail
        public int getTransactionForDetail(int userId, DateTime dateNow)
        {
            return (from x in db.TransactionDetail where x.UserID == userId && x.TransactionDate == dateNow select x.TransactionId).FirstOrDefault();
        }


    }
}