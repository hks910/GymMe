using GymMe.Handler;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace GymMe.Controller
{
    public class SupplementController
    {
        SupplementHandler supplementHandler = new SupplementHandler();
        public MsSupplement getSupplementById (int id)
        {


            MsSupplement supp = supplementHandler.getSupplementById(id);
            return supp;
        }


        public string deleteSupplement (int id)
        {
            if (supplementHandler.deleteSupplementById(id))
            {
                return "Supplement" + id + "succesfully Deleted";
            }
            return "Can't delete supplement!";
        }

        public List<MsSupplementType> getSupplementTypes()
        {
            return supplementHandler.getSupplementTypes();
        }

        public string updateSupplement(int id, string supplementName, DateTime supplementExpiry, int supplementPrice, int supplementTypeID)
        {
            string validation = ValidateInput(supplementName, supplementExpiry, supplementPrice, supplementTypeID);
            if (validation != string.Empty)
            { 
                return validation;
            }
            return supplementHandler.updateSupplement(id, supplementName, supplementExpiry, supplementPrice, supplementTypeID);
        }

        public string insertSupplement(string supplementName, DateTime supplementExpiry, int supplementPrice, int supplementTypeID)
        {
            string validation = ValidateInput(supplementName, supplementExpiry, supplementPrice, supplementTypeID);
            if (validation != string.Empty)
            {
                return validation;
            }
            return supplementHandler.insertSupplement(supplementName, supplementExpiry, supplementPrice, supplementTypeID);
        }

        public string ValidateInput (string supplementName, DateTime supplementExpiry, int supplementPrice, int supplementTypeID)
        {
            if (string.IsNullOrEmpty(supplementName))
            {
                return "Supplement Name cannot be empty.";
            }
            if (!supplementName.Contains("Supplement"))
            {
                return "Supplement Name must contain 'Supplement'.";
            }
            if (supplementExpiry == DateTime.MinValue || supplementExpiry <= DateTime.Today)
            {
                return "Supplement Expiry Date must be greater than today's date and cannot be empty.";
            }
            if (supplementPrice <= 0)
            {
                return "Supplement Price cannot be empty.";
            }
            if (supplementPrice < 3000)
            {
                return "Supplement Price must be at least 3000.";
            }
            if (supplementTypeID <= 0)
            {
                return "Supplement Type ID cannot be empty.";
            }

            return string.Empty;
        }



    }
}