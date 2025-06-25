using Automation.Helpers;
using Automation.Resources.Data;
using Automation.Resources.Locators;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Automation.PageObjects
{
    public class ImportProcessPage : BaseClass
    {
        private string ProjectRoot
        {
            get
            {
                DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                DirectoryInfo? rootDir = dirInfo.Parent?.Parent?.Parent;

                if (rootDir == null)
                {
                    Console.WriteLine("Not enough parent directories to determine the project root.");
                    Assert.Fail("Cannot locate project root directory.");
                }

                Console.WriteLine("Base project directory: " + rootDir.FullName);
                return rootDir.FullName;
            }
        }

            public void ImportFromFile()
            {
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ImportProcessLocators.clickImportFile))).Click();
            }
            public void UploadBPMNFile(string filePath)
            {
                IWebElement fileInput = driver.FindElement(By.XPath(ImportProcessLocators.uploadFile));
                fileInput.SendKeys(filePath);
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='busy-indicator c-loading pulse']")));
            }
            public void ImportDetails()
            {
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessEditor.importDetails))).Click();
            }
            public void UploadExcelFile(string filePath)
            {
                IWebElement fileInput1 = driver.FindElement(By.XPath(ProcessEditor.uploadExcel));
                fileInput1.SendKeys(filePath);

                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessEditor.nextButton))).Click();
                CommonMethods.Wait(2);
            }
            public void SelectPropertiesData()
            {
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(selectProperties.selectProperty))).Click();

                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(selectProperties.activityName))).Click();

                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(selectProperties.selectPropety1))).Click();
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(selectProperties.systemName))).Click();

                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(selectProperties.selectProperty2))).Click();
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(selectProperties.informedName))).Click();

                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessEditor.nextButton))).Click();
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessEditor.nextButton))).Click();

                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(selectProperties.importButton))).Click();
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(selectProperties.toggleButton))).Click();
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(selectProperties.saveCloseData))).Click();
            }
            public void ProcessDetailsVerification()
            {
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(processDetailsDataVerification.processOpenCloseLink))).Click();
                CommonMethods.Wait(2);
                CommonMethods.GetActions().MoveToElement(driver.FindElement(By.XPath("(//div[contains(@class,'item-activity')])[2]//i"))).Build().Perform();
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(processDetailsDataVerification.selectActivity))).Click();
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(processDetailsDataVerification.activityOpenCloseLink))).Click();

                IWebElement element = driver.FindElement(By.XPath(processDetailsDataVerification.actualValue));
                string actualValue = element.Text;
                Console.WriteLine("Actual Value: " + actualValue);

                string excelFilePath = Path.Combine(ProjectRoot, "Resources", "Files", "IPAC.xlsx");
                VerifyDataFromExcel(actualValue, excelFilePath, "Sheet1", 3, 3);
            }

            public void VerifyDataFromExcel(string actualValue, string excelFilePath, string sheetName, int rowIndex, int columnIndex)
            {
                using FileStream file = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read);
                XSSFWorkbook workbook = new XSSFWorkbook(file);
                ISheet sheet = workbook.GetSheet(sheetName);

                ICell cell = sheet.GetRow(rowIndex)?.GetCell(columnIndex);
                string expectedValue = cell?.ToString() ?? "";

                if (actualValue == expectedValue)
                {
                    Console.WriteLine($"Data matches: {actualValue}");
                }
                else
                {
                    Console.WriteLine($"Mismatch! Expected: {expectedValue}, Got: {actualValue}");
                }
            }
            public void DeleteTheCreatedProcess()
            {
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessHomePage.sidebar))).Click();
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessHomePage.home))).Click();
                element = CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessHomePage.searchbar)));
                element.SendKeys(ProcessData.GeneralDetails.importProcessName + Keys.Enter);
                CommonMethods.Wait(2);
                CommonMethods.GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(ProcessHomePage.deleteIcon))).Click();
            }
        }
}

