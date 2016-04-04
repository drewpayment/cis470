<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeEditCustomerInformation.aspx.cs" Inherits="WSC.EmployeeEditCustomerInformation" %>



<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Edit Customer Information</h2>
    </hgroup>
    <section id="editCustomerInformation">   

    
    <div>
    
        <br />
        <asp:Label ID="lblSearchLastName" runat="server" Text="Search Customer's Last Name: "></asp:Label>
&nbsp;<asp:TextBox ID="txtCustLastName" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSearch" runat="server" Text="Search" />
        <br />
    
    </div>
        <asp:GridView ID="GridViewEmployeeEdit" runat="server">
        </asp:GridView>
  

    </section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
