using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{
    public partial class ViewPlaques : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)//function for clicking the plaque item button
        {
            Session["CartItem2"] = "Plaque";//session variable of cartItem2 equal to plaque
            Response.Redirect("CartItemAdded.aspx");//redirect to cartItemAdded
          
        }
    }
}