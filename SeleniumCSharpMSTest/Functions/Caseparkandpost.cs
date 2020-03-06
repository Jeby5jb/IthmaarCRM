using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharpMSTest.ObjectRepository;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpMSTest.Functions
{
    public class Caseparking : MarketingObjects
    {


        public void Navigateservicepage(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            //Navigate to prospects
            int timeOutInSeconds = 60;
            driver.FindElement(By.XPath("//li[@title='Cases']")).Click();

            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//div[text()='Case Title'])[1]")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not navigate the page ", "can not navigate the page ");
                Assert.Fail("Page can not navigated properly");
            }
            ThinkTime(2);

        }
        public void createnewcase(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration,string Customer,string reason,string Discription)
        {
            //Create new case
            int timeOutInSeconds = 60;
            driver.FindElement(By.XPath("//span[text()='New Case']")).Click();
            ThinkTime(3);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'customerid-customerid.fieldControl-LookupResultsDropdown_customerid')]")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully navigate to the page ", "successfully navigate to the page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "can not navigate the page ", "can not navigate the page ");
                Assert.Fail("Page can not navigated properly");
            }
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'customerid-customerid.fieldControl-LookupResultsDropdown_customerid')]")).SendKeys(Customer);
              ThinkTime(5);
              driver.FindElement(By.XPath("//li[@aria-label='" +Customer+ "']")).Click();
              ThinkTime(2);

            driver.FindElement(By.XPath("//select[contains(@id,'casetypecode-casetypecode.fieldControl-option-set-select')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("(//option[text()='Service Request'])[1]")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//option[text()='Service Request'])[1]")));
                }



                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "subject filled successfully ", "subject filled successfully ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "subject not filled successfully ", "subject not  filled successfully ");
                Assert.Fail("Page can not navigated properly");
            }
            ThinkTime(2);
            driver.FindElement(By.XPath("(//div[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-input')])[1]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-9')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-10')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//label[text()='Restructure/Reschedule (default and MEMO)']")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Restructure/Reschedule (default and MEMO)']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "manditory fields filled successfully ", "manditory fields filled successfully ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "manditory fields not filled successfully ", "manditory fields not filled successfully ");
                Assert.Fail("Page can not navigated properly");
            }

            ThinkTime(4);
            driver.FindElement(By.XPath("(//span[text()='Save'])[1]")).Click();

            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'header_vrp_trackingnumber-header_vrp_trackingnumber.fieldControl-text-box-text')]")));
                }


                string trackingnumber =driver.FindElement(By.XPath("//input[contains(@id,'header_vrp_trackingnumber-header_vrp_trackingnumber.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(trackingnumber);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "tracking number generated properly", "tracking number generated properly");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "tracking number generated properly", "tracking number not generated properly");
                Assert.Fail("tracking number not  generated properly");
            }

            ThinkTime(4);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Park Case']")));
            }



            driver.FindElement(By.XPath("//span[text()='Print & Scan']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "print and scan showing properly ", "print and scan showing properly  properly ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Park Case']")).Click();


            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Status Reason']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "manditory fields not filled successfully ", "manditory fields not filled successfully ");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//input[contains(@id,'parkingrequestreasonid-vrp_parkingrequestreasonid.fieldControl-LookupResultsDropdown_vrp_parkingrequestreasonid')]")).SendKeys(reason);
            ThinkTime(2);
            driver.FindElement(By.XPath("//label[contains(@id,'parkingrequestreasonid-vrp_parkingrequestreasonid.fieldControl-vrp_name')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//textarea[contains(@id,'vrp_parkingrequestdescription-vrp_parkingrequestdescription.fieldControl-text-box-text')]")).SendKeys(Discription);
            ThinkTime(2);
            driver.SwitchTo().Frame("WebResource_ParkingSaveCancel");
            ThinkTime(2);
            IWebElement element1 = driver.FindElement(By.XPath("//button[text()='Submit']"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].scrollIntoView(true);", element1);
            driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
            ThinkTime(2);
            driver.SwitchTo().DefaultContent();
            ThinkTime(2);
            driver.FindElement(By.XPath("//div[@id='modalDialogContentContainer']//button[@id='confirmButton']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@id,'-RequiredDocuments-FieldValue_vrp_name')])[1]")));
            }


            driver.FindElement(By.XPath("//li[text()='Administration']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Escalation Reminder Time']")));
            }
            IWebElement element4 = driver.FindElement(By.XPath("//label[text()='Escalation Reminder Time']"));


            js.ExecuteScript("arguments[0].scrollIntoView(true);", element4);
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Escalation showing successfully", "Escalation showing successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//li[text()='Summary']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@id,'-RequiredDocuments-FieldValue_vrp_name')])[1]")));
            }

            driver.FindElement(By.XPath("(//div[contains(@id,'-RequiredDocuments-FieldValue_vrp_name')])[1]")).Click();


            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Document Title']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "manditory fields not filled successfully ", "manditory fields not filled successfully ");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//div[contains(@id,'vrp_iswaived')]//div[contains(@id,'vrp_iswaived-vrp_iswaived.fieldControl-checkbox-containercheckbox-inner-first')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Save']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "saved successfully", "saved successfully");
            ThinkTime(4);
            driver.Navigate().Back();
            ThinkTime(2);
            driver.FindElement(By.XPath("//button[@id='headerFieldsExpandButton']")).Click();
            ThinkTime(2);
            
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Parked successfully", "Parked successfully");
            driver.FindElement(By.XPath("//button[@id='headerFieldsExpandButton']")).Click();
            ThinkTime(2);
            IWebElement element2 = driver.FindElement(By.XPath("//label[text()='Paused']"));
            
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element2);
            
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Paused']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Paused successfully ", "Paused successfully ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Not Paused successfully", "Not Paused successfully");
                Assert.Fail(" Not Paused successfully ");
            }
            
            //Element(driver, Control("Unpark", "Service")).Click();
            //ThinkTime(4);
            //Element(driver, Control("Expandbutton", "Service")).Click();
            //ThinkTime(2);
            //try
            //{
            //    WaitUntil(driver, Control("Inprogress", "Service"), 60);
            //    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Inprogress successfully", "Inprogress successfully");
            //}
            //catch
            //{
            //    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Not Inprogress successfully ", "Not Inprogress successfully ");
            //    Assert.Fail("Page can not navigated properly");
            //}
            //Element(driver, Control("Postcase", "Service")).Click();
            //ThinkTime(6);
            //try
            //{
            //    WaitUntil(driver, Control("customer", "Service"), 60);
            //    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Posted successfully", "Posted successfully");
            //}
            //catch
            //{
            //    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Not posted successfully ", "Not posted successfully ");
            //    Assert.Fail("Page can not navigated properly");
            //}
            ////IWebElement element1 = Element(driver, Control("Weived", "Service"));
           
        }
    }
    }
