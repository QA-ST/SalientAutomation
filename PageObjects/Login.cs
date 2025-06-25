using Automation.Helpers;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Automation.Resources.Locators;

namespace Automation.PageObjects
{
    public class Login : BaseClass
    {
        public void ClickLogin()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.login))).Click();
        }

        public void EnterEmail()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.username)));
            element.SendKeys(TestContext.Parameters.Get("Email"));
        }
        public void EnterPassword()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.password)));
            element.SendKeys(TestContext.Parameters.Get("Password"));
        }

        public void LoginUser()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.loginbutton))).Click();
        }

        public void ForgotPasswordlink()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.forgotPassword))).Click();
        }

        public void Submit()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.submitButton))).Click();
        }
        
        public void ConfirmSubmission()
        {
           element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.confirmationMessage)));
           Assert.IsTrue(element.Displayed);       
        }
    }
}
