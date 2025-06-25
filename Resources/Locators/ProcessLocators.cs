
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Automation.Resources.Locators
{
    public static class ProcessPage
    {
        public static string importProcess = "//div[contains(@class,'UserControl Card')]//p[text()='Import BPMN File']";
        public static string createProcess = "//div[contains(@class,'UserControl Card')]//p[text()='Create from Scratch']";
        public static string modeler = "//div[contains(@class,'bpmn-diagram-plane root editor')]";
        public static string pool = "//div[@class='palette']/div[contains(@class,'pool item')]/div";
        public static string startEvent = "//div[@title='Start event']";
        public static string swimLane = "//div[@title='Swimlane']";
        public static string start = "//*[name()='circle' and contains(@class,'body')]";
        public static string port = "//*[name()='g' and contains(@class,'right')]//*[name()='circle' and contains(@class,'port')]";
        public static string selectActivity = "//div[contains(@class,'bpmn-diagram-plane root editor')]//*[name()='path' and contains(@index,'0')]";
        public static string selectFirstActivityPort = "//*[name()='g' and contains(@class,'right')]//*[name()='circle' and contains(@data-index,'1')]";
        public static string firstActivity = "(//div[contains(@class,'root editor')]//*[name()='g' and contains(@class,'task root shape rect')]//*[name()='tspan'and contains(text(),'Task')])[1]";
        public static string secondActivity = "//div[contains(@class,'root editor')]//*[name()='g' and contains(@class,'task root shape rect')]//*[name()='tspan'and contains(text(),'Task')]";
        public static string selectSecondActivityPort = "//*[name()='g' and contains(@class,'task root shape rect')][2]//*[name()='g' and contains(@class,'right')]//*[name()='circle'][2]";
        public static string endPoint = "//div[contains(@class,'bpmn-diagram-plane root editor')]//*[name()='path' and contains(@index,'3')]";
        public static string saveDropdown = "//div[@class='saveChangesDropdownWrapper']//button[2]";
        public static string saveAndClose = "//div[contains(@class,'saveAndClose')]";
        public static string processOpenCloseLink = "//div[contains(@class,'ProcessDetailsTab')]//p[text()='Open/Close All']";
        public static string activityOpenCloseLink = "//div[contains(@class,'ActivityDetailsTab')]//p[text()='Open/Close All']";

    }

    public static class ProcessGeneralDetails
    {
        public static string editButton = "//div[@class='processEditorButton']/button";
        public static string processName = "//div[contains(@class,'processNameInputWrapper')]//input";
        public static string processOwner = "(//div[contains(@class,'processOwnerInputWrapper')]//following::span[@class='select2-selection__arrow'])[1]";
        public static string onwerInput = "//input[@role='searchbox']";
        public static string selectOwner = "//span[@class='select2-results']/ul/li[text()='{0}']";
        public static string processTag = "//div[contains(@class,'processTagEditWrapper')]//textarea";
        public static string processStage = "//div[contains(@class,'processStageSelect')]//select";
        public static string descriptionButton = "//button[text()='Description ']";
        public static string description = "//textarea[@placeholder='Enter Description']";
        public static string objectiveButton = "//button[text()='Objectives ']";
        public static string objective = "//textarea[@placeholder='Enter Objectives']";
        public static string scopeButton = "//button[text()='Scope ']";
        public static string scope = "//textarea[@placeholder='Enter Scope']";
        public static string saveDetails = "//button[text()='Save']";
        public static string saveDropdown = "//div[contains(@class,'UserControl Dropdown')]/div/button[2]";
        public static string saveAndClose = "//li/div[text()='Save and close']";

    }

    public static class ProcessHomePage
    {
        public static string sidebar = "//div[@id='navSidebar']";
        public static string home = "//a[text()='Home']";
        public static string searchbar = "//div[@id='processListDatatable_filter']//input[@type='search']";
        public static string deleteIcon = "//table[@id='processListDatatable']/tbody/tr[1]/td/button[@data-action='Delete']";

    }

    public static class ActivitySearchableTimeProperties
    {

        public static string editWorkTime = "//div[contains(@class,'ActivityDetailsEditorTab')]//p[text()='Work Time']/following::input[1]";
        public static string editFirstActivity = "//div[contains(@class,'root editor')]//*[name()='g' and contains(@class,'task root shape rect')][1]//*[name()='g' and contains(@class,'container')]";
        public static string editSecondActivity = "//div[contains(@class,'root editor')]//*[name()='g' and contains(@class,'task root shape rect')][2]";
        public static string workTimeColumn = "//div[contains(@class,'ActivityDetailsEditorTab')]//p[text()='Work Time']/following::select[1]";
        public static string editWaitTime = "//div[contains(@class,'ActivityDetailsEditorTab')]//p[text()='Wait Time']/following::input[1]";
        public static string waitTimeColumn = "//div[contains(@class,'ActivityDetailsEditorTab')]//p[text()='Wait Time']/following::select[1]";
        public static string dueTimeColumn = "//div[contains(@class,'ActivityDetailsEditorTab')]//p[text()='Due After']/following::select[1]";
        public static string editDueTime = "//div[contains(@class,'ActivityDetailsEditorTab')]//p[text()='Due After']/following::input[1]";
        public static string valueAfterColumn = "//div[contains(@class,'ActivityDetailsEditorTab')]//p[text()='Value Added ']/following::select[1]";
    }

    public static class ActivitySearchableProperties
    {
        public static string description = "//div[contains(@class,'UserControl Accordion')]//i[contains(@class,'descriptionTooltip')]";
        public static string editDescription = " //div[contains(@class,'ADDescriptionAccordionBody')]/div/div/textarea";

        public static string addCost = "//div[contains(@class,'costEditorAccordionBody')]//following::input[@placeholder='Cost Name']";
        public static string clickCostIcon = "//div[contains(@class,'UserControl Accordion')]//i[contains(@class,'costTooltip')]";
        public static string costCurrency = "(//div[contains(@class,'costEditorAccordionBody')]//select)[1]";
        public static string costTab = "//div[contains(@class,'costEditorAccordionBody')]//following::input[contains(@placeholder,'Value')]";
        public static string selectInstance = "(//div[contains(@class,'costEditorAccordionBody')]//select)[2]";

        public static string systemIcon = "//i[contains(@class,'systemsTooltip')]";
        public static string system = "//button[text()='Add New System']";
        public static string addSystem = "//span[text()='Select System']//following::input[@aria-label='Search']";

        public static string assetsIcon = "//i[contains(@class,'assetsTooltip')]";
        public static string assets = "//button[text()='Add New Asset']";
        public static string addAssets = "//span[text()='Select Asset']//following::input[@aria-label='Search']";

        public static string sipocIcon = "//i[contains(@class,'sipocTooltip')]";
        public static string supplier = "//button[text()='Add New Supplier']";
        public static string addSupplier = "//span[text()='Select Supplier']//following::input[@aria-label='Search']";

        public static string input = "//button[text()='Add New Input']";
        public static string addInput = "//span[text()='Select Input']//following::input[@aria-label='Search']";

        public static string output = "//button[text()='Add New Output']";
        public static string addOutput = "//span[text()='Select Output']//following::input[@aria-label='Search']";

        public static string customer = "//button[text()='Add New Customer']";
        public static string addCustomer = "//span[text()='Select Customer']//following::input[@aria-label='Search']";

        public static string raciIcon = "//i[contains(@class,'raciTooltip')]";
        public static string accountable = "//button[text()='Add New Accountable']";
        public static string addAccountable = "//span[text()='Select Accountable']//following::input[@aria-label='Search']";
        public static string consulted = "//button[text()='Add New Consulted']";
        public static string addConsulted = "//span[text()='Select Consulted']//following::input[@aria-label='Search']";
        public static string informed = "//button[text()='Add New Informed']";
        public static string addInformed = "//span[text()='Select Informed ']//following::input[@aria-label='Search']";

        public static string selectValue = "//li[text()='{0}']";


    }

    public static class VerifyGeneralDetails
    {
        public static string nameOfProcess = "//h6[contains(@class,'processNameElement')]";
        public static string ownerName = "//div[@class='bc-name-badge__text']";
        public static string tagName = "//div[@data-control-type='BadgeList']/div";
        public static string currentStatus = "//div[contains(@class,'processStageElement')]";
        public static string descriptionBtn = "//button[text()='Description ']";
        public static string objectiveBtn = "//button[text()='Objectives ']";
        public static string scopeBtn = "//button[text()='Scope ']";
        public static string descriptionContent = "(//div[contains(@class,'ProcessDetailsInfoContainer ')]//following::textarea)[1]";
        public static string objectiveContent = "(//div[contains(@class,'ProcessDetailsInfoContainer ')]//following::textarea)[2]";
        public static string scopeContent = "(//div[contains(@class,'ProcessDetailsInfoContainer ')]//following::textarea)[3]";

    }

    public static class VerifySearchableTimeProperties
    {
        public static string activityOne = "//div[contains(@class,'bpmn-diagram-plane root')]//*[name()='g' and contains(@class,'task root shape rect')]//*[name()='tspan' and contains(text(),'Activity 1')]";
        public static string activityOne1 = "(//div[contains(@class,'bpmn-diagram-plane root')]//*[name()='g' and contains(@class,'task root shape rect')]//*[name()='g' and contains(@class,'container')])[2]";
        public static string workTimeValue = "//p[contains(text(),'Work Time')]/following::div[1]";
        public static string waitTimeValue = "//p[contains(text(),'Wait Time')]/following::div[1]";
        public static string dueAfterValue = "//p[contains(text(),'Due After')]/following::div[1]";
        public static string valueAfterData = "//p[contains(text(),'Value Added')]/following::div[1]";
    }


    public static class VerifySearchableProperties
    {
        public static string verifySystems = "//div[contains(@class,'ADSystemsAccordionBody')]//p";
        public static string verifyAssets = "//div[contains(@class,'ADAssetsAccordionBody')]//p";
        public static string openCost = "//div[contains(@class,'ADCostAccordionBody')]//p[text()='Activity cost 1']";
        public static string verifyCurrency = "//div[contains(@class,'ADCostAccordionBody')]//p[text()='Currency']/following::p[1]";
        public static string verifyValue = "//div[contains(@class,'ADCostAccordionBody')]//p[text()='Value']/following::p[1]";
        public static string verifyFrequency = "//div[contains(@class,'ADCostAccordionBody')]//p[text()='Frequency']/following::p[1]";
        public static string verifySupplier = "//div[contains(@class,'ADSipocAccordionBody')]//p[text()='Suppliers']/following::p[1]";
        public static string verifyInputs = "//div[contains(@class,'ADSipocAccordionBody')]//p[text()='Inputs']/following::p[1]";
        public static string verifyOutputs = "//div[contains(@class,'ADSipocAccordionBody')]//p[text()='Outputs']/following::p[1]";
        public static string verifyCustomers = "//div[contains(@class,'ADSipocAccordionBody')]//p[text()='Customers']/following::p[1]";
        public static string verifyAccountable = "//div[contains(@class,'ADRaciAccordionBody')]//p[text()='Accountable']/following::p[1]";
        public static string verifyConsulted = "//div[contains(@class,'ADRaciAccordionBody')]//p[text()='Consulted']/following::p[1]";
        public static string verifyInformed = "//div[contains(@class,'ADRaciAccordionBody')]//p[text()='Informed']/following::p[1]";
        public static string verifyDescription = "//div[contains(@class,'ADDescriptionAccordionBody')]";
    }

}

