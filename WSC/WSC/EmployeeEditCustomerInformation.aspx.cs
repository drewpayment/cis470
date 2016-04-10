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
            GridViewEmployeeEdit.EditIndex = e.NewEditIndex;
            GridViewEmployeeEdit.DataBind();
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
            GridViewRow row = GridViewEmployeeEdit.Rows[e.RowIndex];
            string custID = (row.FindControl("custID") as TextBox).Text;
            string custFirstName = (row.FindControl("custFirstName") as TextBox).Text;
            string custLastName = (row.FindControl("custLastName") as TextBox).Text;
            string custAddress = (row.FindControl("custAddress") as TextBox).Text;
            string custCity = (row.FindControl("custCity") as TextBox).Text;
            string custState = (row.FindControl("custState") as TextBox).Text; 
            int custZip = Convert.ToInt16((row.FindControl("custZip") as TextBox).Text);
            string custPhone = (row.FindControl("custPhone") as TextBox).Text;
            string custEmail = (row.FindControl("custEmail") as TextBox).Text;
            string accessID = (row.FindControl("accessID") as TextBox).Text;
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            using (MySqlConnection myConn = new MySqlConnection(myConnection))
            {
                using (MySqlCommand myCommand = new MySqlCommand("UPDATE customer SET custID = @custID, custFirstName = @custFirstName,  custLastName = @custLastName, custAddress = @custAddress, custCity = @custCity, custState = @custState, custZip = @custZip, custPhone = @custPhone, custEmail = @custEmail, accessID = @accessID WHERE custID = @custID"))
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
                        myCommand.Parameters.AddWithValue("@accessID", accessID);
                        myCommand.Connection = myConn;
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                        myConn.Close();
                    }
                }
            }
            //reset edit index on cancel 
            GridViewEmployeeEdit.EditIndex = -1;
            GridViewEmployeeEdit.DataBind();
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
            GridViewEmployeeEdit.EditIndex = -1;
            GridViewEmployeeEdit.DataBind();
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
            string custID = Convert.ToString(GridViewEmployeeEdit.DataKeys[e.RowIndex].Values[0]);
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            using (MySqlConnection myConn = new MySqlConnection(myConnection))
            {

                using (MySqlCommand myCommand = new MySqlCommand("DELETE FROM customer WHERE custID = @custID"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        myCommand.Parameters.AddWithValue("@custID", custID);
                        myCommand.Connection = myConn;
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                        myConn.Close();
                    }
                }
            }
            GridViewEmployeeEdit.DataSource = SqlDataSource1;
            GridViewEmployeeEdit.DataBind();
        }

        
    }
}