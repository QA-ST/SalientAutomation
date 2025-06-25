using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Resources.Locators
{
    public static class Locator
    {
        public static class LoginPage
        {
            public static string login = "//a[@href='/Session/Login']";
            public static string username = "//input[@id='username']";
            public static string password = "//input[@id='password']";
            public static string loginbutton = "//input[@name='login']";
            public static string forgotPassword = "//a[text()='Forgot Password?']";
            public static string submitButton = "//input[@value='Submit']";
            public static string confirmationMessage = "//span[text()='You should receive an email shortly with further instructions.']";
            public static string selectAccount = "//select[@id='accounts']";
            public static string select = "//button[@id='Button_1']";
        }


        public static class HomeLocators
        {
            public static string GotoProcess = "//button[text()='Go to Process']";
            public static string GoToSimulation = "//button[text()='Go to Simulation']";
            public static string GoToOpportunity = "//button[text()='Go to Opportunity']";
            public static string GoToInSights = "//button[text()='Go to Insights']";
        }

    }
}