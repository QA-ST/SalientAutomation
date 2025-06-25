using Automation.Helpers;
using Automation.Resources.Locators;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.PageObjects
{
    internal class Homepage : BaseClass
    {
        public void NavigateToProcessModule()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomeLocators.GotoProcess))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
        }

        public void NavigateToOpportunityModule()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomeLocators.GoToOpportunity))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
        }


    }
}
