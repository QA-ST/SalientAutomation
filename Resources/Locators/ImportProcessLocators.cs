namespace Automation.Resources.Locators
{
    public static class ImportProcessLocators
    {
        public static string clickImportFile = "(//div[contains(@class,'standard UserControl')])[2]";
        public static string uploadFile = "//input[@type='file']";
    }

    public static class ProcessEditor
    {
        public static string importDetails = "//div[contains(@class,'importExcelBtnWrapper')]//button[@data-control-type='Button']";
        public static string uploadExcel = "//input[@type='file']";
        public static string nextButton = "//button[text()='Next ']";
    }

    public static class selectProperties
    {
        public static string selectProperty = "//tr[@class='odd'][1]//span[text()='Select property']";
        public static string activityName = "//li[text()='Activity Name (Mandatory)']";
        public static string selectPropety1 = "//tr[@class='even'][2]//span[text()='Select property']";
        public static string systemName = "//li[text()='System']";
        public static string selectProperty2 = "//tr[@class='odd'][4]//span[text()='Select property']";
        public static string informedName = "//li[text()='Informed']";
        public static string importButton = "//button[text()='Import']";
        public static string toggleButton = "//div[@class='saveChangesDropdownWrapper']//button[2]";
        public static string saveCloseData = "//div[text()='Save and close']";
    }

    public static class processDetailsDataVerification
    {
        public static string processOpenCloseLink = "//div[contains(@class,'ProcessDetailsTab')]//p[text()='Open/Close All']";
        public static string activityOpenCloseLink = "//div[contains(@class,'ActivityDetailsTab')]//p[text()='Open/Close All']";
        public static string accordionButton = "//button[@class='accordion-button']";
        public static string selectActivity = "(//div[contains(text(),'Excel spreadsheet')])[2]";
        public static string actualValue = "//div[contains(@class,'ADSystemsAccordionBody')]//p";
    }
}