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
    public partial class EditCatalog : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /**
         * Edit catalog submit button
         * 
         * @param object, EventArgs
         * @var string, decimal, int
         * @return void
         */
        protected void Button1_Click(object sender, EventArgs e)
        {

            string myMediaID = txtEditItemID.Text;//grabbing text from the Edit Item ID text box and storing in a string variable
            string myMediaType = txtEditItemType.Text; //grabbing text from the Edit Item Type text box and storing in a string variable
            decimal myPrice = Convert.ToDecimal(txtEditPrice.Text);////grabbing the numerical value from a text box, converting it to a decimal and then storing in a decimal string
            int myQuantity = Convert.ToInt16(txtQty.Text);//grabbing the numerical value from the text box and converting it to an int before storing in a int variable
           
            //connection string 
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            MySqlConnection myConn = new MySqlConnection(myConnection);//new SQL connection
            MySqlCommand myCommand; //new SQL command
            myConn.Open();//opening the SQL connection
            try
            {
                myCommand = myConn.CreateCommand();//creating a new instance of a command for SQL
                myCommand.CommandText = "INSERT INTO catalog (mediaID, mediaType, price, qtyAvailable)"//inserting variables into the SQL catalog table
                + "VALUES (@myMediaID,@myMediaType,@myPrice,@myQuantity)";
                myCommand.Parameters.AddWithValue("@myMediaID", myMediaID);//parameters for the SQL table insert
                myCommand.Parameters.AddWithValue("@myMediaType", myMediaType);//parameters for the SQL table insert
                myCommand.Parameters.AddWithValue("@myPrice", myPrice);//parameters for the SQL table insert
                myCommand.Parameters.AddWithValue("@myQuantity", myQuantity);//parameters for the SQL table insert
                myCommand.ExecuteNonQuery();//executing the SQL command 
            }
            catch (Exception)
            {
                throw; //catching any exceptions in the event that the SQL command gives an error
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();//when everything is complete close the SQL connection
                }
            }
            GridView1.DataBind();//bind data to the gridview
            ClearInputs(Page.Controls);//clear the inputs
            
        }
        void ClearInputs(ControlCollection ctrls)//function for clearing the inputs areas of the webform
        {
            foreach (Control ctrl in ctrls)//for each control that is a text box, empty the string
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }
        }

       

        //Get row to be updated
        
        /**
         * Bind grid data on editing
         * 
         * @param object, GridViewEditEventArgs
         * @return void
         */
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; //edit the gridview with the new content
            GridView1.DataBind();//bind the data of the gridview
        }

        /**
         * Persist updated gridview to database
         * 
         * @param object, GridViewUpdateEventArgs
         * @var string, decimal, int
         * @return void
         */
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];//setting up rows for the gridview
            string mediaID = (row.FindControl("mediaID") as TextBox).Text; //mediaID will be equal to the data found in the mediaID row
            string mediaType = (row.FindControl("mediaType") as TextBox).Text;//mediaType will be equal to the data found in the mediaType row
            decimal price = Convert.ToDecimal((row.FindControl("price") as TextBox).Text);//price will be equal to the data found in the price row
            int qtyAvailable = Convert.ToInt16((row.FindControl("qtyAvailable") as TextBox).Text);//qtyAvailable will be equal to the qtyAvailable row
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();//SQL String setup
            using (MySqlConnection myConn = new MySqlConnection(myConnection))//using the SQL connection, execute the following lines 
            {
                using (MySqlCommand myCommand = new MySqlCommand("UPDATE catalog SET mediaType = @mediaType, price = @price, qtyAvailable = @qtyAvailable WHERE mediaID = @mediaID"))
                //using the SQL command, update the catalog table to reflect the new values
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter()) //using the SQL adapter, execute the following code
                    {
                        myCommand.Parameters.AddWithValue("@MediaID", mediaID);//add the values using the media ID parameters
                        myCommand.Parameters.AddWithValue("@MediaType", mediaType);//add the values using the mediaType parameters
                        myCommand.Parameters.AddWithValue("@price", price);//add the values using the price parameters
                        myCommand.Parameters.AddWithValue("@qtyAvailable", qtyAvailable);//add the values using the qtyAvailable parameters
                        myCommand.Connection = myConn;
                        myConn.Open();//open the SQL connection
                        myCommand.ExecuteNonQuery();//execute the SQL statements
                        myConn.Close();//close the connection
                    }
                }
            }
            //reset edit index on cancel 
            GridView1.EditIndex = -1; //reset the gridview
            GridView1.DataBind();//bind the data to the gridview
        }

        /**
         * Cancel edit of gridview
         * 
         * @param object, EventArgs
         * @return void
         */
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            //reset edit index on cancel 
            GridView1.EditIndex = -1; //clear the data from the gridview
            GridView1.DataBind();//rebind the gridview
        }

        /**
         * Delete row from gridview and persist to database
         * 
         * @param object, GridViewDeleteEventArgs
         * @var string
         * @return void
         */
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string mediaID = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values[0]);
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            using (MySqlConnection myConn = new MySqlConnection(myConnection)) 
            {

                using (MySqlCommand myCommand = new MySqlCommand("DELETE FROM catalog WHERE mediaID = @mediaID"))//using the SQL command, delete the value from the catalog where the media ID matches the input one
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())//using the adapter, execute the following code
                    {
                        myCommand.Parameters.AddWithValue("@mediaID", mediaID);//add the values 
                        myCommand.Connection = myConn;
                        myConn.Open();//open the SQL connection
                        myCommand.ExecuteNonQuery();//execute the SQL commands
                        myConn.Close();//close the SQL connection
                    }
                }
            }
            GridView1.DataBind();//rebind the gridview
        }
    }
}
       

