<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WSC.ShoppingCart" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Shopping Cart</h2>
    </hgroup>
    <section id="shoppingCart">
        
           <asp:Button ID="CancelButton" runat="server" Text="Cancel Order" style="float:left;" PostBackUrl="~/Catalog.aspx"/>
           <asp:Button ID="Checkout" runat="server" Text="Checkout" style="float:right;" OnClick="Checkout_Click" PostBackUrl="~/Checkout.aspx"/>                    
              
   </section>
    
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
    </asp:Content>
