/*
Module Name: CartItemAdded
Program Name: WSC eCommerce
Author: Sarah Barreca
CoAuthor: n/a
Date: 3/28/16 - 4/15/16
Purpose: This form is used to confirm items have been added to customer shopping cart
and to provide a choice to continue shopping or go to shopping cart. 
System Functions & Processes: 
	Page_Load: initializes page components & links	

Change Log:	4/1/16 Page creation and processes completed
	
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WSC
{
    public partial class CartItemAdded : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //cart item added confirmation page
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //post back to Shopping Cart
        }
    }
}