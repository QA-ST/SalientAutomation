using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DBA_Simulation_App_AutomationTests
{
    public class BaseClass
    {
        public IWebDriver Driver;
        public IWebElement Element;
        #region Constants

        private const int MaxWaitTime =4;
        public int delay;

        #endregion

        public string[] Opportunities = new string[] { "Testing", "K123", "Test6547", "Opportunity Test", "Test Benefit" };

        public string[] Processes = new string[] { "Accounts(Testing)", "Accounts(Automation)", "QA Hiring" };

        public string ApprovalDate = GetDate(12);

        public string StartDate = GetDate(20);

        public string TargetDate = GetDate(25);

        #region Setup
        [SetUp]
        public void Setup()
        {
            GetChromeDriverInstaller().GetAwaiter().GetResult();

            #region Chrome options
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            options.AddArguments("--window-size=1920,1080");
            options.AddArgument("no-sandbox");
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache");
            options.AddArgument("--enable-javascript");  // Enable JavaScript
            options.AddArgument("--enable-cookies");    // Enable cookies
            options.AddUserProfilePreference("download.default_directory", TestContext.Parameters.Get("DownloadPath"));
            #endregion

            Driver = new ChromeDriver(options);
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("WebsiteURLTest"));
            Wait(5);
            string currentURL = Driver.Url;
            Console.WriteLine("Current URL-" + currentURL);
            Driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(90));
            IWebElement LoginButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("loginBtn")));
            LoginButton.Click();
        }

        [TearDown]
        public void Dispose()
        {
            Driver.Quit();
        }

        /// <summary>
        /// Login with credentials.
        /// </summary>
        public void Login()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            //Inspecting Email field placeholder & Sending Valid Email id to Email field.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtLoginEmail")));
            Element.SendKeys(TestContext.Parameters.Get("Email"));

            //Inspecting Password field placeholder & Sending Valid Password to Password field.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtLoginPassword")));
            Element.SendKeys(TestContext.Parameters.Get("Password"));

            //Login with Enter Key.
            Driver.FindElement(By.Id("btnLogin")).Click();
            Wait(2);
        }

        /// <summary>
        /// Get and install chromedriver
        /// </summary>
        /// <returns></returns>
        private async Task GetChromeDriverInstaller()
        {
            var chromeDriverInstaller = new ChromeDriverInstaller();
            var chromeVersion = await chromeDriverInstaller.GetChromeVersion();
            await chromeDriverInstaller.Install(chromeVersion);
        }
        #endregion

        /// <summary>
        /// Get web driver wait
        /// </summary>
        public WebDriverWait GetWebDriverWait() => new WebDriverWait(Driver, TimeSpan.FromMinutes(MaxWaitTime));

        /// <summary>
        /// Get actions(Perform mouse and keyboard events)
        /// </summary>
        /// <returns></returns>
        public Actions GetActions() => new Actions(Driver);

        /// <summary>
        /// Js is interface that is used to execute JavaScript with Selenium
        /// </summary>
        public IJavaScriptExecutor Js() => (IJavaScriptExecutor)Driver;

        /// <summary>
        /// Select() will select the element from options 
        /// </summary>
        public SelectElement Select() => new SelectElement(Element);

        /// <summary>
        /// Search the created opportunity.
        /// </summary>
        public void SearchCreatedOpportunity()
        {
            //Delete the Created Opportunity
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[5]"))).Click();
            
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[5]/ul/li[3]/a"))).Click();
            Wait(3);
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblPipeline_filter']/label/input")));
            Element.Clear();
        }

        /// <summary>
        /// Delete the created opportunity.
        /// </summary>
        public void DeleteCreatedOpportunity()
        {
            //Delete the Created Opportunity.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@title='Delete Opportunity']"))).Click();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='swal2-actions']/button[1]"))).Click();
            Wait(3);
        }

        /// <summary>
        /// Search the created process.
        /// </summary>
        public void SearchProcess()
        {
            //Delete the Created Process
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/div/a/i"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/ul/li[4]/a"))).Click();

            //Search the Created Process
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects_filter']/label/input")));
            Element.Clear();
        }

        /// <summary>
        /// Delete the created process.
        /// </summary>
        public void DeleteProcess()
        {
            //Confirm the Deletion
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divMyProcesses']/div/div[2]/div/div[2]/div/table/tbody/tr[1]/td/div/a[3]"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='swal2-actions']/button[1]"))).Click();
        }
        public static string GetDate(int days) => DateTime.Now.Date.AddDays(days).ToString("MM/dd/yyyy");

        public void Wait(int delay)
        {
            // Causes the WebDriver to wait for at least a fixed delay
            var now = DateTime.Now;
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(delay));
            wait.Until(Driver => (DateTime.Now - now) - TimeSpan.FromSeconds(delay) > TimeSpan.Zero);
        }

        /// <summary>
        /// It will retry click on the element.
        /// </summary>
        /// <param name="element"></param>
     
        #region Common methods

        /// <summary>
        /// Run Simulation and add scenario
        /// </summary>
        public void RunSimulation()
        {
            //Click on action button.
            Element = Driver.FindElement(By.Id("actionsResultSimulation"));
            Click(Element);

            //Select run simulation.
            Element = Driver.FindElement(By.Id("runSimulation"));
            Click(Element);
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath("//div[@id='divMainTab']/div")));

            //Click on Next(to move on step-2).
            Element = Driver.FindElement(By.XPath("//*[@id='divMainTab']/div/div[1]/div[2]/div/div[2]"));
            Click(Element);

            //Turn on the advanced mode.
            Element = Driver.FindElement(By.XPath("//*[@id='divMainTab']/div/div[3]/div[4]/div[2]/div/label"));
            Click(Element);

            Js().ExecuteScript("window.scrollTo(0,1500)");   
            //Click on step to edit details in activites table.
            Element = Driver.FindElement(By.XPath("//div[@id='simulation-1-table']/div/div[1]/div[2]/div/table/tbody/tr[3]/td[7]"));
            Click(Element);
            Wait(3);

            //Enter work time.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtWorkTime1")));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("5").Perform();
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id='ddlWorkTimeUnit']")));
            Select().SelectByValue("Hours");

            //Enter cost.
            Element = Driver.FindElement(By.Id("txtCost1"));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("65").Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalEditStep']/div/div/div[3]/div[2]"))).Click();
        }

        /// <summary>
        /// Discover automation.
        /// </summary>
        public void AutomationDiscovery()
        {

            //Click on action menu and discover automation.
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//a[@id='actionsResultSimulation']")));
            Element = Driver.FindElement(By.XPath("//a[@id='actionsResultSimulation']"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@id='divGettingStartedSimulationResult3']")));
            Element = Driver.FindElement(By.XPath(" //*[@id='divGettingStartedSimulationResult3']/li[1]/a/span[2]"));
            Click(Element);
            Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@id='discoveryCards-divMain']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='discoveryCards-divMain']/div[2]/div[2]")));
            Element = Driver.FindElement(By.XPath("(//label[@class='checkbox checkbox-dark'])[8]"));
            Wait(1);
            Click(Element);
        }

        /// <summary>
        /// It retries click on element.
        /// </summary>
        /// <param name="element"></param>
        public void Click(IWebElement element)
        {
            Func<IWebDriver, bool> ElementToBeClickable = arg0 => {
                try
                {
                    element.Click();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            };
            GetWebDriverWait().Until(ElementToBeClickable);
        }


        #endregion

    }
}
