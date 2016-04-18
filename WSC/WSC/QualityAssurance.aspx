<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QualityAssurance.aspx.cs" Inherits="WSC.QualityAssurance" %>

<%-- Quality assurance page that shows orders to be reviewed --%>
<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Quality Assurance</h2>
    </hgroup>
    <section id="qualityAssurance">
    <div style="float:left; text-align: right;" class="auto-style1">
    
        <asp:Label ID="lblpurchID" runat="server" Text="Purchase Item ID: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtQAPurchID" runat="server"></asp:TextBox>
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
        <br />
        <br />
         <asp:Label ID="lblQANotes" runat="server" Text="Inspection Notes: "></asp:Label>
            &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtQANotes" runat="server"></asp:TextBox>
        <br />
        <br />
         <asp:RadioButtonList ID="rblQAStatus" runat="server" RepeatDirection="Horizontal" Width="135px">
                <asp:ListItem Text="Pass" Value="P"/>
                <asp:ListItem Text="Fail" Value="F" />              
         </asp:RadioButtonList>
        <br />
        <asp:Button ID="btnSubmitQA" runat="server" Text="Submit QA" OnClick="btnSubmitQA_Click" />
        <br />
        <br />

    </div>
   </section>
    <asp:Label ID="lblConfirm" runat="server" style="font-weight: 700; font-size: large"></asp:Label>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
