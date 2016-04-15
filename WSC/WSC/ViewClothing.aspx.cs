/*
Module Name: View Clothing 
Program Name: WSC eCommerce
Author: Sarah Barreca
CoAuthor: n/a
Date: 3/28/16 - 4/15/16
Purpose: This form is used to display products to customers and add those items to their shopping cart. 
System Functions & Processes: 
	Page_Load: initializes page components & displays links		

Change Log:	4/2/16 Page creation, design, and functions completed 
		4/2/12 Changed post back to redirect to shopping cart  			
	
*/
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
        protected void Button1_Click(object sender, EventArgs e)//function for clicking the button for viewing clothing
        {
            Session["CartItem1"] = "Clothing";//cartItem1 session variable equal to clothing
            Response.Redirect("CartItemAdded.aspx");   //redirect to cartItemAdded page        
        }        
	}
}