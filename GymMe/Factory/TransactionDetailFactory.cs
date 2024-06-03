using GymMe.Models;

namespace GymMe.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail Create(int transactionID, int supplementID, int quantity)
        {
            TransactionDetail transactionDetail = new TransactionDetail();

            transactionDetail.TransactionID = transactionID;
            transactionDetail.SupplementID = supplementID;
            transactionDetail.Quantity = quantity;

            return transactionDetail;
        }
    }
}
