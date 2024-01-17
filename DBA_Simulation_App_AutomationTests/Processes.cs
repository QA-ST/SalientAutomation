using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace DBA_Simulation_App_AutomationTests
{
    public class Processes : BaseClass
    {        
        ///<summary >
        ///Login With Credentials.
        ///Click on Lab.
        ///Creating new experiment by using a template(Accounting services).
        ///Edit the template and discover automation.
        ///Select the required opportunities and Run simulation.
        ///Edit the instances and duration.
        ///Save the project.
        ///Run the Simulation.
        ///Delete the created process.
        ///</summary >         
        public void StartFromTemplate()
        {
            //Click on Process.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]"))).Click();

            //Click on Create New Experiment.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/ul/li[2]/div/i"))).Click();
            SelectTemplate();
            ProcessDetails();
            AddPainGainSummary();
            //Save Process details
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='saveAll']"))).Click();
            Wait(3);
            AutomationDiscovery();

            RunTheSimulation();
            SearchProcess();
            Element.SendKeys(Processes[1]);
            DeleteProcess();
            Wait(3);
        }

        /// <summary>
        /// Select the template
        /// </summary>
        private void SelectTemplate()
        {
            //Click on Start from template.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/ul/li[2]/ul/li[1]/a"))).Click();

            //Selection of Accounting Services template.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalTemplate']/div/div/div[2]/div[2]/div/div")));
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='lstTemplate']/li[1]/a/div/div[2]")));
            Click(Element);

            GetWebDriverWait()
                .Until(ExpectedConditions.ElementIsVisible(By.Id("divGettingStartedProject1")));
        }

        /// <summary>
        /// Adding process details
        /// </summary>
        private void ProcessDetails()
        {
            //Editing the Process Name and Adding Details
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementIsVisible(By.Id("txtSimulationName"))).Clear();
            Driver.FindElement(By.Id("txtSimulationName"))
                .SendKeys("Accounts(Automation)");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtSimulationDescription")))
                .SendKeys("We are using an accounting services template.");

            //Adding process owner.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedProject1']/div/form/div[1]/div[2]/div/span/span[1]/span/ul/li/input")))
               .SendKeys("Maria" + Keys.Enter);

            //Linking capability to process.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedProject1']/div/form/div[1]/div[3]/div/span/span[1]/span/ul/li/input")));
            GetActions().Click(Element).SendKeys(Keys.Enter).Perform();

            //Selecting category.
            Element = GetWebDriverWait()
               .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='selectSimulationCategory']")));
            Select().SelectByIndex(2);
        }
  
        /// <summary>
        /// Add pain and gain summary.
        /// </summary>
        private void AddPainGainSummary()
        {
            //Adding Gain summary.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='pills-strategic-tab']/i"))).Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblGaint_wrapper']/div[2]/div/table/tbody/tr[1]/td[3]/select")));
            Select().SelectByValue("2");

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblGaint_wrapper']/div[2]/div/table/tbody/tr[2]/td[3]/select")));
            Select().SelectByValue("4");

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblGaint_wrapper']/div[2]/div/table/tbody/tr[3]/td[3]/select")));
            Select().SelectByValue("5");

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblGaint_wrapper']/div[2]/div/table/tbody/tr[4]/td[3]/select")));
            Select().SelectByValue("1");

            //Adding Pain summary.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='pills-pain-tab']"))).Click();

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblPaint_wrapper']/div[2]/div/table/tbody/tr[1]/td[2]/select")));
            Select().SelectByValue("4");

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblPaint_wrapper']/div[2]/div/table/tbody/tr[2]/td[2]/select")));
            Select().SelectByValue("5");

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='tblPaint_wrapper']/div[2]/div/table/tbody/tr[3]/td[2]/select")));
            Select().SelectByValue("2");
        }

        ///<summary>
        ///Go to homepage.
        ///Click on Lab and create new experiment.
        ///Click on create from Scratch.
        ///Enter the details in steps.
        ///Enter the process information and simulate the process.
        ///Edit the instances and duration.
        ///Save the project.
        ///Run the Simulation 
        /// </summary>   
        public void CreatingFromScratch()
        {
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id='preloader']")));
            Element=GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]")));
            Click(Element);
            //Click on Create New Experiment
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/ul/li[2]/div/i"))).Click();

            CreateAndAddDetails();
            EnterProcessDetailsAndSimulate();
            RunTheSimulation();
            Wait(3);
        }

        /// <summary>
        /// Add process details.
        /// Add new steps and enter details.
        /// </summary>
        private void CreateAndAddDetails()
        {
            //Click on Create From Scratch
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/ul/li[2]/ul/li[2]/a"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divGettingStartedCreate1")));

            //Enter details in Step One
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divSteplist")));

            GetWebDriverWait().
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divSteplist']/div/div[4]/div/div/div/div/div/div/input")))
                .SendKeys("Round 1");

            GetWebDriverWait().
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@class='form-control resource-text form-control-sm resource-input']")))
                .SendKeys("Rohit");

            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@class='form-control task-type form-control-sm']")));
            Select().SelectByText("Normal");

            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divSteplist']/div[1]/div[4]/div[3]/div/div[1]/div[2]/div/input ")))
                .SendKeys("Online Interview");

            //Add new step
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='addStepButton']"))).Click();

            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divSteplist']/div[2]/div[4]/div/div/div/div/div/div/input"))).SendKeys("Round 2");
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divSteplist']/div[2]/div[4]/div[3]/div/div/div[1]/div/select")));
            Select().SelectByText("User");

            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divSteplist']/div[2]/div[4]/div[3]/div/div[1]/div[2]/div/input")))
                .SendKeys("Walk in Interview");


            //Add new step
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='addStepButton']"))).Click();

            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divSteplist']/div[3]/div[4]/div/div/div/div/div/div/input"))).SendKeys("Round 3");
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divSteplist']/div[2]/div[4]/div[3]/div/div/div[1]/div/select")));
            Select().SelectByText("User");

            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divSteplist']/div[3]/div[4]/div[3]/div/div[1]/div[2]/div/input")))
                .SendKeys("Joining");

        }

        /// <summary>
        /// Enter Name and description.
        /// Click on simulate.
        /// </summary>
        private void EnterProcessDetailsAndSimulate()
        {
            //Enter Process Information
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("txtProjectName"))).SendKeys("QA Hiring");

            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("txtProjectDescription")))
                .SendKeys("We are hiring QA's for both manual and automated testing.");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedCreate1']/div[2]/div[3]/div/tags/span"))).SendKeys("Rohit");

            //Click on Save
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divSticky']/div[2]/button[1]"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divProjectDetails']/div[1]")));
        }

        ///<summary >
        /// Login With Credentials.
        /// Click on Lab.
        /// Click on Manage experiments
        /// Search an experiment And open it.
        /// Click on Actions And Run simulation
        /// Edit the instances and duration.
        /// Save the project.
        /// Run the Simulation.
        /// Delete the created process.
        ///</summary >      
        public void ManageExperiments()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]"))).Click();

            //Click on Manage Processes
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/ul/li[4]/a"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tblProjects")));
            SearchTheProcess();
            RunTheSimulation();
            SearchProcess();
            Element.SendKeys(Processes[2]);
            DeleteProcess();
            Wait(3);
        }

        /// <summary>
        /// Search the created process.
        /// </summary>
        private void SearchTheProcess()
        {
            //Click on Search bar and search
            Driver.FindElement(By.XPath("//*[@id='tblProjects_filter']/label/input"));
            Element = GetWebDriverWait().
                   Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#tblProjects_filter>label>input")));
            Element.Clear();
            Element.SendKeys("QA Hiring");

            //Click on link to open process.                       
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[2]/a"))).Click();

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divProjectDetails']/div[1]/div/div")));            
        }

        /// <summary>
        /// Click on run simulation.
        /// Add simulation details.
        /// </summary>
        private void RunTheSimulation()
        {
            RunSimulation();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divMainTab']/div/div[1]/div[2]/div/div[4]"))).Click();
            Js().ExecuteScript("window.scrollTo(0,1000)");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedSimulation6']/div[5]/div[2]/div[1]/div/label/span"))).Click();

            //Click on Run Simulation.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnRunAnalysis']"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@id='tblSummary_wrapper']")));
        }

        [Test]
        public void TestingProcesses()
        {
            Login();
            StartFromTemplate();
            Wait(2);
            CreatingFromScratch();
            ManageExperiments();
        }
    }
}