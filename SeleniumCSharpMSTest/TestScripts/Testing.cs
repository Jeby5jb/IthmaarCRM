//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using RelevantCodes.ExtentReports;
//using SeleniumCSharpMSTest.Functions;
//using System;
//using System.IO;
//using System.Reflection;
//using TesthouseSeleniumCSharp.Functions;

//namespace SeleniumCSharpMSTest.TestScripts
//{
//    [TestClass]
//    public class Testing : BaseClass
//    {
//        public static int maxTestRunsCount = 2;
//        public static int maxTestRuns = maxTestRunsCount;

//        /// <summary>
//        /// Method to set report path
//        /// </summary>
//        [AssemblyInitialize]
//        public static void StartReport(TestContext test)
//        {
//            AssemblyInitialize();
//        }

//        /// <summary>
//        /// Method to start the driver and report
//        /// </summary>
//        [TestInitialize]
//        public void Initialize()
//        {
//            TestInitialize();
//            maxTestRuns = maxTestRunsCount;
//        }

//        /// <summary>
//        /// Test Method to "Creating a Marketing Campaign, Add a Lead, Qualify the created Lead to Opportunity, Close as Won the opportunity" - Test Method Example for execution
//        /// </summary>
//        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Testdata$", DataAccessMethod.Sequential), TestMethod]
//        public void MarketingCampaign()
//        {
//            MarketingFunctions marketing = new MarketingFunctions();
//            LoginFunctions login = new LoginFunctions();

//            //Launch and Login to the Application
//            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

//            //Create a new Marketing Campaign
//            marketing.CreateNewMarketingCampaign(driver, extentTest, testName, testDataIteration, TestContext.DataRow["CampaignName"].ToString(), TestContext.DataRow["CampaignCode"].ToString(), TestContext.DataRow["CampaignType"].ToString(), TestContext.DataRow["ExpectedResponse"].ToString(), TestContext.DataRow["ProposedStart"].ToString(), TestContext.DataRow["ProposedEnd"].ToString(), TestContext.DataRow["ActualStart"].ToString(), TestContext.DataRow["ActualEnd"].ToString(), TestContext.DataRow["Offer"].ToString(), TestContext.DataRow["AllocatedBudget"].ToString(), TestContext.DataRow["MiscCost"].ToString(), TestContext.DataRow["CampaignDescription"].ToString(), TestContext.DataRow["ExpectedRevenue"].ToString(), TestContext.DataRow["StatusDetails"].ToString());

//            //Logout of the Application
//            login.Logout(driver, extentTest, testName, testDataIteration);

//        }

//        /// <summary>
//        /// Test Method to "Login to CRM" - Example on how rerun of test method can be Implemented if a element identification fails
//        /// </summary>
//        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Testdata$", DataAccessMethod.Sequential), TestMethod]
//        public void LoginToCRM()
//        {
//            LoginFunctions login = new LoginFunctions();

//            try
//            {
//                //Launch and Login to the Application
//                login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

//                //Logout of the Application
//                login.Logout(driver, extentTest, testName, testDataIteration);
//            }
//            catch (Exception e)
//            {
//                if (e.Message.Contains("no such element") || e.Message.Contains("no such window"))
//                {
//                    AddLog(driver, extentTest, testName, testDataIteration, "Info", "Failed at this step", "Test Failed");
//                    Type thisType = this.GetType();
//                    object testCall = this;
//                    ReRun(TestContext.TestName, ref maxTestRuns, maxTestRunsCount, extentTest, extentReport, thisType, testCall, "DriverSetup", "GetResult");
//                }
//                else
//                {
//                    Console.WriteLine(e.Message);
//                    throw;
//                }
//            }
//        }

//        /// <summary>
//        /// Method to close the browsers and Write to Report
//        /// </summary>
//        [TestCleanup]
//        public void GetResult()
//        {
//            TestCleanUp();
//        }

//        /// <summary>
//        /// Method to close the report
//        /// </summary>
//        [AssemblyCleanup]
//        public static void EndReport()
//        {
//            AssemblyCleanup();
//        }

//    }
//}