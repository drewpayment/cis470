/*
Module Name: Shopping Cart 
Program Name: WSC eCommerce
Author: Sarah Barreca
CoAuthor: n/a
Date: 3/28/16 - 4/15/16
Purpose: This form is used to display products customers have placed in their shopping cart and to allow them 
to make additional selections and edits before proceeding to checkout. Creates purchase item record in database.  
System Functions & Processes: 
	Page_Load: initializes page components & displays links, hides components if cart is empty 	
	Checkout_Click: creates record for each purchase item added to the shopping cart and saves session variables for 
	use in checkout page. Redirects user to checkout page. 
	View_Panel: checks to see if items have been added into the shopping cart. 
	GetUnitPrice: method to multiply qty by unit price for each item in cart
	CalculateTotalPrice: method to calculate total cost
	CancelButton_Click: clears input controls, resets session variables to null, and redirects user to catalog page. 
	ClearInputs: method to clear input controls on page. 
	btnUpdate1_Click: method to get unit price for each item in cart 
	Total_Display: method to display total cost 
	btnDelete 1,2,3; methods to delete item from cart and reset variable values. 
 * 
Change Log:	4/2/16 Page creation and design completed 
		4/11/12 Completed cart item added functions to shopping cart  
		4/12/12 Completed all functions and procedures. 			
	
*/
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
        //connection string 
        string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            View_Panel();//display panels for items added to the shopping cart 
            if (cartitems == true) //displays instructions or message to user depending on if the cart is empty 
            {
                lblMessage.Text = "Enter desired quantity and select Update to calculate price.";
            }
            else
            {
                btnUpdate1.Visible = false; //hids control if cart is empty 
                lblMessage.Text = "There are no items in your shopping cart.";
            }

        }
        //variables for purchase item ids 
        string purchItemID1 = null;
        string purchItemID2 = null;
        string purchItemID3 = null;
        protected void Checkout_Click(object sender, EventArgs e)
        {
            if (Session["CartItem1"] != null) //checks to see if this item was added to shopping cart
            {
                int mediaID = Convert.ToInt16(lblitemNum1.Text); //gets media id for item 
                string jobType = DropDownList1.SelectedValue; //gets print or engraving selection from user 
                int jobID; //job type based on print/engrave selection 
                int specialistID; //specialist assigned to complete print/engraving 
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
                int purchQty = Convert.ToInt16(txtQuantity1.Text); //gets qty desired from user 
                decimal purchItemCost = 15; //item cost 
                string contentDesc = txtContent1.Text; //content ordered 
                Session["content1"] = contentDesc; //sets session variable for content ordered 
                //query to input record into database 
                string query1 = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";

                //connection string            
                string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand command = new MySqlCommand(query1, myConn))
                    {
                        MySql.Data.MySqlClient.MySqlDataReader myDataReader; //sets reader to get purchase item id from newly entered record

                        myConn.Open();//open connection 
                        //query to input new record 
                        command.CommandText = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')"; 
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT purchaseItemID FROM purchase_item ORDER BY purchaseItemID DESC LIMIT 1"; //query to get purchase item id 
                        myDataReader = command.ExecuteReader(); //execute query 
                         while (myDataReader.Read())
                        //gets purchase item id from row just entered into the database                       
                        {
                            purchItemID1 = myDataReader["purchaseItemID"].ToString(); //read purchase item id and save to variable 
                        }
                        myDataReader.Close(); //close connection 
                        myConn.Close();
                    }
                }
            }
            
            Session["purchItem1"] = purchItemID1; //creats session variable for purchase item id 
            //repeat steps above for second purchase item 
            if (Session["CartItem2"] != null)//checks for item 
            {
                int mediaID = Convert.ToInt16(lblitemNum2.Text); //sets item data 
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
                Session["content2"] = contentDesc; //content for second item session variable 
                //query to insert new record 
                string query2 = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";

                //connection string            
                string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader;
                    using (MySqlCommand command = new MySqlCommand(query2, myConn))
                    {
                        myConn.Open(); //open connection and insert new record 
                        command.CommandText = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT purchaseItemID FROM purchase_item ORDER BY purchaseItemID DESC LIMIT 1"; //query to get purchase item id 
                        myDataReader = command.ExecuteReader();//read from database newly inserted record 
                        while (myDataReader.Read())
                        //gets purchase item id from row just entered into the database                       
                        {
                            purchItemID2 = myDataReader["purchaseItemID"].ToString(); //save purchase item id to variable 
                        }
                        myDataReader.Close(); //close connection 
                        myConn.Close();
                    }
                }
            }
            Session["purchItem2"] = purchItemID2; //save second id to session variable 
            if (Session["CartItem3"] != null) //check for third item 
            {
                int mediaID = Convert.ToInt16(lblitemNum3.Text);//set data for thrid item 
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
                Session["content3"] = contentDesc; //set session variable for third content ordered 
                  //query to insert new record   
                string query3 = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";

                //connection string            
                string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader;
                    using (MySqlCommand command = new MySqlCommand(query3, myConn))
                    {
                        myConn.Open(); //open and insert new record 
                        command.CommandText = "INSERT INTO purchase_item(specialistID, jobID, mediaID, purchQty, purchItemCost, contentDescription)"
                    + "Values(' " + specialistID + " ', ' " + jobID + " ' , ' " + mediaID + "' , ' " + purchQty + "', ' " + purchItemCost + " ' , ' " + contentDesc + " ')";
                        command.ExecuteNonQuery();
                        command.CommandText = "SELECT purchaseItemID FROM purchase_item ORDER BY purchaseItemID DESC LIMIT 1"; //get purchase item id 
                        myDataReader = command.ExecuteReader(); //execute command 
                        while (myDataReader.Read())
                        //gets purchase item id from row just entered into the database                       
                        {
                            purchItemID3 = myDataReader["purchaseItemID"].ToString(); //read purchase item id and save to variable 
                        }
                        myDataReader.Close(); //close connection 
                        myConn.Close();
                    }
                } Session["purchItem3"] = purchItemID3;
            } Response.Redirect("Checkout.aspx"); //redirect user to checkout page 

           
        }
        //populate shoppnig cart with customer selections and set item price
        public bool cartitems = false; //check to see if cart is empty 

        protected void View_Panel() //display panel if item is added to cart 
        {
            if (Session["CartItem1"] != null) //checks for item 1 
            {
                lblItem1.Text = Convert.ToString(Session["CartItem1"]); //displays item 1 information 
                lblitemNum1.Text = "1";                
                lblProductDesc1.Text = "Shirt XYZ (White) - Lg";
                item1Panel.Visible = true;
                cartitems = true;
            }
            else
            {
                item1Panel.Visible = false; //hids panel if item not in cart 
            }

            if (Session["CartItem2"] != null) //checks for item 2 
            {
                lblItem2.Text = Convert.ToString(Session["CartItem2"]); //displays item 2 information 
                lblitemNum2.Text = "2";
                lblProductDesc2.Text = "Round Plaque w/ Banner (Espresso)";
                item2Panel.Visible = true;
                cartitems = true;
            }
            else
            {
                item2Panel.Visible = false; //hids panel if item not in cart 
            }

            if (Session["CartItem3"] != null) //checks for third item 
            {
                lblItem3.Text = Convert.ToString(Session["CartItem3"]); //displays item 3 information 
                lblitemNum3.Text = "3";
                lblProductDesc3.Text = "Silver Cup w/ Pine Base (Cherry) -Med";
                item3Panel.Visible = true;
                cartitems = true;
            }
            else
            {
                item3Panel.Visible = false; //hids panel if item not in cart 
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
            Session["CartItem1"] = null; //reset session variables 
            Session["CartItem2"] = null;
            Session["CartItem3"] = null;
            TotalPrice = 0;
            ClearInputs(Page.Controls); //clear form 
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
        public decimal unitPrice1; //gets unit price of each item 
        public decimal unitPrice2;
        public decimal unitPrice3;
        protected void btnUpdate1_Click(object sender, EventArgs e)
        {
            if (txtQuantity1.Text == null || txtQuantity1.Text == "") //if qty entered get updated price 
            {
                unitPrice1 = 0;
            }
            else
            {
                int qty1 = Convert.ToInt16(txtQuantity1.Text);
                Session["qty1"] = qty1; //set session variables for checkout page 
                unitPrice1 = GetUnitPrice(15, qty1);
                Session["unitPrice1"] = unitPrice1;
            }
            if (txtQuantity2.Text == null || txtQuantity2.Text == "") //check qty of second item 
            {
                unitPrice2 = 0;
            }
            else
            {
                int qty2 = Convert.ToInt16(txtQuantity2.Text);
                Session["qty2"] = qty2;
                unitPrice2 = GetUnitPrice(35, qty2);
                Session["unitPrice2"] = unitPrice2; //set session variables for checkout page 
            }
            if (txtQuantity3.Text == null || txtQuantity3.Text == "") //check third qty 
            {
                unitPrice3 = 0;
            }
            else
            {
                int qty3 = Convert.ToInt16(txtQuantity3.Text);
                Session["qty3"] = qty3; //set session variable for checkout page 
                unitPrice3 = GetUnitPrice(25, qty3);
                Session["unitPrice3"] = unitPrice3;
            }
            Total_Display();
        }
        
        protected void Total_Display() //displays total cost based on updated unitprices to include qty requested by customer 
        {
            CalculateTotalPrice(unitPrice1, unitPrice2, unitPrice3);          
            lblTotal.Text = "Total Price: ";
            lblTotalPrice.Text = String.Format("{0:C}", TotalPrice);   //display money format         
            lblMessage.Text = "";
            Session["Total"] = TotalPrice;       //set session variable for checkout page     
        }

        protected void btnDelete1_Click(object sender, EventArgs e) //method to delete item from cart 
        {
            Session["CartItem1"] = null;           //reset variables 
            unitPrice1 = 0;
            ClearInputs(Page.Controls);            //clear form 
            item1Panel.Visible = false;
            Total_Display();
        }

        protected void btnDelete2_Click(object sender, EventArgs e) //method to delete item from cart
        {
            Session["CartItem2"] = null; //reset variables 
            unitPrice2 = 0;
            ClearInputs(Page.Controls);//clear form 
            item2Panel.Visible = false;
            Total_Display();
        }

        protected void btnDelete3_Click(object sender, EventArgs e)//method to delete item from cart 
        {
            Session["CartItem3"] = null;//reset variables
            unitPrice3 = 0;
            ClearInputs(Page.Controls); //clear form 
            item3Panel.Visible = false;
            Total_Display();
        }

    }
}