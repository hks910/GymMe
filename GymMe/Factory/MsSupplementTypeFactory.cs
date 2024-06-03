using GymMe.Models;

namespace GymMe.Factory
{
    public class MsSupplementTypeFactory
    {
        public static MsSupplementType Create(string supplementTypeName)
        {
            MsSupplementType supplementType = new MsSupplementType();

            supplementType.SupplementTypeName = supplementTypeName;

            return supplementType;
        }
    }
}
