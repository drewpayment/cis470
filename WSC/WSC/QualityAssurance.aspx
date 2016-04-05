﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QualityAssurance.aspx.cs" Inherits="WSC.QualityAssurance" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Quality Assurance</h2>
    </hgroup>
    <section id="qualityAssurance">
    <div style="float:left; text-align: left;" class="auto-style1">
    
        <asp:Label ID="lblQAOrderID" runat="server" Text="Order ID: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtQAOrderID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblQAJobID" runat="server" Text="Job ID: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtQAJobID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblQAEmpID" runat="server" Text="Inspecting Employee ID: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtQAEmpID" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblQASpecialID" runat="server" Text="Assigned Specialist ID: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtQASpecialID" runat="server"></asp:TextBox>
        <br />
         <asp:Label ID="lblQANotes" runat="server" Text="Inspection Notes: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtQANotes" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblQAStatus" runat="server" Text="QA Status:" style="text-align: center"></asp:Label>
         <asp:RadioButtonList ID="rblQAStatus" runat="server" RepeatDirection="Horizontal" Width="135px">
                <asp:ListItem Text="Pass" Value="Pass"/>
                <asp:ListItem Text="Fail" Value="Fail" />              
         </asp:RadioButtonList>
        <br />
        <asp:Button ID="btnSubmitQA" runat="server" Text="Submit QA" />
        <br />
        <br />

    </div>
   </section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
