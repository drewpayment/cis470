/*
Module Name: View Plaques 
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