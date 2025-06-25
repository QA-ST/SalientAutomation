using Automation.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;


namespace Automation
{
    public class BaseClass
    {
        public static IWebDriver driver;
        public static IWebElement element;
        public static string currentDirectory = Directory.GetCurrentDirectory();



        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
           // options.AddArguments("--headless");
            options.AddArguments("--window-size=1920,1080");
            options.AddArgument("no-sandbox");
            options.AddArguments("--disable-extensions"); // to disable extension
            options.AddArguments("--disable-notifications"); // to disable notification
            options.AddArguments("--disable-application-cache");
            options.AddArgument("--enable-javascript");  // Enable JavaScript
            options.AddArgument("--enable-cookies");    // Enable cookies
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore;

            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl(TestContext.Parameters.Get("WebsiteURLTest"));

        }

        [TearDown]
        public void Dispose()
        {
            Thread.Sleep(2000);
            driver.Dispose();
            driver.Quit();
            KillDriverProcesses();

        }

        /// <summary>
        /// Will kill the processes if any.
        /// </summary>
        private void KillDriverProcesses()
        {
            Process[] chromeDriverPID = Process.GetProcessesByName("chromedriver");
            foreach (var chromeDriverids in chromeDriverPID)
            {
                if (chromeDriverids != null)
                {
                    chromeDriverids.Kill();
                    Console.WriteLine("Chromedriver with id =" + chromeDriverids + "killed successfully.");
                }
            }

            //Process[] chromePID = Process.GetProcessesByName("chrome");
            //foreach (var chromeIds in chromePID)
            //{
            //    try
            //    {
            //        chromeIds.Kill();
            //        Console.WriteLine("Chrome with id =" + chromeIds + "killed successfully.");
            //    }
            //    catch
            //    {
            //        chromeIds.WaitForExit();
            //        chromeIds.Dispose();
            //    }
            //}
        }

      


    }
}
