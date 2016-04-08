using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{
    public partial class frmCustomerInformationEdit : System.Web.UI.Page
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["wscompanyConnectionString"].ConnectionString);
        

        protected void Page_Load(object sender, EventArgs e)
        {
             
                if (!Page.IsPostBack)
          {
              string accessID= Request.Cookies["UserInfo"]["accessId"];
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from customer WHERE custID = @accessID", conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataSet dsCustomer = new DataSet();
                adp.Fill(dsCustomer);
                GridViewCustomerInformation.DataSource = dsCustomer;
                GridViewCustomerInformation.DataBind();
                conn.Close();

              /*  conn.Open();
                MySqlCommand strCmd = new MySqlCommand("Select * from cust_order WHERE custID = @custID AND orderStatus = 'completed'", conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter(strCmd);
                DataSet dsOrderHistory = new DataSet();
                adapt.Fill(dsOrderHistory);
                GridViewOrderHistory.DataSource = dsOrderHistory;
                GridViewOrderHistory.DataBind();
                conn.Close();
                    */
              
            
        }

                }
            }
            
        }