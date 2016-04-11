﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WSC.Account.Register" %>

<%-- Load registration page --%>
<asp:Content runat="server" ContentPlaceHolderID="FeaturedContent">
    <hgroup class="title">
       <h2>Register to create a new account</h2>
    </hgroup>
    <asp:CreateUserWizard runat="server" ID="RegisterUser" ViewStateMode="Disabled" OnCreatedUser="RegisterUser_CreatedUser" style="text-align: right; float: none; z-index: 1; left: auto; top: 181px; position: relative; height: 792px; width: 1091px;" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em">
        <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        <LayoutTemplate>
            <asp:PlaceHolder runat="server" ID="wizardStepPlaceholder" />
            <asp:PlaceHolder runat="server" ID="navigationPlaceholder" />
        </LayoutTemplate>
        <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" ID="RegisterUserWizardStep">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td colspan="2">Please enter your information</td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName">First Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" ControlToValidate="FirstName" ErrorMessage="First name is required." ToolTip="First name is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName">Last Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="LastName" ErrorMessage="Last name is required." ToolTip="Last name is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="AddressLabel" runat="server" AssociatedControlID="Address">Address:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Address" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AddressRequired" runat="server" ControlToValidate="Address" ErrorMessage="Address is required." ToolTip="Address is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label ID="CityLabel" runat="server" AssociatedControlID="City">City:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="City" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CityRequired" runat="server" ControlToValidate="City" ErrorMessage="City is required." ToolTip="City is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="StateLabel" runat="server" AssociatedControlID="State">State:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="State" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="StateRequired" runat="server" ControlToValidate="State" ErrorMessage="State is required." ToolTip="State is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="ZipLabel" runat="server" AssociatedControlID="Zip">Zip:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Zip" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ZipRequired" runat="server" ControlToValidate="Zip" ErrorMessage="Zip is required." ToolTip="Zip is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="PhoneLabel" runat="server" AssociatedControlID="Phone">Phone:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Phone" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PhoneRequired" runat="server" ControlToValidate="Phone" ErrorMessage="Phone is required." ToolTip="Phone is required." ValidationGroup="RegisterUser">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match." ValidationGroup="RegisterUser"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="color:Red;">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                    <br />
                </ContentTemplate>
                <CustomNavigationTemplate >
                    <asp:Button alight="left" ID="SubmitButton" runat="server" Text="Submit" />
                </CustomNavigationTemplate>
            </asp:CreateUserWizardStep>
<asp:CompleteWizardStep runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <td colspan="2">Complete</td>
            </tr>
            <tr>
                <td>Your account has been successfully created.</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue" Text="Continue" ValidationGroup="RegisterUser" />
                </td>
            </tr>
        </table>
    </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
        <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
        <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
        <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
        <StartNavigationTemplate>
            <asp:Button ID="StartNextButton" runat="server" CommandName="MoveNext" Text="Next" />
        </StartNavigationTemplate>
        <StepNavigationTemplate>
            <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" CommandName="MovePrevious" Text="Previous" />
            <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" Text="Next" />
        </StepNavigationTemplate>
        <StepStyle BorderWidth="0px" />
    </asp:CreateUserWizard>
</asp:Content>