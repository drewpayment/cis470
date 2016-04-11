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
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString);

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
        protected void btnFindOrder_Click(object sender, EventArgs e)
        {
            string orderID = txtGetOrder.Text;
            //connection string             
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand myCommand = new MySqlCommand("SELECT orders.*, purchase_item.* FROM orders JOIN purchase_item WHERE orders.orderID = @orderID AND purchase_item.orderID = @orderID"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            myCommand.Parameters.AddWithValue("@orderID", orderID);
                            myCommand.Connection = myConn;
                            myConn.Open();
                            sda.SelectCommand = myCommand;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridViewReviewOrders.DataSource = dt;
                                GridViewReviewOrders.DataBind();
                            }
                            myConn.Close();
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }  
        }

        protected void GridViewReviewOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}