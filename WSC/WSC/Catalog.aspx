<%@ Page Title="Catalog" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="WSC.Catalog" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Catalog</h2>
    </hgroup>
    <section id="catalog">       
       
            <asp:Panel ID="Panel1" runat="server"  style="float:left;" BorderStyle="None" Width="320px">
                <p class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp; Clothing</strong></p>
                <p><asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/clothing.jpg" BorderStyle="Outset" Height="115px" Width="115px" PostBackUrl="~/ViewClothing.aspx" /></p> 
                <p>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ViewClothing.aspx">View Item Details</asp:HyperLink>
                </p>              
                <p>Add to Shopping Cart</p>
            </asp:Panel>        
            <asp:Panel ID="Panel2" runat="server" style="float:left;" BorderStyle="None"  Width="320px">
                <p class="auto-style1"><strong>&nbsp;&nbsp;&nbsp;&nbsp; Plaques</strong></p>
                <p><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/plaques.jpg" BorderStyle="Outset" Height="115px" Width="115px" PostBackUrl="~/ViewPlaques.aspx" /></p>
                <p>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/ViewPlaques.aspx">View Item Details</asp:HyperLink>
                </p>
                <p>Add to Shopping Cart</p>
            </asp:Panel>        
            <asp:Panel ID="Panel3" runat="server" style="float:left;" BorderStyle="None" Width="320px">
                <p class="auto-style1"><strong>&nbsp;&nbsp;&nbsp; Trophies</strong></p>
                <p><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/trophies.jpg" BorderStyle="Outset" Height="115px" Width="115px" PostBackUrl="~/ViewTrophies.aspx" /></p>
                <p>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/ViewTrophies.aspx">View Item Details</asp:HyperLink>
                </p>
                <p>Add to Shopping Cart</p>
            </asp:Panel>       
      
    </section>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
            width: 299px;
        }
    </style>
</asp:Content>

