<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewTrophies.aspx.cs" Inherits="WSC.ViewTrophies" %>


<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>View Trophy Item</h2>
    </hgroup>
    <section id="viewTrophy">
        <div style="float:left;">
            <asp:HyperLink ID="HyperLink1"  runat="server" NavigateUrl="~/Catalog.aspx">Return to Catalog</asp:HyperLink>                         
        </div>
        <br />
        <br />
        <div style="float:left;">   
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/trophy.jpg" />    
        </div>
        <div style="float:left; width: 550px;">

            <span class="auto-style1">Trophy Item Name (Medium Silver Cup)<br />
            Item Description (Metal Plated Cup, Pine Wood Bottom w/ Name Plate)<br />
            Color (Silver Cup, Cherry Stain on Wood Bottom, Black Name Plate)<br />
            Size (Medium)<br />
            Demensions (12x4x4) <br />
            Item Price ($25.00)<br />
            </span>
            <br />
            <br />

        </div>
        <asp:Button ID="Button1" runat="server" Text="Add to Cart" PostBackUrl="~/CartItemAdded.aspx" Width="200px" />
   </section>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
    </style>
    </asp:Content>
