<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WSC.ShoppingCart" %>

<%-- Shopping cart view for user to review their order --%>
<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Shopping Cart</h2>
    </hgroup>
    <section id="shoppingCart">
        <asp:Panel ID="item1Panel" runat="server" BorderStyle="Solid">
             <asp:Label ID="itemName1" runat="server" Text="Item Name:"></asp:Label>
             &nbsp;<asp:Label ID="lblItem1" runat="server" style="font-weight: 700"></asp:Label>
              &nbsp;&nbsp;&nbsp;<asp:Label ID="itemNum1" runat="server" Text="Item Number:"></asp:Label>
             &nbsp;<asp:Label ID="lblitemNum1" runat="server" style="font-weight: 700"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="productDesc1" runat="server" Text="Product Description:"></asp:Label>
             &nbsp;<asp:Label ID="lblProductDesc1" runat="server" style="font-weight: 700"></asp:Label>
             <br />             
             <asp:Label ID="lblPrintEngrave1" runat="server" Text="Select Customization:"></asp:Label>
             &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                 <asp:ListItem>Print</asp:ListItem>
                 <asp:ListItem>Engrave</asp:ListItem>
             </asp:DropDownList>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblQuantity1" runat="server" Text="Quantity:"></asp:Label>
             &nbsp;<asp:TextBox ID="txtQuantity1" runat="server" Width="35px"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblContent1" runat="server" Text="Enter Desired Content:"></asp:Label>
             &nbsp;<asp:TextBox ID="txtContent1" runat="server" MaxLength="150" Width="155px"></asp:TextBox>
             </asp:Panel>
             <br />
          <asp:Panel ID="item2Panel" runat="server" BorderStyle="Solid">
             <asp:Label ID="itemName2" runat="server" Text="Item Name:"></asp:Label>
             &nbsp;<asp:Label ID="lblItem2" runat="server" style="font-weight: 700"></asp:Label>
              &nbsp;&nbsp;&nbsp;<asp:Label ID="itemNum2" runat="server" Text="Item Number:"></asp:Label>
             &nbsp;<asp:Label ID="lblitemNum2" runat="server" style="font-weight: 700"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="productDesc2" runat="server" Text="Product Description:"></asp:Label>
             &nbsp;<asp:Label ID="lblProductDesc2" runat="server" style="font-weight: 700"></asp:Label>
             <br />             
             <asp:Label ID="lblPrintEngrave2" runat="server" Text="Select Customization:"></asp:Label>
             &nbsp;<asp:DropDownList ID="DropDownList2" runat="server">
                 <asp:ListItem>Print</asp:ListItem>
                 <asp:ListItem>Engrave</asp:ListItem>
             </asp:DropDownList>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblQuantity2" runat="server" Text="Quantity:"></asp:Label>
             &nbsp;<asp:TextBox ID="txtQuantity2" runat="server" Width="35px"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblContent2" runat="server" Text="Enter Desired Content:"></asp:Label>
             &nbsp;<asp:TextBox ID="txtContent2" runat="server" MaxLength="150" Width="155px"></asp:TextBox>
             </asp:Panel>
                         
            <br />
         <asp:Panel ID="item3Panel" runat="server" BorderStyle="Solid">
             <asp:Label ID="itemName3" runat="server" Text="Item Name:"></asp:Label>
             &nbsp;<asp:Label ID="lblItem3" runat="server" style="font-weight: 700"></asp:Label>
              &nbsp;&nbsp;&nbsp;<asp:Label ID="itemNum3" runat="server" Text="Item Number:"></asp:Label>
             &nbsp;<asp:Label ID="lblitemNum3" runat="server" style="font-weight: 700"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="productDesc3" runat="server" Text="Product Description:"></asp:Label>
             &nbsp;<asp:Label ID="lblProductDesc3" runat="server" style="font-weight: 700"></asp:Label>
             <br />             
             <asp:Label ID="lblPrintEngrave3" runat="server" Text="Select Customization:"></asp:Label>
             &nbsp;<asp:DropDownList ID="DropDownList3" runat="server">
                 <asp:ListItem>Print</asp:ListItem>
                 <asp:ListItem>Engrave</asp:ListItem>
             </asp:DropDownList>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblQuantity3" runat="server" Text="Quantity:"></asp:Label>
             &nbsp;<asp:TextBox ID="txtQuantity3" runat="server" Width="35px"></asp:TextBox>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblContent3" runat="server" Text="Enter Desired Content:"></asp:Label>
             &nbsp;<asp:TextBox ID="txtContent3" runat="server" MaxLength="150"></asp:TextBox>
             </asp:Panel>
             <br />
      
            <asp:Label ID="total" runat="server"></asp:Label>
             &nbsp;&nbsp;&nbsp; <asp:Label ID="totalPrice" runat="server"></asp:Label>
                       
            <br />
            <asp:Label ID="lblCartEmpty" runat="server"></asp:Label>
            <br /> 
           <asp:Button ID="CancelButton" runat="server" Text="Cancel Order" style="float:left;" OnClick="CancelButton_Click"/>
           <asp:Button ID="Checkout" runat="server" Text="Checkout" style="float:right;" OnClick="Checkout_Click" PostBackUrl="~/Checkout.aspx"/>                    
              
   </section>
    
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
