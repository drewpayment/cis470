using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{
    public partial class EmployeeReviewOrder : System.Web.UI.Page
    {
        /**
         * Set MySql connection string
         * 
         * @var MySqlConnection
         */
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString);//SQL connection string

        protected void Page_Load(object sender, EventArgs e)
        { 
        }

        /**
         * Find order button click event code
         * 
         * @param object, EventArgs
         * @var string
         * @return void
         */
        protected void btnFindOrder_Click(object sender, EventArgs e)//function for clicking the find order button
        {
            string orderID = txtGetOrder.Text;//orderID  equal to the value in the get order text box
            //connection string             
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();//SQL connection string
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand myCommand = new MySqlCommand("SELECT * FROM orders WHERE orderID = @orderID"))//using the SQL command select everything from orders table where the orderId matches the given value
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            myCommand.Parameters.AddWithValue("@orderID", orderID);//adding the value of the order ID to the parameters
                            myCommand.Connection = myConn;
                            myConn.Open();//opening the SQL connection
                            sda.SelectCommand = myCommand;//creating SQL command
                            using (DataTable dt = new DataTable())//using the data table, execute the following code
                            {
                                sda.Fill(dt);//fill the data table using the SQL adapter
                                GridViewReviewOrders.DataSource = dt;//making the data source for the gridview equal to the data table
                                GridViewReviewOrders.DataBind();//rebind the data to the gridview
                            }
                            myConn.Close();//close the SQL connection
                        }
                    }
                    using (MySqlCommand myCommand = new MySqlCommand("SELECT * FROM purchase_item WHERE orderID = @orderID"))//using the SQL command select everything from the purchase_item table where orderID matches the given value
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            myCommand.Parameters.AddWithValue("@orderID", orderID);//adding the value of the order ID to the parameters
                            myCommand.Connection = myConn;
                            myConn.Open();//opening the SQL connection
                            sda.SelectCommand = myCommand;//creating SQL command
                            using (DataTable dt = new DataTable()) //using the data table, execute the following code
                            {
                                sda.Fill(dt);//fill the data table using the SQL adapter
                                GridViewReviewPurch.DataSource = dt;//making the data source for the gridview equal to the data table
                                GridViewReviewPurch.DataBind();//rebind the data to the gridview
                            }
                            myConn.Close();//close the SQL connection
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;//catch an execeptions that occur
            }  
        }

        protected void GridViewReviewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}