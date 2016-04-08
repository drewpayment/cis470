<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="frmCustomerInformationEdit.aspx.cs" Inherits="WSC.frmCustomerInformationEdit" %>


<asp:Content  runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Customer Information</h2>
    </hgroup>
<section id="customerInformationEdit">
    <div style="margin-left: 40px">
    
        <asp:GridView ID="GridViewCustomerInformation" runat="server" DataSourceID="SqlDataSource1">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:wscompanyConnectionString %>" ProviderName="<%$ ConnectionStrings:wscompanyConnectionString.ProviderName %>" SelectCommand="SELECT [custID], [custFirstName], [custLastName], [custAddress], [custCity], [custState], [custZip], [custPhone], [custEmail] FROM [customer] WHERE ([accessID] = ?)">
            <SelectParameters>
                <asp:CookieParameter CookieName="userInfo" DefaultValue="accessID" Name="accessID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
        <br />
        <br />
    <br />
    <br />
    <br />
    <br />
        <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" PostBackUrl="~/frmCustomerInformationEdit.aspx" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="~/Account/Login.aspx" />
    <asp:GridView ID="GridViewOrderHistory" runat="server">
    </asp:GridView>
        <br />
    
</section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
