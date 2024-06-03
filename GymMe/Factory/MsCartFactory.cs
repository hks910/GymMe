using GymMe.Models;

namespace GymMe.Factory
{
    public class MsCartFactory
    {
        public static MsCart Create(int userID, int supplementID, int quantity)
        {
            MsCart cart = new MsCart();

            cart.UserID = userID;
            cart.SupplementID = supplementID;
            cart.Quantity = quantity;

            return cart;
        }
    }
}
