using GymMe.Handler;
using GymMe.Models;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TransactionHandler = GymMe.Handler.TransactionHandler;

namespace GymMe.Views
{
    public partial class OrderQueue : System.Web.UI.Page
    {
        MsUserRepository UserRepository = new MsUserRepository();

        public int UserId { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    UserId = user.UserID;

                }
                else
                {

                    user = (MsUser)Session["user"];
                    UserId = user.UserID;
                }

            }
            RoleLbl.Text = "Curren Role : [Admin]";
            List<TransactionHeader> tr = TransactionHandler.getUnhandledTransaction();
            UnhandledOrderGv.DataSource = tr;
            UnhandledOrderGv.DataBind();
        }

        protected void UnhandledOrderGv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = UnhandledOrderGv.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            TransactionHandler.HandleTransaction(id);
            Response.Redirect("~/Views/OrderQueue.aspx");

        }

        protected void UnhandledOrderGv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            GridViewRow row = UnhandledOrderGv.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/TransactionDetailPage.aspx?ID=" + id);
        }

    }
}