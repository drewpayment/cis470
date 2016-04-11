<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WSC._Default" %>

<%-- 
    Program Name: Williams Specialty Company e-commerce website
    Authors: Sarah Barreca, Rebecca Kolb, Andrew Payment
    Date: April 10th, 2016
     --%>

<%-- Load default view for homepage of wscompany --%>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Welcome to Williams Specialty Company</h1>
            </hgroup>
            <p>
                Williams Specialty Company is small printing and engraving company specailized in serving all of your printing and engraving needs. Shop now and enter your own personalized message or logo for us to masterfully print or engrave onto your purchase selections. Make it your own, today!</p>
            <p>
                &nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Shop Now" OnClick="Button1_Click" PostBackUrl="~/Catalog.aspx" />
            </p>
        </div>
    <address>
        Williams Specialty Company</address>
    <address>
        100 Print Lane</address>
    <address>
        Staten Island, New York 10309</address>
    <address>
        (800)867-5309</address>
    </section>
</asp:Content>

