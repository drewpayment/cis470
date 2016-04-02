<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewClothing.aspx.cs" Inherits="WSC.ViewClothing" %>


<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>View Clothing Item</h2>
    </hgroup>
    <section id="viewClothing">
        <div style="float:left;">
            <asp:HyperLink  runat="server" NavigateUrl="~/Catalog.aspx">Return to Catalog</asp:HyperLink>                         
        </div>
        <br />
        <br />
        <div style="float:left;">   
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/shirt.png" />    
        </div>
        <div style="float:left; width: 550px;">

            <span class="auto-style1">Clothing Item Name (Shirt)<br />
            Item Description (100% Cotton Brand XYZ)<br />
            Color (White)<br />
            Size (Large)<br />
            Item Price ($15.00)<br />
            </span>
            <br />
            <br />

        </div>
        <asp:Button ID="Button1" runat="server" Text="Add to Cart" />
   </section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
    </style>
    </asp:Content>
