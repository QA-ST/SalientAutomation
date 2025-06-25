using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using Automation.PageObjects;

namespace Automation.Tests
{
    class Opportunity : OpportunityPage
    {
        OpportunityPage opp = new OpportunityPage();
        Homepage homepage = new Homepage();

      //  [Test]
        public void NavigateToOpportunityPage()
        {
            CommonMethods.SignInUser();
            homepage.NavigateToOpportunityModule();
            CreateOpp();
        }
        public void CreateOpp()
        {
            opp.CreateNewOpp();
            opp.EditButton();
            opp.AddOpportunityGeneralDetails();
            opp.AddProcess();
            opp.ROIAnalysis();
            opp.AddScores();
            opp.SaveOpportunity();
            opp.VerifyOppGeneralDetails();
            opp.DeleteTheCreatedOpportunity();
        }


    
    }
}
