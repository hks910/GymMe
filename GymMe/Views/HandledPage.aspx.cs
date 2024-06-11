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
    public partial class HandledPage : System.Web.UI.Page
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
            RoleLbl.Text = "Current Role : [Admin]";

            List<TransactionHeader> tr = TransactionHandler.getHandledTransaction();
            HandledGv.DataSource = tr;
            HandledGv.DataBind();

        }

        protected void HandledGv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = HandledGv.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Response.Redirect("~/Views/TransactionDetailPage.aspx?ID=" + id);
        }
    }
}