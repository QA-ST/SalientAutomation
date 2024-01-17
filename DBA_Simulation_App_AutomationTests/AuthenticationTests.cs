using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace DBA_Simulation_App_AutomationTests
{
    class AuthenticationTests : BaseClass
    {
        private const string Email = "khushboo@salientprocess.com";
        private IWebElement Emailfeild() => Driver.FindElement(By.Id("txtLoginEmail"));
        private IWebElement Password() => Driver.FindElement(By.Id("txtLoginPassword"));
        private IWebElement LoginBtn() => Driver.FindElement(By.Id("btnLogin"));

        /// <summary>
        ///  Verify the functionality of Enter key on login page.
        /// </summary>
        [Property("Priority", "Critical")]
        [Category("QuickTests")]
        [Test, Order(1)]
        public void LoginEnterFunctionalityTest()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Emailfeild().SendKeys(TestContext.Parameters.Get("Email"));
            Password().SendKeys(TestContext.Parameters.Get("Password"));
            //Inspecting Sign In button & Click on Sign In button.
            LoginBtn().SendKeys(Keys.Enter);
            Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divProfileHeaderImage']"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@onclick='Logout()']"))).Click();
        }

        /// <summary>
        /// Test case for Login with Invalid Credentials(Invalid-Email & Valid-Password)
        /// </summary>
        [Property("Priority", "Critical")]
        [Category("QuickTests")]
        [Test, Order(2)]
        public void LoginInvalidEmailTest()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Emailfeild().SendKeys(TestContext.Parameters.Get("InvalidEmail"));
            Password().SendKeys(TestContext.Parameters.Get("Password"));
            //Inspecting Sign In button & Click on Sign In button.
            LoginBtn().Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divLoginError']")));
            Assert.IsTrue(Element.Displayed);
            Wait(2);
        }

        /// <summary>
        /// Test case for Login with Invalid Credentials(Valid-Email & Invalid-Password)
        /// </summary>
        [Category("QuickTests")]
        [Test, Order(3)]
        public void LoginInvalidPasswordTest()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Emailfeild().SendKeys(TestContext.Parameters.Get("Email"));
            Password().SendKeys(TestContext.Parameters.Get("InvalidPassword"));
            //Inspecting Sign In button & Click on Sign In button.
            LoginBtn().Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divLoginError']")));
            Assert.IsTrue(Element.Displayed);
            Wait(2);
        }

        /// <summary>
        /// Test case for Login with Invalid Credentials(Invalid-Email & Invalid-Password)
        /// </summary>
        [Property("Priority", "Critical")]
        [Test, Order(4)]
        public void LoginInvalidCredentialsTest()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Emailfeild().SendKeys(TestContext.Parameters.Get("InvalidEmail"));
            Password().SendKeys(TestContext.Parameters.Get("InvalidPassword"));

            //Inspecting Sign In button & Click on Sign In button.
            LoginBtn().Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divLoginError']")));
            Assert.IsTrue(Element.Displayed);
            Wait(2);
        }

        /// <summary>
        /// Test case for Login without providing any credentials.
        /// </summary>
        [Test, Order(5)]
        public void LoginWithoutCredentialsTest()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Emailfeild();
            Password();

            //Inspecting Sign In button & Click on Sign In button.
            LoginBtn().Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divTextLoginEmail']")));
            Assert.IsTrue(Element.Displayed);
            Wait(2);
        }

        /// <summary>
        /// Go to forget password link.
        /// Enter the invalid email.
        /// Verify that error message displays.
        /// </summary>
        [Test, Order(6)]
        public void ForgetPasswordValidation()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            //Inspect Forgot Password? Link and Click on Forgot Password? Link
            Driver.FindElement(By.Id("kt_login_forgot")).Click();
            //Enter Invalid email.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtForgetPasswordEmail']")));
            Element.SendKeys(TestContext.Parameters.Get("InvalidEmail"));
            Wait(2);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='kt_login_forgot_form']/div[2]/button[2]")));
            GetActions().MoveToElement(Element).Click(Element).Perform();

            //Verify error message is displayed.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'This is not a valid email address. Please try again.')]")));
            Assert.IsTrue(Element.Displayed);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='kt_body']/div[2]/div/div[3]/button[1]"))).Click();
        }

        /// <summary>
        /// Functionality of Forgot Password link on Login Page.
        /// </summary>
        [Test, Order(7)]
        public void ForgotPasswordTest()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            //Inspect Forgot Password? Link and Click on Forgot Password? Link
            Driver.FindElement(By.Id("kt_login_forgot")).Click();
            //Enter a valid email.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtForgetPasswordEmail']")));
            Element.SendKeys(Email);
            try
            {
                //Click on Request Reset button and confirm.
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='kt_login_forgot_submit']"))).Click();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//button[@id='btnForgotLoading']")));
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='swal2-actions']/button[1]"))).Click();
            }
            catch (Exception)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='login-forgot']/form/div[2]/button[2]"))).Click();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//button[@id='btnForgotLoading']")));
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='swal2-actions']/button[1]"))).Click();
            }
        }

        ///// <summary>
        ///// Verify the functionality of "SignIn with Google" link on the login page.
        ///// </summary>
        //[Test, Order(8)]
        //public void LoginWithGoogleTest()
        //{
        //    Driver.SwitchTo().Window(Driver.WindowHandles[1]);
        //    //Inspecting Sign In With Google button & Click on Sign In With Google button.
        //    Element = Driver.FindElement(By.XPath("//a[@onclick='SignInWithGoogle()']"));
        //    Element.Click();
        //    Driver.Navigate().Back();
        //    Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        //}

        /// <summary>
        /// Test case for Login with valid credentials.
        /// </summary>

        [Test, Order(8)]
        [Property("Priority", "Highest")]
        public void LoginValidCredentialsTest()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Emailfeild().SendKeys(TestContext.Parameters.Get("Email"));
            Password().SendKeys(TestContext.Parameters.Get("Password"));

            //Login with Enter Key.
            LoginBtn().Click();
            Wait(2);
        }
    }
}