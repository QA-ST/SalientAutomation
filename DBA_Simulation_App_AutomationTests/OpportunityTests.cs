using NUnit.Framework;
using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;

namespace DBA_Simulation_App_AutomationTests
{
    [TestFixture]
    public class OpportunityTests : BaseClass
    {
        /// <summary>
        /// Create new opportunity.
        /// Add information.
        /// </summary>
        public void Info()
        {
            //Inspecting add opportunity element and sending inputs.         
            GetWebDriverWait()
                 .Until(ExpectedConditions.ElementToBeClickable(By.ClassName("opprotunity-btn"))).Click();

            //Inspecting enter name element and sending inputs.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("txtOpportunityName")));
            GetActions()
                .Click(Element)
                .SendKeys("Opportunity Test").Perform();
            Console.WriteLine("Enter Name");

            //Inspecting pipeline options element and sending inputs.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("ddlPipeline")));
            Select().SelectByIndex(2);
            Console.WriteLine("Select Pipeline Options");

            //Inspecting summary element and sending inputs.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtFileDescription")))
                .SendKeys(" process of Selling some goods.");
            Console.WriteLine("Enter Summary");

            //Inspecting source options element and sending inputs.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id='ddlOpportunitySource']")));
            Select().SelectByIndex(3);
            Console.WriteLine("Enter Source Options");

            //Inspecting department element and sending inputs.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@class='select2-search__field'])[1]")))
                .SendKeys("Human Resource" + Keys.Enter);
            Console.WriteLine("Enter Departments");

            //Inspecting sponsor element and sending inputs.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Sponsor']")))
                .SendKeys("Jack");
            Console.WriteLine("Enter Sponser");

            //Inspecting process owner element and sending inputs.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='ProcessOwner']")))
                .SendKeys("Amit");
            Console.WriteLine("Enter Process Owner");

            //Inspecting  core system element and sending inputs.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@class='select2-search__field'])[2]")))
                .SendKeys("Time Saved" + Keys.Enter);
            Console.WriteLine("Enter Core System");

            //Inspecting automation alignment element and sending inputs.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@class='select2-search__field'])[3]")))
                .SendKeys("General Automation" + Keys.Enter);
            Console.WriteLine("Enter Automation Alignment");

            //Inspecting business benefit element and sending inputs.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='Add or Select a Benefit']")))
                .SendKeys("Accuracy" + Keys.Enter);
            Console.WriteLine("Enter Business Benefits");

            //Inspecting goals element and sending inputs.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='Select organizational goals related']"))).SendKeys(Keys.ArrowDown + Keys.Enter);
            Console.WriteLine("Enter organizational goal");

            //Inspecting capabilities and sending inputs.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@placeholder='Select capabilities impacted']")))
                .SendKeys(Keys.ArrowDown + Keys.Enter);
            Console.WriteLine("Enter Capabilities");

            //Inspecting approval date and sending inputs.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Name("ApprovalDate")));
            Element.Clear();
            Element.SendKeys(ApprovalDate);
            Console.WriteLine("Enter ApprovalDate ");

            //Inspecting start date element and sending inputs.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='dtpOpportunityStartDate']")));
            Element.Clear();
            Element.SendKeys(StartDate);
            Console.WriteLine("Enter StartDate");

            //Inspecting target go live date element and sending inputs.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='dtpOpportunityCompletionDate']")));
            Element.Clear();
            Element.SendKeys(TargetDate);
            Console.WriteLine("Enter TargetGoLiveDate");
        }

