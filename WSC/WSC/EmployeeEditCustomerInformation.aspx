<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeEditCustomerInformation.aspx.cs" Inherits="WSC.EmployeeEditCustomerInformation" %>



<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Edit Customer Information</h2>
    </hgroup>
    <section id="editCustomerInformation">   

    
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
  

    </section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
            width: 299px;
        }
    </style>
</asp:Content>
