using Automation.Helpers;
using Automation.Resources.Data;
using Automation.Resources.Locators;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Reflection.Metadata;

namespace Automation.PageObjects
{
    public class ProcessDetails : BaseClass
    {
        #region Create and Import Process

        public void CreateNewProcess()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.createProcess))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(ProcessPage.modeler)));
        }

        public void CreatePool()
        {
            IWebElement fitToCanvas = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'bc-diagram__buttons')]/div/i")));
            IWebElement addPool = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.pool)));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", fitToCanvas);
            CommonMethods.Wait(2);
            IWebElement modeler = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.modeler)));
            CommonMethods.GetActions().ClickAndHold(addPool).MoveByOffset(30, -20).Release(addPool).Perform();
            CommonMethods.Wait(2);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[name()='g' and contains(@class,'cnt root shape rect')]")));
            IWebElement addSwimlanes = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.swimLane)));
            CommonMethods.GetActions().ClickAndHold(addSwimlanes).DragAndDrop(addSwimlanes, element).Release(addSwimlanes).Perform();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'bc-diagram__buttons')]/div/i")));
            element.Click();
        }

        public void AddFirstActivity()
        {
            IWebElement addToLane = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[name()='rect' and contains(@class,'swimlane-diag-cnt-bg body')]")));
            IWebElement start = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.startEvent)));
            CommonMethods.GetActions().ClickAndHold(start).MoveToElement(addToLane).Release(start).Perform();
            IWebElement moveStart = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.start)));
            CommonMethods.GetActions().ClickAndHold(moveStart).MoveByOffset(300, 0).Release(moveStart).Perform();
            IWebElement clickStart = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.port)));
            IWebElement lineConnect = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.port)));
            CommonMethods.GetActions().MoveToElement(clickStart).ClickAndHold(lineConnect).MoveByOffset(200, 0).Release().Perform();
            IWebElement selectFirstActivity = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.selectActivity)));
            selectFirstActivity.Click();

        }

        public void AddSecondActivity()
        {
            IWebElement pool = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.swimLane)));
            IWebElement firstActivity = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.firstActivity)));
            IWebElement lineConnect = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.selectFirstActivityPort)));
            CommonMethods.GetActions().MoveToElement(firstActivity).ClickAndHold(lineConnect).MoveByOffset(200, 0).Release().Perform();
        }

        public void AddEndEvent()
        {
            IWebElement selectSecondActivity = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.selectActivity)));
            selectSecondActivity.Click();
            IWebElement secondActivityHover = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.secondActivity)));
            IWebElement endPointConnect = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.selectSecondActivityPort)));
            CommonMethods.GetActions().MoveToElement(secondActivityHover).ClickAndHold(endPointConnect).MoveByOffset(80, 0).Release().Perform();
            IWebElement endEvent = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.endPoint)));
            endEvent.Click();
        }

        public void EditActivityNames()
        {
            IWebElement firstActivityName = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.firstActivity)));
            CommonMethods.GetActions().DoubleClick(firstActivityName).KeyDown(Keys.Control).SendKeys("a" + Keys.Backspace).KeyUp(Keys.Control).SendKeys("Activity 1").Perform();
            IWebElement secondActivityNAme = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.secondActivity)));
            CommonMethods.GetActions().DoubleClick(secondActivityNAme).KeyDown(Keys.Control).SendKeys("a" + Keys.Backspace).KeyUp(Keys.Control).SendKeys("Activity 2").Perform();

        }

        public void SaveProcess()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.saveDropdown))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.saveAndClose))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("(//div[contains(@class,'process-details')])[1]")));
        }

        #endregion

        #region Edit Process
        public void ClickEdit()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.editButton))).Click();
        }

        public void EditName()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.processName)));
            element.Clear();
            element.SendKeys(ProcessData.GeneralDetails.name);
        }

        public void AddProcessOwner()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.processOwner))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.onwerInput)));
            element.SendKeys(ProcessData.GeneralDetails.processOwner);
            string xpath = string.Format(ProcessGeneralDetails.selectOwner, ProcessData.GeneralDetails.processOwner);
            Console.WriteLine(xpath);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).Click();
        }

        public void AddProcessTag()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.processTag)));
            element.SendKeys(ProcessData.GeneralDetails.processTag);
            driver.FindElement(By.XPath("//ul[@role='listbox']/li[contains(text(),'" + ProcessData.GeneralDetails.processTag + "')]")).Click();
        }

        public void AddProcessStage()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.processStage)));
            CommonMethods.Select().SelectByText(ProcessData.GeneralDetails.stage);
        }

        public void AddDescription()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.descriptionButton))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.description)));
            element.SendKeys(ProcessData.GeneralDetails.description);
        }

        public void AddObjective()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.objectiveButton))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.objective)));
            element.SendKeys(ProcessData.GeneralDetails.objective);
        }

        public void AddScope()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.scopeButton))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.scope)));
            element.SendKeys(ProcessData.GeneralDetails.scope);
        }

        public void SaveGeneralDetails()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.saveDropdown))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.saveAndClose))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//h2[text()='Changes Saved!']")));
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h1[text()='Process Details']")));
        }

        #endregion

        #region Searchable properties    
        public void EditSearchableTimeProperties()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessGeneralDetails.editButton))).Click();
            CommonMethods.Wait(2);
            try
            {
                element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableTimeProperties.editFirstActivity)));
                CommonMethods.GetActions().MoveToElement(element).Click(element).Perform();
            }
            catch (Exception ex)
            {
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableTimeProperties.editFirstActivity))).Click();
            }
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableTimeProperties.editWorkTime)));
            CommonMethods.GetActions().Click(element).KeyDown(Keys.Control).SendKeys("a" + Keys.Backspace).KeyUp(Keys.Control).SendKeys(ProcessData.SearchableTimePropertiesDetails.workTime).Perform();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableTimeProperties.workTimeColumn)));
            CommonMethods.Select().SelectByText(ProcessData.SearchableTimePropertiesDetails.selectWorkTime);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableTimeProperties.editWaitTime)));
            CommonMethods.GetActions().Click(element).KeyDown(Keys.Control).SendKeys("a" + Keys.Backspace).KeyUp(Keys.Control).SendKeys(ProcessData.SearchableTimePropertiesDetails.waitTime).Perform();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableTimeProperties.waitTimeColumn)));
            CommonMethods.Select().SelectByText(ProcessData.SearchableTimePropertiesDetails.selectWaitTime);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableTimeProperties.editDueTime)));
            CommonMethods.GetActions().Click(element).KeyDown(Keys.Control).SendKeys("a" + Keys.Backspace).KeyUp(Keys.Control).SendKeys(ProcessData.SearchableTimePropertiesDetails.dueTime).Perform();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableTimeProperties.dueTimeColumn)));
            CommonMethods.Select().SelectByText(ProcessData.SearchableTimePropertiesDetails.selectDueTime);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableTimeProperties.valueAfterColumn)));
            CommonMethods.Select().SelectByText(ProcessData.SearchableTimePropertiesDetails.selectValueAdded);
        }

        public void EditSearchableProperties()
        {
            AddActivityDescription();
            AddCost();
            AddSystems();
            AddAssets();
            AddRACI();
            AddSIPOC();
        }
        private static void AddActivityDescription()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.description))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.editDescription)));
            CommonMethods.GetActions().Click(element).SendKeys(ProcessData.SearchablePropertiesDetails.activityDescription).Perform();
        }
        private void AddCost()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.clickCostIcon))).Click();

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addCost)));
            CommonMethods.GetActions().Click(element).KeyDown(Keys.Control).SendKeys("a" + Keys.Backspace).KeyUp(Keys.Control).SendKeys(ProcessData.SearchablePropertiesDetails.costColumn).Perform();

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.costCurrency)));
            CommonMethods.Select().SelectByText(ProcessData.SearchablePropertiesDetails.currency);

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.costTab)));
            CommonMethods.GetActions().Click(element).KeyDown(Keys.Control).SendKeys("a" + Keys.Backspace).KeyUp(Keys.Control).SendKeys(ProcessData.SearchablePropertiesDetails.costData).Perform();

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.selectInstance)));
            CommonMethods.Select().SelectByText(ProcessData.SearchablePropertiesDetails.instances);

        }
        public void AddSystems()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.systemIcon))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.system))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addSystem)));
            element.SendKeys(ProcessData.SearchablePropertiesDetails.system);
            string xpath = string.Format(ActivitySearchableProperties.selectValue, ProcessData.SearchablePropertiesDetails.system);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).Click();

        }
        public void AddAssets()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.assetsIcon))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.assets))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addAssets)));
            element.SendKeys(ProcessData.SearchablePropertiesDetails.asset);
            string xpath = string.Format(ActivitySearchableProperties.selectValue, ProcessData.SearchablePropertiesDetails.asset);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).Click();
        }
        public void AddRACI()
        {
            IWebElement element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@id,'ActivityDetailsEditorTab')]//div[contains(@class,'LinkedOpportunities')]")));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.raciIcon))).Click();
            CommonMethods.Wait(2);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.accountable))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addAccountable)));
            element.SendKeys(ProcessData.SearchablePropertiesDetails.accountable);
            string xpath = string.Format(ActivitySearchableProperties.selectValue, ProcessData.SearchablePropertiesDetails.accountable);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).Click();

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.consulted))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addConsulted)));
            element.SendKeys(ProcessData.SearchablePropertiesDetails.consulted);
            string xpath1 = string.Format(ActivitySearchableProperties.selectValue, ProcessData.SearchablePropertiesDetails.consulted);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath1))).Click();


            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.informed))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addInformed)));
            element.SendKeys(ProcessData.SearchablePropertiesDetails.informed);
            string xpath2 = string.Format(ActivitySearchableProperties.selectValue, ProcessData.SearchablePropertiesDetails.informed);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath2))).Click();
        }
        public void AddSIPOC()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.sipocIcon))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.supplier))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addSupplier)));
            element.SendKeys(ProcessData.SearchablePropertiesDetails.supplier);
            string xpath = string.Format(ActivitySearchableProperties.selectValue, ProcessData.SearchablePropertiesDetails.supplier);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).Click();

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.input))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addInput)));
            element.SendKeys(ProcessData.SearchablePropertiesDetails.input);
            string xpath1 = string.Format(ActivitySearchableProperties.selectValue, ProcessData.SearchablePropertiesDetails.input);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath1))).Click();

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.output))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addOutput)));
            element.SendKeys(ProcessData.SearchablePropertiesDetails.output);
            string xpath2 = string.Format(ActivitySearchableProperties.selectValue, ProcessData.SearchablePropertiesDetails.output);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath2))).Click();

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.customer))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ActivitySearchableProperties.addCustomer)));
            element.SendKeys(ProcessData.SearchablePropertiesDetails.customer);
            string xpath3 = string.Format(ActivitySearchableProperties.selectValue, ProcessData.SearchablePropertiesDetails.customer);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath3))).Click();
        }
        
        #endregion       

        #region Verify general details.
        public void VerifyDetails()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyGeneralDetails.nameOfProcess)));
            string a = element.Text; 
            Assert.IsTrue(a.Equals(ProcessData.GeneralDetails.name));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyGeneralDetails.ownerName)));
            string b = element.Text;
            Assert.IsTrue(b.Equals(ProcessData.GeneralDetails.processOwner));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyGeneralDetails.tagName)));
            string c = element.Text;
            Assert.IsTrue(c.Equals(ProcessData.GeneralDetails.processTag));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyGeneralDetails.currentStatus)));
            string d = element.Text;
            Assert.IsTrue(d.Equals(ProcessData.GeneralDetails.stage));

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyGeneralDetails.descriptionBtn))).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string descValue = (string)js.ExecuteScript("return document.querySelector('.descriptionEditWrapper textarea')?.value;");         
            Assert.IsTrue(descValue.Equals(ProcessData.GeneralDetails.description));

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyGeneralDetails.objectiveBtn))).Click();
            string objValue = (string)js.ExecuteScript("return document.querySelector('.objectivesEditWrapper textarea')?.value;");
            Assert.IsTrue(objValue.Equals(ProcessData.GeneralDetails.objective)); 

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyGeneralDetails.scopeBtn))).Click();
            string scopeValue = (string)js.ExecuteScript("return document.querySelector('.scopeEditWrapper textarea')?.value;");
            Assert.IsTrue(scopeValue.Equals(ProcessData.GeneralDetails.scope));
        }

        #endregion

        #region Verify Searchable Properties Details       
        public void VerfiySearchableTimeProperties()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
            CommonMethods.Wait(8);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableTimeProperties.activityOne1))).Click();

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableTimeProperties.workTimeValue)));
            string a = element.Text;
            Assert.IsTrue(a.Equals(ProcessData.SearchableTimePropertiesDetails.workTime + " " + ProcessData.SearchableTimePropertiesDetails.selectWorkTime));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableTimeProperties.waitTimeValue)));
            string b = element.Text;
            Assert.IsTrue(b.Equals(ProcessData.SearchableTimePropertiesDetails.waitTime + " " + ProcessData.SearchableTimePropertiesDetails.selectWaitTime));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableTimeProperties.dueAfterValue)));
            string c = element.Text;
            Assert.IsTrue(c.Equals(ProcessData.SearchableTimePropertiesDetails.dueTime + " " + ProcessData.SearchableTimePropertiesDetails.selectDueTime));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableTimeProperties.valueAfterData)));
            string d = element.Text;
            Assert.IsTrue(d.Equals(ProcessData.SearchableTimePropertiesDetails.selectValueAdded));
        }
        public void VerfiyActivitySearchableProperties()
        {
            VerifySystem();
            VerifyAsset();
            VerifyCostDetails();
            VerifySIPOC();
            VerifyRACI();
            VerifyActivityDescription();
        }
        private static void VerifySystem()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessPage.activityOpenCloseLink))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifySystems)));
            string a = element.Text;
            Assert.IsTrue(a.Equals(ProcessData.SearchablePropertiesDetails.system));
        }
        private static void VerifyAsset()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyAssets)));
            string b = element.Text;
            Assert.IsTrue(b.Equals(ProcessData.SearchablePropertiesDetails.asset));
        }
        private static void VerifyCostDetails()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.openCost))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyCurrency)));
            string a = element.Text;
            Assert.IsTrue(a.Equals(ProcessData.SearchablePropertiesDetails.currency));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyValue)));
            string b = element.Text;
            Assert.IsTrue(b.Equals(ProcessData.SearchablePropertiesDetails.costData));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyFrequency)));
            string c = element.Text;
            Assert.IsTrue(c.Equals(ProcessData.SearchablePropertiesDetails.instances));

        }
        private static void VerifySIPOC()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifySupplier)));
            string c = element.Text;
            Assert.IsTrue(c.Equals(ProcessData.SearchablePropertiesDetails.supplier));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyInputs)));
            string d = element.Text;
            Assert.IsTrue(d.Equals(ProcessData.SearchablePropertiesDetails.input));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyOutputs)));
            string e = element.Text;
            Assert.IsTrue(e.Equals(ProcessData.SearchablePropertiesDetails.output));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyCustomers)));
            string f = element.Text;
            Assert.IsTrue(f.Equals(ProcessData.SearchablePropertiesDetails.customer));
        }
        private static void VerifyRACI()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyAccountable)));
            string a = element.Text;
            Assert.IsTrue(a.Equals(ProcessData.SearchablePropertiesDetails.accountable));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyConsulted)));
            string b = element.Text;
            Assert.IsTrue(b.Equals(ProcessData.SearchablePropertiesDetails.consulted));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyInformed)));
            string c = element.Text;
            Assert.IsTrue(c.Equals(ProcessData.SearchablePropertiesDetails.informed));

        }
        private static void VerifyActivityDescription()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifySearchableProperties.verifyDescription)));
            string c = element.Text;
            Assert.IsTrue(c.Equals(ProcessData.SearchablePropertiesDetails.activityDescription));
        }
        #endregion
        public void DeleteTheCreatedProcess()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessHomePage.sidebar))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessHomePage.home))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessHomePage.searchbar)));
            element.SendKeys(ProcessData.GeneralDetails.name + Keys.Enter);
            CommonMethods.Wait(2);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessHomePage.deleteIcon))).Click();
        }
    }
}