using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class TransactionHandler
    {
        private static Database1Entities1 db = DatabaseSingleton.getInstance();
        public static List<TransactionHeader> getUnhandledTransaction()
        {
            return TransactionHeaderRepository.getUnhandledTransactionHeader();
        }

        public static List<TransactionHeader> getHandledTransaction()
        {
            return TransactionHeaderRepository.getHandledTransactionHeader();
        }

        public static List <TransactionHeader> getTransaction() {
            return TransactionHeaderRepository.GetTransactions();
        }

        public static void HandleTransaction(int id)
        {
            TransactionHeaderRepository.handlingTransaction(id);
        }

        //buat ngambil transaksi khusus user

        public static List<TransactionHeader> getTransactionByUserId(int userId)
        {
             return TransactionHeaderRepository.getTransactionHeadersbyUserId(userId);
        }

        /*public static TransactionDetail getTransactionDetailById(int id)
        {
            return TransactionDetailRepository.getAllTransactiondetailbyTransactionID(id);
        }*/

        public static List<TransactionDetail> GetTransactionDetailsById(int id)
        {
            return TransactionDetailRepository.getAllTransactiondetailbyTransactionID(id);
        }

        public static MsSupplement getSupplementByID(int id)
        {
            MsSupplementRepository msSupplementRepository = new MsSupplementRepository();
            return msSupplementRepository.getSupplementById(id);
        }
    }
}