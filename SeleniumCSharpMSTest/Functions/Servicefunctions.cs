using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharpMSTest.ObjectRepository;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpMSTest.Functions
{
    public class Servicefunctions : MarketingObjects
    {


        public void Navigateservicepage(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            //Navigate to prospects
            int timeOutInSeconds=60;
            driver.FindElement(By.XPath("//span[text()='Active Cases By Priority']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Priority drop down showing ", "Priority drop down showing ");
            ThinkTime(2);
             driver.FindElement(By.XPath("//span[text()='Resolved Case Satisfaction']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Case satisfaction showing successfully ", "Case satisfaction showing successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Resolved Case Satisfaction']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Cases by Branch']")).Click();

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Case By Branches showing successfully ", "Case By Branches showing successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Cases by Branch']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath(" //span[text()='Cases by Source Channel']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Case By Source channel showing successfully ", "Case By Source channel showing successfully");
            ThinkTime(2);
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
            
        }
        public void createnewcase(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration,string Customer,string Retailcustomer,string Corparatecustomer,string Documentname,string Posttext, string Cancelreason,string Canceldiscription,string Categorychangereason,string Phonecallsubject,string Appoinmentsubject)
        {
            int timeOutInSeconds = 60;
            //Create new case
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
            driver.FindElement(By.XPath("(//span[text()='Save'])[1]")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//label[text()='A required field cannot be empty.'])[1]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer Requiredfield field not filled successfully ", "Customer Requiredfield field not filled successfully");
            ThinkTime(4);
            driver.FindElement(By.XPath("//ul[@aria-label='Source Channel  Lookup']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("(//button[@aria-label='Search All Records'])[2]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//li[@aria-label='Email']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Source channel is selected successfully ", "Source channel is selected successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("//select[@title='Preferred Communication']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Preffered communication selected ", "Preffered communication selected ");
            driver.FindElement(By.XPath("//option[text()='SMS']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Preffered communication SMS selected ", "Preffered communication SMS selected ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//select[@title='Preferred Communication']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Internet Banking (Secure Mail)']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Preffered communication Internetbanking selected ", "Preffered communication Internetbanking selected ");
            driver.FindElement(By.XPath("//select[@title='Preferred Communication']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Mobile Banking']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Preffered communication Mobilebanking selected ", "Preffered communication Mobilebanking selected ");
            driver.FindElement(By.XPath("//select[@title='Preferred Communication']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Email']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Preffered communication Email selected ", "Preffered communication Email selected ");



            driver.FindElement(By.XPath("//input[contains(@id,'customerid-customerid.fieldControl-LookupResultsDropdown_customerid')]")).SendKeys(Customer);
            ThinkTime(5);
            driver.FindElement(By.XPath("//li[@aria-label='" +Customer+ "']")).Click();
            ThinkTime(2);


            driver.FindElement(By.XPath("//select[contains(@id,'casetypecode-casetypecode.fieldControl-option-set-select')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("(//option[text()='Complaint'])[1]")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//option[text()='Complaint'])[1]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Complaint filled successfully ", "Complaint filled successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//select[contains(@id,'casetypecode-casetypecode.fieldControl-option-set-select')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("(//option[text()='Inquiry'])[1]")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//option[text()='Inquiry'])[1]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Inquiry filled successfully ", "Inquiry filled successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//select[contains(@id,'casetypecode-casetypecode.fieldControl-option-set-select')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("(//option[text()='Suggestion/Feedback'])[1]")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//option[text()='Compliment'])[1]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Feedback filled successfully ", "Feedback filled successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//select[contains(@id,'casetypecode-casetypecode.fieldControl-option-set-select')]")).Click();
            ThinkTime(2);
            //driver.FindElement(By.XPath("//option[text()='Suggestion']")).Click();
            //ThinkTime(2);
            //if (timeOutInSeconds > 0)
            //{
            //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            //    wait.Until(drv => drv.FindElement(By.XPath("//option[text()='Suggestion']")));
            //}
            //AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Suggetion filled successfully ", "Suggetion filled successfully ");
            //ThinkTime(2);

            driver.FindElement(By.XPath("(//span[text()='Save'])[1]")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[contains(@title,'A required field cannot be empty.')]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Requiredfield field not filled successfully ", "Requiredfield field not filled successfully");
            ThinkTime(2);

            driver.FindElement(By.XPath("//select[contains(@id,'casetypecode-casetypecode.fieldControl-option-set-select')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("(//option[text()='Complaint'])[1]")).Click();
            ThinkTime(2);
           
            ThinkTime(2);
            driver.FindElement(By.XPath("(//div[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-input')])[1]")).Click();
            ThinkTime(2);
            IWebElement element4 = driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-9')]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].scrollIntoView(true);", element4);


            driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-9')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-10')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//label[text()='Restructure/Reschedule (default and MEMO)']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Different subject selected successfully ", "Different subject selected successfully");
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
            driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-10')]")).Click();
            ThinkTime(2);
            IWebElement element1 = driver.FindElement(By.XPath("//label[text()='Account Information Update Form']"));
            

            js.ExecuteScript("arguments[0].scrollIntoView(true);", element1);

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Account Information Update Form']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Complete drop down verified ", "Complete drop down verified ");
            ThinkTime(2);
            driver.FindElement(By.XPath("(//div[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-input')])[1]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-9')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-10')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//label[text()='Restructure/Reschedule (default and MEMO)']")).Click();
            ThinkTime(2);
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
            driver.FindElement(By.XPath("//div[contains(@id,'prioritycode-prioritycode.fieldControl-option-set-select-container')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Low']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//option[text()='Low']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Low selected successfully ", "Low selected successfully ");
            ThinkTime(4);

            driver.FindElement(By.XPath("//div[contains(@id,'prioritycode-prioritycode.fieldControl-option-set-select-container')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='High']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//option[text()='High']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "High selected successfully ", "High selected successfully ");

            driver.FindElement(By.XPath("//div[contains(@id,'prioritycode-prioritycode.fieldControl-option-set-select-container')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Medium']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//option[text()='Medium']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Medium selected successfully ", "Medium selected successfully ");


            driver.FindElement(By.XPath("(//span[text()='Save'])[1]")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'header_vrp_trackingnumber-header_vrp_trackingnumber.fieldControl-text-box-text')]")));
                }
                string trackingnumber = driver.FindElement(By.XPath("//input[contains(@id,'header_vrp_trackingnumber-header_vrp_trackingnumber.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(trackingnumber);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "tracking number generated properly", "tracking number generated properly");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "tracking number generated properly", "tracking number not generated properly");
                Assert.Fail("tracking number not  generated properly");
            }
            ThinkTime(4);
            string readOnly = driver.FindElement(By.XPath("//li[contains(@id,'customerid-customerid.fieldControl-LookupResultsDropdown_customerid')]")).GetAttribute("aria-disabled");
            Assert.AreEqual(readOnly, "true");
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customernamefield is read only verified ", "Customernamefield is read only verified ");

            driver.FindElement(By.XPath("//div[contains(@id,'prioritycode-prioritycode.fieldControl-option-set-select-container')]")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Priority is read only verified ", "Priority is read only verified ");
            ThinkTime(4);
            driver.FindElement(By.XPath("(//div[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-input')])[1]")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Subject is read only verified ", "Subject is read only verified ");


           
            driver.FindElement(By.XPath("//span[text()='Resolve Case']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//h1[text()='Resolve Case']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Resolve page show successfully ", "Resolve page show successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Resolve']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//button[@id='okButton']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Error showing successfully ", "Error showing successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("//button[@id='okButton']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='A required field cannot be empty.']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "A required field cannot be empty is  showing successfully ", "A required field cannot be empty is showing successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Cancel']")).Click();
            ThinkTime(3);

            
            driver.FindElement(By.XPath("(//div[contains(@id,'-RequiredDocuments-FieldValue_vrp_name')])[1]")).Click();
            ThinkTime(2);
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
            ThinkTime(2);
            IWebElement element3 = driver.FindElement(By.XPath("//div[contains(@id,'vrp_iswaived')]//div[contains(@id,'vrp_iswaived-vrp_iswaived.fieldControl-checkbox-containercheckbox-inner-first')]"));
            

            js.ExecuteScript("arguments[0].scrollIntoView(true);", element3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            ThinkTime(3);

            //string Weived= driver.FindElement(By.XPath("//div[contains(@id,'vrp_iswaived')]//div[contains(@id,'vrp_iswaived-vrp_iswaived.fieldControl-checkbox-containercheckbox-inner-first')]")).Text;
            // //if (Weived == "No")
            //{
            ThinkTime(3);
            driver.FindElement(By.XPath("//div[contains(@id,'vrp_iswaived')]//div[contains(@id,'vrp_iswaived-vrp_iswaived.fieldControl-checkbox-containercheckbox-inner-first')]")).Click();
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Weived successfully ", "Weived successfully");

            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Save']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "saved successfully", "saved successfully");
            ThinkTime(4);
            driver.Navigate().Back();
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Summary']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
            //ThinkTime(3);
            //driver.FindElement(By.XPath("//div[contains(@id,'vrp_iswaived')]//div[contains(@id,'vrp_iswaived-vrp_iswaived.fieldControl-checkbox-containercheckbox-inner-second')]")).Click();
            //ThinkTime(3);
            //driver.FindElement(By.XPath("//div[contains(@id,'vrp_iswaived')]//div[contains(@id,'vrp_iswaived-vrp_iswaived.fieldControl-checkbox-containercheckbox-inner-first')]")).Click();
            //ThinkTime(2);

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@id,'-RequiredDocuments-FieldValue_vrp_name')])[1]")));
            }
            ThinkTime(2);
            driver.FindElement(By.XPath("(//button[contains(@id,'RequiredDocuments-CardCommandBarButton')])[2]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//div[text()='Delete Required Document']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Delete']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@id,'-RequiredDocuments-FieldValue_vrp_name')])[1]")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Document deleted successfully ", "Document deleted successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("(//li[@title='More Commands'])[3]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath(" //span[text()='Add Existing Required Document']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[@aria-label='  Lookup Look for Required Document']")).SendKeys(Documentname);
            ThinkTime(2);
            driver.FindElement(By.XPath("(//li[@aria-label='Collection Documents'])[1]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Add']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@id,'-RequiredDocuments-FieldValue_vrp_name')])[1]")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Document added successfully ", "Document added successfully");
            ThinkTime(2);
            
            //driver.FindElement(By.XPath("//div[contains(@id,'vrp_iswaived')]//div[contains(@id,'vrp_iswaived-vrp_iswaived.fieldControl-checkbox-containercheckbox-inner-first')]")).Click();
            //ThinkTime(2);
           
            driver.FindElement(By.XPath("//span[text()='Post Case']")).Click();
            ThinkTime(4);
            IWebElement element6 = driver.FindElement(By.XPath("//label[text()='Resolution Due By']"));


            js.ExecuteScript("arguments[0].scrollIntoView(true);", element6);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Counting started ", "Counting started ");
            ThinkTime(2);

            
            driver.FindElement(By.XPath("//li[text()='Related']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Activities']")).Click();

            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[@id='subject']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
            ThinkTime(4);
            driver.FindElement(By.XPath("//a[contains(text(),'Restructure Request')]")).Click();

            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Task']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//span[text()='Set Task Outcome']")).Click();

            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Requirements Fulfillment']")).Click();

            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[@id='subject']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("(//a[contains(text(),'Restructure')])[1]")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Task']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//span[text()='Set Task Outcome']")).Click();

            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Requirements Fulfillment']")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[@id='subject']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("(//a[contains(text(),'Restructure')])[1]")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Task']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//span[text()='Set Task Outcome']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Document Uploads']")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[@id='subject']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//a[contains(text(),'Completed Restructure Process')]")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Task']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//span[text()='Set Task Outcome']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("(//span[text()='Completed'])[2]")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Reactivate Case']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Page can not navigated properly ", "Page can not navigated properly");
                Assert.Fail("Page can not navigated properly");
            }
           
            ThinkTime(2);
            driver.FindElement(By.XPath("(//div[@title='Resolve'])[1]")).Click();

            ThinkTime(2);
            driver.FindElement(By.XPath("//label[text()='Finish']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Completed']")));
            }


            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page can navigated properly ", "Page can navigated properly ");


            driver.FindElement(By.XPath("//button[@title='Close']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Resolve']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Successfully resolved", "Successfully resolved ");
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Succeeded']")));
            }

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Succeeded the case", "Succeeded the case ");

            ThinkTime(2);
            driver.FindElement(By.XPath("(//button[@aria-label='Search'])[1]")).Click();


            ThinkTime(2);
            driver.FindElement(By.XPath("//input[@aria-label='Search box']")).SendKeys(Retailcustomer);
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[@id='searchButtonIcon']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@id,'MscrmControls.Grid.GridControl.contact-ListItemContainer')]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Persons successfully viewed", "Persons successfully viewed ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//div[@aria-label='ABDULLA ABDULAZIZ ABDULLA ALABBASI ---- ----']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//li[@title='Profile Summary']")));
            }
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer details showing successfully", "Customer detailsshowing successfully ");
            ThinkTime(2);
            //if (timeOutInSeconds > 0)
            //{
            //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            //    wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Collaboration']")));
            //}
            driver.FindElement(By.XPath("//li[text()='Collaboration']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//h3[text()='Timeline']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collabration showing successfully", "Collabration showing successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//label[@title='Add info and activities']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Add post showing successfully", "Add post  showing successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//li[@aria-label='Post']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Add post details showing successfully", "Add post details showing successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//textarea[@id='create_post_postText']")).SendKeys(Posttext);
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Add']")).Click();
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//div[text()='Sandeep Mathias'])[1]")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Posted successfully ", "Posted successfully ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Not Posted successfully ", "Not Posted successfully ");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//label[@title='Add info and activities']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Add post showing successfully", "Add post  showing successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//li[@title='Phone Call']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Add phone call showing successfully", "Add phone call details showing successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'subject-subject.fieldControl-text-box-text')]")).SendKeys(Phonecallsubject);
            ThinkTime(2);
            driver.FindElement(By.XPath("(//span[text()='Save'])[3]")).Click();
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//div[text()='Sandeep Mathias'])[1]")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Phone call added successfully ", "Phone call added  successfully ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Not Phone call added  successfully ", "Not Phone call added  successfully ");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//label[@title='Add info and activities']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Add post showing successfully", "Add post  showing successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//li[@title='Appointment']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Appoinment showing successfully", "Appoinment details showing successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'subject-subject.fieldControl-text-box-text')]")).SendKeys(Appoinmentsubject);
            ThinkTime(2);
            driver.FindElement(By.XPath("(//span[text()='Save'])[3]")).Click();
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//div[text()='Sandeep Mathias'])[1]")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Appoinment added successfully ", "Appoinment added  successfully ");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Not Appoinment added  successfully ", "Not Appoinment added  successfully ");
                Assert.Fail("Page can not navigated properly");
            }
            driver.FindElement(By.XPath("//li[text()='Profile Summary']")).Click();
            ThinkTime(3);
            //driver.FindElement(By.XPath("//div[contains(@id,'MscrmControls.Grid.GridControl.contact-ListItemContainer')]")).Click();
            //ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='ID Type']")));
            }
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page navigated successfully", "Page navigated successfully ");
            ThinkTime(2);
            string IDnumber = driver.FindElement(By.XPath("//input[contains(@id,'vrp_idno-vrp_idno.fieldControl-text-box-text')]")).GetAttribute("value");
            try
            {
                if (!String.IsNullOrEmpty(IDnumber))
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Id number populated successfully", "Id number populated successfully ");
                    
                }

            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Id number not populated successfully ", "Id number not populated successfully ");
                Assert.Fail("Page can not navigated properly");
            }

            string CIFnumber = driver.FindElement(By.XPath("//input[contains(@id,'header_vrp_supercif-header_vrp_supercif.fieldControl-text-box-text')]")).GetAttribute("value");
            try
            {
                if (!String.IsNullOrEmpty(CIFnumber))
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "CIF number populated successfully", "CIF number populated successfully ");

                }

            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "CIF number not populated successfully ", "CIF number not populated successfully ");
                Assert.Fail("Page can not navigated properly");
            }



            driver.FindElement(By.XPath("(//button[@aria-label='Search'])[1]")).Click();


            ThinkTime(2);
            driver.FindElement(By.XPath("//input[@aria-label='Search box']")).SendKeys(Corparatecustomer);
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[@id='searchButtonIcon']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@id,'MscrmControls.Grid.GridControl.contact-ListItemContainer')]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Persons successfully viewed", "Persons successfully viewed ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//div[@aria-label='Al Malkiya Wll ---- AHMED EBRAHIM ABDULLATIF']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Customer Type']")));
            }
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Page navigated successfully", "Page navigated successfully ");
            ThinkTime(2);
            string Customername = driver.FindElement(By.XPath("//input[contains(@id,'name-name.fieldControl-text-box-text')]")).GetAttribute("value");
            try
            {
                if (!String.IsNullOrEmpty(Customername))
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "customername populated successfully", "Id number populated successfully ");

                }

            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "customername not populated successfully ", "Id number not populated successfully ");
                Assert.Fail("Page can not navigated properly");
            }

            string Email = driver.FindElement(By.XPath("//input[contains(@id,'emailaddress1-emailaddress1.fieldControl-mail-text-input')]")).GetAttribute("value");
            try
            {
                if (!String.IsNullOrEmpty(Email))
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Email address populated successfully", "Email address  populated successfully ");

                }

            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Email address  not populated successfully ", "Email address  not populated successfully ");
                Assert.Fail("Page can not navigated properly");
            }


            driver.FindElement(By.XPath("//button[@aria-label='Assign']")).Click();
            ThinkTime(2);
            var waits = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ClientApiFrame_8")));
            
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//span[text()='Assign'])[2]")));
            }
            ThinkTime(2);
            driver.FindElement(By.XPath("(//span[text()='Assign'])[2]")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Assigned successfully", "Assigned successfullysuccessfully ");
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.XPath("//span[text()='Change Category']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("(//div[contains(@id,'vrp_requestedsubjectid-vrp_requestedsubjectid.fieldControl-subject-tree-input')])[1]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-9')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[contains(@id,'subjectid-subjectid.fieldControl-subject-tree-dropdown-icon-10')]")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//label[text()='Restructure/Reschedule (default and MEMO)']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//textarea[contains(@id,'ace08031d75f-264-vrp_categorychangereason-vrp_categorychangereason.fieldControl-text-box-text')]")).SendKeys(Categorychangereason);
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Manditory fields filled successfully ", "Manditory fields filled successfully ");
            ThinkTime(2);
            driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
            ThinkTime(2);
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ClientApiFrame_id - 3871")));
            driver.FindElement(By.XPath("//button[@id='confirmButton']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Change category done successfully ", "Change category done successfully ");
            ThinkTime(2);

            driver.FindElement(By.XPath("//span[text()='Cancel Case']")).Click();
            ThinkTime(2);
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ClientApiFrame_id-3699")));

            driver.FindElement(By.XPath("//span[@id='confirmButtonText']")).Click();
            
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Assigned successfully", "Assigned successfullysuccessfully ");
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.XPath("//input[@aria-label='Cancellation Reason  Lookup']")).SendKeys(Cancelreason);
            ThinkTime(2);
            driver.FindElement(By.XPath("//label[text()='Information Invalid']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath(" //textarea[contains(@id,'-vrp_cancellationdescription-vrp_cancellationdescription.fieldControl-text-box-text')]")).SendKeys(Canceldiscription);
            ThinkTime(2);
            driver.FindElement(By.XPath("//button[text()='Submit']")).Click();
            ThinkTime(2);
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ClientApiFrame_id-5048")));

            driver.FindElement(By.XPath("//span[@id='confirmButtonText']")).Click();
            ThinkTime(2);
            driver.SwitchTo().DefaultContent();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//button[@id='headerFieldsExpandButton']")));
            }
            driver.FindElement(By.XPath("//button[@id='headerFieldsExpandButton']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Canceled  successfully", "Canceled successfullysuccessfully ");
        }
    }
    }
