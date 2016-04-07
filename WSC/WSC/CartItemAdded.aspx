<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CartItemAdded.aspx.cs" Inherits="WSC.CartItemAdded" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Item Successfully Added to Cart!</h2>
    </hgroup>
    <section id="itemAddedtoCart">
    <div>
    
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/Catalog.aspx" Text="Continue Shopping" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" PostBackUrl="~/ShoppingCart.aspx" Text="Go to Shopping Cart" OnClick="Button2_Click" />
    
    </div>
   </section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
