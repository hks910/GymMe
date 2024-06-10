using GymMe.Controller;
using GymMe.Factory;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GymMe.Views
{
    public partial class InsertSupplementPage : System.Web.UI.Page
    {

       RegisterController controller = new RegisterController();
       SupplementController supplementController = new SupplementController();
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorLbl.Text = "";

            if (!IsPostBack)
            {

                List<MsSupplementType> list = supplementController.getSupplementTypes();
                SupplementTypeList.DataSource = list;
                SupplementTypeList.DataTextField = "SupplementTypeName"; // Display name
                SupplementTypeList.DataValueField = "SupplementTypeID";
                SupplementTypeList.DataBind();
            }

            // Validate if Register Page only accessible to guests
            if (Session["user"] != null)
            {
                var user = (MsUser)Session["user"];
                if (user.UserRole != "Admin")
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void InsertSupplement_Click(object sender, EventArgs e)
        { // Fetch input values from the form
            string supplementName = SupplementNameTxt.Text;
            DateTime supplementExpiryDate;
            DateTime.TryParse(SupplementExpiryDateTxt.Text, out supplementExpiryDate);
            int supplementPrice = 0;
            int.TryParse(SupplementPriceTxt.Text, out supplementPrice);
            int supplementTypeID = int.Parse(SupplementTypeList.SelectedValue);
            int id = Convert.ToInt32(Request["SupplementId"]);

            string result = supplementController.insertSupplement(supplementName, supplementExpiryDate, supplementPrice, supplementTypeID);

            if (result == "Successfully Inserted")
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Green;
                ErrorLbl.Text = result;
            }
            else
            {
                ErrorLbl.ForeColor = System.Drawing.Color.Red;
                ErrorLbl.Text = result;
            }


        }

        protected void radioMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void radioFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void LoginLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}