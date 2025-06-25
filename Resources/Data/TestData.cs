

namespace Automation.Resources.Data
{
    public static class ProcessData
    {
        public static class GeneralDetails
        {
            public static string name = "Automated Process";
            public static string importedProcessName = "Automated Imported Process";
            public static string processOwner = "Automated User";
            public static string processTag = "Test Tag";
            public static string stage = "Approved";
            public static string description = "Test description.";
            public static string objective = "Test objective of the process.";
            public static string scope = "Test scope of the process.";
            public static string importProcessName = "IPAC";
        }
        public static class SearchableTimePropertiesDetails
        {
            public static string workTime = "10";
            public static string selectWorkTime = "minutes";
            public static string waitTime = "10";
            public static string selectWaitTime = "hours";
            public static string dueTime = "10";
            public static string selectDueTime = "hours";
            public static string selectValueAdded = "Mandatory";
        }

        public static class SearchablePropertiesDetails
        {
            public static string costColumn = "Activity cost 1";
            public static string costData = "10";
            public static string currency = "EUR";
            public static string instances = "Daily";
            public static string activityDescription = "Add Description";
            public static string system = "Test System";
            public static string supplier = "Test Supplier";
            public static string input = "Test inputs";
            public static string output = "Test outputs";
            public static string customer = "Test Customer";
            public static string accountable = "QA";
            public static string consulted = "Test Consultant";
            public static string informed = "Test Informed";
            public static string asset = "Test Asset";
        }
        public static class Simulations
        {
            public static string simulationName = "New Simulation 88";
            public static string hiringManagerDuration = "10";
            public static string managerDurationUnit = "minutes";
            public static string enterDeviation = "10";
            public static string managerDeviationUnit = "minutes";
            public static string costAmount = "10";
            public static string currencyName = "USD";
        }

        public static class Rescourcesdata
        {
            public static string numberOfWorkers = "5";
            public static string cost = "10";
            public static string frequencyData = "Per Day";
        }

        public static class WarmUpActivitiesData
        {
            public static string numberOfInstances = "10";
            public static string distributionData = "Random";
        }
    }
}
