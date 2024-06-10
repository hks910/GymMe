using GymMe.Controller;
using GymMe.Handler;
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
    public partial class ManageSupplementPage : System.Web.UI.Page
    {
        MsUserRepository UserRepository = new MsUserRepository();
        MsSupplementRepository SupplementRepository = new MsSupplementRepository();
        OrderController OrderController = new OrderController();
        SupplementController SupplementController = new SupplementController();



        public int UserId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
     

            if (!IsPostBack)
            {
                RefreshSupplement();
            }

            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
            }
            else 
            {
               
                MsUser user;
                if (Session["user"] == null)
                {
                    var id = Convert.ToInt32(Request.Cookies["user_cookie"].Value);
                    user = UserRepository.getUserbyId(id);
                    Session["user"] = user;
                }
                else
                {

                    user = (MsUser)Session["user"];
                    if (user.UserRole != "Admin")
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }

                }

            }


        }
        private void RefreshSupplement()
        {

            SupplementList.DataSource = OrderController.getSupplements();
            SupplementList.DataBind();
     
        }

        protected void EditSupplement(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = SupplementList.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/UpdateSupplementPage.aspx?SupplementId=" + id);
        }

        protected void DeleteSupplement(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = SupplementList.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            ErrorLbl.Text = SupplementController.deleteSupplement(id);
            RefreshSupplement();
        }


    }
}