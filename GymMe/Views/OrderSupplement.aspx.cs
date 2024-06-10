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
    public partial class OrderSupplement : System.Web.UI.Page
    {
        OrderController OrderController = new OrderController();
        UserController UserController = new UserController();


        public int UserId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
     

            if (!IsPostBack)
            {   
                RefreshCart();              
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
                    user = UserController.GetUserById(id);
                    Session["user"] = user;
                    UserId = user.UserID;

                }
                else
                {
                  
                    user = (MsUser)Session["user"];
                    UserId = user.UserID;
                }

            }
            List<MsCart> cartItems = OrderController.getCartById(UserId);
            CheckOutList.DataSource = cartItems;
            CheckOutList.DataBind();

            foreach (GridViewRow checkoutRow in CheckOutList.Rows)
            {
                int rowIndex = checkoutRow.RowIndex;
                int quantity = Convert.ToInt32(checkoutRow.Cells[3].Text);
                int price = Convert.ToInt32(cartItems[rowIndex].MsSupplement.SupplementPrice);
                int subTotal = quantity * price;

                Label subTotalLabel = (Label)checkoutRow.FindControl("SubTotal");
                subTotalLabel.Text = subTotal.ToString();
            }


            int totalPrice = cartItems.Sum(item => item.Quantity * item.MsSupplement.SupplementPrice);
            TotalPriceLabel.Text = totalPrice.ToString();

        }

        protected void SupplementList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {              
                OrderController orderController = new OrderController();
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = SupplementList.Rows[rowIndex];     

                TextBox quantityTextBox = (TextBox)row.FindControl("TextBox1");

                if (orderController.checkQuantityNull(quantityTextBox.Text))
                {


                    int quantity = Convert.ToInt32(quantityTextBox.Text);

                    if (orderController.checkQuantity(quantity).Equals("true"))
                    {
                        int id = Convert.ToInt32(row.Cells[0].Text);
                        OrderController.updateCart(UserId, id, quantity);
                        RefreshCart();
                        Message2.Text = "Succesfully updated cart";
                        Message2.ForeColor = System.Drawing.Color.Green;

                    }
                    else
                    {
                        Message2.Text = orderController.checkQuantity(quantity);
                        Message2.ForeColor = System.Drawing.Color.Red;

                    }

                }
                else
                {
                    Message2.Text = "Value must be filled";
                    Message2.ForeColor = System.Drawing.Color.Red;
                }


            }
        }

        private void RefreshCart()
        {
            List<MsCart> cartItems = OrderController.getCartById(UserId);
            CheckOutList.DataSource = cartItems;
            CheckOutList.DataBind();

            foreach (GridViewRow checkoutRow in CheckOutList.Rows)
            {
                int rowIndex = checkoutRow.RowIndex;
                int quantity = Convert.ToInt32(checkoutRow.Cells[3].Text); 
                int price = Convert.ToInt32(cartItems[rowIndex].MsSupplement.SupplementPrice);
                int subTotal = quantity * price;

                Label subTotalLabel = (Label)checkoutRow.FindControl("SubTotal");
                subTotalLabel.Text = subTotal.ToString();
            }

       
            int totalPrice = cartItems.Sum(item => item.Quantity * item.MsSupplement.SupplementPrice);
            TotalPriceLabel.Text = totalPrice.ToString();


            SupplementList.DataSource = OrderController.getSupplements();
            SupplementList.DataBind();
     
        }

        protected void CheckOut_Click(object sender, EventArgs e)
        {
            string result = OrderController.doTransaction(UserId);

            Message.Text = result;
            if (result.Equals("Checkout Successfull and Your Transaction already generated"))
            {
                Message.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Message.ForeColor = System.Drawing.Color.Red;

            }

            RefreshCart();

        }

        protected void ClearCart_Click(object sender, EventArgs e)
        {
            string result = OrderController.deleteAllCartByID(UserId).Trim();
            Message.Text = result;
            if (result.Equals("Cart cleared successfully", StringComparison.OrdinalIgnoreCase))
            {
                Message.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Message.ForeColor = System.Drawing.Color.Red;
            }

            RefreshCart();
        }

    }
}