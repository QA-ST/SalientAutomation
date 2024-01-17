using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;

namespace DBA_Simulation_App_AutomationTests
{
    public class EndToEndTesting : BaseClass
    {

        #region ProcessFlow          
        public void ProcessFlow()
        {
            OpenProcess();
            AddDetails();
            AutomationDiscovery();
            RunSimulation();
            Schedules();
            MoveToNextStep();
            EditReports();
            ChangeScenario();
            CostCalculator();
            AddOpportunity();
            Wait(2);
            SearchProcess();
            Element.SendKeys(Processes[0]);
            DeleteProcess();
        }

        /// <summary>
        /// Open a Process
        /// </summary>
        private void OpenProcess()
        {
            //Click on process.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]")));
            Click(Element);
            //Click on create new process.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/ul/li[2]/div/i")));
            Click(Element);
            //Click on Start from template.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/ul/li[2]/ul/li[1]/a")));
            Click(Element);
            //Selection of accounting services template
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalTemplate']/div/div/div[2]/div[2]/div/div")));
            Element = Driver.FindElement(By.XPath("//*[@id='lstTemplate']/li[1]/a/div/div[2]"));
            Click(Element);
        }

        /// <summary>
        /// Add details to Process page
        /// </summary>
        private void AddDetails()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.Id("divGettingStartedProject1")));
            //Editing the process name.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.Id("txtSimulationName")));
            Element.Clear();
            Driver.FindElement(By.Id("txtSimulationName")).SendKeys("Accounts(Testing)");
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("txtSimulationDescription")))
                .SendKeys("We are testing the processes");
            //Save Process details
            Element = Driver.FindElement(By.XPath("//a[@id='saveAll']"));
            Click(Element);
            Wait(3);
        }

        /// <summary>
        /// Add schedules.
        /// Edit schedules.
        /// Assign schedule and cost to resources.
        /// </summary>
        private void Schedules()
        {
            Element = Driver.FindElement(By.XPath("//button[@id='nextStep']"));
            Click(Element);

            string a = "//div[@class='simulation-2__table']/div/div[2]/div/table/tbody/tr[";
            string b = "]/td/div";
            for (int i = 1; i <= 2; i++)
            {
                string c = a + i + b;
                //Edit Resource-1.
                Element = GetWebDriverWait()
                  .Until(ExpectedConditions.ElementToBeClickable(By.XPath(c)));
                Click(Element);
                //Add number of workers.
                Element = GetWebDriverWait()
                  .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtResourceNumber']")));
                GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("2").Perform();

                //Add cost. 
                Element = GetWebDriverWait()
                 .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtResourceCost']")));
                GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("70").Perform();

                //Save the details.
                Element = GetWebDriverWait()
                  .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalEditResource']/div/div/div[2]/form/div[5]/div[2] ")));
                Click(Element);
            }
            Element = Driver.FindElement(By.XPath("//*[@id='nextStep']"));
            Click(Element);

        }

        /// <summary>
        /// Move to next step
        /// </summary>
        private void MoveToNextStep()
        {
            //Click on first monday.
            Element = Driver.FindElement(By.XPath("//*[@id='divGettingStartedSimulation6']/div[1]/a[3]"));
            Click(Element);

            //Change number of instances.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedSimulation6']/div[2]/div/span/span[3]")));
            GetActions().MoveToElement(Element).Click().SendKeys(Keys.ArrowDown).Perform();

            //Change simulation duration.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedSimulation6']/div[3]/div/span/span[3]")));
            GetActions().MoveToElement(Element).Click().SendKeys(Keys.ArrowDown).Perform();

            //Visualize Simulation.
            Js().ExecuteScript("window.scrollTo(0,1000)");
            Element = Driver.FindElement(By.XPath("//*[@id='divGettingStartedSimulation6']/div[5]/div[2]/div[1]/div/label/span"));
            Click(Element);

            //Click on Next Step.
            Element = Driver.FindElement(By.XPath("//*[@id='nextStep']"));
            Click(Element);

            //Click on Run Simulation.
            Element = Driver.FindElement(By.XPath("//*[@id='runSimulationBtn']"));
            Click(Element);
        }

        /// <summary>
        /// Edit reports
        /// </summary>
        private void EditReports()
        {
            //Export to IBM process mining.
            Element = Driver.FindElement(By.XPath("(//*[@id='actionsResultSimulation'])[2]"));
            Click(Element);
            Wait(2);
            Element = Driver.FindElement(By.XPath("//*[@id='simulationResultsActions']/div/div/ul/li[6]/a"));
            Click(Element);

            //Click on count reports.
            Element = Driver.FindElement(By.XPath("//*[@id='chkHeatmap']/label[2]/span"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//*[@id='chkReportTables']/label[2]"));
            Click(Element);
            //Download reports in CSV, Excel and PDF.
            Element = Driver.FindElement(By.XPath("//button[@class='btn btn-secondary buttons-csv buttons-html5']"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//button[@class='btn btn-secondary buttons-excel buttons-html5']"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//button[@class='btn btn-secondary buttons-pdf buttons-html5']"));
            Click(Element);

            //Download Step-Count chart.(PNG)
            Element = Driver.FindElement(By.XPath("//*[@id='divCountChartBar']/div/div[4]/div[1]"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("(//div[@title='Download PNG'])[1]"));
            Click(Element);

            //Download Measurement Report.(SVG)
            Element = Driver.FindElement(By.XPath("//div[@id='divMeasurementReport']/div/div[4]/div[1]"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//div[@id='divMeasurementReport']/div/div[4]/div[2]/div[1]"));
            Click(Element);

            //Click on setup
            Element = Driver.FindElement(By.XPath("//*[@id='btnBackToSetup2']"));
            Click(Element);
        }

        /// <summary>
        /// Change Scenario
        /// </summary>
        private void ChangeScenario()
        {
            //Click on SetUp scenario.
            Element = Driver.FindElement(By.XPath("//*[@id='divMainTab']/div/div[1]/div[2]/div/div[2]"));
            Click(Element);

            //Click on add scenario.
            Element = Driver.FindElement(By.XPath("//*[@id='divMainTab']/div/div[3]/div[1]/div[2]/div[1]"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='newScenarioName']"))).SendKeys("Third Scenario");
            Element = Driver.FindElement(By.XPath("//*[@id='modalAddNewScenario']/div/div/div[2]/div[2]"));
            Click(Element);

            //Unhide the scenario.
            Element = Driver.FindElement(By.XPath("//*[@id='divMainTab']/div/div[3]/div[1]/div[1]/div[3]/div/div[2]/div[2]"));
            Click(Element);

            //Hide the current scenario.
            Element = Driver.FindElement(By.XPath("//*[@id='divMainTab']/div/div[3]/div[1]/div[1]/div[1]/div/div[2]/div[2]/img[2]"));
            Click(Element);

            Element = Driver.FindElement(By.XPath("//div[@class='simulation-1__diagram']/div[1]/ul/li[3]/a"));
            Click(Element);
            Wait(3);

            //Click on step to edit details in activites table.
            Js().ExecuteScript("window.scrollTo(0,1500)");
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='simulation1Content']/div[4]/div[2]/div/div[3]/div[2]/div/table/tbody/tr[3]/td/div")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            //Enter work time.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtWorkTime1")));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("6").Perform();

            ////Enter wait time.
            //Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtWaitTime1")));
            //GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("25").Perform();

            //Enter cost.
            Element = Driver.FindElement(By.Id("txtCost1"));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("76").Perform();

            Element = Driver.FindElement(By.XPath("//*[@id='modalEditStep']/div/div/div[3]/div[2]"));
            Click(Element);
            Js().ExecuteScript("window.scrollTo(1500,0)");
            Element = Driver.FindElement(By.XPath("//*[@id='btnRunAnalysis']"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='runSimulationEngine']/div/div[4]/div/div[2]")));
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//span[text()='Project Saved!']")));
        }

        /// <summary>
        /// Calculate the benefit cost 
        /// </summary>
        private void CostCalculator()
        {
            //Click on ROI calculator.
            Element = Driver.FindElement(By.XPath("//div[@id='simulationResultsActions']/button[1]"));
            Click(Element);

            //Click on estimated investment on new automation.
            Element = Driver.FindElement(By.Id("addInvestmentAutomation"));
            Click(Element);

            Element = Driver.FindElement(By.Id("txtSoftwareCostWizard"));
            Element.Clear();
            Element.SendKeys("20000");

            Element = Driver.FindElement(By.Id("txtProjectLengthWizard"));
            Element.Clear();
            Element.SendKeys("20");

            Element = Driver.FindElement(By.Id("txtProjectCostWizard"));
            Element.Clear();
            Element.SendKeys("50000");

            Element = Driver.FindElement(By.XPath("//a[@onclick='ShowResult()']"));
            Click(Element);

            //Click on current state. 
            Element = Driver.FindElement(By.XPath("//input[@id='txtCurrentCost']"));
            GetActions().DoubleClick(Element).SendKeys("150.45").Perform();
            Element = Driver.FindElement(By.XPath("//input[@id='txtActivitiesPerDay']"));
            GetActions().DoubleClick(Element).SendKeys("120.79").Perform();

            //Click on with automation.
            Element = Driver.FindElement(By.Id("txtNewCost"));
            GetActions().DoubleClick(Element).SendKeys("63").Perform();

            Element = Driver.FindElement(By.Id("txtProjectLength"));
            GetActions().DoubleClick(Element).SendKeys("8").Perform();

            Element = Driver.FindElement(By.Id("txtProjectCost"));
            GetActions().DoubleClick(Element).SendKeys("40000").Perform();
        }

        /// <summary>
        /// Add opportunity
        /// </summary>
        private void AddOpportunity()
        {
            // Click on action. 
            Element = Driver.FindElement(By.Id("actionsResultSimulation"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//a[@onclick='AddToPipeline()']"));
            Click(Element);

            //Click on summary.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("txtFileDescription"))).SendKeys("We are testing");

            //Click on source.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("ddlOpportunitySource")));
            Select().SelectByIndex(3);

            //Click on department.
            Element = Driver.FindElement(By.XPath("//input[@placeholder='Add or Select a Team']"));
            GetActions().Click(Element).SendKeys("IT" + Keys.Enter).Perform();

            //Click on sponsor.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Name("Sponsor"))).SendKeys("Test");

            //Click on process owner.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Name("ProcessOwner"))).SendKeys("John");

            // Click on business benefit.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedOpportunity4']/div[2]/div[7]/span/span/span/ul")));
            GetActions().Click(Element).SendKeys("Cost Reduction" + Keys.Enter).Perform();

            //Click on automation alignment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@class='select2-search__field'])[3]")))
                .SendKeys("General Automation" + Keys.Enter);

            //Click on core system.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='Enter a system name']"))).SendKeys("ZOHO" + Keys.Enter);

            // Click on organizational goals.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedOpportunity7']/span/span[1]/span/ul/li/input")));
            GetActions().Click(Element).SendKeys("goal 2" + Keys.Enter);

            //Move to estimated relative impact.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedOpportunity5']/div/div[1]/div/span/span[3]")));
            GetActions().MoveToElement(Element).ClickAndHold(Element).MoveByOffset(100, 0).Release(Element).Perform();

            //Select the Approval date.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Name("ApprovalDate")));
            Element.Clear();
            Element.SendKeys(ApprovalDate);

            //Select the Start date.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='dtpOpportunityStartDate']")));
            Element.Clear();
            Element.SendKeys(StartDate);

            //Select the Target Go-Live date.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='dtpOpportunityCompletionDate']")));
            Element.Clear();
            Element.SendKeys(TargetDate);

            //Click on save opportunity button.
            Element = Driver.FindElement(By.XPath("//div[@id='btnSaveOpportunity']/button[1]/i"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            GetWebDriverWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@id='tabsOpportunityContent']")));
        }
        #endregion

        #region PipelineFlow            
        public void Pipelines()
        {
            Element = Driver.FindElement(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[5]"));
            Click(Element);
            SelectPipeline();
            DeleteOpportunity();
            OpenOpportunity();
            DecoupleModel();
            SaveOpportunity();
            AutomationDiscovery();
            SaveProgress();
            RunSimulation();
            SaveAndRun();
            Wait(2);
            BenefitCostCalculator();
            SeeResults();
            ChangePhase();
            SearchCreatedOpportunity();
            Element.SendKeys(Opportunities[0]);
            DeleteCreatedOpportunity();
        }

        /// <summary>
        /// Click on pipeline and select a pipeline.
        /// </summary>
        private void SelectPipeline()
        {
            //Click on pipeline.
            Element = Driver.FindElement(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[5]/ul/li[2]/div/i"));
            Click(Element);
            GetWebDriverWait()
               .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@id='mnuPipelineOpenExisting']/li[1]/a")));
            Element = Driver.FindElement(By.XPath("//ul[@id='mnuPipelineOpenExisting']/li[1]/a"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//div[@id='selectPipeline']/a/span"));
            Click(Element);

            //Change the pipeline.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline2']/div/li[1]"))).Click();
        }

        /// <summary>
        /// Click on pipeline And delete opportunity.
        /// </summary>
        private void DeleteOpportunity()
        {
            Element = GetWebDriverWait()
                 .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblPipeline_filter']/label/input")));
            Element.Clear();
            Element.SendKeys(Keys.Enter);
            //Delete an opportunity.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@title='Delete Opportunity'])[1]")));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//button[@class='swal2-cancel swal2-styled']"));
            Click(Element);
        }

        /// <summary>
        /// Open an opportunity
        /// </summary>
        private void OpenOpportunity()
        {
            //Search the opportunity.
            Element = Driver.FindElement(By.XPath("//a[@onclick='CreateOpportunity()']"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='tabsOpportunityContent']")));

            //Click on  opportunity name.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtOpportunityName']")));
            GetActions().DoubleClick(Element).SendKeys("Testing").Perform();

            //Go to model tab.
            Element = Driver.FindElement(By.Id("tab-Simulation-Model"));
            Click(Element);

            //Add new model.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnProcessOpenModel")));
            Click(Element);
            Wait(2);
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[1]/a")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            Wait(3);
            //Save opportunity.
            Element = Driver.FindElement(By.XPath("//div[@id='btnSaveOpportunity']/button[1]/i"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='divOppportunity']")));
        }

        /// <summary>
        /// Decouple model and add new model.
        /// </summary>
        private void DecoupleModel()
        {
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='tab-Simulation-Model']")));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='newSimulationModal']/div/a")));
            if (Element.Displayed)
            {
                //Add a new model.
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='newSimulationModal']/div/a"))).Click();
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[1]/a"))).Click();
            }
            else
            {
                //Decouple the attached model.              
                Element = Driver.FindElement(By.XPath("//div[@id='tabSimulationModel']/div/div[1]/div[3]/div/div[3]/button/i"));
                Click(Element);
                Element = Driver.FindElement(By.XPath("//button[@class='swal2-confirm swal2-styled']"));
                Click(Element);
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
                Wait(3);

                //Add a new model.
                Element = Driver.FindElement(By.XPath("//div[@id='newSimulationModal']/div/a"));
                Click(Element);
                Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects_filter']/label/input")));
                Element.Clear();
                Element.SendKeys("Accounting Services");
                Element = Driver.FindElement(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[1]/a"));
                Click(Element);
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divDiagramSimulationModel']")));
            }
        }

        /// <summary>
        /// Save opportunity.
        /// </summary>
        private void SaveOpportunity()
        {
            //Save the opportunity.
            Wait(2);
            Element = Driver.FindElement(By.XPath("//div[@id='btnSaveOpportunity']/button[1]/i"));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='divOppportunity']")));

            //Go to model tab and open the process
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='tab-Simulation-Model']/span[2]")));
            Element.Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='btnEditModel']/i")));
            Click(Element);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.Id("txtOpportunityName")));
        }
       
        /// <summary>
        /// Save progress.
        /// </summary>
        private void SaveProgress()
        {
            //Click on action menu and then save progress.
            Element = Driver.FindElement(By.Id("actionsResultSimulation"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//a[@id='saveProgress']/span[2]"));
            Click(Element);

            //Click on action menu and then summary.
            Element = Driver.FindElement(By.Id("actionsResultSimulation"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//a[@id='summary']/span[2]"));
            Click(Element);
        }

        /// <summary>
        ///Save changes and run simulation.
        /// </summary>
        private void SaveAndRun()
        {
            Element=GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"divMainTab\"]/div/div[1]/div[2]/div/div[4]/div")));
            Element.Click();
            //Change number of instances.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedSimulation6']/div[2]/div/span/span[3]")));
            GetActions().MoveToElement(Element).Click().SendKeys(Keys.ArrowDown).Perform();

            Js().ExecuteScript("window.scrollTo(0,1000)");
            Element = Driver.FindElement(By.XPath("//*[@id='divGettingStartedSimulation6']/div[5]/div[2]/div[1]/div/label/span"));
            Click(Element);

            //Click on Run Simulation.
            Element = Driver.FindElement(By.XPath("//*[@id='btnRunAnalysis']"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@id='tblSummary_wrapper']")));
        }

        /// <summary>
        /// Go to benefit cost calculator.
        /// </summary>
        private void BenefitCostCalculator()
        {
            //Click on benefit cost calculator.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnValue']")));
            Click(Element);

            //Change the default values.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtActivitiesPerDayWizard")));
            Element.Clear();
            Element.SendKeys("2.50");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtCurrentCostWizard']")));
            Element.Clear();
            Element.SendKeys("202");
        }

        /// <summary>
        /// Lets see the results.
        /// </summary>
        private void SeeResults()
        {
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtNewCostWizard']")));
            Element.Clear();
            Element.SendKeys("250");

            Element = Driver.FindElement(By.XPath("//a[@id='addInvestmentAutomation']"));
            Click(Element);

            //Click on Let's see the results.
            Element = Driver.FindElement(By.XPath("//a[@onclick='ShowResult()']"));
            Click(Element);
           
            Element = Driver.FindElement(By.XPath("//*[@id='btnSaveValueOpportunity']/i"));
            Click(Element);
        }

        /// <summary>
        ///Change the phase of opportunity.
        /// </summary>
        private void ChangePhase()
        {
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='divOppportunity']")));
            //Change the phase of opportunity to planned.
            Element = Driver.FindElement(By.XPath("//div[@id='divOpportunityPhase']/div[3]"));
            Click(Element);
        }
        #endregion

        #region Business Architecture 
        public void BusinessArchitecture()
        {
            Element = Driver.FindElement(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[6]"));
            Click(Element);
            EditVision();
            Wait(3);
            EditMission();
            Wait(3);
            AddAndDeleteCoreValue();
            Wait(2);
            AddGoal();
            Wait(2);
            ChangeCapabilityTitle();
            ChangeCapabilityName();
            AddCapability();
            RenameTheCapability();
            AddGroupOfCapabilities();
            DeleteCapability();
            Heatmap();
            OrganizationalMap();
            AddChild();
            DeleteChild();
            SelectTheCreatedGoal();
            SearchCreatedOpportunity();
            Element.SendKeys(Opportunities[1]);
            DeleteCreatedOpportunity();
            Wait(2);
            DeleteTheGoal();
            DeleteHeatmap();
        }

        /// <summary>
        ///Edit vision.
        /// </summary>
        private void EditVision()
        {
            //Click on edit button and add vision.
            Element = Driver.FindElement(By.XPath("//*[@id='btnEditVision']"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtVision']")));
            Element.Clear();
            Element.SendKeys("new vision");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSaveVision']")));
            Element.Click();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStarted4']")));
        }

        /// <summary>
        ///Edit mission.
        /// </summary>
        private void EditMission()
        {
            //Click on edit button and add mission.
            Element = Driver.FindElement(By.Id("btnEditMission"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtMission']")));
            Element.Clear();
            Element.SendKeys("new mission");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSaveMission']")));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStarted5']")));
        }

        /// <summary>
        ///Add a new core value and delete a core value.
        /// </summary>
        private void AddAndDeleteCoreValue()
        {
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            //Click on add button and add core value.
            Element = Driver.FindElement(By.Id("btnEditValues"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtCoreValueTitle']")));
            Element.Clear();
            Element.SendKeys("We are together.");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtCoreValueTitle']")));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStarted6']/div/div[3]/button[1]")));
            Click(Element);

            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='divCoreValues']/div[5]/div[5]/button[2]/i")));
            Wait(2);

            //Delete the core value.
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));

            Element = Driver.FindElement(By.XPath("//*[@id='divCoreValues']/div[6]/div[5]/button[2]"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#kt_body>div.swal2-container.swal2-center.swal2-backdrop-show>div>div.swal2-actions>button.swal2-confirm.swal2-styled")));
            Click(Element);
        }

        /// <summary>
        ///Add a new goal. 
        /// </summary>
        private void AddGoal()
        {
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            //Click on add button and add a goal.
            Element = Driver.FindElement(By.XPath("//*[@id='divGettingStarted7']/div[1]/div[2]/button"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtGoalTitle']")));
            Element.Click();
            Element.SendKeys("new goal");
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtGoalDescription']")));
            Element.Click();
            Element.SendKeys("new goal description");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='selectGoalPriority']")));
            Select().SelectByValue("5");
            Element = Driver.FindElement(By.XPath("//*[@id='modalGoal']/div/div/div[3]/button[1]"));
            Click(Element);
            GetWebDriverWait()
                .Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
        }

        /// <summary>
        /// Change title capability group.
        /// </summary>
        private void ChangeCapabilityTitle()
        {
            //Go to capability.
            Element = Driver.FindElement(By.XPath("//*[@id='pills-capabilities-tab']"));
            Click(Element);

            //Import the capability map.
            Element = Driver.FindElement(By.XPath("//button[@data-original-title='Generate a sample capability map']"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id='ddlSampleCapability']")));
            Select().SelectByValue("1");
            Element = Driver.FindElement(By.XPath("//button[@onclick='SelectSampleCapability()']"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='swal2-confirm swal2-styled']")));
            Click(Element);
            //Go to capability.
            Element = Driver.FindElement(By.XPath("//*[@id='pills-capabilities-tab']"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='cap-map']")));
            Wait(3);

            //Change the capability title.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='cap-map']/div[1]/div[2]/div[2]")));
            IWebElement EditCapability = Driver.FindElement(By.XPath("//div[@id='cap-map']/div[1]/div[2]/div[4]/button[3]/i"));
            GetActions().MoveToElement(Element).Click(EditCapability).Perform();

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtCapabilityName")));
            Element.Click();
            Element.Clear();
            Element.SendKeys("New Primary Capability");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='saveCapabilityInfo']")));
            Element.Click();
        }

        /// <summary>
        ///Change capability name.
        /// </summary>
        private void ChangeCapabilityName()
        {
            //Change name of capability.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='cap-map']/div[1]/div[3]/div[1]/div[2]/div[1]")));
            GetActions().MoveToElement(Element).Perform();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='cap-map']/div[1]/div[3]/div[1]/div[2]/div[4]/button[3]/i")));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtCapabilityName']")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            Element.Clear();
            Element.SendKeys("New Offer");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='saveCapabilityInfo']")));
            Element.Click();
        }

        /// <summary>
        /// Add capability.
        /// </summary>
        private void AddCapability()
        {
            //Add a capability under 1. 
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='cap-map']/div[1]/div[3]/div[1]/div[2]")));
            GetActions().MoveToElement(Element).Perform();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='cap-map']/div[1]/div[3]/div[1]/div[2]/div[4]/button[2]/i")));
            Element.Click();
        }

        /// <summary>
        /// Rename the capability. 
        /// </summary>
        private void RenameTheCapability()
        {
            //Click on edit button and rename the capability.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='cap-map']/div[1]/div[3]/div[1]/div[3]/div[1]/div[2]")));
            GetActions().MoveToElement(Element).Perform();
            Element = Driver.FindElement(By.XPath("//div[@id='cap-map']/div[1]/div[3]/div[1]/div[3]/div[1]/div[2]/div[4]/button[3]/i"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtCapabilityName")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            Element.Click();
            Element.Clear();
            Element.SendKeys("Accept new Offer");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='saveCapabilityInfo']")));
            Element.Click();
        }

        /// <summary>
        ///Add group of capabilities.
        /// </summary>
        private void AddGroupOfCapabilities()
        {
            Wait(2);
            //Add a group of capabilities (section) and add child.
            Element = Driver.FindElement(By.XPath("//div[@id='cap-map']/button"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='cap-map']/div[3]/div[2]/div[3]")));
            GetActions().MoveToElement(Element).Perform();
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='cap-map']/div[3]/div[2]/div[4]/button[2]/i")));
            Element.Click();
        }

        /// <summary>
        /// Delete capabilities.
        /// </summary>
        private void DeleteCapability()
        {
            //Delete capability 5 and children.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='cap-map']/div[3]/div[2]/div[2]")));
            GetActions().MoveToElement(Element).Perform();
            Element = Driver.FindElement(By.XPath("//div[@id='cap-map']/div[3]/div[2]/div[4]/button[1]"));
            Click(Element);
            Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='swal2-confirm swal2-styled']"))).Click();
            Wait(2);
        }

        /// <summary>
        /// Go to organizational map.
        /// </summary>
        private void OrganizationalMap()
        {
            Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));

            //Click on organization map.
            GetWebDriverWait()
                .Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-container swal2-center swal2-backdrop-show']")));
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMain']/div/div/ul/li[5]/a")));
            Element.Click();
        }

        /// <summary>
        ///Add two children on organizational map.
        /// </summary>
        private void AddChild()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='orgChart']")));

            //Add child
            Wait(3);
            Element = Driver.FindElement(By.XPath("//*[@id='orgChart']/table/tbody/tr[4]/td[1]/table/tbody/tr[1]/td/div/div[1]/i"));
            GetActions().MoveToElement(Element).Click(Element).Perform();

            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtOrganizationName']")));
            Element.Click();
            Element.SendKeys("third level");
            Element = GetWebDriverWait()
                  .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='organizationModal']/div/div/div[3]/button[1]")));
            Element.Click();
        }

        /// <summary>
        /// Delete the child on organizational map.
        /// </summary>
        private void DeleteChild()
        {
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            //Delete right child.
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("(//*[@id='orgChart']/table/tbody/tr[4]/td/table/tbody/tr[4]/td[2]/table/tbody[1])[1]")));
            Wait(3);
            Element = Driver.FindElement(By.XPath("(//*[@id='orgChart']/table/tbody/tr[4]/td/table/tbody/tr[4]/td[2]/table/tbody/tr/td/div/div[3])[1]"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//button[@class='swal2-confirm swal2-styled']"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));

            Wait(2);
            Element = Driver.FindElement(By.XPath("//*[@id='orgChart']/table/tbody/tr[4]/td[1]/table/tbody/tr[1]/td/div/div[2]"));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtOrganizationName']")));
            Element.Click();
            Element.Clear();
            Element.SendKeys("My Organization ");

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@onclick='SaveOrganization()']")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
        }

        /// <summary>
        /// Select the created goal in an opportunity.
        /// </summary>
        private void SelectTheCreatedGoal()
        {
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-container swal2-top-right swal2-backdrop-show']")));

            //Click on pipelines.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[5]")));
            GetActions().MoveToElement(Element).Perform();

            //Click on create new opportunity.
            Element = Driver.FindElement(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[5]/ul/li[5]/div/a"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//li[@onclick='CreateNewOpportunity()']/a"));
            Click(Element);

            //Enter name.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtOpportunityName']"))).SendKeys("K123");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedOpportunity7']")));

            //Select the created goal.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedOpportunity7']/span/span/span/ul/li/input")));
            Element.Click();
            Element.SendKeys("new goal" + Keys.Enter);

            //Save the opportunity.
            Element = Driver.FindElement(By.XPath("//div[@id='btnSaveOpportunity']/button[1]/i"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("tabsOpportunityContent")));
            Wait(3);
        }

        /// <summary>
        /// Delete the created goal.
        /// </summary>
        private void DeleteTheGoal()
        {
            //Go to business architecture and delete the created goal.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[6]"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGoalValues']/div[5]/div[5]/button[2]"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(" //button[@class='swal2-confirm swal2-styled']"))).Click();
            Wait(3);
        }

        /// <summary>
        /// Create the heatmap.
        /// Add levels to few capabilities.
        /// Delete the heatmap.
        /// </summary>
        public void Heatmap()
        {
            //Go to heatmap.
            Element = Driver.FindElement(By.XPath("//ul[@id='myTab']/li[2]/a"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//button[@id='addHeatmap']"));
            Click(Element);
            Wait(2);
            Element = Driver.FindElement(By.XPath("//div[@id='manualSelectCard']"));
            Click(Element);
            Element = Driver.FindElement(By.XPath("//button[@id='nextHeatmapSelect']"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtHeatmapCreateName']"))).SendKeys("Testing Heatmap");

            //Save the heatmap.
            Element = Driver.FindElement(By.XPath("//button[@id='saveHeatmapCreate']"));
            Click(Element);
            Wait(3);
            //Add levels to the capabilities.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='heatmap']/div[1]/div[3]/div[1]/div[2]")));
            GetActions().MoveToElement(Element).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='heatmap']/div[1]/div[3]/div[1]/div[2]/div[4]/button[3]"))).Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divEditHeatmap']/select")));
            Select().SelectByIndex(4);
            Wait(2);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='saveCapabilityInfo']")));
            Click(Element);

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='heatmap']/div[1]/div[3]/div[2]/div[2]")));
            GetActions().MoveToElement(Element).Perform();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='heatmap']/div[1]/div[3]/div[2]/div[2]/div[4]/button[3]")));
            Click(Element);

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divEditHeatmap']/select")));
            Select().SelectByIndex(2);

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='saveCapabilityInfo']"))).Click();
            Driver.Navigate().Refresh();
        }

        /// <summary>
        /// Delete the created heatmap
        /// </summary>
        public void DeleteHeatmap()
        {
            //Go to capability.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pills-capabilities-tab']")));
            Click(Element);
            //Go to heatmap.
            Element = Driver.FindElement(By.XPath("//ul[@id='myTab']/li[2]/a"));
            Click(Element);

            //Search the created heatmap.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("chooseHeatmap")));
            Select().SelectByText("Testing Heatmap");

            //Delete the created heatmap.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedBluePrints12']/button[2]/i")));
            try
            {
                Element = Driver.FindElement(By.XPath("//button[@id='deleteHeatmap']/i"));
                Click(Element);
            }
            catch (Exception)
            {

                Element = Driver.FindElement(By.XPath("//div[@id='divGettingStartedBluePrints12']/button[2]/i"));
                Click(Element);
            }
            Wait(3);

            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@id='modalCapabilityInfo']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//button[@class='swal2-confirm swal2-styled']")));
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='swal2-confirm swal2-styled']")));
            Element.Click();
        }

        #endregion

        #region HomeFlow        
        public void HomeFlow()
        {
            ClickCompassLogo();
            ClickManageProcesses();
            ReviewPipeline();
            ClickGetStarted();
            SelectThePipeline();

            #region Download all charts
            OpportunityPipelineBreakdownChart();
            OpportunityPipelineChart();
            ImpactVsComplexity();
            OpportunityTimelineChart();
            #endregion
            MoveOpportunity();
            OpenTheOpportunity();
            AddTheOpportunity();
            AddModel();
            AddBenefitCost();
            Wait(2);
            SearchCreatedOpportunity();
            Element.SendKeys(Opportunities[2]);
            DeleteCreatedOpportunity();
        }

        /// <summary>
        /// Click on compass logo. 
        /// </summary>
        private void ClickCompassLogo()
        {
            //Click on Compass logo.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("Header_aHeaderLogo")));
            GetActions().Click(Element).Perform();
            Driver.Navigate().Back();
        }

        /// <summary>
        /// Click on manage experiments.
        /// </summary>
        private void ClickManageProcesses()
        {
            //Click on manage processes.
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//button[contains(text(),'Manage Processes')]")));
            Element = Driver.FindElement(By.XPath("//button[contains(text(),'Manage Processes')]"));
            Click(Element);
            Driver.Navigate().Back();
        }

        /// <summary>
        /// Click on review pipeline.
        /// </summary>
        private void ReviewPipeline()
        {
            //Click on review pipeline.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.ClassName("pipeline-btn"))).Click();
            Driver.Navigate().Back();
        }

        /// <summary>
        /// Click on tutorials in the header menu.
        /// </summary>
        private void ClickGetStarted()
        {
            //Click on tutorials
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.ClassName("get-started-btn"))).Click();
            Driver.Navigate().Back();
        }

        /// <summary>
        /// Select the pipeline to display.
        /// </summary>
        private void SelectThePipeline()
        {
            //Select the pipeline
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("selectedpipeline"))).Click();
            Element = Driver.FindElement(By.XPath("//div[@id='ddlpipelines']/li[1]/a/span[2]"));
            Click(Element);
        }

        /// <summary>
        /// Download  opportunity-pipeline breakdown chart(svg).
        /// </summary>
        private void OpportunityPipelineBreakdownChart()
        {
            //Download chart opportunity- pipeline breakdown(svg)
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMain")));
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id ='divdonutchart']")));
            Element = Driver.FindElement(By.XPath("//div[@class='apexcharts-menu-icon']"));
            Js().ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Click(Element);
            Element = Driver.FindElement(By.XPath("//div[@class='apexcharts-menu-item exportSVG']"));
            Click(Element);
        }

        /// <summary>
        /// Download opportunity-pipeline past 12 months chart(csv).
        /// </summary>
        private void OpportunityPipelineChart()
        {
            //Download chart opportunity pipeline past 12months(csv).         
            Driver.Navigate().Refresh();
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id ='divColumnChart']")));
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divColumnChart']/div/div[3]/div")));
            Js().ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divColumnChart']/div/div[3]/div/div[3]"))).Click();
        }

        /// <summary>
        /// Download impact-complexity chart(png).
        /// </summary>
        private void ImpactVsComplexity()
        {
            // Download chart impact VS complexity(png).
            Driver.Navigate().Refresh();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id ='divBubbleChart']")));
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divBubbleChart']/div/div[4]/div[6]")));
            Js().ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divBubbleChart']/div/div[4]/div[7]/div[2]"))).Click();
        }

        /// <summary>
        /// Download opportunity-timeline chart(png).
        /// </summary>
        private void OpportunityTimelineChart()
        {
            //Download chart opportunity-timeline(png).
            Driver.Navigate().Refresh();
            Js().ExecuteScript("window.scrollTo(0,3000)");
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id ='divOpportunityTimeline']")));
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divOpportunityTimeline']/div/div[3]/div")));
            Js().ExecuteScript("arguments[0].scrollIntoView(true);", Element);
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divOpportunityTimeline']/div/div[3]/div/div[2]"))).Click();
        }

        /// <summary>
        /// Open an opportunity from opportunity table.
        /// </summary>
        private void OpenTheOpportunity()
        {
            Js().ExecuteScript("window.scrollTo(0,1500)");
            //Open an opportunity.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblPipeline']/tbody/tr[2]/td[2]/a")));
            Click(Element);
            Driver.Navigate().Back();
        }

        /// <summary>
        /// Click on move opportunity.
        /// Select the pipeline to move the opportunity.
        /// </summary>
        private void MoveOpportunity()
        {
            Js().ExecuteScript("window.scrollTo(0,1500)");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMain")));
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@title='Change Pipeline']")));
            Click(Element);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divPickPipelineList']/div[3]/button")));
            Click(Element);
            Wait(2);
            Js().ExecuteScript("window.scrollTo(-200, 0)");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("selectedpipeline")));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='ddlpipelines']/li[3]/a"))).Click();
        }

        /// <summary>
        /// Click on add opportunity.
        /// Add information.
        /// </summary>
        private void AddTheOpportunity()
        {
            //Add Opportunity. 
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.ClassName("opprotunity-btn"))).Click();
            //Add name. 
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtOpportunityName"))).SendKeys("Test6547");

            //Inspecting approval date and sending inputs.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Name("ApprovalDate")));
            Element.Clear();
            Element.SendKeys(ApprovalDate);

            //Inspecting start date element and sending inputs.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='dtpOpportunityStartDate']")));
            Element.Clear();
            Element.SendKeys(StartDate);

            //Inspecting target go live date element and sending inputs.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='dtpOpportunityCompletionDate']")));
            Element.Clear();
            Element.SendKeys(TargetDate);
        }

        /// <summary>
        ///  Go to model tab and add model.
        /// </summary>
        private void AddModel()
        {
            //Go to model tab.
            Js().ExecuteScript("window.scrollTo(0,200)");
            Element = Driver.FindElement(By.Id("tab-Simulation-Model"));
            Click(Element);
            //Add new model.
            Element = Driver.FindElement(By.Id("btnProcessOpenModel"));
            Click(Element);
            Wait(2);
            //Link the model
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[1]/a")));
            Click(Element);
        }

        /// <summary>
        /// Go to benefit cost calculator tab.
        /// Enter details.
        /// </summary>
        private void AddBenefitCost()
        {
            Wait(3);
            //Go to benefit cost/calculator tab.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMain']/div[2]/div[2]/ul/li[5]/a/span[2]")));
            GetActions().MoveToElement(Element).Click(Element).Perform();

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divResults']/div/div/div/div[2]/div/input")));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("20000").Perform();

            //Service cost.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divResults']/div[1]/div/div/div[4]/div/input")));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("5000").Perform();

            //Save opportunity.         
            Element = Driver.FindElement(By.XPath("//div[@id='btnSaveOpportunity']/button[1]/i"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            GetWebDriverWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@id='tabsOpportunityContent']")));
        }
        #endregion

        #region End To End Testing
        [Test]
        public void EndToEndTests()
        {
            Login();
            ProcessFlow();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
            Pipelines();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
            BusinessArchitecture();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
            HomeFlow();

        }

        #endregion
    }
}