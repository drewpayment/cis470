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
    public partial class frmCustomerInformationEdit : System.Web.UI.Page
    {
        /**
         * Set connection string
         * 
         * @var string
         */
        string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
       
        protected void Page_Load(object sender, EventArgs e)
        {           
        }

        /**
         * Submit changes to customer information button
         * 
         * @param object, EventArgs
         * @var string
         * @return void
         */
        protected void btnSubmitName_Click(object sender, EventArgs e)
        {      
           
            Session["custID"]= txtCustID.Text;
            string custID = Convert.ToString(Session["custID"]);
            //connection string             
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand myCommand = new MySqlCommand("SELECT * FROM customer WHERE custID = @custID"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            myCommand.Parameters.AddWithValue("@custID", custID);
                            myCommand.Connection = myConn;
                            myConn.Open();
                            sda.SelectCommand = myCommand;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridViewCustomerInformation.DataSource = dt;
                                GridViewCustomerInformation.DataBind();                                                                                               
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

        /**
         * Bind gridview changes on edit
         * 
         * @param object, GridViewEditEventArgs
         * @return void
         */
        protected void GridViewCustomerInformation_OnRowEditing(object sender, GridViewEditEventArgs e)
        {             
            GridViewCustomerInformation.EditIndex = e.NewEditIndex;
            GridViewCustomerInformation.DataBind();            
        }

        /**
         * Persist changes to database from gridview
         * 
         * @param object, GridViewUpdateEventArgs
         * @var int, TextBox, string
         * @return void
         */
        protected void GridViewCustomerInformation_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           
            int custID = int.Parse(GridViewCustomerInformation.DataKeys[e.RowIndex].Value.ToString());
            TextBox txtFirstName = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtFirstName");
            TextBox txtLastName = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtLastName");
            TextBox txtAddress = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtAddress");
            TextBox txtcustCity = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustCity");
            TextBox txtcustState = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustState");
            TextBox txtcustZip = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustZip");
            TextBox txtcustPhone = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustPhone");
            TextBox txtcustEmail = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustEmail");
                       
            string custFirstName = txtFirstName.Text;
            string custLastName = txtLastName.Text;
            string custAddress = txtAddress.Text;
            string custCity = txtcustCity.Text;
            string custState = txtcustState.Text;
            int custZip = Convert.ToInt32(txtcustZip.Text);
            int custPhone = Convert.ToInt32(txtcustPhone.Text);
            string custEmail = txtcustEmail.Text;

                string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand myCommand = new MySqlCommand("UPDATE customer SET custFirstName = @custFirstName,  custLastName = @custLastName, custAddress = @custAddress, custCity = @custCity, custState = @custState, custZip = @custZip, custPhone = @custPhone, custEmail = @custEmail WHERE custID = @custID"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            myCommand.Parameters.AddWithValue("@custID", custID);
                            myCommand.Parameters.AddWithValue("@custFirstName", custFirstName);
                            myCommand.Parameters.AddWithValue("@custLastName", custLastName);
                            myCommand.Parameters.AddWithValue("@custAddress", custAddress);
                            myCommand.Parameters.AddWithValue("@custCity", custCity);
                            myCommand.Parameters.AddWithValue("@custState", custState);
                            myCommand.Parameters.AddWithValue("@custZip", custZip);
                            myCommand.Parameters.AddWithValue("@custPhone", custPhone);
                            myCommand.Parameters.AddWithValue("@custEmail", custEmail);
                            myCommand.Connection = myConn;
                            myConn.Open();
                            sda.SelectCommand = myCommand;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridViewCustomerInformation.DataSource = dt;
                                GridViewCustomerInformation.DataBind();                            
                            }
                            myConn.Close();
                            GridViewCustomerInformation.EditIndex = -1;                          
                        }
                    }
                }                         
        }

        /**
         * Cancel changes to gridview
         * 
         * @param object, GridViewCancelEditEventArgs
         * @return void
         */
        protected void GridViewCustomerInformation_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //reset edit index on cancel 
            GridViewCustomerInformation.EditIndex = -1;
            GridViewCustomerInformation.DataBind(); 
        }

        /**
         * Gridview button event
         * 
         * @param object, EventArgs
         * @var string
         * @return void
         */
        protected void btnViewOrders_Click(object sender, EventArgs e)
        {

            string custID = Convert.ToString(Session["custID"]);//get customer id
            //connection string             
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand myCommand = new MySqlCommand("SELECT * FROM orders WHERE custID = @custID"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            myCommand.Parameters.AddWithValue("@custID", custID);
                            myCommand.Connection = myConn;
                            myConn.Open();
                            sda.SelectCommand = myCommand;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                GridViewOrderHistory.DataSource = dt;
                                GridViewOrderHistory.DataBind();
                                                          
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

        /**
         * Save changes to grid view
         * 
         * @param object, EventArgs
         * @return void
         */
        protected void GridViewCustomerInformation_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewCustomerInformation.DataBind(); 
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }       
    }
}
