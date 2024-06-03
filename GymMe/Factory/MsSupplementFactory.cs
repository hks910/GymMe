using GymMe.Models;
using System;

namespace GymMe.Factory
{
    public class MsSupplementFactory
    {
        public static MsSupplement Create(string supplementName, DateTime supplementExpiryDate, int supplementPrice, int supplementTypeID)
        {
            MsSupplement supplement = new MsSupplement();

            supplement.SupplementName = supplementName;
            supplement.SupplementExpiryDate = supplementExpiryDate;
            supplement.SupplementPrice = supplementPrice;
            supplement.SupplementTypeID = supplementTypeID;

            return supplement;
        }
    }
}
