<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="EmployeeReviewOrder.aspx.cs" Inherits="WSC.EmployeeReviewOrder" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Review Customer Orders</h2>
    </hgroup>
    <section id="reviewCustomerOrder" runat="server">
   
    <div>   
        <asp:GridView ID="GridViewReviewOrders" runat="server">
        </asp:GridView>
        <br />
        Look Up Order by Order ID:
        <asp:TextBox ID="txtGetOrder" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnFindOrder" runat="server" PostBackUrl="~/Account/Login.aspx" Text="Review" OnClick="btnFindOrder_Click" />
        <asp:Button ID="btnFinishReview" runat="server" PostBackUrl="~/Account/Login.aspx" Text="Finished Reviewing" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
   </section>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
