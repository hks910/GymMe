using GymMe.Factory;
using GymMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymMe.Repositories
{
    public class MsSupplementRepository

    {
        Database1Entities1 db = DatabaseSingleton.getInstance();

        //dipake buat admin ketika mau input supplement
        public void insertSupplement(String supplementName, DateTime expiryDate, int price, int typeId)
        {
            MsSupplement supplement = MsSupplementFactory.Create(supplementName, expiryDate, price, typeId);
            db.MsSupplements.Add(supplement);
            db.SaveChanges();
        }
        // dipake buat update supplement oleh admin
        public void updateSupplement(int id, String supplementName, DateTime expiryDate, int price, int typeId)
        {
            MsSupplement supplement = db.MsSupplements.Find(id);
            supplement.SupplementName = supplementName;
            supplement.SupplementExpiryDate = expiryDate;
            supplement.SupplementPrice = price;
            supplement.SupplementTypeID = typeId;
            db.SaveChanges();

        }

        //pas admin mau delete supplement
        public void deleteSupplement(int id)
        {
            MsSupplement supplement = db.MsSupplements.Find(id);

            db.MsSupplements.Remove(supplement);
            db.SaveChanges();
        }

        //kalau mau ambil semua list supplement

        public List<MsSupplement> getAllSupplement()
        {
            return (from x in db.MsSupplements select x).ToList();
        }

        //kalau mau supplement by id

        public MsSupplement getSupplementById(int id)
        {
            return (from x in db.MsSupplements where x.SupplementID == id select x).FirstOrDefault();
        }

        public MsSupplement getSupplementByName(string name)
        {
            return (from x in db.MsSupplements where x.SupplementName.Equals(name) select x).FirstOrDefault();
        }

        public List<MsSupplementType> getAllSupplementType()
        {
            return (from x in db.MsSupplementTypes select x).ToList();

        }




    }
}