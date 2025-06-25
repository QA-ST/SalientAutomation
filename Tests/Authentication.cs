using Automation.Helpers;
using Automation.PageObjects;


namespace Automation.Tests
{
    public class Authentication : BaseClass
    {
        Login test = new Login();

        [Property("Priority", "Critical")]
        [Test, Order(1)]
        public void ValidSignIn()
        {
            test.ClickLogin();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            test.EnterEmail();
            test.EnterPassword();
            test.LoginUser();         
            CommonMethods.LogoutAccount();
        }

        [Property("Priority", "Medium")]
        [Test, Order(2)]
        public void ForgotPasswordEmail()
        {
            test.ClickLogin();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            test.ForgotPasswordlink();
            test.EnterEmail();
            test.Submit();
            test.ConfirmSubmission();

        }
    }
}
