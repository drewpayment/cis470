﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmCustomerInformationEdit.aspx.cs" Inherits="WSC.frmCustomerInformationEdit" %>


<asp:Content  runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Customer Information</h2>
    </hgroup>
<section id="customerInformationEdit">
    <div style="margin-left: 40px">
    
    </div>
        <asp:GridView ID="GridViewCustomerInformation" runat="server">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:wscompanyConnectionString %>" ProviderName="<%$ ConnectionStrings:wscompanyConnectionString.ProviderName %>" SelectCommand="SELECT [custFirstName], [custLastName], [custAddress], [custCity], [custState], [custZip], [custPhone], [custEmail] FROM [customer]"></asp:SqlDataSource>
        <br />
        <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="GridViewOrderHistory" runat="server">
    </asp:GridView>
    <br />
        <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        <br />
    
</section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
