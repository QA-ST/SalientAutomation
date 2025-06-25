using Automation.Resources.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Automation.Helpers
{
    internal class CommonMethods:BaseClass
    {
        public static void Wait(int delay)
        {
            // Causes the WebDriver to wait for at least a fixed delay
            var now = DateTime.Now;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(delay));
            wait.Until(Driver => (DateTime.Now - now) - TimeSpan.FromSeconds(delay) > TimeSpan.Zero);
        }
        /// <summary>
        /// Get web driver wait
        /// </summary>
        public static WebDriverWait GetWebDriverWait() => new WebDriverWait(driver, TimeSpan.FromSeconds(90));

        /// <summary>
        /// Get actions(Perform mouse and keyboard events)
        /// </summary>       
        public static Actions GetActions() => new Actions(driver);

        /// <summary>
        /// Js is interface that is used to execute JavaScript with Selenium
        /// </summary>
        public static IJavaScriptExecutor Js() => (IJavaScriptExecutor)driver;

        /// <summary>
        /// Select() will select the element from options 
        /// </summary>
        public static SelectElement Select() => new SelectElement(element);

        public static void SignInUser()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.login))).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.username)));
            element.SendKeys(TestContext.Parameters.Get("Email"));
            element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.password)));
            element.SendKeys(TestContext.Parameters.Get("Password"));
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.LoginPage.loginbutton))).Click();     
        }

        public static void WaitForLoaderToDisappear()
        {

            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
        }
        public static void LogoutAccount()
        {
           GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='navSidebar']"))).Click();
           GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='settings']//a[2]"))).Click();
        }

    }
}
