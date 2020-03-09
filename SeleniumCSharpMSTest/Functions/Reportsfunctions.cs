using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharpMSTest.ObjectRepository;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumCSharpMSTest.Functions
{
    public class Reportsfunctions : MarketingObjects
    {
        private object waits;

        public void Navigatetoreports(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            //Navigate to prospects
            int timeOutInSeconds = 60;
            driver.FindElement(By.XPath("//button[@title='Site Map']")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Reports']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not navigate the page ", "can not navigate the page ");
                Assert.Fail("Page can not navigated properly");
            }
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Reports']")).Click();
            ThinkTime(4);
            string parentwindowHandle = driver.CurrentWindowHandle;
            foreach (string windowhandle in driver.WindowHandles)
            {
                if(windowhandle !=parentwindowHandle)
                {
                    string secondWindowHandle = windowhandle;
                    driver.SwitchTo().Window(secondWindowHandle);
                    driver.Manage().Window.Maximize();

                }
            }


            var waits = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("InlineDialog_Iframe")));
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[@class='navTourClose']//a[@id='buttonClose']")));
            }

            driver.FindElement(By.XPath("//div[@class='navTourClose']//a[@id='buttonClose']")).Click();
            ThinkTime(2);
            driver.SwitchTo().DefaultContent();
           
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("contentIFrame0")));
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Available Reports']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not navigate the page ", "can not navigate the page ");
                Assert.Fail("Page can not navigated properly");
            }

        }
        public void Reportdetails(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string Searchrecords,string Numberofdays,string agingSearchrecords,string Days,string AverageCaseClosuresearch)
        {
            //Reports
            int timeOutInSeconds = 60;
            driver.FindElement(By.XPath("//input[@title='Search for records']")).SendKeys(Searchrecords);
            ThinkTime(3);
            driver.FindElement(By.XPath("//a[@id='crmGrid_findCriteriaButton']")).Click();
            ThinkTime(3);

            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//a[text()='Neglected Cases']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Neglected Cases successfully filtered ", "Neglected Cases successfully filtered");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not Neglected Cases successfully filtered ", "can not Neglected Cases successfully filtered");
                Assert.Fail("Page can not Neglected Cases successfully filtered");
            }
            ThinkTime(2);

               driver.FindElement(By.XPath("//a[text()='Neglected Cases']")).Click();

               ThinkTime(2);
            string secondWindowHandle = driver.CurrentWindowHandle;
            foreach (string windowhandle in driver.WindowHandles)
            {
                if (windowhandle != secondWindowHandle)
                {
                    string thirdWindowHandle = windowhandle;
                    driver.SwitchTo().Window(thirdWindowHandle);
                    driver.Manage().Window.Maximize();

                }
            }


            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//button[@id='btnRun']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Report filtering criteria successfully verified ", "Report filtering criteria successfully verified");
            ThinkTime(2);



            driver.FindElement(By.XPath("//button[@id='btnRun']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//button[@id='btnEditFilter']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Neglected case filtering criteria successfully verified ", "Neglected case filtering criteria successfully verified");
            ThinkTime(2);
            var waits = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("resultFrame")));

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[@id='reportViewer_ctl08_ctl06']")));
            }


            driver.FindElement(By.XPath("//div[@id='reportViewer_ctl08_ctl06']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Group filtering criteria successfully verified ", "Group filtering criteria successfully verified");
            ThinkTime(2);
            driver.FindElement(By.XPath(" //select[contains(@id,'reportViewer_ct')]//option[text()='Owner']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[text()='Neglected Cases By: Owner']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Owner filtering criteria successfully verified ", "Owner filtering criteria successfully verified");
            ThinkTime(2);


            driver.FindElement(By.XPath(" //input[contains(@id,'reportViewer_ctl08_ctl04_txtValue')]")).Clear();
            ThinkTime(2);
            driver.FindElement(By.XPath(" //input[contains(@id,'reportViewer_ctl08_ctl04_txtValue')]")).SendKeys(Numberofdays);
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[text()='Show All']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Minimum days filter is showing successfully", "Minimum days filter is showing successfully");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not Minimum days filter is showing successfully ", "can not Minimum days filter is showing successfully ");
                Assert.Fail("Page can not navigated properly");
            }
            driver.SwitchTo().Window(secondWindowHandle);

            ThinkTime(4);
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("contentIFrame0")));
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[@title='Search for records']")).Clear();
            driver.FindElement(By.XPath("//input[@title='Search for records']")).SendKeys(AverageCaseClosuresearch);
            ThinkTime(3);
            driver.FindElement(By.XPath("//a[@id='crmGrid_findCriteriaButton']")).Click();
            ThinkTime(3);

            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//a[text()='Average Case Closure']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Average Case ClosureCases successfully filtered ", "Average Case Closure successfully filtered");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not Average Case Closure successfully filtered ", "can not Average Case Closure successfully filtered");
                Assert.Fail("Page can not Neglected Cases successfully filtered");
            }
            ThinkTime(2);

            driver.FindElement(By.XPath("//a[text()='Average Case Closure']")).Click();

            foreach (string windowhandle in driver.WindowHandles)
            {
                if (windowhandle != secondWindowHandle)
                {
                    string thirdWindowHandle = windowhandle;
                    driver.SwitchTo().Window(thirdWindowHandle);
                    driver.Manage().Window.Maximize();

                }
            }
            ThinkTime(2);
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("resultFrame")));
            ThinkTime(6);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//input[@type='submit']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Average Case ClosureCases successfully Navigated ", "Average Case Closure successfully Navigated");
            ThinkTime(2);

            driver.FindElement(By.XPath("//input[@name='reportViewer$ctl08$ctl04$txtValue']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//input[contains(@id,'reportViewer_ctl08_ctl04_divDropDown_ctl04')]")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//span[contains(@id,'reportViewer_ctl08_ctl06_ctl01')]")).Click();
            ThinkTime(3);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'reportViewer_ctl08_ctl06_divDropDown_ctl18')]")));
            }


            driver.FindElement(By.XPath("//input[contains(@id,'reportViewer_ctl08_ctl06_divDropDown_ctl18')]")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
            ThinkTime(3);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[text()='Average Case Closure']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Average Case ClosureCases successfully Navigated ", "Average Case Closure report successfully generated");
            ThinkTime(2);






            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("contentIFrame0")));
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[@title='Search for records']")).Clear();
            driver.FindElement(By.XPath("//input[@title='Search for records']")).SendKeys(agingSearchrecords);
            ThinkTime(3);
            driver.FindElement(By.XPath("//a[@id='crmGrid_findCriteriaButton']")).Click();
            ThinkTime(3);

            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//a[text()='Aging Report']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Aging Report Cases successfully filtered ", "Aging Report Cases successfully filtered");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not Aging Report Cases successfully filtered ", "can not Aging Report Cases successfully filtered");
                Assert.Fail("Page can not Neglected Cases successfully filtered");
            }
            ThinkTime(2);

            driver.FindElement(By.XPath("//a[text()='Aging Report']")).Click();
            
            foreach (string windowhandle in driver.WindowHandles)
            {
                if (windowhandle != secondWindowHandle)
                {
                    string thirdWindowHandle = windowhandle;
                    driver.SwitchTo().Window(thirdWindowHandle);
                    driver.Manage().Window.Maximize();

                }
            }
            ThinkTime(2);
            //try
            //{
            //    if (timeOutInSeconds > 0)
            //    {
            //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            //        wait.Until(drv => drv.FindElement(By.XPath(" //input[@type='submit']")));
            //    }

               AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Aging Report Cases successfully Navigated ", "Aging Report Cases successfully Navigated");
            //}
            //catch
            //{
            //    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not Aging Report Cases successfully Navigated ", "can not Aging Report Cases successfully Navigated");
            //    Assert.Fail("Page can not Neglected Cases successfully filtered");
            //}
            ThinkTime(2);
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("resultFrame")));
            ThinkTime(2);
            
            driver.FindElement(By.XPath("//span[contains(@id,'reportViewer_ctl08_ctl04_ctl01')]")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Aging Report Case types successfully verified ", "Aging Report Case types successfully verified");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[@id='reportViewer_ctl08_ctl06_ctl01']")).Click();
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Aging Report Subject  successfully verified ", "Aging Report Subject  successfully verified");
            //
            driver.FindElement(By.XPath("//span[contains(@id,'reportViewer_ctl08_ctl08_ctl01')]")).Click();
            ThinkTime(3);

            //JSClick(driver, By.XPath("//input[contains(@id,'reportViewer_ctl08_ctl08_txtValue')]"));
            driver.FindElement(By.XPath("//input[contains(@id,'reportViewer_ctl08_ctl08_divDropDown_ctl00')]")).Click();
            ThinkTime(4);
           // JSClick(driver, By.XPath("//input[@id='reportViewer_ctl08_ctl08_divDropDown_ctl00']"));
            //driver.FindElement(By.XPath("(//input[@type='checkbox'])[1]")).Click();


            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Aging Report Branch successfully verified ", "Aging Report Branch  successfully verified");
            ThinkTime(4);
           // driver.FindElement(By.XPath("//input[contains(@id,'reportViewer_ctl08_ctl08_divDropDown_ctl00')]")).Click();

           
             driver.FindElement(By.XPath("//input[contains(@id,'reportViewer_ctl08_ctl10_txtValue')]")).Click();
            


            //ThinkTime(5);
            ////waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("reportViewer_ctl08_ctl08_ctl02")));
            ////ThinkTime(7);
            //ElementHighlight(driver, By.XPath("(//input[contains(@id,'reportViewer_ctl')])[16]"));
            driver.FindElement(By.XPath("(//input[contains(@id,'reportViewer_ctl')])[14]")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Aging Report Business units successfully verified ", "Aging Report Business units  successfully verified");
            ThinkTime(4);
            //driver.FindElement(By.XPath("//span[contains(@id,'reportViewer_ctl08_ctl10_ctl01')]")).Click();
            //ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'reportViewer_ctl08_ctl12_txtValue')]")).SendKeys(Days);
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Number of days successfully verified ", "Number of days successfully verified");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[contains(@id,'reportViewer_ctl08_ctl14_ctl01')]")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Calender start date successfully verified ", "Calender start date  successfully verified");
            ThinkTime(4);
            driver.FindElement(By.XPath("//span[contains(@id,'reportViewer_ctl08_ctl16_ctl01')]")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Calender End date successfully verified ", "Calender End date  successfully verified");
            ThinkTime(2);
           
            

            driver.FindElement(By.XPath("//span[contains(@id,'reportViewer_ctl08_ctl04_ctl01')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//label[text()='Service Request']")).Click(); 
            ThinkTime(3);

            
            driver.FindElement(By.XPath(" //input[@type='submit']")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[text()='Case Aging Report']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Reports successfully generated ", "Reports successfully generated");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not Reports successfully generated ", "can not Reports successfully generated");
                Assert.Fail("Page can not navigated properly");
            }






           


        }
        public void CreatenewprospectsCorparate(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string Mobilenumber, string Firstname, string Lastname, string Monthlyliabilities, string IDtype, string IDnumber,string companyname,string Corpproduct,string Netprofit,string Equity,string Turnover)
        {
            //Create new prospects
            int timeOutInSeconds = 60;
            driver.FindElement(By.XPath("//span[text()='New']")).Click();

            ThinkTime(3);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//h1[@title='New Prospect']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not navigate the page ", "can not navigate the page ");
                Assert.Fail("Page can not navigated properly");
            }
            ThinkTime(2);

            driver.FindElement(By.XPath("//select[@title='Prospect Type']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Corporate']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'mobilephone-mobilephone.fieldControl-phone-text-input')]")).SendKeys(Mobilenumber);
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'firstname-firstname.fieldControl-text-box-text')]")).SendKeys(Firstname);
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'lastname-lastname.fieldControl-text-box-text')]")).SendKeys(Lastname);
            ThinkTime(4);
            driver.FindElement(By.XPath("//input[contains(@id,'vrp_idtype-vrp_idtype.fieldControl-LookupResultsDropdown_vrp_idtype_')]")).SendKeys(IDtype);
            ThinkTime(4);
            driver.FindElement(By.XPath("//input[contains(@id,'idnumber-msfsi_idnumber.fieldControl-text-box-text')]")).SendKeys(IDnumber);
            ThinkTime(4);
            driver.FindElement(By.XPath("(//label[contains(@id,'vrp_idtype-vrp_idtype.fieldControl-vrp_name0')])[1]")).Click();
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully fill the page ", "successfully fill the page");
            ThinkTime(3);

            driver.FindElement(By.XPath("//input[contains(@id,'companyname-companyname.fieldControl-text-box-text')]")).SendKeys(companyname);
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'companyname-companyname.fieldControl-text-box-text')]")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not navigate the page ", "can not navigate the page ");
                Assert.Fail("Page can not navigated properly");
            }

            driver.FindElement(By.XPath("(//span[text()='Save'])[1]")).Click();
            ThinkTime(4);
           
            driver.FindElement(By.XPath("//li[@title='Eligibility']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Interested Product']")));
            }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");

            driver.FindElement(By.XPath("//input[contains(@id,'msfsi_interestedproductid-msfsi_interestedproductid.fieldControl-LookupResultsDropdown_msfsi_interestedproductid_7_textInputBox_with_filter_new')]")).SendKeys(Corpproduct);
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='Mastercard Corporate']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'vrp_netprofit-vrp_netprofit.fieldControl-currency-text-input')]")).SendKeys(Netprofit);
            ThinkTime(3);
            driver.FindElement(By.XPath("//input[contains(@id,'vrp_equity-vrp_equity.fieldControl-whole-number-text-input')]")).SendKeys(Equity);
            ThinkTime(3);
            driver.FindElement(By.XPath("//input[contains(@id,'vrp_turnover-vrp_turnover.fieldControl-currency-text-input')]")).SendKeys(Turnover);
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='Check Eligibility']")).Click();
            ThinkTime(2);
            
            
            
            
            //IAlert alert = driver.SwitchTo().Alert();
            //alert.Accept();
            //if (timeOutInSeconds > 0)
            //{
            //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            //    wait.Until(drv => drv.FindElement(By.XPath("//h2[text()='ELIGIBILITY DETAILS']")));
            //}
            //ThinkTime(2);

            //IWebElement element7 = driver.FindElement(By.XPath(" //label[text()='Eligibility Results']"));
            //IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            //js.ExecuteScript("arguments[0].scrollIntoView(true);", element7);
            //ThinkTime(3);
            //AddLog(driver, testInReport, testName, testDataIteration, "Pass", " Eligibilty checked successfully", "Eligibilty checked successfully");








            driver.FindElement(By.XPath("//li[text()='Preferences']")).Click();
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Preferred Language']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page navigated successfully", "Page navigated successfully");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page not navigated successfully", "Page not navigated successfully");
                Assert.Fail("page not navigated");
            }

            IWebElement element2 = driver.FindElement(By.XPath("//h2[text()='MARKETING INFORMATION']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].scrollIntoView(true);", element2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//h2[text()='MARKETING INFORMATION']")));
                }

                ThinkTime(2);
                Console.WriteLine("Inside Market info");
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Marketinginfo verified", "successfully Marketinginfo verified");
                ThinkTime(4);
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "successfully Marketinginfo not verified", "successfully Marketinginfo not verified");
                Assert.Fail("prospect can not created");
            }
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Marketinginfo verified", "successfully Marketinginfo verified");
            ThinkTime(4);
            driver.FindElement(By.XPath("//span[text()='Disqualify']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Dropdown listed", "successfully Dropdown listed");
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Cannot Contact']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Dropdown listed", "successfully Dropdown listed");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", " Dropdown not listed", " Dropdown not listed");
                Assert.Fail(" Dropdown not listed ");
            }
            driver.FindElement(By.XPath("//span[text()='Cannot Contact']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Dropdown listed", "successfully Dropdown listed");
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Reactivate Lead']")));
                }
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Disqualified successfully", "Disqualified successfully");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", " Not Disqualified successfully", "Not Dropdown not listed");
                Assert.Fail(" Not disqualified successfully ");
            }
            driver.FindElement(By.XPath("//span[text()='Reactivate Lead']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Qualify']")));
            }
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page navigated successfully", "Page navigated successfully");
            ThinkTime(2);

            driver.FindElement(By.XPath("//span[text()='Qualify']")).Click();
            if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Potential Customer']")));
                }	 

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='OPPORTUNITY']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Opportunity created", "successfully Opportunity created");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", " Opportunity can not created", " Opportunity can not created");
                Assert.Fail(" Opportunity can not created");
            }


            driver.FindElement(By.XPath("//li[@title='Prospects']")).Click();

            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Prospects']")));
                }


                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Opportunity created", "successfully navigated");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", " page can not navigated", " page can not navigated");
                Assert.Fail(" Opportunity can not created");
            }

            //search
            //string newFrstname = Firstname + " newauto";
            //Console.WriteLine(newFrstname);

            //driver.FindElement(By.XPath("///a[text()='" + newFrstname + "']")).Click();
            //ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Opportunity created", "successfully navigated");
        }
        public void Inactiveprospect(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string Mobilenumber, string Firstname, string Lastname, string Monthlyliabilities, string IDtype, string IDnumber)
        {
            //Create new prospects
            int timeOutInSeconds = 60;
            driver.FindElement(By.XPath("//span[text()='New']")).Click();
            ThinkTime(3);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//h1[@title='New Prospect']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not navigate the page ", "can not navigate the page ");
                Assert.Fail("Page can not navigated properly");
            }
            ThinkTime(2);

            driver.FindElement(By.XPath("//select[@title='Prospect Type']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Retail']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'mobilephone-mobilephone.fieldControl-phone-text-input')]")).SendKeys(Mobilenumber);
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'firstname-firstname.fieldControl-text-box-text')]")).SendKeys(Firstname);
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'lastname-lastname.fieldControl-text-box-text')]")).SendKeys(Lastname);
            ThinkTime(4);
            driver.FindElement(By.XPath("//input[contains(@id,'vrp_idtype-vrp_idtype.fieldControl-LookupResultsDropdown_vrp_idtype_')]")).SendKeys(IDtype);
            ThinkTime(4);
            driver.FindElement(By.XPath("//input[contains(@id,'idnumber-msfsi_idnumber.fieldControl-text-box-text')]")).SendKeys(IDnumber);
            ThinkTime(4);
            driver.FindElement(By.XPath("(//label[contains(@id,'vrp_idtype-vrp_idtype.fieldControl-vrp_name0')])[1]")).Click();
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully fill the page ", "successfully fill the page");
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@title='Eligibility']")).Click();
            ThinkTime(2);
            try
            {
                 if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//h2[text()='ELIGIBILITY DETAILS']")));
                }	 

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not navigate the page ", "can not navigate the page ");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//input[contains(@id,'liability-vrp_liability.fieldControl-currency-text-input')]")).SendKeys(Monthlyliabilities);
            ThinkTime(2);

            driver.FindElement(By.XPath("(//span[text()='Save'])[1]")).Click();


            ThinkTime(4);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'header_vrp_prospectid-header_vrp_prospectid.fieldControl-text-box-text')]")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully prospect created", "successfully prospect created");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "prospect can not created ", "prospect can not created");
                Assert.Fail("prospect can not created");
            }
            ThinkTime(4);
            driver.FindElement(By.XPath("//span[text()='Disqualify']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Dropdown listed", "successfully Dropdown listed");
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Cannot Contact']")));
                }


                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Dropdown listed", "successfully Dropdown listed");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", " Dropdown not listed", " Dropdown not listed");
                Assert.Fail(" Dropdown not listed ");
            }
            driver.FindElement(By.XPath("//span[text()='Cannot Contact']")).Click();

            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Dropdown listed", "successfully Dropdown listed");
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Reactivate Lead']")));
                }
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Disqualified successfully", "Disqualified successfully");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", " Not Disqualified successfully", "Not Dropdown not listed");
                Assert.Fail(" Not disqualified successfully ");
            }


            driver.FindElement(By.XPath("//li[@title='Prospects']")).Click();

            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Prospects']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Opportunity created", "successfully navigated");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", " page can not navigated", " page can not navigated");
                Assert.Fail(" Opportunity can not created");
            }
           driver.FindElement(By.XPath("//span[text()='Active Prospects']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully drop down listed", "successfully drop down listed");
            driver.FindElement(By.XPath("//li[@data-text='Inactive Leads']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[text()='Topic'])[1]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigated", "successfully navigated");
            ThinkTime(2);
            string newFrstname = Firstname + " newauto";
            Console.WriteLine(newFrstname);
            driver.FindElement(By.XPath("//a[text()='" + newFrstname + "']")).Click();
            
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Reactivate Lead']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Navigated", "successfully Navigated");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Not successfully Navigated", "Not successfully Navigated");
                Assert.Fail(" Opportunity can not created");
            }
            driver.FindElement(By.XPath("//span[text()='Reactivate Lead']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Qualify']")));
            }

            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page navigated successfully", "Page navigated successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Qualify']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Potential Customer']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='OPPORTUNITY']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Opportunity created", "successfully Opportunity created");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", " Opportunity can not created", " Opportunity can not created");
                Assert.Fail(" Opportunity can not created");
            }
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Potential Customer']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Details showing", "successfully Details showing");


        }

    }
}
   