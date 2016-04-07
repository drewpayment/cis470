using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace WSC.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            TextBox UserNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");
            TextBox PasswordTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Password");
            TextBox ConfirmPwTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("ConfirmPassword");
            TextBox EmailTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Email");
            TextBox FirstNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("FirstName");
            TextBox LastNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("LastName");
            TextBox AddressTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Address");
            TextBox CityTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("City");
            TextBox StateTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("State");
            TextBox ZipTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Zip");
            TextBox PhoneTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("Phone");
            
            MembershipUser user = Membership.GetUser(UserNameTextBox.Text);
            Membership.UpdateUser(user);
            
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }
    }
}