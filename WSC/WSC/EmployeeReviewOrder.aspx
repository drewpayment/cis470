<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="EmployeeReviewOrder.aspx.cs" Inherits="WSC.EmployeeReviewOrder" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Review Customer Orders</h2>
    </hgroup>
    <section id="reviewCustomerOrder" runat="server">
   
    <div>   
        <br />
        Look Up Order by Order ID:
        <asp:TextBox ID="txtGetOrder" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnFindOrder" runat="server" Text="Review" OnClick="btnFindOrder_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        </div>
        <asp:GridView ID="GridViewReviewOrders" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" OnSelectedIndexChanged="GridViewReviewOrders_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="Order Details:"></asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
   </section>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
