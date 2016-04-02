<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeReviewOrder.aspx.cs" Inherits="WSC.EmployeeReviewOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LblReviewCustOrder" runat="server" Text="Review Customer Orders"></asp:Label>
        <br />
        <br />
    
    </div>
        <asp:GridView ID="GridViewReviewCustOrders" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <asp:Button ID="btnFinishReview" runat="server" PostBackUrl="~/Account/Login.aspx" Text="Finished Reviewing" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/Account/Login.aspx" Text="Cancel" />
    </form>
</body>
</html>
