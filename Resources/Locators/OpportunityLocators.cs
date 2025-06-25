using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Resources.Locators
{
    
            public static class NavigateToOpportunity
            {
                public static string moduleButton = "//button[@id='modulesDropdownBtn']";
                public static string clickOpportunityModule = "//p[text()='Opportunity Compass']";
            }
            public static class Opportunityform
            {
                public static string clickNewOppButton = "//p[text()='Create New Opportunity']";
                public static string opportunityName = "//input[@placeholder='Input Opportunity Name']";
                public static string selectPriority = "//select[@placeholder='Select Priority']";
                public static string opportunityOwner = "//span[text()='Select Opportunity Owner']";
                public static string opportunityOwnerSearchBar = "//input[@role='searchbox']";
                public static string opportunityOwnerSearch = "//input[@role='searchbox']";
                public static string opportunityOwnerListBox = "//ul[@role='listbox']";
                public static string opportunityDescription = "//div[contains(@class,'Textarea')]//textarea";
                public static string saveButton = "//button[text()='Save']";
            }
            public static class ClickEditButton
            {
                public static string EditButton = "//button[text()='Edit ']";
            }
            public static class OpportunityGeneralDetails
            {
                public static string selectPriority = "//select[@placeholder='Select Status']";
                public static string enterTags = "//textarea[@placeholder='Enter Tags']";
                public static string selectTag = "//li[text()='Tag 4']";
                public static string clickSave = "//button[text()='Save']";
                public static string clickSaveAndClose = "//div[text()='Save and Exit']";
                public static string clickSaveDropDown = "//div[@class='saveChangesDropdownWrapper']//button[2]";
            }
            
            public static class OpportunityDetails
            {
                public static string opportunityDescription = "//textarea[@placeholder='Add a description to explain this opportunity and its expected outcomes...']";
                public static string processTab = "//li[text()='Impacted Processes']";
                public static string roiAnalysisTab = "//li[text()='ROI Analysis']";
                public static string scoringTab = "//li[text()='Scoring']";
                public static string associateProcessTab = "//div[@class='emptyOppProcessAndProblemsCtaWrapper']//button";
                public static string clickSearch = "//div[@id='processListDatatable_filter']//input";
                public static string clickCheckBox = "//tr[@class='odd']//span";
                public static string clickSelect = "//button[text()='Select']";
                public static string clickScoring = "//li[text()='Scoring']";
                public static string clickScoreDropdown = "//div[@class='UserControl ScoringTable']//tr[2]//td[2]/div";
                public static string clickSaveButton = "//div[@class='saveChangesDropdownWrapper']//button[2]";
                public static string clickSaveAndExitButton = "//div[text()='Save and Exit']";

    }

            public static class OpportunityViewerPage
            {
               public static string opportunitySearchColumn = "//div[@id='opportunityListDatatable_filter']";
               public static string clickDeleteButton = "//tr[@class='odd'][1]//td[9]//button";
            }

            public static class AddFeasibityScores
            {
               public static string clickScoresTab = "//li[text()='Scoring']";
               public static string addfeasibilityFirstScore = "//div[contains(@class,'ScoringTable')]/table/tbody/tr[1]/td[2]//select";
               public static string addFeasibilitySecondScore = "//div[contains(@class,'ScoringTable')]/table/tbody/tr[2]/td[2]//select";
               public static string addFeasibilityThirdScore = "//div[contains(@class,'ScoringTable')]/table/tbody/tr[3]/td[2]//select";
            }

            public static class AddBenefitScores
            {
               public static string clickBenefitsTab = "//button[text()='Benefits']";
               public static string addBenefitFirstScore = "//div[contains(@class,'ScoringTable')]/table/tbody/tr[1]/td[2]//select";
               public static string addBenefitSecondScore = "//div[contains(@class,'ScoringTable')]/table/tbody/tr[2]/td[2]//select";
               public static string addBenefitThirdScore = "//div[contains(@class,'ScoringTable')]/table/tbody/tr[3]/td[2]//select";
            }


            public static class AddStrategicImpactScores
            {
               public static string clickStrategicImpactTab = "//button[text()='Strategic Impact']";
               public static string addStrategicImpactFirstScore = "//div[contains(@class,'ScoringTable')]/table/tbody/tr[1]/td[2]//select";
               public static string addStrategicImpactSecondScore = "//div[contains(@class,'ScoringTable')]/table/tbody/tr[2]/td[2]//select";
               public static string addStrategicImpactThirdScore = "//div[contains(@class,'ScoringTable')]/table/tbody/tr[3]/td[2]//select";
            }

            public static class OpportunityHomePage
            {
               public static string sidebar = "//div[@id='navSidebar']";
               public static string home = "//a[text()='Opportunity']";
               public static string searchbar = "//input[@placeholder='Search']";
               public static string deleteicon = "//button[contains(@class,'action-button')]";
               public static string yesButton = "//button[text()='Yes']";
            }

            public static class RoiTab
            {
               public static string horizonButton = "//div[@class='horizonButton']";
               public static string inputContainer = "//div[contains(@class,'periodInputContainer')]";
               public static string saveButton = "//*[contains(@class,'c-modal-sm show')]//button[text()='Save']";
               public static string firstBenefit = "//tr[@class='benefit '][1]//i[1]";
               public static string secondBenefit = "//tr[@class='benefit '][2]//i[1]";
               public static string thirdBenefit = "//tr[@class='benefit '][3]//i[1]";
               public static string forthBenefit = "//tr[@class='benefit '][4]//i[1]";
               public static string fifthBenefit = "//tr[@class='benefit '][5]//i[1]";
               public static string valueColumn = "//input[@placeholder='Value']";
               public static string firstCost = "//tr[@class='cost '][1]//i[1]";
               public static string secondCost = "//tr[@class='cost '][2]//i[1]";
               public static string thirdCost = "//tr[@class='cost '][3]//i[1]";
               public static string forthCost = "//tr[@class='cost '][4]//i[1]";
               public static string fifthCost = "//tr[@class='cost '][5]//i[1]";
               public static string recurrentRadioButton = "//div[@class='addEntrytimingRadio']//span[text()='Recurrent']";
               public static string oneTimeRadioButton = "//div[@class='addEntrytimingRadio']//span[text()='One time']";
               public static string addEntryButton = "//button[text()='Add Entry ']";
               public static string addBenefitName= "//input[@placeholder='Add Benefit Name']";
               public static string repeatEverycolumn = "//div[@class='addEntryRecurrentPeriodContainer']";
               public static string startDateColumn = "//div[contains(@class,'addEntryStartDateContainer')]//button";
               public static string endDateColumn = "//div[contains(@class,'addEntryEndDateContainer')]//button";
               public static string currencyColumn = "//span[text()='USD']";
               public static string changeCurrency = "//li[text()='AED']";
               public static string saveBenefit = "//div[contains(@class,'UserControl Modal')]//following::button[@class='c-button-primary-md']";

            }

            public static class VerifyOppDetails
            {
                public static string nameOfOpp = "//h6[contains(@class,'opportunityName')]";
                public static string ownerName = "//div[@class='opportunityOwner u-pb-2']//div[2]";
                public static string tagName = "//div[contains(@class,'badge sm primary')]";
                public static string currentStatus = "//div[contains(@class,'processStageElement')]";
                public static string priorityStatus = "//div[contains(@class,'priorityWrapper')]//p";
                public static string checkStatus = "//div[@class='statusWrapper']//p";
            }
}
