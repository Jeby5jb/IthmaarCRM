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
//    public class Testing1 : BaseClass
//    {
//        /// <summary>
//        /// Method to start the driver and report
//        /// </summary>
//        [TestInitialize]
//        public void Initialize()
//        {
//            TestInitialize();
//        }

//        /// <summary>
//        /// Test Method to "Creating a Marketing Campaign, Add a Lead, Qualify the created Lead to Opportunity, Close as Won the opportunity" - Test Method Example for execution
//        /// </summary>
//        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Testdata$", DataAccessMethod.Sequential), TestMethod]
//        public void MarketingCampaign1()
//        {
//           // MarketingFunctions marketing = new MarketingFunctions();
//            LoginFunctions login = new LoginFunctions();

//            //Launch and Login to the Application
//            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

//            //Create a new Marketing Campaign
//            //marketing.CreateNewMarketingCampaign(driver, extentTest, testName, testDataIteration, TestContext.DataRow["CampaignName"].ToString(), TestContext.DataRow["CampaignCode"].ToString(), TestContext.DataRow["CampaignType"].ToString(), TestContext.DataRow["ExpectedResponse"].ToString(), TestContext.DataRow["ProposedStart"].ToString(), TestContext.DataRow["ProposedEnd"].ToString(), TestContext.DataRow["ActualStart"].ToString(), TestContext.DataRow["ActualEnd"].ToString(), TestContext.DataRow["Offer"].ToString(), TestContext.DataRow["AllocatedBudget"].ToString(), TestContext.DataRow["MiscCost"].ToString(), TestContext.DataRow["CampaignDescription"].ToString(), TestContext.DataRow["ExpectedRevenue"].ToString(), TestContext.DataRow["StatusDetails"].ToString());

//            //Logout of the Application
//            login.Logout(driver, extentTest, testName, testDataIteration);

//        }

//        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Testdata$", DataAccessMethod.Sequential), TestMethod]
//        public void Test()
//        {
//            driver.Navigate().GoToUrl("https://google.com");
//            AddLog(driver, extentTest, testName, testDataIteration, "Info", "Test started", "TestStarted");
//        }

//        /// <summary>
//        /// Method to close the browsers and Write to Report
//        /// </summary>
//        [TestCleanup]
//        public void GetResult()
//        {
//            TestCleanUp();
//        }

//    }
//}