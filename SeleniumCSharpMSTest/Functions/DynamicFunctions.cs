using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesthouseSeleniumCSharp.Functions;
using System.Windows.Forms;

namespace SeleniumCSharpMSTest.Functions
{
    public class DynamicFunctions : Helper
    {
        int timeOutInSeconds = 60;
        GenericFunctions generic = new GenericFunctions();
        /// <summary>
        /// Method to Login to CRM Application
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="hitUrl"></param>
        /// <param name="testName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string hitUrl, string username, string password)
        {
            ThinkTime(1);
            string callUrl = "http://" + ConfigurationManager.AppSettings["UAT-URL"].Replace("&amp;", "&");
            driver.Navigate().GoToUrl(callUrl);
            ThinkTime(2);
            driver.Manage().Window.Maximize();
            System.Windows.Forms.SendKeys.SendWait(username);
            System.Windows.Forms.SendKeys.SendWait("{TAB}");
            System.Windows.Forms.SendKeys.SendWait(password);
            ThinkTime(2);
            System.Windows.Forms.SendKeys.SendWait("{ENTER}");
            ThinkTime(8);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Sales Pipeline']")));
                }

                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Application launched successfully", "Application launched successfully");
            }
            catch
            {
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Application failed to launched", "ApplicationLaunchFailed");
                ThinkTime(2);
                Assert.Fail("Login Failed/ Home Page failed to load");
            }
            ThinkTime(2);
        }
        public void LoginDyn(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string hitUrl, string username, string password)
        {
            //try
            //{
            //AddLog(driver, testInReport, testName, testDataIteration, "Info", "Application successfully launched", "ApplicationLaunched");

            //Console.WriteLine("password=" + password);
            //string baseUrlAuthentication = "http://" + username + ":" + password + "@" + ConfigurationManager.AppSettings["URL"];
            //ThinkTime(2);
            //Console.WriteLine("url=" + baseUrlAuthentication);
            //driver.Navigate().GoToUrl(baseUrlAuthentication);
            AddLog(driver, testInReport, testName, "Info", "Test started for " + username);
            driver.Navigate().GoToUrl(hitUrl);
            driver.Manage().Window.Maximize();
            WaitUntil(driver, Control("emailAddress", "DynLogin"), 50);
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Info", "Application successfully launched", "ApplicationLaunched");
            Element(driver, Control("emailAddress", "DynLogin")).SendKeys(username);
            Element(driver, Control("passWord", "DynLogin")).SendKeys(password);
            ThinkTime(3);
            Element(driver, Control("signIn", "DynLogin")).Click();
           
            WaitUntil(driver, Control("loginVerify", "DynLogin"), 50);
            try
            { 
                WaitUntil(driver, Control("closeWelcomePopup", "DynLogin"), 50);
                Element(driver, Control("closeWelcomePopup", "DynLogin")).Click();
            }
            catch(Exception e)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unexpected error:\n " + e, "Unexpected error");
                throw;
            } 
            
                // Verify Login Successful
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
                if (Element(driver, Control("loginVerify", "DynLogin")).Displayed)
                {
                    ThinkTime(1);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Successfully logged into the application", "Successfully logged in");
                }
                else
                {
                    ThinkTime(1);
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unable to login to the application", "Login failed");
                    Assert.IsTrue(false);
                }
         }
        //}
        //catch (Exception e)
        //{
        //    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unexpected error and unable to login :\n " + e, "Unexpectederrorandunabletologin");
        //    throw;
        //}


        /// <summary>
        /// Method to Logout of CRM Application
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        public void Logout(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                // Element(driver, Control("userInfoLink", "Login")).Click();
                ThinkTime(1);
                Element(driver, Control("signOutLabel", "DynLogin")).Click();
                ThinkTime(2);
                Element(driver, Control("signOut", "DynLogin")).Click();
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Info", "User logged out of application", "UserLogout");
            }
            catch (Exception e)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unexpected error and unable to Logout :\n " + e, "Unexpectederrorandunabletologout");
                throw;
            }
        }

    }
}
