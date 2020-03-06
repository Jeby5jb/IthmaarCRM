//using OpenQA.Selenium;
//using RelevantCodes.ExtentReports;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium.Support.UI;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TesthouseSeleniumCSharp.Functions;

//namespace SeleniumCSharpMSTest.Functions
//{
//    public class LoginFunctions : Helper
//    {
//        /// <summary>
//        /// Method to Login to CRM Application
//        /// </summary>
//        /// <param name="driver"></param>
//        /// <param name="testInReport"></param>
//        /// <param name="hitUrl"></param>
//        /// <param name="testName"></param>
//        /// <param name="username"></param>
//        /// <param name="password"></param>
//        public void Login(IWebDriver driver, ExtentTest testInReport,  string testName, string testDataIteration, string hitUrl, string username, string password)
//        {
//            try
//            {
//                AddLog(driver, testInReport, testName, "Info", "Test started for " + username);
//                driver.Navigate().GoToUrl(hitUrl);
//                driver.Manage().Window.Maximize();
//                WaitUntil(driver, Control("emailAddress", "Login"), 50);
//                ThinkTime(1);
//                AddLog(driver, testInReport, testName, testDataIteration, "Info", "Application successfully launched", "ApplicationLaunched");
//                Element(driver, Control("emailAddress", "Login")).SendKeys(username);
//                Element(driver, Control("passWord", "Login")).SendKeys(password);
//                ThinkTime(3);
//                Element(driver, Control("signIn", "Login")).Click();

//                // Verify Login Successful
//                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
//                if (Element(driver, Control("loginVerify", "Login")).Displayed)
//                {
//                    ThinkTime(1);
//                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Successfully logged into the application", "Successfully logged in");
//                }
//                else
//                {
//                    ThinkTime(1);
//                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unable to login to the application", "Login failed");
//					Assert.IsTrue(false);
//                }
//            }
//            catch (Exception e)
//            {
//                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unexpected error and unable to login :\n " + e, "Unexpectederrorandunabletologin");
//                throw;
//            }
//        }

//        /// <summary>
//        /// Method to Logout of CRM Application
//        /// </summary>
//        /// <param name="driver"></param>
//        /// <param name="testInReport"></param>
//        /// <param name="testName"></param>
//        public void Logout(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
//        {
//            try
//            {
//                driver.SwitchTo().DefaultContent();
//                Element(driver, Control("userInfoLink", "Login")).Click();
//                ThinkTime(1);
//                Element(driver, Control("signOut", "Login")).Click();
//                ThinkTime(3);
//                AddLog(driver, testInReport, testName, testDataIteration, "Info", "User logged out of application", "UserLogout");
//            }
//            catch (Exception e)
//            {
//                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unexpected error and unable to Logout :\n " + e, "Unexpectederrorandunabletologout");
//                throw;
//            }
//        }
//    }
//}
