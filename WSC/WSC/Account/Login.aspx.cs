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
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
           
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        private bool SiteSpecificAuthenticationMethod(string UserName, string Password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ToString();
            MySqlConnection mysql = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter;
            DataTable table = new DataTable();

            adapter = new MySqlDataAdapter("SELECT * FROM user_access WHERE userName = '" + UserName + "' and password = '" + Password + "'", mysql);
            adapter.Fill(table);

            if (table.Rows.Count <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            bool Authenticated = false;
            Authenticated = SiteSpecificAuthenticationMethod(LoginForm.UserName, LoginForm.Password);

            e.Authenticated = Authenticated;
        }
    }
}