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

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ToString();
            MySqlConnection mysql = new MySqlConnection(connectionString);
            MySqlDataAdapter adapter;
            DataTable table = new DataTable();
            String username;
            String password;
            username = LoginForm.UserName.ToString();
            password = LoginForm.Password.ToString();

            adapter = new MySqlDataAdapter("SELECT * FROM user_access WHERE userName = '" + username + "' and password = '" + password + "'", mysql);
            adapter.Fill(table);

            if (table.Rows.Count <= 0)
            {
                string script = "alert(\"Incorrect username and password. Please try again.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                "ServerControlScript", script, true);
            }
            else
            {
                Membership.CreateUser(username, password); // This doesn't store user's logon. IDK what I'm doing... lol
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}