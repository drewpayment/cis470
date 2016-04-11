using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WSC
{
	public partial class ViewClothing : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        /**
         * Set session variable for item on button event
         * 
         * @param object, EventArgs
         * @return void
         */
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["CartItem1"] = "Clothing";
            Response.Redirect("CartItemAdded.aspx");           
        }        
	}
}