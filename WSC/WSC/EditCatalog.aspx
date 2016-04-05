<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCatalog.aspx.cs" Inherits="WSC.EditCatalog" %>

<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Edit Catalog</h2>
    </hgroup>
    <section id="editCatalog">
    <div style="float:left;">    
        <asp:Panel ID="NewMediaPanel" runat="server" >
            <h3>Add New Media to Catalog</h3>
            <asp:Label ID="lblEditItemName" runat="server" Text="Item Name:"></asp:Label>
            <asp:TextBox ID="txtEditItemName" runat="server"></asp:TextBox>
            <br />
           <asp:Label ID="lblEditItemType" runat="server" Text="Item Type:"></asp:Label>
            <asp:RadioButtonList ID="rblItemType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Clothing" Value="Clothing"/>
                <asp:ListItem Text="Plaque" Value="Plaque" />
                <asp:ListItem Text="Trophy" Value="Trophy" />
            </asp:RadioButtonList>
            <asp:Label ID="lblEditPrice" runat="server" Text="Price: "></asp:Label>
            <asp:TextBox ID="txtEditPrice" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblQty" runat="server" Text="Qty: "></asp:Label>
            <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Add Media Item" />
            <br />
        </asp:Panel>       
        <br />
        <br />
        <br />
          <asp:Panel ID="EditCatalogPanel" runat="server">
            <h3>View & Edit Catalog</h3>
                 <br />
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
          </asp:Panel>
        </div>
   </section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            font-size: medium;
            width: 299px;
        }
    </style>
</asp:Content>
