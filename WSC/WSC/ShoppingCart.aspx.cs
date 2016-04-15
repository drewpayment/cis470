using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace WSC
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            View_Panel();
            if (cartitems == true)
            {
                lblMessage.Text = "Enter desired quantity and select Update to calculate price.";
            }
            else
            {
                btnUpdate1.Visible = false;
                lblMessage.Text = "There are no items in your shopping cart.";
            }

        }
        //variables for purchase item ids 
        string purchItemID1 = null;
        string purchItemID2 = null;
        string purchItemID3 = null;
        protected void Checkout_Click(object sender, EventArgs e)
        {
            if (Session["CartItem1"] != null)
            {
                int mediaID = Convert.ToInt16(lblitemNum1.Text);
                string jobType = DropDownList1.SelectedValue;
                int jobID;
                int specialistID;
                if (jobType == "Print")
                {
                    jobID = 1;
                    specialistID = 1;
                }
                else
                {
                    jobID = 2;
                    specialistID = 2;
                }
                int purchQty = Convert.ToInt16(txtQuantity1.Text);
                decimal purchItemCost = 15;
                string contentDesc = txtContent1.Text;
                Session["content1"] = contentDesc;

                string query1 = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";

                //connection string            
                string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand command = new MySqlCommand(query1, myConn))
                    {
                        MySql.Data.MySqlClient.MySqlDataReader myDataReader;

                        myConn.Open();
                        command.CommandText = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')"; 
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT purchaseItemID FROM purchase_item ORDER BY purchaseItemID DESC LIMIT 1";
                        myDataReader = command.ExecuteReader();
                         while (myDataReader.Read())
                        //gets purchase item id from row just entered into the database                       
                        {
                            purchItemID1 = myDataReader["purchaseItemID"].ToString(); 
                        }
                        myDataReader.Close();
                        myConn.Close();
                    }
                }
            }
            
            Session["purchItem1"] = purchItemID1;
            if (Session["CartItem2"] != null)
            {
                int mediaID = Convert.ToInt16(lblitemNum2.Text);
                string jobType = DropDownList2.SelectedValue;
                int jobID;
                int specialistID;
                if (jobType == "Print")
                {
                    jobID = 1;
                    specialistID = 1;
                }
                else
                {
                    jobID = 2;
                    specialistID = 2;
                }
                int purchQty = Convert.ToInt16(txtQuantity2.Text);
                decimal purchItemCost = 35;
                string contentDesc = txtContent2.Text;
                Session["content2"] = contentDesc;

                string query2 = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";

                //connection string            
                string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader;
                    using (MySqlCommand command = new MySqlCommand(query2, myConn))
                    {
                        myConn.Open();
                        command.CommandText = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT purchaseItemID FROM purchase_item ORDER BY purchaseItemID DESC LIMIT 1";
                        myDataReader = command.ExecuteReader();
                        while (myDataReader.Read())
                        //gets purchase item id from row just entered into the database                       
                        {
                            purchItemID2 = myDataReader["purchaseItemID"].ToString();
                        }
                        myDataReader.Close();
                        myConn.Close();
                    }
                }
            }
            Session["purchItem2"] = purchItemID2;
            if (Session["CartItem3"] != null)
            {
                int mediaID = Convert.ToInt16(lblitemNum3.Text);
                string jobType = DropDownList3.SelectedValue;
                int jobID;
                int specialistID;
                if (jobType == "Print")
                {
                    jobID = 1;
                    specialistID = 1;
                }
                else
                {
                    jobID = 2;
                    specialistID = 2;
                }
                int purchQty = Convert.ToInt16(txtQuantity3.Text);
                decimal purchItemCost = 25;
                string contentDesc = txtContent3.Text;
                Session["content3"] = contentDesc;
                    
                string query3 = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";

                //connection string            
                string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader;
                    using (MySqlCommand command = new MySqlCommand(query3, myConn))
                    {
                        myConn.Open();
                        command.CommandText = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT purchaseItemID FROM purchase_item ORDER BY purchaseItemID DESC LIMIT 1";
                        myDataReader = command.ExecuteReader();
                        while (myDataReader.Read())
                        //gets purchase item id from row just entered into the database                       
                        {
                            purchItemID3 = myDataReader["purchaseItemID"].ToString();
                        }
                        myDataReader.Close();
                        myConn.Close();
                    }
                } Session["purchItem3"] = purchItemID3;
            } Response.Redirect("Checkout.aspx");

           
        }
        //populate shoppnig cart with customer selections and set item price
        public bool cartitems = false;

        protected void View_Panel()
        {
            if (Session["CartItem1"] != null)
            {
                lblItem1.Text = Convert.ToString(Session["CartItem1"]);
                lblitemNum1.Text = "1";                
                lblProductDesc1.Text = "Shirt XYZ (White) - Lg";
                item1Panel.Visible = true;
                cartitems = true;
            }
            else
            {
                item1Panel.Visible = false;
            }

            if (Session["CartItem2"] != null)
            {
                lblItem2.Text = Convert.ToString(Session["CartItem2"]);
                lblitemNum2.Text = "2";
                lblProductDesc2.Text = "Round Plaque w/ Banner (Espresso)";
                item2Panel.Visible = true;
                cartitems = true;
            }
            else
            {
                item2Panel.Visible = false;
            }

            if (Session["CartItem3"] != null)
            {
                lblItem3.Text = Convert.ToString(Session["CartItem3"]);
                lblitemNum3.Text = "3";
                lblProductDesc3.Text = "Silver Cup w/ Pine Base (Cherry) -Med";
                item3Panel.Visible = true;
                cartitems = true;
            }
            else
            {
                item3Panel.Visible = false;
            }

        }
        //Calculate the Unit Price for each purchase item
        protected decimal GetUnitPrice(decimal unitPrice, int qty)
        {
            unitPrice = unitPrice * qty;
            return unitPrice;
        }
        //Calculate the Total Price 
        protected decimal TotalPrice;
        protected decimal CalculateTotalPrice(decimal unitPrice1, decimal unitPrice2, decimal unitPrice3)
        {
            TotalPrice = unitPrice1 + unitPrice2 + unitPrice3;
            return TotalPrice;
        }

        //Cancel Shopping Cart purchases
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Session["CartItem1"] = null;
            Session["CartItem2"] = null;
            Session["CartItem3"] = null;
            TotalPrice = 0;
            ClearInputs(Page.Controls);
            Response.Redirect("Catalog.aspx");
        }
        //Clears customer selections and input feilds 
        void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }
        }
        // 3 btnUpdate methods Updates price of item to new qty 
        public decimal unitPrice1;
        public decimal unitPrice2;
        public decimal unitPrice3;
        protected void btnUpdate1_Click(object sender, EventArgs e)
        {
            if (txtQuantity1.Text == null || txtQuantity1.Text == "")
            {
                unitPrice1 = 0;
            }
            else
            {
                int qty1 = Convert.ToInt16(txtQuantity1.Text);
                Session["qty1"] = qty1;
                unitPrice1 = GetUnitPrice(15, qty1);
                Session["unitPrice1"] = unitPrice1;
            }
            if (txtQuantity2.Text == null || txtQuantity2.Text == "")
            {
                unitPrice2 = 0;
            }
            else
            {
                int qty2 = Convert.ToInt16(txtQuantity2.Text);
                Session["qty2"] = qty2;
                unitPrice2 = GetUnitPrice(35, qty2);
                Session["unitPrice2"] = unitPrice2;
            }
            if (txtQuantity3.Text == null || txtQuantity3.Text == "")
            {
                unitPrice3 = 0;
            }
            else
            {
                int qty3 = Convert.ToInt16(txtQuantity3.Text);
                Session["qty3"] = qty3;
                unitPrice3 = GetUnitPrice(25, qty3);
                Session["unitPrice3"] = unitPrice3;
            }
            Total_Display();
        }
        
        protected void Total_Display()
        {
            CalculateTotalPrice(unitPrice1, unitPrice2, unitPrice3);          
            lblTotal.Text = "Total Price: ";
            lblTotalPrice.Text = String.Format("{0:C}", TotalPrice);            
            lblMessage.Text = "";
            Session["Total"] = TotalPrice;           
        }

        protected void btnDelete1_Click(object sender, EventArgs e)
        {
            Session["CartItem1"] = null;           
            unitPrice1 = 0;
            ClearInputs(Page.Controls);            
            item1Panel.Visible = false;
            Total_Display();
        }

        protected void btnDelete2_Click(object sender, EventArgs e)
        {
            Session["CartItem2"] = null;
            unitPrice2 = 0;
            ClearInputs(Page.Controls);
            item2Panel.Visible = false;
            Total_Display();
        }

        protected void btnDelete3_Click(object sender, EventArgs e)
        {
            Session["CartItem3"] = null;
            unitPrice3 = 0;
            ClearInputs(Page.Controls);
            item3Panel.Visible = false;
            Total_Display();
        }

    }
}