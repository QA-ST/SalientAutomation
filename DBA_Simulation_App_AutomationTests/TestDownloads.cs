using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;

namespace DBA_Simulation_App_AutomationTests
{
    class TestDownloads : BaseClass
    {
        /// <summary>
        /// Check the files in download folder and delete the existing files.
        /// Go to Opportunity table.
        /// Extract data from the second column of table rows.
        /// Stores the extracted data in array1.
        /// Exports the Excel format of the table.
        /// Extraxt data from second column of sheet rows.
        /// Stores the extracted data in array2.
        /// Compare the array1 and array2.
        /// Print the results.
        /// </summary>
        [Test]
        public void TestingDownloads()
        {            
            Login();
            //Check the files in the folder and delete them.
            DirectoryInfo di = new DirectoryInfo(TestContext.Parameters.Get("DownloadPath"));
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='divGettingStartedPipeline4']")));
            Wait(3);
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='tblPipeline_length']/label/select")));
            Select().SelectByIndex(1);
            //Get the data from the first column of rows (from the table) and store them in array.
            string[] columnData1 = ExtractTable(Driver, "//*[@id='tblPipeline']/tbody");

            //Export the file in excel format.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='divGettingStartedPipeline4']/div[2]/button")));
            GetActions().MoveToElement(Element).Click(Element).Perform();
            Element = GetWebDriverWait()
              .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedPipeline4']/div[2]/div[2]/div/a[3]")));
            Element.Click();
            Wait(5);

            // Set the download path using JavaScript for exporting.
            string script = $"var inputs = document.querySelectorAll('input[type=file]');" +
                            $"for (var i = 0; i < inputs.length; i++) {{" +
                            $"   inputs[i].setAttribute('downloadPath', '{TestContext.Parameters.Get("DownloadPath")}');" +
                            $"}}";
            Wait(5);
            Js().ExecuteScript(script);
             //Get the data from the first column of rows (from excel sheet) and store them in array.
            string[] columnData2 = ExtractExcel(Driver);
            //Compare the data stored in two arrays.
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
        /// Extracts data from excel sheet and store them in an array.
        /// </summary>
        /// <param name="Driver"></param>
        /// <returns></returns>
       public static string[] ExtractExcel(IWebDriver Driver)
        {
            string fileName = "xlsx.xlsx";
            string downloadFolder = TestContext.Parameters.Get("DownloadPath");
            string filePath = Path.Combine(downloadFolder, fileName);

            bool fileExists = File.Exists(filePath);

            if (fileExists)
            {
                Console.WriteLine("The file exists in the folder.");


                XSSFWorkbook workbook = new XSSFWorkbook(File.Open(filePath, FileMode.Open));
                ISheet sheet = workbook.GetSheetAt(0); // Assuming you want to work with the first sheet

                if (sheet != null)
                {
                    int rowCount = sheet.LastRowNum;
                    string[] columnData = new string[rowCount-1];
                    // Iterate through each row in the sheet
                    for (int rowIndex = sheet.FirstRowNum + 2; rowIndex <= sheet.LastRowNum; rowIndex++)
                    {
                        IRow row = sheet.GetRow(rowIndex);

                        if (row != null)
                        {
                            ICell cell = row.GetCell(1); // Get the second column (index 1)

                            if (cell != null)
                            {
                                string cellValue = cell.ToString();
                                columnData[rowIndex - 2] = cellValue;
                            }
                        }
                    }
                    return columnData;
                }
            }
            return null;
        }

        /// <summary>
        /// Extracts data from table and store them in an array.
        /// </summary>
        /// <param name="Driver"></param>
        /// <param name="tableId"></param>
        /// <returns></returns>
        static string[] ExtractTable(IWebDriver Driver,string tableId)
        {
            IWebElement table = Driver.FindElement(By.XPath(tableId));         
            var rows = table.FindElements(By.TagName("tr"));
            string[] columnData = new string[rows.Count];
            int index = 0;
            foreach (var row in rows)
            {
                IList<IWebElement> Columns = row.FindElements(By.XPath("td[2]"));
                foreach (var column in Columns)
                {
                    string a = column.Text;
                    columnData[index] = a;
                    index++; 
                }
            }
            return columnData;
        }
       
        /// <summary>
        /// Compare the data extracted from table and excel sheet.
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
                Console.WriteLine(array1[i] + " & " + array2[i]);
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}