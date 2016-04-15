/*
Module Name: Checkout
Program Name: WSC eCommerce
Author: Sarah Barreca
CoAuthor: n/a
Date: 3/28/16 - 4/15/16
Purpose: This form is used to display and finalize purchase items for customer orders, and
to gather billing and payment information. An order is created when the form is submitted and 
saved in the database.  
System Functions & Processes: 
	Page_Load: initializes page components & displays purchase items +price
	View_Checkout_Panel 1,2,3: methods to display purchased items
	Button1_Click: cancels order and clears page controls, redirects user back to catalog page
	ClearInputs: method to clear controls
	SubmitOrderBtn_Click: populates billing_information, payment_information, orders, and 
	inputs orderID into purchase_item tables in the database. Creates customer order. 	

Change Log:	4/2/16 Page creation and design completed
		4/13/16 Purchase item display completed
		4/14/16 Functions and processes completed	
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
namespace WSC
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString(); //displays today's date
            View_Checkout_Panel1(); //methods to fill purchase item panels with items selected by customer
            View_Checkout_Panel2();
            View_Checkout_Panel3();
            lblTotalPrice.Text = String.Format("Total: {0:C}", (Session["Total"])); //displays total cost of purchases
        }
        //set panel visible and populate with customer purchases
        protected void View_Checkout_Panel1()
        {
            if (Session["purchItem1"] != null) //get purchaseItemId from purchase_item table in database 
            {
                lblItemNum1.Text = Convert.ToString(Session["purchItem1"]); //purchaseItemID
                lblMediaType1.Text = Convert.ToString(Session["CartItem1"]);//purchase item name or media type
                lblMediaID1.Text = "1"; //media id 
                lblContent1.Text = Convert.ToString(Session["content1"]);//chosen content to print or engrave
                lblQTY1.Text = Convert.ToString(Session["qty1"]);//qty ordered
                lblPrice1.Text = String.Format("{0:C}",(Session["unitPrice1"]));  //unit price           
            }
            else 
                {
                    checkoutItemPanel1.Visible = false; //if item was not purchased the panel is not displayed
                }
        }
        protected void View_Checkout_Panel2() //same method to display purchase item information in panel for second item 
        {

            if (Session["purchItem2"] != null)
            {
                lblItemNum2.Text = Convert.ToString(Session["purchItem2"]);
                lblMediaType2.Text = Convert.ToString(Session["CartItem2"]);
                lblMediaID2.Text = "2";
                lblContent2.Text = Convert.ToString(Session["content2"]);
                lblQTY2.Text = Convert.ToString(Session["qty2"]);
                lblPrice2.Text = String.Format("{0:C}", (Session["unitPrice2"]));                
            }
            else
            {
                checkoutItemPanel2.Visible = false;
            }
        }
        protected void View_Checkout_Panel3() //same method to display purchase item information in panel for third item 
        {
            if (Session["purchItem3"] != null)
            {
                lblItemNum3.Text = Convert.ToString(Session["purchItem3"]);
                lblMediaType3.Text = Convert.ToString(Session["CartItem3"]);
                lblMediaID3.Text = "3";
                lblContent3.Text = Convert.ToString(Session["content3"]);
                lblQTY3.Text = Convert.ToString(Session["qty3"]);
                lblPrice3.Text = String.Format("{0:C}",(Session["unitPrice3"]));                
            }
            else
            {
                checkoutItemPanel3.Visible = false;                
            }
        }
        //cancel checkout button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["purchItem1"] = null; //sets session variables to null
            Session["purchItem2"] = null;
            Session["purchItem3"] = null; 
            ClearInputs(Page.Controls); //clears user inputs
            Response.Redirect("Catalog.aspx"); //reidrects user to catalog page
        }
        //Clears customer selections and input feilds 
        void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls) //clears all controls 
            {
                if (ctrl is TextBox) //empties textboxes
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }
        }
        //database connection string 
        string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
        protected void SubmitOrderBtn_Click(object sender, EventArgs e) //submit order button 
        {
            //billing_info table inputs
            string billFirst = txtBillFirst.Text; //billing customer first name
            string billLast = txtBillLast.Text; //billing customer last name
            string billAddress = txtBillAddress.Text; //billing address info
            string billCity = txtBillCity.Text;
            string billState = txtBillState.Text; 
            int billZip = Convert.ToInt32(txtBillZip.Text);
            string ccNum =txtCCNum.Text; //credit card information
            int ccExpDate = Convert.ToInt32(txtCCExpDate.Text);
            int billID = 0; //variable to hold the billing id that is auto incremented when new billing record is created in database
            //connection string             
            using (MySqlConnection myConn = new MySqlConnection(myConnection))
            {
                using (MySqlCommand command = new MySqlCommand()) //query to input billing information 
                {                                      
                    command.CommandText = "INSERT INTO billing_info(billFirstName, billLastName, billStreet, billCity, billState, billZip, ccNum, ccExpDate)"
                + "Values(' " + billFirst + " ', ' " + billLast + " ' , ' " + billAddress + " ' , ' " + billCity + " ', ' " + billState + " ' , ' " + billZip + " ', ' " + ccNum + " ', ' " + ccExpDate + " ')";
                    myConn.Open();//open connection 
                    command.Connection = myConn;
                    command.ExecuteNonQuery(); //execute query 
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader;  
                    command.CommandText = "SELECT billID FROM billing_info ORDER BY billID DESC LIMIT 1"; //get billing id from new record
                    myDataReader = command.ExecuteReader();
                    while (myDataReader.Read())
                    //gets purchase item id from row just entered into the database                       
                    {
                        billID = Convert.ToInt32(myDataReader["billID"].ToString()); //variable to store billing id 
                    }
                    myDataReader.Close();//close reader and connection to database
                    myConn.Close();
                }
            }


            //payment_info table inputs            
            string payType = DropDownList1.SelectedValue; //get billing type from dropdown list
            string payStatus;            
            if (payType == "Billing") //set paytype and pay status based on billing type selection 
            {
                payType = "b";     //billing          
                payStatus = "pd"; //paid 
            }
            else
            {
                payType = "d";   //delivery            
                payStatus = "br"; //balance due
            }
            int payID = 0; //variable to hold auto incremented pay id when new record is input into table 
            using (MySqlConnection myConn = new MySqlConnection(myConnection)) //connection string
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader; //reader to get pay id 

                    myConn.Open(); //open connection 
                    command.Connection = myConn;
                    command.CommandText = "INSERT INTO payment_info(payType, payStatus)" //insert query 
                + "Values(' " + payType + " ', ' " + payStatus + "')";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT payID FROM payment_info ORDER BY payID DESC LIMIT 1"; //get pay id query 
                    myDataReader = command.ExecuteReader();
                    while (myDataReader.Read())
                    //gets purchase item id from row just entered into the database                       
                    {
                        payID = Convert.ToInt32(myDataReader["payID"].ToString()); //variable to hold pay id 
                    }
                    myDataReader.Close(); //close connection 
                    myConn.Close();
                }
            }

            //orders table inputs 
            string custID = txtCustID.Text; //input customer id 
            string orderDate = Convert.ToDateTime(lblDate.Text).ToString("yyyy-MM-dd");     
            //billID from new record will be inserted into orders table 
            //payID from new record will be inserted into orders table 
            string orderStatus = "open"; //opens order
            double totalPrice = Convert.ToDouble(Session["Total"]);
            int orderID = 0; //variable to hold auto incremented order id when new order is created 
            using (MySqlConnection myConn = new MySqlConnection(myConnection))//connection string 
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader;//reader to get order id 

                    myConn.Open(); //open connection 
                    command.Connection = myConn;
                    command.CommandText = "INSERT INTO orders(custID, orderDate, billID, payID, orderStatus, totalDue)"//query to insert new record
                + "Values(' " + custID + " ', ' " + orderDate + " ' , ' " + billID + "' , ' " + payID + "', ' " + orderStatus + "', ' " + totalPrice + "')";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT orderID FROM orders ORDER BY orderID DESC LIMIT 1";//query to get order id 
                    myDataReader = command.ExecuteReader();
                    while (myDataReader.Read())
                    //gets purchase item id from row just entered into the database                       
                    {
                        orderID = Convert.ToInt32(myDataReader["orderID"].ToString()); //store order id in variable 
                    }
                    myDataReader.Close();
                    myConn.Close(); //close connection 
                }
            }
            
            //purchase_item input order id for each item
            //updates purchase item record created on shopping cart page to include order id for all items purchased 
            int purchItem1 = Convert.ToInt16(Session["purchItem1"]);
            int purchItem2 = Convert.ToInt16(Session["purchItem2"]);
            int purchItem3 = Convert.ToInt16(Session["purchItem3"]);
            if (purchItem1 > 0) //if item was purchased 
            {
              
                using (MySqlConnection myConn = new MySqlConnection(myConnection)) //connection string 
                {//query to update table with order id 
                    using (MySqlCommand myCommand = new MySqlCommand("UPDATE purchase_item  SET orderID = @orderID WHERE purchaseItemID = @purchaseItemID"))
                    {                        
                            myCommand.Parameters.AddWithValue("@orderID", orderID);
                            myCommand.Parameters.AddWithValue("@purchaseItemID", purchItem1);
                            myCommand.Connection = myConn;
                            myConn.Open();
                            myCommand.ExecuteNonQuery();//place order id into purchase item table 
                            myConn.Close();                        
                    }
                }
            }
            if (purchItem2 > 0) //same method to input order id into purchase item table for second item purchased 
            {
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand myCommand = new MySqlCommand("UPDATE purchase_item  SET orderID = @orderID WHERE purchaseItemID = @purchaseItemID"))
                    {
                        myCommand.Parameters.AddWithValue("@orderID", orderID);
                        myCommand.Parameters.AddWithValue("@purchaseItemID", purchItem2);
                        myCommand.Connection = myConn;
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                        myConn.Close();
                    }
                }
            }
            if (purchItem3 > 0) //same method to input order id into purchase item table for third item purchased 
            {
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand myCommand = new MySqlCommand("UPDATE purchase_item  SET orderID = @orderID WHERE purchaseItemID = @purchaseItemID"))
                    {
                        myCommand.Parameters.AddWithValue("@orderID", orderID);
                        myCommand.Parameters.AddWithValue("@purchaseItemID", purchItem3);
                        myCommand.Connection = myConn;
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                        myConn.Close();
                    }
                }
            }
            Response.Redirect("OrderSubmitted.aspx"); //send user to order confirmation page 
        }
    }
}