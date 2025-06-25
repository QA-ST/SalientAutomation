using Automation.Helpers;
using Automation.PageObjects;


namespace Automation.Tests
{
    internal class Processes : ProcessDetails
    {
        ProcessDetails process = new ProcessDetails();
        Homepage homepage = new Homepage();

        [Test]
        public void CreateProcessFunctionality()
        {
            CommonMethods.SignInUser();
            homepage.NavigateToProcessModule();
            CreateProcessModel();
            AddGeneralDetails();
            VerifyGeneralDetails();
            AddSearchableProperties();
            VerifySearchablePropertiesDetails();
            DeleteProcess();
        }

      private void CreateProcessModel()
        {
            process.CreateNewProcess();
            process.CreatePool();
            process.AddFirstActivity();
            process.AddSecondActivity();
            process.AddEndEvent();
            process.EditActivityNames();
            process.SaveProcess();          
        }

        private void AddGeneralDetails()
        {
            process.ClickEdit();
            process.EditName();
            process.AddProcessOwner();
            process.AddProcessTag();
            process.AddProcessStage();
            process.AddDescription();
            process.AddObjective();
            process.AddScope();
            process.SaveGeneralDetails();
            
        }

        public void AddSearchableProperties()
        {
            process.EditSearchableTimeProperties();
            process.EditSearchableProperties();
            process.SaveProcess();
        }

        private void VerifyGeneralDetails()
        {
            process.VerifyDetails();
        }

        private void VerifySearchablePropertiesDetails()
        {
            process.VerfiySearchableTimeProperties();
            process.VerfiyActivitySearchableProperties();
        }
        private void DeleteProcess()
        {
            process.DeleteTheCreatedProcess();
        }

      
    }
}
