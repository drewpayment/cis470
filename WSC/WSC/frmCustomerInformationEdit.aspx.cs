using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{
    public partial class frmCustomerInformationEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Declare the Dataset
                dsCustomer myDataSet = new dsCustomer();
                string strSearch = Request["txtSearch"];
                //Fill the dataset with what is returned from the method.
                //myDataSet = ClsDataLayer.GetCustomer(Server.MapPath("wscompanyConnectionString"), strSearch);
                //Set the DataGrid to the DataSource based on the table
                GridViewCustomerInformation.DataSource = myDataSet.Tables["customer"];
                //Bind the DataGrid
                GridViewCustomerInformation.DataBind();
            }
        }
    }
}