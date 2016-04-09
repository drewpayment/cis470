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

        protected void Button1_Click(object sender, EventArgs e)
        {

            string myMediaID = txtEditItemID.Text;
            string myMediaType = txtEditItemType.Text;
            decimal myPrice = Convert.ToDecimal(txtEditPrice.Text);
            int myQuantity = Convert.ToInt16(txtQty.Text);
           
            //connection string 
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand myCommand;
            myConn.Open();
            try
            {
                myCommand = myConn.CreateCommand();
                myCommand.CommandText = "INSERT INTO catalog (mediaID, mediaType, price, qtyAvailable)"
                + "VALUES (@myMediaID,@myMediaType,@myPrice,@myQuantity)";
                myCommand.Parameters.AddWithValue("@myMediaID", myMediaID);
                myCommand.Parameters.AddWithValue("@myMediaType", myMediaType);
                myCommand.Parameters.AddWithValue("@myPrice", myPrice);
                myCommand.Parameters.AddWithValue("@myQuantity", myQuantity);
                myCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            GridView1.DataBind();
            ClearInputs(Page.Controls);
            
        }
        void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }
        }

       

        //Get row to be updated
       
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            GridView1.DataBind();
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            string mediaID = (row.FindControl("mediaID") as TextBox).Text;
            string mediaType = (row.FindControl("mediaType") as TextBox).Text;
            decimal price = Convert.ToDecimal((row.FindControl("price") as TextBox).Text);
            int qtyAvailable = Convert.ToInt16((row.FindControl("qtyAvailable") as TextBox).Text);
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            using (MySqlConnection myConn = new MySqlConnection(myConnection)) 
            {
                using (MySqlCommand myCommand = new MySqlCommand("UPDATE catalog SET mediaType = @mediaType, price = @price, qtyAvailable = @qtyAvailable WHERE mediaID = @mediaID"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        myCommand.Parameters.AddWithValue("@MediaID", mediaID);
                        myCommand.Parameters.AddWithValue("@MediaType", mediaType);
                        myCommand.Parameters.AddWithValue("@price", price);
                        myCommand.Parameters.AddWithValue("@qtyAvailable", qtyAvailable);
                        myCommand.Connection = myConn;
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                        myConn.Close();
                    }
                }
            }
            //reset edit index on cancel 
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            //reset edit index on cancel 
            GridView1.EditIndex = -1;
            GridView1.DataBind();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string mediaID = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values[0]);
            string myConnection = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            using (MySqlConnection myConn = new MySqlConnection(myConnection)) 
            {

                using (MySqlCommand myCommand = new MySqlCommand("DELETE FROM catalog WHERE mediaID = @mediaID"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        myCommand.Parameters.AddWithValue("@mediaID", mediaID);
                        myCommand.Connection = myConn;
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                        myConn.Close();
                    }
                }
            }
            GridView1.DataBind();
        }
    }
}
       

