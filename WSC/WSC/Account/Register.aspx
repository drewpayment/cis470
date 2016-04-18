<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WSC.Account.Register" %>

<%-- Load registration page --%>
<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
       <h2>Register to create a new account</h2>
    </hgroup>
    <br />
    <asp:Label ID="lblUsername" runat="server" Text="username: " style="text-align: left"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="password: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password: "></asp:Label>
    <asp:TextBox ID="txtConfirm" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Text="email address: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblFirstName" runat="server" Text="First Name: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblLastName" runat="server" Text="Last Name: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblAddress" runat="server" Text="Street Address: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblZip" runat="server" Text="Zip Code: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lblPhone" runat="server" Text="Phone Number: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
</asp:Content>