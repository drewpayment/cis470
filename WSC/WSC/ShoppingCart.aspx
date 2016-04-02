<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WSC.ShoppingCart" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Shopping Cart</h2>
    </hgroup>
       <section id="shoppingCart">
        <div style="float:left;" class="auto-style1">
          <asp:Panel ID="item1Panel" runat="server" BorderStyle="Solid">
              <h3>Item 1:</h3>
            <asp:Label ID="lblitemName1" runat="server" Text="Item Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtitemName1" runat="server"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblitemNum1" runat="server" Text="Item Number:"></asp:Label>
            &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtitemNum1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblProductDesc1" runat="server" Text="Product Description:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtProductDesc1" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblContent1" runat="server" Text="Enter Desired Content:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtContent1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrintEngrave1" runat="server" Text="Select Printing or Engraving:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPrintEngrave1" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblQuantity1" runat="server" Text="Quantity:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtQuantity1" runat="server"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPrice1" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="txtPrice1" runat="server"></asp:TextBox>        
          </asp:Panel>
            <br />
            <br />
            <br />
          <asp:Panel ID="item2Panel" runat="server" BorderStyle="Solid">
              <h3>Item 2:</h3>
            <asp:Label ID="lblItemName2" runat="server" Text="Item Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtItemName2" runat="server"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblItemNum2" runat="server" Text="Item Number:"></asp:Label>
            &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtItemNum2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblProductDesc2" runat="server" Text="Product Description:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtProductDesc2" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblContent2" runat="server" Text="Enter Desired Content:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtContent2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrintEngrave2" runat="server" Text="Select Printing or Engraving:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPrintEngrave2" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblQuantity2" runat="server" Text="Quantity:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtQuantity2" runat="server"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPrice2" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="txtPrice2" runat="server"></asp:TextBox>        
          </asp:Panel>
            <br />
            <br />
            <br />
          <asp:Panel ID="item3Panel" runat="server" BorderStyle="Solid">
              <h3>Item 3:</h3>
            <asp:Label ID="lblItemName3" runat="server" Text="Item Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtItemName3" runat="server"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblItemNum3" runat="server" Text="Item Number:"></asp:Label>
            &nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtItemNum3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblProductDesc3" runat="server" Text="Product Description:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtProductDesc3" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblContent3" runat="server" Text="Enter Desired Content:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtContent3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblPrintEngrave3" runat="server" Text="Select Printing or Engraving:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPrintEngrave3" runat="server"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblQuantity3" runat="server" Text="Quantity:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtQuantity3" runat="server"></asp:TextBox>
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPrice3" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="txtPrice3" runat="server"></asp:TextBox>        
          </asp:Panel>  
            <br />            
            <br />
            <br /> 
           <asp:Button ID="CancelButton" runat="server" Text="Cancel Order" style="float:left;"/>
           <asp:Button ID="Checkout" runat="server" Text="Checkout" style="float:right;"/>                    
        </div>          
   </section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
    </asp:Content>
