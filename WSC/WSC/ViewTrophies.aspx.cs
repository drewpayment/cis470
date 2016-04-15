using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{
    public partial class ViewTrophies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)//function for clicking on button for trophy
        {
            Session["CartItem3"] = "Trophy";//session variable of cartItem3 is equal to trophy
            Response.Redirect("CartItemAdded.aspx");// redirect to cartItemAdded
        }
    }
}