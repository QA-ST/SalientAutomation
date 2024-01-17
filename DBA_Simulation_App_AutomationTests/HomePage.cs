using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DBA_Simulation_App_AutomationTests
{
    public class HomePage :BaseClass
    {     
        /// <summary>
        /// Click on my dashboard.
        /// </summary>
        private void Dashboard()
        {
            //Click on My Dashboard.       
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.ClassName("my-dashboard-btn"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']")));
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
        }

        /// <summary>
        /// Click on Manage experiments.
        /// </summary>
        private void ManageExperiments()
        {
            //Click on Manage Experiments
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divWelcome']/div[2]/div/div[2]/div/div[2]/button"))).Click();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
        }

        /// <summary>
        /// Click on Review pipeline.
        /// </summary>
        private void ReviewPipeline()
        {
            //Click on Review Pipeline
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.ClassName("pipeline-btn"))).Click();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
        }

        /// <summary>
        /// Click on tutorials.
        /// </summary>
        private void GetStarted()
        {
            //Click on Get Started
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.ClassName("get-started-btn"))).Click();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
        }

        /// <summary>
        /// Click on Automation Compass logo.
        /// </summary>
        private void SalientProcess()
        {
            //Click on  Automation Compass Logo
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divWelcome']/div[1]/div/div/a"))).Click();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
        }

        /// <summary>
        /// Select the pipeline to display.
        /// </summary>
        private void SelectThePipeline()
        {
            //Click on Select pipeline and select from the list.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("selectedpipeline"))).Click();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='selectpipeline']/div/ul/div/li[3]"))).Click();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
        }

        /// <summary>
        /// Print the opportunity table.
        /// </summary>
        private void Print()
        {
            Js().ExecuteScript("window.scrollTo(0,1000)");
            //Click on Print on Opportunity table.
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='divGettingStartedPipeline4']")));
            Wait(3);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline4']/div[2]/button")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedPipeline4']/div[2]/div[2]/div/a[1]"))).Click();
        }

        /// <summary>
        /// Copy the opportunity table.
        /// </summary>
        private void Copy()
        {
            //Click on Copy on Opportunity table.
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='divGettingStartedPipeline4']")));
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline4']/div[2]/button")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedPipeline4']/div[2]/div[2]/div/a[2]"))).Click();
            Driver.Navigate().Refresh();
        }

        /// <summary>
        /// Download opportunity table in excel format.
        /// </summary>
        private void ExportExcel()
        {
            //Click on Excel on Opportunity table.
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='divGettingStartedPipeline4']")));
            Wait(3);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline4']/div[2]/button")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedPipeline4']/div[2]/div[2]/div/a[3]"))).Click();
        }

        /// <summary>
        /// Download opportunity table in csv format.
        /// </summary>
        private void ExportCsv()
        {
            //Click on CSV on Opportunity table.
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='divGettingStartedPipeline4']")));
            Wait(3);
            Element=GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline4']/div[2]/button")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedPipeline4']/div[2]/div[2]/div/a[4]"))).Click();
        }

        /// <summary>
        /// Download opportunity table in pdf format.
        /// </summary>
        private void ExportPdf()
        {
            //Click on PDF on Opportunity table.
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='divGettingStartedPipeline4']")));
            Wait(3);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline4']/div[2]/button")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedPipeline4']/div[2]/div[2]/div/a[5]"))).Click();
        }

        /// <summary>
        /// Click on add opportunity.
        /// </summary>
        private void AddNewOpportunity()
        {
            //Click on Add Opportunity on Opportunity table.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divMain']/div/div[2]/div/div/div/div[1]/div[2]/a"))).Click();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
        }

        /// <summary>
        /// Click on move opportunity.
        /// Select the pipeline to move the opportunity.
        /// </summary>
        private void MoveOpportunity()
        {
            //Click on Move opportunity on Opportunity table
            Js().ExecuteScript("window.scrollTo(0,1000)");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMain")));
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline4']/div[2]/button")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            try
            {
                Driver.FindElement(By.XPath("//a[@title='Change Pipeline']")).Click();
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divPickPipelineList']/div[2]"))).Click();
            }
            catch
            {
                Driver.FindElement(By.XPath("(//a[@title='Change Pipeline'])[8]")).Click();
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divPickPipelineList']/div[2]"))).Click();
            }

            //Select the pipeline to move the opportunity.
            Js().ExecuteScript("window.scrollTo(-200, 0)");
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='divGettingStartedPipeline1']")));
            Wait(3);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='selectpipeline']/button"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='ddlpipelines']/li[2]/a"))).Click();
        }

        /// <summary>
        /// Open an opportunity from the opportunity table.
        /// </summary>
        private void EditOpportunity()
        {
            //Click on Edit on Opportunity table.
            Js().ExecuteScript("window.scrollTo(0,1000)");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMain")));

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@title='Edit Opportunity'])[1]")));
            GetActions().MoveToElement(Element).Click().Perform();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
        }

        /// <summary>
        /// Download the opportunity-pipeline breakdown chart(svg).
        /// </summary>
        private void OpportunityPipelineBreakdownChartsSvg()
        {
            try
            {
                //Click on menu icon on Opportunity Pipeline Breakdown Charts and download SVG.
                Js().ExecuteScript("window.scrollTo(0,2000)");
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.Id("divMain")));
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id ='divdonutchart']")));
                Element = GetWebDriverWait()
                      .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divdonutchart']/div/div[2]/div[1]")));
                Js().ExecuteScript("arguments[0].scrollIntoView(true);", Element);
                Element.Click();
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divdonutchart']/div/div[2]/div[2]/div[1]"))).Click();
            }
            catch
            {
                //Click on menu icon on Opportunity Pipeline Breakdown Charts and download SVG
                Js().ExecuteScript("window.scrollTo(0,2000)");
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.Id("divMain")));
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id ='divdonutchart']")));
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@class='col-md-6 draggable-zone'])[1]/div/div[2]/div[1]/div/div[2]"))).Click();
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@class='col-md-6 draggable-zone'])[1]/div/div[2]/div[1]/div/div[2]/div[2]/div[1]"))).Click();
            }
        }

        /// <summary>
        /// Download the opportunity-pipeline breakdown chart(png).
        /// </summary>
        private void OpportunityPipelineBreakdownChartsPng()
        {
            // Click on menu icon on Opportunity Pipeline Breakdown Charts and download SVG
          // Js().ExecuteScript("window.scrollTo(0,2000)");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMain")));
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id ='divdonutchart']")));
            Element= GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divdonutchart']/div/div[2]/div[1]")));
            Js().ExecuteScript("arguments[0].scrollIntoView(true);", Element);      
            Element.Click();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divdonutchart']/div/div[2]/div[2]/div[2]"))).Click();
            Driver.Navigate().Refresh();
        }

        /// <summary>
        /// Download the opportunity-pipeline past chart 12 months(csv).
        /// </summary>
        private void OpportunityPipelinePastCharts12MonthsCsv()
        {
            //Click on menu icon on Opportunity Pipeline Breakdown Charts and download CSV foe past 12 months.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divColumnChart']")));
            By ele = By.XPath("//div[@id='divOpportunityTimeline']//div[@class='apexcharts-menu-icon']");
            Js().ExecuteScript("arguments[0].scrollIntoView(true);", Driver.FindElement(ele));
            Driver.FindElement(ele).Click();
            Driver.FindElement(By.XPath("//div[@id='divOpportunityTimeline']//div[@class='apexcharts-menu-icon']//following::div[contains(text(),'Download CSV')]")).Click();
            Driver.Navigate().Refresh();
        }
      
         [Test]
        public void HomePageModule()
        {           
            Login();
            Dashboard();
            ManageExperiments();
            ReviewPipeline();
            GetStarted();
            SalientProcess();
            SelectThePipeline();
            Copy();
            ExportExcel();
            ExportCsv();
            ExportPdf();
            MoveOpportunity();
            AddNewOpportunity();
            EditOpportunity();
            OpportunityPipelineBreakdownChartsSvg();
            OpportunityPipelineBreakdownChartsPng();
            OpportunityPipelinePastCharts12MonthsCsv();
            Print();
        }
    }
}
