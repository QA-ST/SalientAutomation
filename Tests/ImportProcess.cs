using Automation.Helpers;
using Automation.PageObjects;
using OpenQA.Selenium;
using System.ComponentModel;
namespace Automation.Tests
{
    class ImportProcess : ImportProcessPage
    {
        Homepage homepage = new Homepage();
        ImportProcessPage importProcessPage = new ImportProcessPage();
        string currentDir = Directory.GetCurrentDirectory();
       
        [Test]
        public void NavigateToProcessCompassPage()
        {
            string projectRoot = null;
            
            DirectoryInfo dirInfo = new DirectoryInfo(currentDir);
            if (dirInfo.Parent?.Parent?.Parent != null)
            {
                projectRoot = dirInfo.Parent.Parent.Parent.FullName;
                Console.WriteLine("Base project directory: " + projectRoot);
            }
            else
            {
                Console.WriteLine("Not enough parent directories.");
                Assert.Fail("Cannot locate project root directory.");
                return;
            }
          
            CommonMethods.SignInUser();
            homepage.NavigateToProcessModule();
            importProcessPage.ImportFromFile();
            importProcessPage.UploadBPMNFile(projectRoot + "\\Resources\\Files\\IPAC.bpmn");
            importProcessPage.ImportDetails();
            importProcessPage.UploadExcelFile(projectRoot + "\\Resources\\Files\\IPAC.xlsx");
            importProcessPage.SelectPropertiesData();
            importProcessPage.ProcessDetailsVerification();
            importProcessPage.DeleteTheCreatedProcess();
    

        }

        
    }
}
