using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace DBA_Simulation_App_AutomationTests
{
    public class MonitorTab : BaseClass
    {
        private readonly string DeployDate = GetDeployDate(-3);
        private readonly string p = "1000";
        private string q = "1200";
        private readonly int[] CalculatedPlannedBenefit = new int[4];
        private readonly int[] CalculatedActualBenefit = new int[4];
        [Test]
        public void MonitorBenefit()
        {
            Login();
            //Click on Add opportunity.        
            GetWebDriverWait()
                 .Until(ExpectedConditions.ElementToBeClickable(By.ClassName("opprotunity-btn"))).Click();

            //Add name.
            Element = GetWebDriverWait()
                .Until(ExpectedConditions.ElementToBeClickable(By.Id("txtOpportunityName")));
            GetActions()
                .Click(Element)
                .SendKeys("Test Benefit").Perform();
            Wait(5);
            //Select the phase deployed.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divOpportunityPhase']/div[5]")));
            Element.Click();

            //Save the opportunity.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSaveOpportunity']/button[1]"))).Click();
            Wait(3);
            GetWebDriverWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='oportuinityPage']")));

            AddPlan();
            AddPlannedBenefit();
            AddActualBenefit();
            AddBenefitsFromTable();
            VerifySumFromChart();
            DeleteOpportunity();
        }

        /// <summary>
        /// Go to Monitor tab.
        ///Add a plan.
        /// </summary>
        private void AddPlan()
        {            
            //Go to Monitor tab and add plan.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedOpportunity20']")));
            Element.Click();
            
            //Click on Add New plan button.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='addMonitorBtn']")));
            Element.Click();

            //Select the deploy date of two months ago.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='dtpOpportunityMonitorDate']")));
            Element.Click();
            Element.Clear();
            Element.SendKeys(DeployDate);

            //Select the period of plan.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='frequency']")));
            Element.Click();
            Element.Clear();
            Element.SendKeys("4");

            //Set the plan.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='setPeriodsBtn']"))).Click();
            Wait(2);
        }

        /// <summary>
        /// Add the values of Planned benefit according to period of plan.
        ///Save the plan.
        /// </summary>
        public void AddPlannedBenefit()
        {
            //Add the values for planned benefit in the plan.
            string a = "//div[@id='generatedFields']/div/div/div/div[";
            string b = "]/input";
            string c = "//div[@id='generatedFields']/div[2]/div/div/div[";
            for (int i = 1; i <= 4; i++)
            {
                try
                {
                    Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a + i + b)));
                    Element.Click();
                    Element.Clear();
                    Element.SendKeys(p);
                }
                catch 
                {
                    Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"generatedFields\"]/div[2]/button/span/i")));
                    Element.Click();    
                    Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(c + 1 + b)));
                    Element.Click();
                    Element.Clear();
                    Element.SendKeys(p);
                }
            }

            //Save the plan.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='saveMonitorInfo']"))).Click();
        }

        /// <summary>
        /// Add the valyes for Actual benefit.
        /// </summary>
        public void AddActualBenefit()
        {
            //Add the values for actual benefit in the table.
            string k = "//*[@id='tblMonitor']/tbody/tr[";
            string l = "]/td/div/a";
            for (int j = 1; j <= 4; j++)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(k + j + l))).Click();
                Element=GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='txtActualData']")));
                Element.Click();
                Element.Clear();
                Element.SendKeys(q);
           
                // Update q by adding 200
                int qInt = int.Parse(q) + 200;
                q = qInt.ToString();

                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='saveMonitorData']"))).Click();
            }

            //Save the opportunity.
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='btnSaveOpportunity']/button[1]"))).Click();
            Wait(3);
            GetWebDriverWait().Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//div[@class='oportuinityPage']")));

            //Go to Monitor tab and add plan.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divGettingStartedOpportunity20']")));
            Element.Click();
        }

        /// <summary>
        /// Get the values of Planned benefit from the table.
        ///Store the values upto current month in first array.
        ///Get the values of Actual benefit from the table.
        ///Store the values upto current month in second array.
        /// </summary>    
        public void AddBenefitsFromTable()
        {
            //Get current month.
            DateTime now = DateTime.Now;
            string CurrentMonth = now.ToString("MMM");        

            string m = "//*[@id='tblMonitor']/tbody/tr[";
            string n = "]/td[2]";
            string o = "]/td[3]";
            string s = "]/td[4]";

            //Iterate through table to get the values upto current month only.
            for (int v = 1; v <= 4; v++)
            {
                Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(m + v + n)));
                string Month = Element.Text;

                if (Month != CurrentMonth)
                {
                    //Get the values of planned benefit and store it in array.
                    Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(m + v + o)));
                    string Benefit = Element.Text;
                    string cleanedValueStr = new string(Benefit.Where(char.IsDigit).ToArray());
                    Benefit = Benefit.Replace(",", ""); 
                    int PlannedBenefit = int.Parse(cleanedValueStr);
                    Console.WriteLine("Planned benefit for "+ Month +"="+ PlannedBenefit);
                    CalculatedPlannedBenefit[v] = PlannedBenefit;

                    //Get the values of actual benefit and store it in array.
                    Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(m + v + s)));
                    string actualBenefit = Element.Text;
                    string cleanValueStr = new string(actualBenefit.Where(char.IsDigit).ToArray());
                    actualBenefit = actualBenefit.Replace(",", "");
                    int ActualBenefit = int.Parse(cleanValueStr);
                    Console.WriteLine("Actual benefit for "+ Month + " = " + ActualBenefit);
                    CalculatedActualBenefit[v] = ActualBenefit;
                }
                else 
                {
                    break;
                }
            }         
        }

        /// <summary>
        /// Get the values of Planned and Actual benefit from chart.
        ///Sum the values we have in both the arrays.
        ///Compare the sums and values we got from chart.
        /// </summary>
        public void VerifySumFromChart()
        {
            //Add the values of planned benefit present in array.
            int sumOfPlannedValues = 0;
            for (int i = 0; i < CalculatedPlannedBenefit.Length; i++)
            {
                sumOfPlannedValues += CalculatedPlannedBenefit[i];
            }
            Console.WriteLine("Sum of planned benefit upto current month ="+ sumOfPlannedValues);

            //Add the values of planned benefit present in array.
            int sumOfACtualValues = 0;
            for (int j = 0; j < CalculatedActualBenefit.Length; j++)
            {
                sumOfACtualValues += CalculatedActualBenefit[j];
            }
            Console.WriteLine("Sum of actual benefit upto current month ="+ sumOfACtualValues);

            //Get the values of Planned benefit from chart.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divPlanned']")));
            string PlannedValueFromchart = Element.Text;
            string[] parts = PlannedValueFromchart.Split('.');
            string PlannedBenefitFromchart = new string(parts[0].Where(char.IsDigit).ToArray());
            int PlannedBenefit = int.Parse(PlannedBenefitFromchart);

            //Get the values of Actual benefit from chart.
            Element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='divActual']")));
            string ActualValueFromchart = Element.Text;
            string[] part = ActualValueFromchart.Split('.');
            string ActualBenefitFromchart = new string(part[0].Where(char.IsDigit).ToArray());
            int ActualBenefit = int.Parse(ActualBenefitFromchart);

            //Assert that the values we get from sum is equal to the values we get from chart.
            Assert.AreEqual(sumOfPlannedValues, PlannedBenefit);
            Assert.AreEqual(sumOfACtualValues, ActualBenefit);
            Console.WriteLine("The values are updated upto current month");
          
        }

        /// <summary>
        /// Delete the created opportunity.
        /// </summary>
        public void DeleteOpportunity()
        {
            SearchCreatedOpportunity();
            Element.SendKeys(Opportunities[4]);
            DeleteCreatedOpportunity();
        }

        public static string GetDeployDate(int months) => DateTime.Now.Date.AddMonths(months).ToString("MM/dd/yyyy");
    }
}
