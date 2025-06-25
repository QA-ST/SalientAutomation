
using Automation.Helpers;
using Automation.Resources.Data;
using Automation.Resources.Locators;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;



namespace Automation.PageObjects
{
    class OpportunityPage : BaseClass
    {
        public void CreateNewOpp()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Opportunityform.clickNewOppButton))).Click();
            CommonMethods.Wait(2);
            IWebElement opportunityName = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Opportunityform.opportunityName)));
            opportunityName.Click();
            opportunityName.SendKeys(NewOpportunityData.opportunityName);
            CommonMethods.Wait(2);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Opportunityform.selectPriority)));
            CommonMethods.Select().SelectByText(NewOpportunityData.selectOpportunityPriority);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Opportunityform.opportunityOwner))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Opportunityform.opportunityOwnerSearchBar)));
            element.Click();
            element.SendKeys(NewOpportunityData.ownerName);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Opportunityform.opportunityOwnerListBox))).Click();
            IWebElement opportunityDescription = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Opportunityform.opportunityDescription)));
            opportunityDescription.Click();
            opportunityDescription.SendKeys(NewOpportunityData.opportunityDescription);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Opportunityform.saveButton))).Click();
            CommonMethods.Wait(2);
        }
        public void EditButton()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(ClickEditButton.EditButton))).Click();
            CommonMethods.Wait(2);
        }
        
        public void AddOpportunityGeneralDetails()
        {
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityGeneralDetails.selectPriority)));
            CommonMethods.Select().SelectByText(OpportuntiyDetailsData.opportunityStatus);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityGeneralDetails.enterTags)));
            element.Click();
            element.SendKeys(OpportuntiyDetailsData.opportunityTag);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(OpportunityGeneralDetails.selectTag))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityGeneralDetails.clickSave))).Click();
        }

        public void AddProcess()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityDetails.processTab))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityDetails.associateProcessTab))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityDetails.clickSearch)));
            element.Click();
            element.SendKeys(OpportuntiyDetailsData.processName);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityDetails.clickCheckBox))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityDetails.clickSelect))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Opportunityform.saveButton))).Click();
        }

        #region Roi Calculator

        public void ROIAnalysis()
        {
            TimeHorizon();
            Addbenefits();
            AddCosts();
            AddBenefitEntry();
        }


        private void TimeHorizon()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityDetails.roiAnalysisTab))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.horizonButton))).Click();
            IWebElement timeHorizon = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.inputContainer)));
            CommonMethods.GetActions().Click(timeHorizon).KeyDown(Keys.Control).SendKeys("a" + Keys.Backspace).KeyUp(Keys.Control).SendKeys(RoiTabData.timeHorizon).Perform();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityGeneralDetails.clickSave))).Click();
        }

        private void Addbenefits()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.firstBenefit))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            element.SendKeys(RoiTabData.valueData);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();
            
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.secondBenefit))).Click();
            IWebElement secondBenefitData = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            CommonMethods.GetActions().Click(secondBenefitData).SendKeys(RoiTabData.valueData).Perform();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();
            
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.thirdBenefit))).Click();
            IWebElement thirdBenefitData = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            CommonMethods.GetActions().Click(thirdBenefitData).SendKeys(RoiTabData.valueData).Perform();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();
            
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.forthBenefit))).Click();
            IWebElement forthtBenefitData = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            CommonMethods.GetActions().Click(forthtBenefitData).SendKeys(RoiTabData.valueData).Perform();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();
            
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.fifthBenefit))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.recurrentRadioButton))).Click();
            IWebElement fifthBenefitData = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            CommonMethods.GetActions().Click(fifthBenefitData).SendKeys(RoiTabData.valueData).Perform();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();
        }

        private void AddCosts()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.firstCost))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            element.SendKeys(RoiTabData.valueData);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.secondCost))).Click();
            IWebElement secondBenefitData = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            CommonMethods.GetActions().Click(secondBenefitData).SendKeys(RoiTabData.valueData).Perform();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.thirdCost))).Click();
            IWebElement thirdBenefitData = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            CommonMethods.GetActions().Click(thirdBenefitData).SendKeys(RoiTabData.valueData).Perform();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.forthCost))).Click();
            IWebElement forthtBenefitData = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            CommonMethods.GetActions().Click(forthtBenefitData).SendKeys(RoiTabData.valueData).Perform();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();

            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.fifthCost))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.oneTimeRadioButton))).Click();
            IWebElement fifthBenefitData = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            CommonMethods.GetActions().Click(fifthBenefitData).SendKeys(RoiTabData.valueData).Perform();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveButton))).Click();
        }

        private void AddBenefitEntry()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.addEntryButton))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.addBenefitName)));
            element.Click();
            element.SendKeys(RoiTabData.benefitName);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.currencyColumn)));
            element.Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.changeCurrency))).Click();
            IWebElement BenefitValue = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.valueColumn)));
            CommonMethods.GetActions().Click(BenefitValue).SendKeys(RoiTabData.valueData).Perform();
            CommonMethods.Wait(2);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(RoiTab.saveBenefit))).Click();

        }

        #endregion

        #region Add Scores

        public void AddScores()
        {
            AddFeasibilityScoring();
            AddBenefitsScoring();
            AddStrategicImpactScoring();
        }

        private void AddFeasibilityScoring()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddFeasibityScores.clickScoresTab))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddFeasibityScores.addfeasibilityFirstScore)));
            CommonMethods.Select().SelectByText(FeasibilityScoresData.feasibilityFirstScoreData);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddFeasibityScores.addFeasibilitySecondScore)));
            CommonMethods.Select().SelectByText(FeasibilityScoresData.feasibilitySecondScoreData);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddFeasibityScores.addFeasibilityThirdScore)));
            CommonMethods.Select().SelectByText(FeasibilityScoresData.feasibilityThirdScoreData);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityGeneralDetails.clickSave))).Click();
        }

        private void AddBenefitsScoring()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddBenefitScores.clickBenefitsTab))).Click();
            CommonMethods.Wait(2);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddBenefitScores.addBenefitFirstScore)));
            CommonMethods.Select().SelectByText(benefitScoresData.benefitFirstScoreData);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddBenefitScores.addBenefitSecondScore)));
            CommonMethods.Select().SelectByText(benefitScoresData.benefitSecondScoreData);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddBenefitScores.addBenefitThirdScore)));
            CommonMethods.Select().SelectByText(benefitScoresData.benefitThirdScoreData);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityGeneralDetails.clickSave))).Click();
        }

        private void AddStrategicImpactScoring()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddStrategicImpactScores.clickStrategicImpactTab))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddStrategicImpactScores.addStrategicImpactFirstScore)));
            CommonMethods.Select().SelectByText(StrategicImpactScoresData.strategicImpactFirstScoreData);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddStrategicImpactScores.addStrategicImpactSecondScore)));
            CommonMethods.Select().SelectByText(StrategicImpactScoresData.strategicImpactSecondScoreData);
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(AddStrategicImpactScores.addStrategicImpactThirdScore)));
            CommonMethods.Select().SelectByText(StrategicImpactScoresData.strategicImpactThirdScoreData);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityGeneralDetails.clickSave))).Click();
        }
        #endregion


        #region Save Opportunity
        public void SaveOpportunity()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityDetails.clickSaveButton))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityDetails.clickSaveAndExitButton))).Click();
        }

        #endregion


        public void VerifyOppGeneralDetails()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyOppDetails.nameOfOpp)));
            string a = element.Text;
            Assert.IsTrue(a.Equals(NewOpportunityData.opportunityName));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyOppDetails.ownerName)));
            string b = element.Text;
            Assert.IsTrue(b.Equals(NewOpportunityData.ownerName));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyOppDetails.tagName)));
            string c = element.Text;
            Assert.IsTrue(c.Equals(OpportuntiyDetailsData.opportunityTag));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyOppDetails.priorityStatus)));
            string d = element.Text;
            Assert.IsTrue(d.Equals(NewOpportunityData.selectOpportunityPriority));

            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(VerifyOppDetails.checkStatus)));
            string e = element.Text;
            Assert.IsTrue(e.Equals(OpportuntiyDetailsData.opportunityStatus));
        }

        #region Delete Opportunity
        public void DeleteTheCreatedOpportunity()
        {
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityHomePage.sidebar))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityHomePage.home))).Click();
            element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityHomePage.searchbar)));
            element.SendKeys(NewOpportunityData.opportunityName);
            CommonMethods.Wait(2);
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityHomePage.deleteicon))).Click();
            CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(OpportunityHomePage.yesButton))).Click();
        }
        #endregion
    }
}
