using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;

namespace DBA_Simulation_App_AutomationTests
{    
    public class DashboardFlow : BaseClass
    {        
        /// <summary>
        /// Go to create new dashboard.
        /// Add row at the end.
        /// Add charts in the widgets.
        /// </summary>

        [Test]
        public void Dashboard()
        {
            Login();
            GetWebDriverWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@id='divWelcome']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[3]")))).Click();

            //Click on dashboard navigation tab
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[3]/ul/li[4]/a"))).Click();
            //Add a row at the end
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedDashboard1']/div[1]/button"))).Click();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedDashboard1']/div[1]/div/div/div/div/button[2]"))).Click();

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMainDashboard")));

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[2]/button[2]")));
            FirstWidget();
            SecondWidget();
            ThirdWidget();
            FourthWidget();
            FifthWidget();
            SixthWidget();
            SeventhWidget();
            EightWidget();
            NinthWidget();
            MoveEntireRow();
            ChangeDashboardName();
            RunSimulationAndDiscoverAutomation();
            DownloadTable();
            Wait(3);
            DeleteRow();
            SetDefaultDashboard();
            EditNameAndDeleteDashboard();
            OpenYourDefaultDashboard();
        }
        #region Widgets
        /// <summary>
        /// Add charts in the widgets.
        /// </summary>
        private void FirstWidget()
        {
            IWebElement elementFirstDiv = GetWebDriverWait()
                            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]/div[1]/div")));
            GetActions().MoveToElement(elementFirstDiv).Perform();

            IWebElement insertChart = GetWebDriverWait()
                            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]/div[1]/div/button/i")));
            GetActions().Click(insertChart).Perform();

            IWebElement pipelineChart = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#modalCharts>div>div>div.modal-body>div.row.mt-6.mb-6>div:nth-child(1)>button:nth-child(4)")));
            pipelineChart.Click();
        }
        private void SecondWidget()
        {
            //Artifact Counts – Opportunities
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMainDashboard")));
            IWebElement elementSecondDiv = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]/div[2]/div")));
            GetActions().MoveToElement(elementSecondDiv).Perform();
            IWebElement insertSecondChart = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]/div[2]/div/button/i")));
            GetActions().Click(insertSecondChart).Perform();

            IWebElement opportunityChart = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[1]/div[1]/button[2]")));
            opportunityChart.Click();
        }
        private void ThirdWidget()
        {
            //Artifact Counts -Experiments
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMainDashboard")));
            IWebElement elementThirdDiv = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]/div[3]/div")));
            GetActions().MoveToElement(elementThirdDiv).Perform();
            IWebElement insertThirdChart = GetWebDriverWait().
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]/div[3]/div/button/i")));
            GetActions().MoveToElement(elementThirdDiv).Click(insertThirdChart).Perform();

            IWebElement experimentsChart = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[1]/div[1]/button[3]")));
            experimentsChart.Click();
        }
        private void FourthWidget()
        {
            //Artifact Counts -Experiments
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMainDashboard")));
            IWebElement elementFourthDiv = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]/div[4]/div")));
            GetActions().MoveToElement(elementFourthDiv).Perform();
            IWebElement insertFourthChart = GetWebDriverWait().
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]/div[4]/div/button/i")));
            GetActions().Click(insertFourthChart).Perform();

            IWebElement taskChart = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[1]/div[1]/button[4]")));
            taskChart.Click();
        }
        private void FifthWidget()
        {
            //Pipeline / Opportunity - Pipeline summary
            IWebElement elementFifthDiv = GetWebDriverWait()
            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[2]/div[1]/div")));
            GetActions().MoveToElement(elementFifthDiv).Perform();
            IWebElement insertFifthChart = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[2]/div/div/button/i")));
            Click(insertFifthChart);

            IWebElement opportunitiesChart = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[1]/div[3]/button[1]")));
            Click(opportunitiesChart);
        }
        private void SixthWidget()
        {
            //Pipeline/Opportunity - Opportunity breakdown
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMainDashboard")));
            IWebElement elementSixthDiv = GetWebDriverWait()
                .Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='divMainDashboard']/div[2]/div[2]/div")));
            GetActions().MoveToElement(elementSixthDiv).Perform();
            IWebElement insertSixthChart = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[2]/div[2]/div/button/i")));
            Click(insertSixthChart);

            IWebElement experimentChart = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[1]/div[3]/button[2]")));
            Click(experimentChart);
        }
        private void SeventhWidget()
        {
            try
            { AddWidget7(); }

            catch (Exception)
            {
                if (Element.Displayed)
                {
                    Element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[2]/button[2]")));
                    Element.Click();
                    AddWidget7();
                }
                else
                {
                    AddWidget7();
                }
            }
        }
        private void AddWidget7()
        {
            Js().ExecuteScript("window.scrollTo(0,1000)");
            //Pipeline/Opportunity - Impact/Complexity
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMainDashboard")));
            IWebElement elementSeventhDiv = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='divMainDashboard']/div[3]/div/div")));
            GetActions().MoveToElement(elementSeventhDiv).Perform();
            IWebElement insertSeventhChart = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[3]/div/div/button/i")));
            Click(insertSeventhChart);

            IWebElement painVSGainChart = GetWebDriverWait()
            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[1]/div[2]/div/div[2]/button[3]")));
            Click(painVSGainChart);
        }
        private void EightWidget()
        {
            try
            { AddWidget8(); }
          
            catch (Exception)
            {
                if (Element.Displayed)
                {
                    Element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[2]/button[2]")));
                    Element.Click();
                    AddWidget8();
                }
                else
                {
                    AddWidget8();
                }
            }
}
        private void AddWidget8()
        {
            Js().ExecuteScript("window.scrollTo(0,1500)");
            Wait(2);
            //Experiments – Experiment Summary
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMainDashboard")));
            IWebElement elementEightDiv = GetWebDriverWait().
                Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='divMainDashboard']/div[4]/div[2]/div")));
            GetActions().MoveToElement(elementEightDiv).Perform();
            IWebElement insertEightChart = GetWebDriverWait().
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[4]/div[2]/div/button/i")));
            Click(insertEightChart);
            IWebElement opportunityPipelineChart = GetWebDriverWait()
         .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[1]/div[2]/div/div[1]/button[1]")));
            Click(opportunityPipelineChart);
        }
        private void NinthWidget()
        {
            try
            { AddWidget9(); }

            catch (Exception)
            {
                if (Element.Displayed)
                {
                    Element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[2]/button[2]")));
                    Element.Click();
                    AddWidget9();
                }
                else
                {
                    Js().ExecuteScript("window.scrollTo(0,1500)");
                    AddWidget9();
                }
            }
        }
        private void AddWidget9()
        {
            Wait(3);
            //Pipeline/Opportunity - Opportunity timeline
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("divMainDashboard")));
            IWebElement elementNinthDiv = GetWebDriverWait()
                .Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='divMainDashboard']/div[4]/div/div")));
            GetActions().MoveToElement(elementNinthDiv).Perform();
            IWebElement insertNinthChart = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[4]/div/div/button/i")));
            Click(insertNinthChart);
            IWebElement tasksChart = GetWebDriverWait()
            .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[1]/div[3]/button[3]")));
            Click(tasksChart);
        }
        #endregion

        /// <summary>
        /// Move the entire row to third position.
        /// </summary>
        private void MoveEntireRow()
        {
            Wait(2);
            try { DragAndDropRow(); }            
            catch (Exception)
            {
                if (Element.Displayed)
                {
                    Element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='modalCharts']/div/div/div[2]/div[2]/button[2]")));
                    Element.Click();
                    DragAndDropRow();
                }
                else
                {
                    DragAndDropRow();
                }
            }
        }
        private void DragAndDropRow()
        {
            IWebElement row = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h3[contains(text(),'Pain vs Gain')]")));
            GetActions().MoveToElement(row).Perform();
            IWebElement row2 = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divMainDashboard']/div[1]")));

            IWebElement button = GetWebDriverWait()
                 .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h3[contains(text(),'Pain vs Gain')]//following::button[@data-original-title='Move Entire Row'][1]")));
            GetActions().DragAndDrop(button, row2).Perform();

        }

        /// <summary>
        /// Delete the second row of dashboard.
        /// </summary>
        private void DeleteRow()
        {    
            //Delete second row
           IWebElement  findRow= GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]")));
            GetActions().MoveToElement(findRow).Perform();
           IWebElement deleteButton=  GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divMainDashboard']/div[1]/div[2]/div[2]/button/i")));
            GetActions().MoveToElement(deleteButton).Click(deleteButton).Perform();
        }

        /// <summary>
        /// Change the name of created dashboard.
        /// </summary>
        private void ChangeDashboardName()
        {
            //Change dashboard name
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@onclick='EditDashboardName()']"))).Click();
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='txtDashboardName']")));
            Element.Click();
            Element.Clear();
            Element.SendKeys("Automated Dashboard");
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@onclick='SaveDashboardName()']"))).Click();
        }

        /// <summary>
        /// Download the opportunity table from the widget.
        /// Download the bpmn diagram and delete and experiment from the table.
        /// </summary>
        private void DownloadTable()
        {
            Js().ExecuteScript("window.scrollTo(0,100)");
            //Download opportunity table.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@chart-name='tableopportunities']")));
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline4']/div[2]/button")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedPipeline4']/div[2]/div[2]/div/a[5]"))).Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline4']/div[2]/button")));
            GetActions().MoveToElement(Element).Click(Element).Perform();

            //Delete an experiment and download BPMN diagram 
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@chart-name='experiements']")));

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedLab2']/a[2]/i"))).Click();

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[12]/div/a[3]"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='swal2-actions']/button[2]"))).Click();
        }

        /// <summary>
        /// Open an experiment from the experiment table.
        /// Run simulation for the opened experiment.
        /// Discover automation for the opened experiment.
        /// </summary>
        private void RunSimulationAndDiscoverAutomation()
        {
            //Open Run simulate process in a new tab
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@title='Process Table']")));

            //Search the Process
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects_filter']/label/input")));
            Element.Clear();
            Element.SendKeys("Accounting");
            GetWebDriverWait()                
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[2]/a"))).Click();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedProject1']")));
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='actionsResultSimulation']"))).Click();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='runSimulation']"))).Click();
            Driver.Navigate().Back();

            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divProjectDetails']")));

            //Open discovery process in a new tab
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='actionsResultSimulation']"))).Click();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedSimulationResult3']/li[1]/a/span[2]"))).Click();
            Driver.Navigate().Back();
            Driver.Navigate().Back();
        }

        /// <summary>
        /// Publish the created dashboard.
        /// Click on set default dashboard.
        /// Set the created dashboard as default dashboard.
        /// </summary>
        private void SetDefaultDashboard()
        {
            //Publish dashboard (it must be available for all the users in the same account ID)
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedDashboard2']/a[1]"))).Click();

            //Click on set up your default dashboard
            Element= GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(Driver.FindElement(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[3]"))));
            GetActions().MoveToElement(Element).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[3]/ul/li[2]/a"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divdashboardList']/div[1]/div/div[2]/div/button[2]"))).Click();
        }

        /// <summary>
        /// Click the set your default dashboard.
        /// Change the name of existing dashboard.
        /// Delete the existing dashboard.
        /// </summary>
        private void EditNameAndDeleteDashboard()
        {
            //Change name of another dashboard and click in the pencil icon (edit)
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divdashboardList']/div[2]/div/div/input")));
            Element.Clear();
            Element.SendKeys("Created dashboard");
            Wait(4);
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divdashboardList']/div[2]/div/div[2]/div/button[3]"))).Click();
            Wait(3);

            //Delete another dashboard
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divdashboardList']/div[3]/div/div[2]/div/button[1]"))).Click();
            GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='swal2-actions']/button[1]"))).Click();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomeURLTest"));
        }

        /// <summary>
        /// Go to homepage and the default dashboard. 
        /// </summary>
        private void OpenYourDefaultDashboard()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@onclick='DisplayDefaultDashbaord()']"))).Click();
        }

    }
}
