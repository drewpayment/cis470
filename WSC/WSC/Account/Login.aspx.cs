using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC.Account
{
    public partial class Login : Page
    {
        /** 
         * Load page and set ReturnUrl for HttpUtility
         *
         * @param object, EventArgs
         * @var string
         * @return void
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
           
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        /**
         * Authenticate user input against MySQL database.
         * 
         * @param string, string
         * @var string
         * @return boolean
         */
        private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ToString();
            MySqlConnection mysql = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter;
            DataTable table = new DataTable();

            adapter = new MySqlDataAdapter("SELECT * FROM user_access WHERE userName = '" + UserName + "' and password = '" + Password + "'", mysql);
            adapter.Fill(table);

            List<DataRow> foundRow = table.Select("userName = '" + UserName + "'").ToList();

            if (table.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                string userType = foundRow[0]["userType"].ToString();
                string userId = foundRow[0]["accessID"].ToString();
                Response.Cookies["UserInfo"]["userType"] = userType;
                Response.Cookies["UserInfo"]["accessID"] = userId;

                return true;
            }
        }

        /**
         * Set authentication token based on user login response.
         * 
         * @param object, AuthenticateEventArgs
         * @var boolean
         * @return void
         */
        protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            Authenticated = SiteSpecificAuthenticationMethod(LoginForm.UserName, LoginForm.Password);

            e.Authenticated = Authenticated;
        }
    }
}