using GymMe.DataSet;
using GymMe.Handler;
using GymMe.Models;
using GymMe.Report;
using GymMe.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Util;

namespace GymMe.Views
{
    public partial class TransactionReport : System.Web.UI.Page
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

            CrystalReport1 rep = new CrystalReport1();
            CrystalReportViewer1.ReportSource = rep;
            DataSet1 dt = getData(TransactionHandler.getTransaction());
            rep.SetDataSource(dt);
        }

        private DataSet1 getData(List<TransactionHeader> th)
        {
            DataSet1 data = new DataSet1();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;
            var supplementTable = data.MsSupplement;

            foreach (TransactionHeader t in th)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionId"] = t.TransactionId;
                hrow["UserID"] = t.UserID;
                hrow["TransactionDate"] = t.TransactionDate;
                hrow["Status"] = t.Status;
                headerTable.Rows.Add(hrow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID;
                    drow["SupplementID"] = d.SupplementID;
                    drow["Quantity"] = d.Quantity;
                    detailTable.Rows.Add(drow);

                    // Mengambil data supplement dari handler dan menambahkannya ke tabel SupplementTable
                    var supplement = TransactionHandler.getSupplementByID(d.SupplementID);
                    if (supplement != null && !IsSupplementInTable(supplementTable, supplement.SupplementID))
                    {
                        var crow = supplementTable.NewRow();
                        crow["SupplementID"] = supplement.SupplementID;
                        crow["SupplementName"] = supplement.SupplementName;
                        crow["SupplementExpiryDate"] = supplement.SupplementExpiryDate;
                        crow["SupplementPrice"] = supplement.SupplementPrice;
                        crow["SupplementTypeID"] = supplement.SupplementTypeID;
                        supplementTable.Rows.Add(crow);
                    }
                }
            }

            return data;
        }

        private bool IsSupplementInTable(DataTable supplementTable, int id)
        {
            foreach (DataRow row in supplementTable.Rows)
            {

                int supplementIdInTable = Convert.ToInt32(row["SupplementID"]);

                if (supplementIdInTable == id)
                {
                    return true;
                }

            }
            return false;
        }
    }
}
