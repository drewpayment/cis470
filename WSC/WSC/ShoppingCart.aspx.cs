using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            View_Panel();
        }

        protected void Checkout_Click(object sender, EventArgs e)
        {
            
        }

        protected void View_Panel()
        {
            if (Session["CartItem1"] != null)
            {
                lblItem1.Text = Convert.ToString(Session["CartItem1"]);
                lblitemNum1.Text = "1";
                lblProductDesc1.Text = "Shirt XYZ (White) - Lg";
                item1Panel.Visible = true;
            }
            else
            {
                item1Panel.Visible = false;
            }

            if (Session["CartItem2"] != null)
            {
                lblItem2.Text = Convert.ToString(Session["CartItem2"]);
                lblitemNum2.Text = "2";
                lblProductDesc2.Text = "Round Plaque w/ Banner (Espresso)";                
                item2Panel.Visible = true;
            }
            else
            {
                item2Panel.Visible = false;
            }

            if (Session["CartItem3"] != null)
            {
                lblItem3.Text = Convert.ToString(Session["CartItem3"]);
                lblitemNum3.Text = "3";
                lblProductDesc3.Text = "Silver Cup w/ Pine Base (Cherry) -Med"; 
                item3Panel.Visible = true;
            }
            else
            {
                item3Panel.Visible = false;
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Session["CartItem1"] = null; 
            Session["CartItem2"] = null; 
            Session["CartItem3"] = null;
            Response.Redirect("Catalog.aspx");
        }
       
    }
}