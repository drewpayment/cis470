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
            Console.WriteLine(myMediaID + myMediaType + myPrice + myQuantity);

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

       

        
    }
}
       

