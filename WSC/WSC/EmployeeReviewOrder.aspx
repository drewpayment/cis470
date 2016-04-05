<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeeReviewOrder.aspx.cs" Inherits="WSC.EmployeeReviewOrder" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Review Customer Orders</h2>
    </hgroup>
    <section id="reviewCustomerOrder">
   
    <div>   
        <asp:GridView ID="GridViewReviewOrders" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <asp:Button ID="btnFinishReview" runat="server" PostBackUrl="~/Account/Login.aspx" Text="Finished Reviewing" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/Account/Login.aspx" Text="Cancel" />
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
