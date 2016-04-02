<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPlaques.aspx.cs" Inherits="WSC.ViewPlaques" %>


<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>View Plaque Item</h2>
    </hgroup>
    <section id="viewPlaque">
        <div style="float:left;">
            <asp:HyperLink runat="server" NavigateUrl="~/Catalog.aspx">Return to Catalog</asp:HyperLink>                         
        </div>
        <br />
        <br />
        <div style="float:left;">   
            <asp:Image runat="server" ImageUrl="~/Images/plaque.jpg" />    
        </div>
        <div style="float:left; width: 550px;">

            <span class="auto-style1">Plaque Item Name (Round Plaque w/ Banner)<br />
            Item Description ( Steel Plated on Pine Wood)<br />
            Color (Black plate w/ Gold Trim, Dark Espresso Wood Stain)<br />
            Demensions (10X12)<br />
            Item Price ($35.00)<br />
            </span>
            <br />
            <br />

        </div>
        <asp:Button ID="Button1" runat="server" Text="Add to Cart" />
   </section>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
        }
    </style>
    </asp:Content>