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
    public partial class EmployeeEditCustomerInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        /**
         * Bind changes from edit on grid view
         * 
         * @param object, GridViewEditEventArgs
         * @return void
         */
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEmployeeEdit.EditIndex = e.NewEditIndex;//edit index for the gridview
            GridViewEmployeeEdit.DataBind();//bind the data to the gridview
        }

        /**
         * Persist changed grid view to database
         * 
         * @param object, GridViewUpdateEventArgs
         * @var string, int, GridViewRow
         * @return void
         */
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewEmployeeEdit.Rows[e.RowIndex];//initializing row for gridview
            string custID = (row.FindControl("custID") as TextBox).Text; //custID will be equal to value from the database table
            string custFirstName = (row.FindControl("custFirstName") as TextBox).Text;//custFirstName will be equal to value from the database table
            string custLastName = (row.FindControl("custLastName") as TextBox).Text;//custLastName will be equal to value from the database table
            string custAddress = (row.FindControl("custAddress") as TextBox).Text;//custAddress will be equal to value from the database table
            string custCity = (row.FindControl("custCity") as TextBox).Text;//custCity will be equal to value from the database table
            string custState = (row.FindControl("custState") as TextBox).Text; //custState will be equal to value from the database table
            int custZip = Convert.ToInt16((row.FindControl("custZip") as TextBox).Text);//custZip will be equal to value from the database table
            string custPhone = (row.FindControl("custPhone") as TextBox).Text;//custPhone will be equal to value from the database table
            string custEmail = (row.FindControl("custEmail") as TextBox).Text;//custEmail will be equal to value from the database table
            string accessID = (row.FindControl("accessID") as TextBox).Text;//accessID will be equal to value from the database table
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();//creating SQL string
            using (MySqlConnection myConn = new MySqlConnection(myConnection))//using the SQL connection, execute the following code
            {
                using (MySqlCommand myCommand = new MySqlCommand("UPDATE customer SET custID = @custID, custFirstName = @custFirstName,  custLastName = @custLastName, custAddress = @custAddress, custCity = @custCity, custState = @custState, custZip = @custZip, custPhone = @custPhone, custEmail = @custEmail, accessID = @accessID WHERE custID = @custID"))
                //using the SQL command update the customer table to set the values to match the values reflected in the variables
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())//using the adapter, execute the following code
                    {
                        myCommand.Parameters.AddWithValue("@custID", custID);//add the value of cust ID to the parameters
                        myCommand.Parameters.AddWithValue("@custFirstName", custFirstName);//add the value of the First Name to the parameters
                        myCommand.Parameters.AddWithValue("@custLastName", custLastName);//add the value of the last name to the parameters
                        myCommand.Parameters.AddWithValue("@custAddress", custAddress);//add the value of the address to the parameters
                        myCommand.Parameters.AddWithValue("@custCity", custCity);//add the value of the city to the parameters
                        myCommand.Parameters.AddWithValue("@custState", custState);//add the value of the state to the parameters
                        myCommand.Parameters.AddWithValue("@custZip", custZip);//add the value of the zip to the parameters
                        myCommand.Parameters.AddWithValue("@custPhone", custPhone);//add the value of the phone number to the parameters
                        myCommand.Parameters.AddWithValue("@custEmail", custEmail);//add the value of the email to the parameters
                        myCommand.Parameters.AddWithValue("@accessID", accessID);//add the value of the accessID to the parameters
                        myCommand.Connection = myConn;
                        myConn.Open();//open SQL connection
                        myCommand.ExecuteNonQuery();//execute the SQL command with the above parameters
                        myConn.Close();//close the connection
                    }
                }
            }
            //reset edit index on cancel 
            GridViewEmployeeEdit.EditIndex = -1;//reflect the gridview edit
            GridViewEmployeeEdit.DataBind();//rebind the data to the gridview
        }

        /**
         * Can changes to gridview
         * 
         * @param object, EventArgs
         * @return void
         */
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            //reset edit index on cancel 
            GridViewEmployeeEdit.EditIndex = -1;//reflect the gridview edit
            GridViewEmployeeEdit.DataBind();//rebind the data to the gridview
        }

        /**
         * Delete and persist row from grid view and database
         * 
         * @param object, GridViewDeleteEventArgs
         * @var string
         * @return void
         */
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string custID = Convert.ToString(GridViewEmployeeEdit.DataKeys[e.RowIndex].Values[0]);//custID string variable equal to the gridview row value
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString(); //SQL connection
            using (MySqlConnection myConn = new MySqlConnection(myConnection)) //using the SQL connection, execute the following code
            {

                using (MySqlCommand myCommand = new MySqlCommand("DELETE FROM customer WHERE custID = @custID"))//using the SQL command, delete a row from the customer table where the custID matches the given value
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())//using the adapter, execute the following code
                    {
                        myCommand.Parameters.AddWithValue("@custID", custID);//add the value of the custID to the parameters
                        myCommand.Connection = myConn;
                        myConn.Open();//open the SQL connection
                        myCommand.ExecuteNonQuery();//execute the SQL command with the above parameters
                        myConn.Close();//close the SQL connection
                    }
                }
            }
            GridViewEmployeeEdit.DataSource = SqlDataSource1;//reflect the gridview edits
            GridViewEmployeeEdit.DataBind();//rebind data to gridview
        }

        
    }
}