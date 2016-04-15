using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WSC.BusinessLayer;
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
            lblDate.Text = DateTime.Now.ToShortDateString();
            View_Checkout_Panel1();
            View_Checkout_Panel2();
            View_Checkout_Panel3();
            lblTotalPrice.Text = String.Format("Total: {0:C}", (Session["Total"]));
        }

        protected void View_Checkout_Panel1()
        {
            if (Session["purchItem1"] != null)
            {
                lblItemNum1.Text = Convert.ToString(Session["purchItem1"]);
                lblMediaType1.Text = Convert.ToString(Session["CartItem1"]);
                lblMediaID1.Text = "1";
                lblContent1.Text = Convert.ToString(Session["content1"]);
                lblQTY1.Text = Convert.ToString(Session["qty1"]);
                lblPrice1.Text = String.Format("{0:C}",(Session["unitPrice1"]));                
            }
            else 
                {
                    checkoutItemPanel1.Visible = false;
                }
        }
        protected void View_Checkout_Panel2()
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
        protected void View_Checkout_Panel3()
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
            Session["purchItem1"] = null;
            Session["purchItem2"] = null;
            Session["purchItem3"] = null; 
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
        string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
        protected void SubmitOrderBtn_Click(object sender, EventArgs e)
        {
            //billing_info table inputs
            string billFirst = txtBillFirst.Text;
            string billLast = txtBillLast.Text;
            string billAddress = txtBillAddress.Text;
            string billCity = txtBillCity.Text;
            string billState = txtBillState.Text; 
            int billZip = Convert.ToInt32(txtBillZip.Text);
            string ccNum =txtCCNum.Text;
            int ccExpDate = Convert.ToInt32(txtCCExpDate.Text);
            int billID = 0; 
            //connection string             
            using (MySqlConnection myConn = new MySqlConnection(myConnection))
            {
                using (MySqlCommand command = new MySqlCommand())
                {                                      
                    command.CommandText = "INSERT INTO billing_info(billFirstName, billLastName, billStreet, billCity, billState, billZip, ccNum, ccExpDate)"
                + "Values(' " + billFirst + " ', ' " + billLast + " ' , ' " + billAddress + " ' , ' " + billCity + " ', ' " + billState + " ' , ' " + billZip + " ', ' " + ccNum + " ', ' " + ccExpDate + " ')";
                    myConn.Open();
                    command.Connection = myConn;
                    command.ExecuteNonQuery();
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader;  
                    command.CommandText = "SELECT billID FROM billing_info ORDER BY billID DESC LIMIT 1";
                    myDataReader = command.ExecuteReader();
                    while (myDataReader.Read())
                    //gets purchase item id from row just entered into the database                       
                    {
                        billID = Convert.ToInt32(myDataReader["billID"].ToString());
                    }
                    myDataReader.Close();
                    myConn.Close();
                }
            }


            //payment_info table inputs            
            string payType = DropDownList1.SelectedValue;
            string payStatus;            
            if (payType == "Billing")
            {
                payType = "b";                 
                payStatus = "pd";
            }
            else
            {
                payType = "d";               
                payStatus = "br";
            }
            int payID = 0; 
            using (MySqlConnection myConn = new MySqlConnection(myConnection))
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader;

                    myConn.Open();
                    command.Connection = myConn;
                    command.CommandText = "INSERT INTO payment_info(payType, payStatus)"
                + "Values(' " + payType + " ', ' " + payStatus + "')";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT payID FROM payment_info ORDER BY payID DESC LIMIT 1";
                    myDataReader = command.ExecuteReader();
                    while (myDataReader.Read())
                    //gets purchase item id from row just entered into the database                       
                    {
                        payID = Convert.ToInt32(myDataReader["payID"].ToString());
                    }
                    myDataReader.Close();
                    myConn.Close();
                }
            }

            //orders table inputs 
            string custID = txtCustID.Text;
            string orderDate = Convert.ToDateTime(lblDate.Text).ToString("yyyy-MM-dd");     
            //billID
            //payID
            string orderStatus = "open";
            double totalPrice = Convert.ToDouble(Session["Total"]);
            int orderID = 0; 
            using (MySqlConnection myConn = new MySqlConnection(myConnection))
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    MySql.Data.MySqlClient.MySqlDataReader myDataReader;

                    myConn.Open();
                    command.Connection = myConn;
                    command.CommandText = "INSERT INTO orders(custID, orderDate, billID, payID, orderStatus, totalDue)"
                + "Values(' " + custID + " ', ' " + orderDate + " ' , ' " + billID + "' , ' " + payID + "', ' " + orderStatus + "', ' " + totalPrice + "')";
                    command.ExecuteNonQuery();
                    command.CommandText = "SELECT orderID FROM orders ORDER BY orderID DESC LIMIT 1";
                    myDataReader = command.ExecuteReader();
                    while (myDataReader.Read())
                    //gets purchase item id from row just entered into the database                       
                    {
                        orderID = Convert.ToInt32(myDataReader["orderID"].ToString());
                    }
                    myDataReader.Close();
                    myConn.Close();
                }
            }
            
            //purchase_item input order id for each item
            int purchItem1 = Convert.ToInt16(Session["purchItem1"]);
            int purchItem2 = Convert.ToInt16(Session["purchItem2"]);
            int purchItem3 = Convert.ToInt16(Session["purchItem3"]);
            if (purchItem1 > 0)
            {
              
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand myCommand = new MySqlCommand("UPDATE purchase_item  SET orderID = @orderID WHERE purchaseItemID = @purchaseItemID"))
                    {                        
                            myCommand.Parameters.AddWithValue("@orderID", orderID);
                            myCommand.Parameters.AddWithValue("@purchaseItemID", purchItem1);
                            myCommand.Connection = myConn;
                            myConn.Open();
                            myCommand.ExecuteNonQuery();
                            myConn.Close();                        
                    }
                }
            }
            if (purchItem2 > 0)
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
            if (purchItem3 > 0)
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
            Response.Redirect("OrderSubmitted.aspx");
        }
    }
}