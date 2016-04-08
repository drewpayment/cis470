<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeEditCustomerInformation.aspx.cs" Inherits="WSC.EmployeeEditCustomerInformation" %>



<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Edit Customer Information</h2>
    </hgroup>
    <section id="editCustomerInformation" style="float:left; text-align: left;">     
        
     <asp:Panel ID="CustomerGridPanel" runat="server" style="float:left; text-align: left;">
     <asp:GridView ID="GridViewEmployeeEdit" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None" DataSourceID="SqlDataSource1" DataKeyNames="custID">
            <Columns>
                <asp:BoundField DataField="custID" HeaderText="custID" ReadOnly="True" SortExpression="custID" />
                <asp:BoundField DataField="custFirstName" HeaderText="custFirstName" SortExpression="custFirstName" />
                <asp:BoundField DataField="custLastName" HeaderText="custLastName" SortExpression="custLastName" />
                <asp:BoundField DataField="custAddress" HeaderText="custAddress" SortExpression="custAddress" />
                <asp:BoundField DataField="custCity" HeaderText="custCity" SortExpression="custCity" />
                <asp:BoundField DataField="custState" HeaderText="custState" SortExpression="custState" />
                <asp:BoundField DataField="custZip" HeaderText="custZip" SortExpression="custZip" />
                <asp:BoundField DataField="custPhone" HeaderText="custPhone" SortExpression="custPhone" />
                <asp:BoundField DataField="custEmail" HeaderText="custEmail" SortExpression="custEmail" />
                <asp:BoundField DataField="accessID" HeaderText="accessID" SortExpression="accessID" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView> 
         <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:wscompanyConnectionString %>" ProviderName="MySql.Data.MySqlClient" 
            SelectCommand="SELECT * FROM customer"
            UpdateCommand="UPDATE customer SET custID = @custID, custFirstName = @custFirstName,  custLastName = @custLastName, custAddress = @custAddress, custCity = @custCity, custState = @custState, custZip = @custZip, custPhone = @custPhone, custEmail = @custEmail, accessID = @accessID WHERE custID = @custID"
            DeleteCommand="DELETE FROM customer WHERE custID = @custID"></asp:SqlDataSource>
  
        </asp:Panel>
    </section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