        /// <summary>
        /// Go to model tab.
        /// Click on new model.
        /// Add model from predefined templates.
        /// Save the oppoetunity. 
        /// </summary>
        public void UseAPredefinedTemplate()
        {
            Model();                     
            //Save opportunity.
            Element = Driver.FindElement(By.XPath("//div[@id='btnSaveOpportunity']/button[1]/i"));
            Click(Element);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='swal2-success-circular-line-right']")));
            GetWebDriverWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='oportuinityPage']")));
            Wait(7);
        }

        /// <summary>
        /// Open Model in Opportunity
        /// </summary>  
        private void Model()
        {
            //Inspecting model Element  and Sending Inputs
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("tab-Simulation-Model"))).Click();
            Console.WriteLine("Select model");

            //Inspecting  New Model Element and Sending Inputs
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("btnProcessOpenModel"))).Click();
            Console.WriteLine("Select New Model-'Accountng Services'");

            //Add a new model.           
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects_filter']/label/input")));
            Element.Clear();
            Element.SendKeys("Accounting Services");
            GetWebDriverWait()
           .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[1]/a"))).Click();
            Wait(7);
        }

        /// <summary>
        /// Go to discovery tab and discover automation.
        /// Click on actions and save progress.
        /// </summary>
        public void Discovery()
        {
            AutomationDiscovery();
            //Inspecting   Action Button Element and Sending Inputs   
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='actionsResultSimulation']"))).Click();
            Console.WriteLine("Click on Action Button");

            //Inspecting   Save Progress Element and Sending Inputs
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//ul[@id='divGettingStartedSimulationResult3']/li[9]/a"))).Click();
            Console.WriteLine("Click on Save Progess");

        }

        /// <summary>
        /// Click on actions and run simulation.
        /// Click actions and save progress.
        /// </summary>
        public void Simulation()
        {
            RunSimulation();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divMainTab']/div/div[1]/div[2]/div/div[4]"))).Click();
            Js().ExecuteScript("window.scrollTo(0,1000)");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedSimulation6']/div[5]/div[2]/div[1]/div/label/span"))).Click();

            //Click on Run Simulation.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnRunAnalysis']"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@id='tblSummary_wrapper']")));
        }

        /// <summary>
        /// Click on actions.
        /// Click on benefit cost calculator.
        /// Enter the details.
        /// </summary>
        public void BenefitCost()

        {
            //Click on benefit cost calculator.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnValue']")))
                              .Click();

            //Change the default values.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("txtActivitiesPerDayWizard")));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("1.5").Perform();
         
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtCurrentCostWizard']")));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("225").Perform();            

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtNewCostWizard']")));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("200").Perform();

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='addInvestmentAutomation']"))).Click();

            //Click on Let's see the results.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@onclick='ShowResult()']"))).Click();
            Wait(2);
            //Click save changes button.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSaveValueOpportunity']/i"))).Click();

            // Inspecting  Benefit Cost Element and Sending Inputs
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='tab-CostBenefit']"))).Click();
            Console.WriteLine("Click on Benefit Cost");

            // Total benefit
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divResults']/div/div/div/div[2]/div/input")));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("2000").Perform();

            // Service cost
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divResults']/div[1]/div/div/div[4]/div/input")));
            GetActions().Click(Element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("6000").Perform();

        }

        /// <summary>
        /// Go to score tab and add score.
        /// </summary>
        public void Score()
        {
            //Click on the Score tab
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tab-Score"))).Click();
            Console.WriteLine("Go to Score Tab");

            //Enter the Materiality Button
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("score0")));
            Element.Clear();
            Element.SendKeys("3");

            //Click on the Suitability Button 
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("score1")));
            Element.Clear();
            Element.SendKeys("2");
            Console.WriteLine("Enter Suitability");

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='score2']")));
            Element.Clear();
            Element.SendKeys("-2");
        }

        /// <summary>
        /// Go to planning and documents.
        /// </summary>
        public void Planning()
        {
            //Click on Planing.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tab-Planning"))).Click();
            Console.WriteLine("Enter Planning");

            //Click on Documents.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tab-Documentation"))).Click();
            Console.WriteLine("Click on Documents");
        }

        /// <summary>
        /// Go to comments tab.
        /// Add comment.
        /// Save the opportunity.
        /// Click on actions.
        /// Run simulation.
        /// </summary>
        public void Comment()
        {
            //Click on Comments Tab
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tab-Comments"))).Click();
            Console.WriteLine("Enter Comments");

            //Write a comment
            GetWebDriverWait().
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//textarea[@placeholder='Enter new comment...']")))
                .SendKeys("We are adding comments");
            try
            {
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='row add-comment']/div/a/i"))).Click();
            }
            catch
            {
                GetWebDriverWait()
                    .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divAddComment']/div/a/i"))).Click();
            }
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='swal2-actions']/button"))).Click();

            Wait(2);
            Js().ExecuteScript("window.scrollTo(500,0)");
            //Saving the Opportunity.
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='btnSaveOpportunity']/button[1]/i"))).Click();
            Console.WriteLine("Enter SaveOpportunity");
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("txtOpportunityName")));
        }

        /// <summary>
        /// Select the pipeline where opportunity is saved
        /// </summary>
        public void SelectPipeline()
        {
            //Select the Pipeline
            GetWebDriverWait()
          .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='selectPipeline']/a"))).Click();
             GetWebDriverWait()
            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='ddlPipelines']/li[3]"))).Click();
        }

        [Test]
        [Property("Priority", "Highest")]
        public void Opportunity()
        {
            Login();
            Info();
            UseAPredefinedTemplate();
            Wait(6);
            Discovery();
            Simulation();
            BenefitCost();
            Score();
            Planning();            
            Comment();
            SearchCreatedOpportunity();
            Element.SendKeys(Opportunities[3]);
            SelectPipeline();           
            DeleteCreatedOpportunity();
        }
    }
}
