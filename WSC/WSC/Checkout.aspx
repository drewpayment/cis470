<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="WSC.Checkout" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Checkout</h2>
    </hgroup>
    <section id="checkout">
     <div style="float:left; text-align: left;">
            <asp:HyperLink ID="returnShopping"  runat="server" NavigateUrl="~/ShoppingCart.aspx">Return to Shopping Cart</asp:HyperLink> 
            <br />                      
   
        <br />
         <asp:Label ID="lblCheckoutOrderID" runat="server" Text="Order ID: "></asp:Label>
         <asp:Label ID="lblOrderID" runat="server" ></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="lblCheckoutOrderDate" runat="server" Text="Order Date: "></asp:Label>
            <asp:Label ID="Date" runat="server"></asp:Label>
         <br />
         <asp:Label ID="lblCheckoutCustID" runat="server" Text="Customer ID: "></asp:Label>
          <asp:Label ID="lblCustID" runat="server"></asp:Label>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCheckoutEmpID" runat="server" Text="Employee ID: "></asp:Label>
          <asp:TextBox ID="txtCheckoutEmpID" runat="server"></asp:TextBox>
         <br />   
              <asp:Panel ID="checkoutItemPanel1" runat="server">
              <h4>1.</h4>
            <asp:Label ID="lblCheckItemName1" runat="server" Text="Item Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblItemName1" runat="server"></asp:Label>
              &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCheckMediaType1" runat="server" Text="Media Type:"></asp:Label>
            &nbsp;&nbsp;&nbsp; <asp:Label ID="lblMediaType1" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCheckMediaID1" runat="server" Text="Media ID:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblMediaID1" runat="server"></asp:Label>
             &nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="lblCheckContent1" runat="server" Text="Content:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblContent1" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;            
            <asp:Label ID="lblCheckQTY1" runat="server" Text="QTY:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblQTY1" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCheckPrice1" runat="server" Text="Price:"></asp:Label>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblPrice1" runat="server"></asp:Label>        
          </asp:Panel>
            <br />
           
         <asp:Panel ID="checkoutItemPanel2" runat="server">
              <h4>2.</h4>
            <asp:Label ID="lblCheckItemName2" runat="server" Text="Item Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblItemName2" runat="server"></asp:Label>
              &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCheckMediaType2" runat="server" Text="Media Type:"></asp:Label>
            &nbsp;&nbsp;&nbsp; <asp:Label ID="lblMediaType2" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCheckMediaID2" runat="server" Text="Media ID:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblMediaID2" runat="server"></asp:Label>
             &nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="lblCheckContent2" runat="server" Text="Content:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblContent2" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;            
            <asp:Label ID="lblCheckQTY2" runat="server" Text="QTY:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblQTY2" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCheckPrice2" runat="server" Text="Price:"></asp:Label>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblPrice2" runat="server"></asp:Label>        
          </asp:Panel>
            <br />
          
           <asp:Panel ID="checkoutItemPanel3" runat="server">
              <h4>3.</h4>
            <asp:Label ID="lblCheckItemName3" runat="server" Text="Item Name:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblItemName3" runat="server"></asp:Label>
              &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCheckMediaType3" runat="server" Text="Media Type:"></asp:Label>
            &nbsp;&nbsp;&nbsp; <asp:Label ID="lblMediaType3" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCheckMediaID3" runat="server" Text="Media ID:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblMediaID3" runat="server"></asp:Label>
             &nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="lblCheckContent3" runat="server" Text="Content:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblContent3" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;            
            <asp:Label ID="lblCheckQTY3" runat="server" Text="QTY:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblQTY3" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblCheckPrice3" runat="server" Text="Price:"></asp:Label>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblPrice3" runat="server"></asp:Label>        
          </asp:Panel>
            <br />
            <asp:Panel ID="addressPanel" runat="server">
                <div style="float:left;">
                    <asp:Label ID="Label2" runat="server" Text="Shipping Address:"></asp:Label>
                    <br />
                    <asp:Label ID="lblShipAddress" runat="server" Text="Address:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtShipAddress" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblShipCity" runat="server" Text="City:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtShipCity" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblShipState" runat="server" Text="State:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtShipState" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblShipZip" runat="server" Text="Zip:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtShipZip" runat="server"></asp:TextBox>
                </div>
                 <div style="float:right;">
                     <asp:Label ID="Label3" runat="server" Text="Billing Address:"></asp:Label>
                     <br />
                     <asp:Label ID="lblBillAddress" runat="server" Text="Address:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBillAddress" runat="server"></asp:TextBox>
                     <br />
                    <asp:Label ID="lblBillCity" runat="server" Text="City:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBillCity" runat="server"></asp:TextBox>
                     <br />
                    <asp:Label ID="lblBillState" runat="server" Text="State:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBillState" runat="server"></asp:TextBox>
                       <br />
                    <asp:Label ID="lblBillZip" runat="server" Text="Zip:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBillZip" runat="server"></asp:TextBox>
                </div>               
            </asp:Panel> 
         <br />
         <br />
         <br />
         <asp:Panel ID="paymentPanel" runat="server" style="margin-top: 162px">
             <h4>Payment Information</h4>
             <br />
             <asp:Label ID="lblPayType" runat="server" Text="Payment Type:"></asp:Label>             
             <asp:ListBox ID="ListBox1" runat="server" Rows="2">
                 <asp:ListItem>Billing</asp:ListItem>
                 <asp:ListItem Value="Delivery">Pay on Delivery</asp:ListItem>
             </asp:ListBox>
             <br />
             <asp:Label ID="lblCCNum" runat="server" Text="Credit Card Number"></asp:Label>
             <asp:TextBox ID="txtCCNum" runat="server"></asp:TextBox>

             <br />
             <asp:Label ID="lblCCExpDate" runat="server" Text="Exp Date:"></asp:Label>
             <asp:TextBox ID="txtCCExpDate" runat="server"></asp:TextBox>
             <br />
             <br />
             <asp:Button ID="Button1" runat="server" PostBackUrl="~/ShoppingCart.aspx" Text="Cancel" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;      
             <asp:Button ID="SubmitOrderBtn" runat="server" Text="Submit Order" PostBackUrl="~/OrderSubmitted.aspx"/>
             <br />

         </asp:Panel>
                    
        </div>
       
   </section>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
