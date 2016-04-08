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
        protected void Page_Load(object sender, EventArgs e)
        {
        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCustomerInformation.EditIndex = e.NewEditIndex;
            GridViewCustomerInformation.DataBind();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridViewCustomerInformation.Rows[e.RowIndex];
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
            GridViewCustomerInformation.EditIndex = -1;
            GridViewCustomerInformation.DataBind();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            //reset edit index on cancel 
            GridViewCustomerInformation.EditIndex = -1;
            GridViewCustomerInformation.DataBind();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string custID = Convert.ToString(GridViewCustomerInformation.DataKeys[e.RowIndex].Values[0]);
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
            GridViewCustomerInformation.DataSource = SqlDataSource1;
            GridViewCustomerInformation.DataBind();
        }


    }
}