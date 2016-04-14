using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace WSC.Account
{
    public partial class Register : Page
    {
        /**
         * Load page and store ContinueDestinationPageUrl
         * 
         * @param object, EventArgs
         * @var string
         * @return void
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            //RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        /**
         * Register user from registration form.
         * 
         * @param object, EventArgs
         * @return void
         */
        string connectString = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
       protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {




            //submitUser.CommandText = "INSERT INTO user_access (userName, password, userType)" +
            //  "VALUES (@userName, @password, @userType)";
            //submitUser.Parameters.AddWithValue("@userName", userName);
            //submitUser.Parameters.AddWithValue("@password", passWord);
            //submitUser.Parameters.AddWithValue("@userType", userType);
            //submitUser.ExecuteNonQuery();

            // FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            // string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            // if (!OpenAuth.IsLocalUrl(continueUrl))
            /* {
                 continueUrl = "~/";
             }
             Response.Redirect(continueUrl);
         }
         catch (Exception)
         {
             throw;
         }
         finally
         {
                                   
         }
     }
 }
}
}
catch (Exception)
{
throw;
}
                
}*/
          //  ClearInputs(Page.Controls);

        }

        /**
         * Clear form inputs after registration
         * 
         * @param ControlCollection
         * @return void
         */
      /*  private void ClearInputs(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }
        }*/

        protected void btnSubmit_Click(object sender, EventArgs e) //function for the submit button
        {
            string userName = txtUsername.Text;// grabs text from the username text box
            string passWord = txtPassword.Text; // grabs text from the password text box
            string confirmPw = txtConfirm.Text;// grabs text from the confirm password text box
            string email = txtEmail.Text; // grabs text from the email text box
            string firstName = txtFirstName.Text; //grabs text from first name text box
            string lastName = txtLastName.Text; //grabs text from last name text box
            string address = txtAddress.Text; //grabs text from address text box
            string city = txtCity.Text; //grabs text from city text box
            string state = txtState.Text; //grabs text from state text box
            string zip = txtZip.Text; // grabs text from zip code text box
            string phone = txtPhone.Text; //grabs text from phone number text box
            string userType = "c"; //assigns the default usertype to customer
            
            //created two strings with SQL insert statements in them for the two different tables we are using in this form
            string query = "INSERT INTO user_access(userName,passWord,userType)" + "Values('" + userName + " ' , ' " + passWord + " ' , ' " + userType+ " ')";
            string Query = "INSERT INTO customer(custEmail, custFirstName, custLastName, custAddress, custCity, custState, custZip, custPhone)" + "Values('" + email + " ' , ' " + firstName + " ' , ' " + lastName + " ' , ' " + address + " ' , ' " + city + " ' , ' " + state + " ' , ' " + zip + " ' , ' " + phone + " ')";


            // MySqlConnection conn = new MySqlConnection(connectString);
            using (MySqlConnection conn = new MySqlConnection(connectString))
            {
                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    conn.Open(); //opening the connection to the database
                    command.CommandText = "INSERT INTO user_access(userName,passWord,userType)" + "Values('" + userName + " ' , ' " + passWord + " ' , ' " + userType+ " ')";
                    //creating the insert command above and then executing it below on the next line
                    command.ExecuteNonQuery();
                    conn.Close();//closing the connection
                }
                using (MySqlCommand command = new MySqlCommand(Query, conn))
                {
                    conn.Open(); //opening the connection
                    command.CommandText = "INSERT INTO customer(custEmail, custFirstName, custLastName, custAddress, custCity, custState, custZip, custPhone)" + "Values('" + email + " ' , ' " + firstName + " ' , ' " + lastName + " ' , ' " + address + " ' , ' " + city + " ' , ' " + state + " ' , ' " + zip + " ' , ' " + phone + " ')";
                    //creating the insert command on the line above and then executing it on the next line down.
                    command.ExecuteNonQuery();
                    conn.Close(); //closing the connection
                }
            }
        }
    }
}
         

                               
                                
                                
                                
        
                          
                       
  