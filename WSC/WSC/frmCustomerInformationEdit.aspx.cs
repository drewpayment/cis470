/*CoAuthor: Rebecca Kolb
Date: 3/28/16 - 4/15/16
Purpose: This form is used by the customers of WSC to review and update their personal information and to 
veiw their order history. 
System Functions & Processes: 
	Page_Load: initializes page components & displays links
	btnSubmitName_Click: takes customer id from user and searches customer database for matching records. 
	GridViewCustomerInformation_OnRowEditing: event handler for gridview on row editing
	GridViewCustomerInformaiton_OnRowUpdating: event handler for updating selected record in grid view. 
	GridViewCustomerInformation_OnRowCancelingEdit: event handler for canceling edits to row. 
	btnViewOrders: searches database for orders placed by customer with matching customer id 	

Change Log:	4/2/16 Page creation and design
		4/5/16 Work on processes  and dataset 
		4/9/16 Functions and processes completed 	
	
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
    public partial class frmCustomerInformationEdit : System.Web.UI.Page
    {
        /**
         * Set connection string
         * 
         * @var string
         */
        //connection string 
        string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GridViewCustomerInformation.DataBind(); //bind data to the gridview 
            }
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
                    using (MySqlCommand myCommand = new MySqlCommand("SELECT * FROM customer WHERE custID = @custID"))//query to select customer from database  with matching id 
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            myCommand.Parameters.AddWithValue("@custID", custID);//parameter for user input customer id 
                            myCommand.Connection = myConn;
                            myConn.Open();//open connection 
                            sda.SelectCommand = myCommand;//execute command
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);//populate gridview with matching record 
                                GridViewCustomerInformation.DataSource = dt;                              
                                GridViewCustomerInformation.DataBind();//bind data to gridview                                                                              
                            }                           
                            myConn.Close();//close connection                  
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
            GridViewCustomerInformation.EditIndex = e.NewEditIndex; //eventhandler for gridview sets edit index 
            Page_Load(null, null);//ensure data is not bound on page back from user clicking edit link in grid view 

           // GridViewCustomerInformation.DataBind();            
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
           
            int custID = int.Parse(GridViewCustomerInformation.DataKeys[e.RowIndex].Value.ToString()); //gets cust id 
            TextBox txtFirstName = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtFirstName");//displays textboxes for user input to edit fields 
            TextBox txtLastName = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtLastName");
            TextBox txtAddress = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtAddress");
            TextBox txtcustCity = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustCity");
            TextBox txtcustState = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustState");
            TextBox txtcustZip = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustZip");
            TextBox txtcustPhone = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustPhone");
            TextBox txtcustEmail = (TextBox)GridViewCustomerInformation.Rows[e.RowIndex].FindControl("txtcustEmail");
                       
            string custFirstName = txtFirstName.Text; //gets user input/changes from edit textboxes in gridview
            string custLastName = txtLastName.Text;
            string custAddress = txtAddress.Text;
            string custCity = txtcustCity.Text;
            string custState = txtcustState.Text;
            int custZip = Convert.ToInt32(txtcustZip.Text);
            int custPhone = Convert.ToInt32(txtcustPhone.Text);
            string custEmail = txtcustEmail.Text;

                string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();//connection string 
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {   //query to update record with new inforamtion 
                    using (MySqlCommand myCommand = new MySqlCommand("UPDATE customer SET custFirstName = @custFirstName,  custLastName = @custLastName, custAddress = @custAddress, custCity = @custCity, custState = @custState, custZip = @custZip, custPhone = @custPhone, custEmail = @custEmail WHERE custID = @custID"))
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter()) //passes new user input data to database
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
                            myConn.Open();//open conneciton 
                            sda.SelectCommand = myCommand;//execute query 
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt); //populate gridview with new information 
                                GridViewCustomerInformation.DataSource = dt;
                                GridViewCustomerInformation.DataBind(); //binds data to gridview 
                                                       
                            }
                            myConn.Close(); //close connection 
                            GridViewCustomerInformation.EditIndex = -1; //reset edit index 
                        }
                    }
                }
                using (MySqlConnection myConn = new MySqlConnection(myConnection)) //second connection string 
                    {
                        using (MySqlCommand myCommand = new MySqlCommand("SELECT * FROM customer WHERE custID = @custID"))//displays new informatio for updated record 
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
            Page_Load(null, null); //ensures data is not bound to grid view at postback

            //GridViewCustomerInformation.DataBind(); 
        }

        /**
         * Gridview button event
         * 
         * @param object, EventArgs
         * @var string
         * @return void
         */
        protected void btnViewOrders_Click(object sender, EventArgs e) //method to get order history for customers with matching id 
        {

            string custID = Convert.ToString(Session["custID"]);//get customer id
            //connection string             
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            try
            {
                using (MySqlConnection myConn = new MySqlConnection(myConnection))
                {
                    using (MySqlCommand myCommand = new MySqlCommand("SELECT * FROM orders WHERE custID = @custID"))//query to get order history
                    {
                        using (MySqlDataAdapter sda = new MySqlDataAdapter())
                        {
                            myCommand.Parameters.AddWithValue("@custID", custID);//pass customer id 
                            myCommand.Connection = myConn;
                            myConn.Open();//open connection 
                            sda.SelectCommand = myCommand;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);//populates griddata with order history records
                                GridViewOrderHistory.DataSource = dt;
                                GridViewOrderHistory.DataBind();
                                                          
                            }
                            myConn.Close(); //close connection 
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }   
        }    
                     
    }
}
