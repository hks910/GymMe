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
    public partial class CustomerTransaction : System.Web.UI.Page
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
            List<TransactionHeader> tr = TransactionHandler.getTransactionByUserId(UserId);
            CustomerTransactionGv.DataSource = tr;
            CustomerTransactionGv.DataBind();
        }

        protected void CustomerTransactionGv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = CustomerTransactionGv.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/TransactionDetailPage.aspx?ID=" + id);
        }
    }
}