<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmCustomerInformationEdit.aspx.cs" Inherits="WSC.frmCustomerInformationEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:wscompanyConnectionString %>" ProviderName="<%$ ConnectionStrings:wscompanyConnectionString.ProviderName %>" SelectCommand="SELECT [custFirstName], [custLastName], [custAddress], [custCity], [custState], [custZip], [custPhone], [custEmail] FROM [customer]"></asp:SqlDataSource>
        <br />
        <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        <br />
    </form>
</body>
</html>
