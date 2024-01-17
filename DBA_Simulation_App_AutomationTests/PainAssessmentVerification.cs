using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBA_Simulation_App_AutomationTests
{
    public class PainAssessmentVerification : BaseClass
    {
      
        private void Settings()
        {
            SettingsTab();

            //Get the data of Pain Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblPaint']/tbody")));        
            string[] columnData1 = ExtractTableColumnData(Driver, "//*[@id='tblPaint']/tbody", 0);

            OpenExistingProcess();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pills-pain-tab']"))).Click();
            //Get the data of Pain Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblPaint']/tbody")));         
            string[] columnData2 = ExtractTableColumnData(Driver, "//*[@id='tblPaint']/tbody", 0);

            bool columnsMatch = CompareArrays(columnData1, columnData2);

            // Print the result
            if (columnsMatch)
            {
                Console.WriteLine("The columns match.");
            }
            else
            {
                Console.WriteLine("The columns do not match.");
            }
        }
     
        /// <summary>
        /// Go to Manage Processes page.
        /// Open an existing process.
        /// </summary>
        private void OpenExistingProcess()
        {
            //Go to Manage Processes.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='kt_header_menu']/div[2]/ul/li[4]/ul/li[4]/a"))).Click();

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects_filter']/label/input")));
            Element.Clear();
            Element.SendKeys(Keys.Enter);
            Wait(2);
            //Open Existing Process.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[2]/a"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedProject1']")));
            //Go to Assessment tab and select pain.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pills-strategic-tab']"))).Click();
            Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pills-pain-tab']"))).Click();
        }

        /// <summary>
        /// Go to Settings page.
        /// Click on Assessment tab.
        /// </summary>
        private void SettingsTab()
        {
            //Go to profile and click on settings.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divProfileHeaderImage']"))).Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='Settings.aspx']")));
            Element.Click();
            //Go to Assessment tab.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='MainContent_painAssestmentTab']")));
            Element.Click();
        }

        /// <summary>
        /// Add new pain assessment.
        /// </summary>
        private void AddAssessment()
        {
            SettingsTab();

            //Add Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pills-Pain']/div[1]/div[2]/a"))).Click();
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtPainName']")));
            Element.SendKeys("Adding New Pain");

            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtPainDescription']")));
            Element.SendKeys("Describing new pain");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='savePainInfo']"))).Click();
            Wait(3);

        }

        /// <summary>
        /// Verify that newly added pain is reflecting on process details page.
        /// </summary>
        private void Verify()
        {
            OpenExistingProcess();
            //Get the data of Pain Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblPaint']/tbody")));
            IWebElement Table = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblPaint']/tbody")));
            IList<IWebElement> list = Table.FindElements(By.TagName("tr"));
            string p = "//*[@id='tblPaint']/tbody/tr[";
            string q = "]/td[1]/div";
            var rowsCount = list.Count();
            int t = 1;
            // Console.WriteLine(rowCount);
            for (int i = 1; i <= rowsCount; i++)
            {
                string r = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(p + t + q))).Text;
                if (r.Contains("Adding New Pain"))
                {
                    Console.WriteLine("New pain added successfullly");                   
                    break;
                }

            }
        }

        /// <summary>
        /// Go to Settings page.
        /// Delete the added pain.
        /// </summary>
        private void DeletePain()
        {
            SettingsTab();

            //Get the data of Pain Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblPaint']/tbody")));
            IWebElement Table1 = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblPaint']/tbody")));
            IList<IWebElement> list1 = Table1.FindElements(By.TagName("tr"));
            string a = "//*[@id='tblPaint']/tbody/tr[";
            string b = "]/td[1]/div";
            string d = "]/td[2]/div/a[2]";
            var rowCount = list1.Count();
            for(int e = 1; e <= rowCount; e++)
            {
                string c = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a + e + b))).Text;
                if(c.Contains("Adding New Pain"))
                {
                    Wait(2);
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a + e + d))).Click();
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Yes, delete it!')]"))).Click();
                    Console.WriteLine("Pain deleted successfully");
                    break;
                }
            }
        }

        /// <summary>
        /// Extracts the data from the table.
        /// Stores the data in an array.
        /// </summary>
        /// <param name="Driver"></param>
        /// <param name="tableId"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        static string[] ExtractTableColumnData(IWebDriver Driver, string tableId, int columnIndex)
        {
            IWebElement table = Driver.FindElement(By.XPath(tableId));
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

            string[] columnData = new string[rows.Count];

            for (int i = 0; i < rows.Count; i++)
            {
                IList<IWebElement> cells = rows[i].FindElements(By.TagName("td"));

                if (columnIndex == 0)
                {
                    IWebElement cell = cells[columnIndex];
                    string data = cell.Text;
                    Console.WriteLine(data);
                    columnData[i] = data;
                }
            }

            return columnData;
        }

        /// <summary>
        /// Compares the data of two arrays.
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        static bool CompareArrays(string[] array1, string[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Go to Settings page.
        /// Click on Assessment tab.
        /// Stores the data of Pain in the array.
        /// Go to Manage processes page.
        /// Click on Assessment tab.
        /// Select the pain from the sub-tabs.
        /// Stores the data of Pain in the array.
        /// Compare the data in the two  arrays.
        /// </summary>
        [Test,Order(1)]
        public void PainAssessment()
        {
            Login();
            Settings();
        }

        /// <summary>
        /// Go to Settings page.
        /// Click on Assessment tab.
        /// Add a new pain.
        /// Go to Manage processes page.
        /// Open an existing proces.
        /// Click on Assessment tab.
        /// Verify that newly added pain is reflecting on process details page.
        /// Go to settings and delete the pain.
        /// </summary>
        [Test,Order(2)]
        public void VerfifyPainAssessment()
        {
            Login();
            AddAssessment();
            Verify();
            DeletePain();
        }

       
    }
}
