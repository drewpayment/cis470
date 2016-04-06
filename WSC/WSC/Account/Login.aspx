<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WSC.Account.Login" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <section id="loginForm">
        <asp:Login ID="LoginForm" runat="server" 
            ViewStateMode="Disabled" 
            RenderOuterTable="false" 
            DestinationPageUrl="~/Default.aspx" 
            OnAuthenticate="OnAuthenticate">
        </asp:Login>
        <p>
            <asp:HyperLink ID="RegisterHyperLink" runat="server">Register</asp:HyperLink>
            if you don't have an account.
        </p>
    </section>

    </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-size: small;
        }
    </style>
</asp:Content>

