<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="WSC.Checkout" %>

<%-- Checkout page to display contents and payment options to user --%>
<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Checkout</h2>
    </hgroup>
    <section id="checkout">
     <div style="float:left; text-align: left;">
            <asp:HyperLink ID="returnShopping"  runat="server" NavigateUrl="~/ShoppingCart.aspx">Return to Shopping Cart</asp:HyperLink> 
            <br />                      
   
        <br />
         <asp:Label ID="lblCheckoutOrderDate" runat="server" Text="Order Date: "></asp:Label>
            <asp:Label ID="lblDate" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblCustID" runat="server" Text="Customer ID: "></asp:Label>
            <asp:TextBox ID="txtCustID" runat="server"></asp:TextBox>
         <br />
         <asp:Label ID="lblCheckoutCustID" runat="server" Text="Customer First Name: "></asp:Label>
            <asp:TextBox ID="txtBillFirst" runat="server"></asp:TextBox>
            Last Name:
            <asp:TextBox ID="txtBillLast" runat="server"></asp:TextBox>
         <br />   
              <asp:Panel ID="checkoutItemPanel1" runat="server" style="font-weight: 700">
            <asp:Label ID="lblCheckItemNum1" runat="server" Text="Item Number:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblItemNum1" runat="server"></asp:Label>
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
            <asp:Label ID="lblCheckPrice1" runat="server" Text="Price:" style="color: #0000FF"></asp:Label>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblPrice1" runat="server" style="color: #0000FF"></asp:Label>        
          </asp:Panel>
            <br />
           
         <asp:Panel ID="checkoutItemPanel2" runat="server" style="font-weight: 700">
            <asp:Label ID="lblCheckItemNum2" runat="server" Text="Item Number:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblItemNum2" runat="server"></asp:Label>
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
            <asp:Label ID="lblCheckPrice2" runat="server" Text="Price:" style="color: #0000FF"></asp:Label>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblPrice2" runat="server" style="color: #0000FF"></asp:Label>        
          </asp:Panel>
            <br />
          
           <asp:Panel ID="checkoutItemPanel3" runat="server" style="font-weight: 700">
            <asp:Label ID="lblCheckItemNum3" runat="server" Text="Item Number:"></asp:Label>
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblItemNum3" runat="server"></asp:Label>
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
            <asp:Label ID="lblCheckPrice3" runat="server" Text="Price:" style="color: #0000FF"></asp:Label>
             &nbsp;&nbsp;&nbsp;<asp:Label ID="lblPrice3" runat="server" style="color: #0000FF"></asp:Label>        
          </asp:Panel>
            <asp:Label ID="lblTotalPrice" runat="server" style="float:right; font-weight: 700; color: #0000FF; font-size: medium;" Text="Label"></asp:Label>
            <br />
            <asp:Panel ID="addressPanel" runat="server">
                <div style="float:left; text-align: right;">
                    <asp:Label ID="Label2" runat="server" Text="Billing Address:" style="text-align: center"></asp:Label>
                    <br />
                    <asp:Label ID="lblShipAddress" runat="server" Text="Address:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBillAddress" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblShipCity" runat="server" Text="City:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBillCity" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblShipState" runat="server" Text="State:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBillState" runat="server"></asp:TextBox>
                    <br />
                    <asp:Label ID="lblShipZip" runat="server" Text="Zip:"></asp:Label>
                    &nbsp;<asp:TextBox ID="txtBillZip" runat="server"></asp:TextBox>
                </div>
            </asp:Panel> 
         <br />
         <br />
         <br />
         <asp:Panel ID="paymentPanel" runat="server" style="margin-top: 162px">
             <h4 class="auto-style1">Payment&nbsp; Information</h4>
             <br />
             <asp:Label ID="lblPayType" runat="server" Text="Payment Type:"></asp:Label>             
             &nbsp;
             <asp:DropDownList ID="DropDownList1" runat="server">
                 <asp:ListItem>Billing</asp:ListItem>
                 <asp:ListItem>Pay at Delivery</asp:ListItem>
             </asp:DropDownList>
             <br />
             <asp:Label ID="lblCCNum" runat="server" Text="Credit Card Number"></asp:Label>
             <asp:TextBox ID="txtCCNum" runat="server" MaxLength="16"></asp:TextBox>
             <br />
             <asp:Label ID="lblCCExpDate" runat="server" Text="Exp Date:"></asp:Label>
             <asp:TextBox ID="txtCCExpDate" runat="server"></asp:TextBox>
             <br />
             <br />
             <asp:Button ID="btnCancelCheckout" runat="server" Text="Cancel" style="float:left;" OnClick="Button1_Click"/>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="SubmitOrderBtn" runat="server" style="float:right;" Text="Submit Order" OnClick="SubmitOrderBtn_Click" />
             <br />

         </asp:Panel>
                    
        </div>
       
   </section>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
    </asp:Content>
