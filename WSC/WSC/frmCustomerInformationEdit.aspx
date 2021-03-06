﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" EnableEventValidation="true" CodeBehind="frmCustomerInformationEdit.aspx.cs" Inherits="WSC.frmCustomerInformationEdit" %>

<%-- User profile page that allows user to edit their information --%>
<asp:Content  runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
      <h2>Customer Information</h2>
    </hgroup>
<section id="customerInformationEdit">
    <asp:Label runat="server" ID="lblGetCustID" >Please enter your customer ID:</asp:Label>
        <asp:TextBox ID="txtCustID" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmitName" runat="server" Text="Find Me" OnClick="btnSubmitName_Click" />
  
        <asp:GridView ID="GridViewCustomerInformation" runat="server" AutoGenerateColumns="False" DataKeyNames="custID" OnRowEditing="GridViewCustomerInformation_OnRowEditing" 
            OnRowCancelingEdit="GridViewCustomerInformation_OnRowCancelingEdit" OnRowUpdating="GridViewCustomerInformation_OnRowUpdating" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>                                
                 <asp:TemplateField HeaderText="First">
                    <EditItemTemplate>
                       <asp:TextBox ID="txtFirstName" runat="server" Text='<%# Eval("custFirstName") %>'></asp:TextBox>
                   </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lbl1" runat="server" Text='<%# Eval("custFirstName") %>'></asp:Label> 
                    </ItemTemplate>                   
                </asp:TemplateField>
                   <asp:TemplateField HeaderText="Last">
                     <EditItemTemplate>
                       <asp:TextBox ID="txtLastName" runat="server" Text='<%# Eval("custLastName") %>'></asp:TextBox>
                   </EditItemTemplate>
                       <ItemTemplate>
                         <asp:Label ID="lbl2" runat="server" Text='<%# Eval("custLastName") %>'></asp:Label> 
                    </ItemTemplate>                  
                </asp:TemplateField>              
                 <asp:TemplateField HeaderText="Address">
                     <EditItemTemplate>
                       <asp:TextBox ID="txtAddress" runat="server" Text='<%# Eval("custAddress") %>'></asp:TextBox>
                   </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lbl3" runat=server Text='<%# Eval("custAddress") %>'></asp:Label>
                    </ItemTemplate>                  
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="City">
                     <EditItemTemplate>
                       <asp:TextBox ID="txtcustCity" runat="server" Text='<%# Eval("custCity") %>'></asp:TextBox>
                   </EditItemTemplate> 
                    <ItemTemplate>
                         <asp:Label ID="lbl4" runat="server" Text= '<%# Eval("custCity") %>'></asp:Label>
                    </ItemTemplate>                   
                </asp:TemplateField>    
                 <asp:TemplateField HeaderText="State">
                     <EditItemTemplate>
                       <asp:TextBox ID="txtcustState" runat="server" Text='<%# Eval("custState") %>'></asp:TextBox>
                   </EditItemTemplate>
                    <ItemTemplate>
                         <asp:Label ID="lbl5" runat="server" Text='<%# Eval("custState") %>'></asp:Label>
                    </ItemTemplate>                   
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="Zip">
                    <EditItemTemplate>
                       <asp:TextBox ID="txtcustZip" runat="server" Text='<%# Eval("custZip") %>'></asp:TextBox>
                   </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lbl6" runat="server" Text='<%# Eval("custZip") %>'></asp:Label>
                    </ItemTemplate>                   
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="Phone">
                     <EditItemTemplate>
                       <asp:TextBox ID="txtcustPhone" runat="server" Text='<%# Eval("custPhone") %>'></asp:TextBox>
                   </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lbl7" runat="server" Text='<%# Eval("custPhone") %>'></asp:Label>
                    </ItemTemplate>                  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Email">
                   <EditItemTemplate> 
                        <asp:TextBox ID="txtcustEmail" runat="server" Text='<%# Eval("custEmail") %>'></asp:TextBox>                         
                    </EditItemTemplate>
                    <ItemTemplate>
                       <asp:Label ID="lbl8" runat="server" Text='<%# Eval("custEmail") %>'></asp:Label>
                    </ItemTemplate>                  
                </asp:TemplateField>
                              
                <asp:CommandField ButtonType= "Link" ShowEditButton="True"  />
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
        
        <br />
        <asp:Button ID="btnViewOrders" runat="server" OnClick="btnViewOrders_Click" Text="View My Orders" />
        <br />
    <asp:Panel runat="server" Width="100%">
        <div>
        <asp:GridView ID="GridViewOrderHistory" runat="server" DataKeyNames="orderID" EmptyDataText="No orders have been placed." BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
            <Columns>
                <asp:TemplateField HeaderText="Order History"></asp:TemplateField>
                 
                
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
        </div>
    </asp:Panel>
        <br />
        <br />
    
</section>
</asp:Content>
<asp:Content runat="server" contentplaceholderid="HeadContent">
    </asp:Content>
