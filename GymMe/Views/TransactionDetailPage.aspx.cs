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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        MsUserRepository UserRepository = new MsUserRepository();
        //public TransactionDetail tran = null;

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

            string m = Request["ID"];
            int Id = Convert.ToInt32(m);
            //TransactionDetail tr = TransactionHandler.getTransactionDetailById(Id);
            List<TransactionDetail> tr = TransactionHandler.GetTransactionDetailsById(Id);
            DetailGv.DataSource = tr;
            DetailGv.DataBind();

        }

    }
}