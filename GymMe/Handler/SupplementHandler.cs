using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Handler
{
    public class SupplementHandler
    {
        public MsSupplement getSupplementById(int id)
        {
            MsSupplementRepository msSupplementRepository = new MsSupplementRepository();

            return (msSupplementRepository.getSupplementById(id));

        }

        public string updateSupplement (int id, string supplementName, DateTime supplementExpiry, int supplementPrice, int supplementTypeID)
        {
            MsSupplementRepository supplementRepository = new MsSupplementRepository();
            var supplement = supplementRepository.getSupplementById(id);
            if (supplement == null)
            {
                return "Failed to update supplement";
            }
            supplementRepository.updateSupplement(id,supplementName, supplementExpiry, supplementPrice, supplementTypeID);
            return "Successfully Updated";
        }

        public string insertSupplement(string supplementName, DateTime supplementExpiry, int supplementPrice, int supplementTypeID)
        {
            MsSupplementRepository supplementRepository = new MsSupplementRepository();
            var supplement = supplementRepository.getSupplementByName(supplementName);
            if (supplement != null)
            {
                return "Supplement name already exist!";
            }
            supplementRepository.insertSupplement(supplementName, supplementExpiry, supplementPrice, supplementTypeID);
            return "Successfully Inserted";
        }
        public Boolean deleteSupplementById(int id)
        {
            MsSupplementRepository supplementRepository = new MsSupplementRepository();
            var supplement = supplementRepository.getSupplementById(id);
            if (supplement== null)
            {
                return false;
            }
            supplementRepository.deleteSupplement(id);
            return true;
        }

        public List<MsSupplementType> getSupplementTypes()
        {
            MsSupplementRepository msSupplementRepository = new MsSupplementRepository();

            return (msSupplementRepository.getAllSupplementType());

        }
    }
}
