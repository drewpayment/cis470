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
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        /**
         * Register user from registration form.
         * 
         * @param object, EventArgs
         * @return void
         */
        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            TextBox UserNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");
            TextBox PasswordTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password");
            TextBox ConfirmPwTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ConfirmPassword");
            TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");
            TextBox FirstNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("FirstName");
            TextBox LastNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastName");
            TextBox AddressTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Address");
            TextBox CityTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("City");
            TextBox StateTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("State");
            TextBox ZipTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Zip");
            TextBox PhoneTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Phone");

            string userName = UserNameTextBox.Text;
            string passWord = PasswordTextBox.Text;
            string confirmPw = ConfirmPwTextBox.Text;
            string email = EmailTextBox.Text;
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string address = AddressTextBox.Text;
            string city = CityTextBox.Text;
            string state = StateTextBox.Text;
            string zip = ZipTextBox.Text;
            string phone = PhoneTextBox.Text;
            string userType = "cust";

            string connectString = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString.ToString();
            MySqlConnection conn = new MySqlConnection(connectString);
            MySqlCommand command, submitUser;
            conn.Open();

            if (passWord == confirmPw)
            {
                try
                {
                    command = conn.CreateCommand();
                    command.CommandText = "SELECT userName FROM user_access";
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        foreach (string value in reader)
                        {
                            if (value == userName)
                            {
                                Response.Write("<script>alert('I'm sorry, but that username has already been used.');</script>");
                                Response.Redirect("~/Account/Register");
                            }
                            else
                            {
                                try
                                {
                                    submitUser = conn.CreateCommand();
                                    submitUser.CommandText = "INSERT INTO user_access (userName, password, userType)" +
                                        "VALUES (@userName, @password, @userType)";
                                    submitUser.Parameters.AddWithValue("@userName", userName);
                                    submitUser.Parameters.AddWithValue("@password", passWord);
                                    submitUser.Parameters.AddWithValue("@userType", userType);
                                    submitUser.ExecuteNonQuery();

                                    FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

                                    string continueUrl = RegisterUser.ContinueDestinationPageUrl;
                                    if (!OpenAuth.IsLocalUrl(continueUrl))
                                    {
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
                                    conn.Close();
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                
            }
            ClearInputs(Page.Controls);

        }

        /**
         * Clear form inputs after registration
         * 
         * @param ControlCollection
         * @return void
         */
        private void ClearInputs(ControlCollection ctrls)
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