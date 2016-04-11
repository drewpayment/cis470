<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCatalog.aspx.cs" Inherits="WSC.EditCatalog" %>

<%-- Edit catalog page enables user to make edits --%>
<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Edit Catalog</h2>
    </hgroup>
    <section id="editCatalog">
    <div style="float:left;">    
            <asp:Panel ID="NewMediaPanel" runat="server" style="text-align: center" >
            <h3>Add New Media to Catalog</h3>
            <table>
                <tr><td><asp:Label ID="lblEditItemName" runat="server" Text="Item ID:"></asp:Label></td>
                    <td><asp:TextBox ID="txtEditItemID" runat="server" Width="160px"></asp:TextBox></td>
                </tr>
                <tr><td><asp:Label ID="lblEditItemType" runat="server" Text="Item Type:"></asp:Label></td>
                    <td><asp:TextBox ID="txtEditItemType" runat="server" width="160px"></asp:TextBox></td>
                </tr>
                <tr><td class="auto-style1"><asp:Label ID="lblEditPrice" runat="server" Text="Price: "></asp:Label></td>
                    <td><asp:TextBox ID="txtEditPrice" runat="server" width="160px"></asp:TextBox></td>
                </tr>
                <tr><td><asp:Label ID="lblQty" runat="server" Text="Qty: "></asp:Label></td>
                    <td><asp:TextBox ID="txtQty" runat="server" width="160px"></asp:TextBox></td>
                </tr>                
            </table>
                        
            <br />
            <asp:Button ID="Button1" runat="server" Text="Add Media Item" OnClick="Button1_Click" />
        </asp:Panel>        
    </div>
    <asp:Panel ID="MediaGridPanel" runat="server" style="float:right;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" DataKeyNames="mediaID" DataSourceID="SqlDataSource1" GridLines="None">
            <Columns>
                <asp:BoundField DataField="mediaID" HeaderText="mediaID" ReadOnly="True" SortExpression="mediaID" />
                <asp:BoundField DataField="mediaType" HeaderText="mediaType" SortExpression="mediaType" />
                <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
                <asp:BoundField DataField="qtyAvailable" HeaderText="qtyAvailable" SortExpression="qtyAvailable" />
                <asp:CheckBoxField DataField="mediaInStock" HeaderText="mediaInStock" SortExpression="mediaInStock" />
                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:wscompanyConnectionString %>" ProviderName="<%$ ConnectionStrings:wscompanyConnectionString.ProviderName %>"
             SelectCommand="SELECT * FROM catalog"
             UpdateCommand="UPDATE catalog SET mediaType = @mediaType, price = @price, qtyAvailable = @qtyAvailable WHERE mediaID = @mediaID"
             DeleteCommand="DELETE FROM catalog WHERE mediaID = @mediaID"> 
        </asp:SqlDataSource>
   </asp:Panel>
    </section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>
    </asp:Content>
