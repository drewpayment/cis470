<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderSubmitted.aspx.cs" Inherits="WSC.OrderSubmitted" %>

<asp:Content  runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Order Submitted</h2>
    </hgroup>
    <section id="orderSubmitted">
    <div>
        Your order was successfully submitted. Thank you for choosing Williams Specialty Company!
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/frmCustomerInformationEdit.aspx" Text="Return to Profile" />
    </div>

   </section>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
            width: 299px;
        }
    </style>
</asp:Content>
