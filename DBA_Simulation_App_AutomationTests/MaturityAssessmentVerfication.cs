using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBA_Simulation_App_AutomationTests
{
    public class MaturityAssessmentVerfication:BaseClass
    {
        /// <summary>
        /// Go to Settings page.
        /// Click on Assessment tab.
        /// Switch to maturity tab.
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

            //Click on Maturity Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pills-Maturity-Tab']"))).Click();
        }

        /// <summary>
        /// Click on Add Maturity.
        /// Add name and description.
        /// Save the maturity.
        /// </summary>
        private void AddMaturity()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pills-Maturity']/div[1]/div[2]/a"))).Click();
            Element=GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtMaturityName']")));
            Element.SendKeys("Adding New Maturity");
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtMaturityDescription']")));
            Element.SendKeys("Describing New Maturity");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='saveMaturityInfo']"))).Click();
            Wait(2);
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
            //Clear the recent search.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects_filter']/label/input")));
            Element.Clear();
            Wait(2);
            //Open Existing Process.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblProjects']/tbody/tr[1]/td[2]/a"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedProject1']")));
            //Go to Assessment tab and select pain.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pills-strategic-tab']"))).Click();
            Wait(3);
            //Click on Maturity Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='pills-maturity-tab']"))).Click();
        }

        /// <summary>
        /// Verify that newly added maturity is reflecting on process details page.
        /// </summary>
        private void Verify()
        {
            //Get the data of Pain Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblMaturityt']/tbody")));
            IWebElement Table = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblMaturityt']/tbody")));
            IList<IWebElement> list = Table.FindElements(By.TagName("tr"));
            string p = "//*[@id='tblMaturityt']/tbody/tr[";
            string q = "]/td[1]/div";
            var rowsCount = list.Count();
            int t = 1;
            // Console.WriteLine(rowCount);
            for (int i = 1; i <= rowsCount; i++)
            {
                string r = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(p + t + q))).Text;
                if (r.Contains("Adding New Maturity"))
                {
                    Console.WriteLine("New Maturity added successfullly");
                    break;
                }

            }
        }

        /// <summary>
        /// Go to Settings page.
        /// Delete the added Maturity.
        /// </summary>
        private void DeleteMaturity()
        {
            SettingsTab();
            IWebElement Table1 = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblMaturity']/tbody")));
            IList<IWebElement> list1 = Table1.FindElements(By.TagName("tr"));
            string a = "//*[@id='tblMaturity']/tbody/tr[";
            string b = "]/td[1]/div";
            string d = "]/td[2]/div/a[2]";
            var rowCount = list1.Count();
            for (int e = 1; e <= rowCount; e++)
            {
                string c = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a + e + b))).Text;
                if (c.Contains("Adding New Maturity"))
                {
                    Wait(2);
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a + e + d))).Click();
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Yes, delete it!')]"))).Click();
                    Console.WriteLine("Maturity deleted successfully");
                    break;
                }
            }
        }


        /// <summary>
        /// Go to Settings page.
        /// Click on Assessment tab and switch to Maturity.
        /// Stores the data of Maturity in the array.
        /// Go to Manage processes page.
        /// Click on Assessment tab.
        /// Select the maturity from the sub-tabs.
        /// Stores the data of Maturity in  the array.
        /// Compare the data in the two  arrays.
        /// </summary>
        [Test]
        public void SettingsMaturity()
        {
            Login();
            SettingsTab();

            //Get the data of Maturity Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblMaturity']/tbody")));
            IWebElement Table1 = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblMaturity']/tbody")));
            IList<IWebElement> list1 = Table1.FindElements(By.TagName("tr"));
            string[] columnData1 = ExtractTableColumnData(Driver, "//*[@id='tblMaturity']/tbody", 0);

            OpenExistingProcess();
       
            //Get the data of Maturity Assessment.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='tblMaturityt']/tbody")));

            string[] columnData2 = ExtractTableColumnData(Driver, "//*[@id='tblMaturityt']/tbody", 0);

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
        /// Extracts the data from the table.
        /// Stores the data in an array.
        /// </summary>
        /// <param name="Driver"></param>
        /// <param name="tableId"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        static string[] ExtractTableColumnData( IWebDriver Driver, string tableId, int columnIndex)
        {
            IWebElement table = Driver.FindElement(By.XPath(tableId));
            IList <IWebElement> rows = table.FindElements(By.TagName("tr"));

            string[] columnData = new string[rows.Count];

            for (int i = 0; i < rows.Count; i++)
            {
                IList<IWebElement> cells = rows[i].FindElements(By.TagName("td"));

                if (columnIndex ==0)
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
        /// Compare the data of two arrays
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
        /// Click on Assessment tab and switch to Maturity tab.
        /// Add a new Maturity.
        /// Go to Manage processes page.
        /// Open an existing proces.
        /// Click on Assessment tab.
        /// Verify that newly added Maturity is reflecting on process details page.
        /// Go to settings and delete the maturity.
        /// </summary>
        [Test]
        public void VerifyMaturityAssessment()
        {
            Login();
            SettingsTab();
            AddMaturity();
            OpenExistingProcess();
            Verify();
            DeleteMaturity();
        }


    }
}
