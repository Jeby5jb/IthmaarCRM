using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharpMSTest.ObjectRepository;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpMSTest.Functions
{
    public class Salesfunctions : MarketingObjects
    {


        public void Navigatetoprospects(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            //Navigate to prospects
            int timeOutInSeconds = 60;
            driver.FindElement(By.XPath("//li[@title='Prospects']")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Prospects']")));
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
        public void Createnewprospects(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string Mobilenumber,string Firstname,string Lastname,string Monthlyliabilities, string IDtype,string IDnumber,string Product,string Monthlysalary,string Dateofbirth,string Lenghtofservice,string Employer)
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
            ThinkTime(4);

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
            IWebElement element1 = driver.FindElement(By.XPath("//div[contains(@id,'vrp_eligible-vrp_eligible.fieldControl-checkbox-containercheckbox-inner-first')]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].scrollIntoView(true);", element1);
            string eligible = driver.FindElement(By.XPath("//div[contains(@id,'vrp_eligible-vrp_eligible.fieldControl-checkbox-containercheckbox-inner-first')]")).GetAttribute("aria-label");
            if (eligible == "No" || eligible == "Yes")

                try
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Boolen verified ", "Boolen verified");

                }
                catch
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Boolen not verified ", "Boolen not verified ");
                    Assert.Fail("Boolen not verified");
                }
            driver.FindElement(By.XPath("//button[@id='headerFieldsExpandButton']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Lead source ", "Lead source");
            driver.FindElement(By.XPath("//select[@title='Rating']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Hot']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Hot selected ", "successfully Hot selected");
            
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Lead source ", "Lead source");
            driver.FindElement(By.XPath("//select[@title='Rating']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Warm']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Warm selected ", "successfully Warm selected");
            
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Lead source ", "Lead source");
            driver.FindElement(By.XPath("//select[@title='Rating']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//option[text()='Cold']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Cold selected ", "successfully Cold selected");
           //SIT isuue
            
            //driver.FindElement(By.XPath("//input[contains(@id,'msfsi_interestedproductid-msfsi_interestedproductid.fieldControl-LookupResultsDropdown_msfsi_interestedproductid_7_textInputBox_with_filter_new')]")).SendKeys(Product);
            //ThinkTime(3);
            //driver.FindElement(By.XPath("//li[@aria-label='Mastercard Corporate']")).Click();
            //ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'vrp_salary-vrp_salary.fieldControl-currency-text-input')]")).SendKeys(Monthlysalary);
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[@aria-label='Date of Birth']")).Click();
            ThinkTime(2);
            int i;
            for (i = 0; i < 200; i++)
            {
                driver.FindElement(By.XPath("//button[contains(@class,'ms-DatePicker-prevMonth js-prevMonth prevMonth')]")).Click();
               
                
            }
            driver.FindElement(By.XPath("//span[text()='18']")).Click();
            ThinkTime(2);
            //driver.FindElement(By.XPath("//input[@aria-label='Date of Birth']")).SendKeys(Dateofbirth);
            //ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'lengthofservice-vrp_lengthofservice.fieldControl-whole-number-text-input')]")).Clear();
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'lengthofservice-vrp_lengthofservice.fieldControl-whole-number-text-input')]")).SendKeys(Lenghtofservice);
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'msfsi_employer-msfsi_employer.fieldControl-text-box-text')]")).Clear();
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@id,'msfsi_employer-msfsi_employer.fieldControl-text-box-text')]")).SendKeys(Employer);
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
            driver.FindElement(By.XPath("//li[@aria-label='Check Eligibility']")).Click();
            ThinkTime(2);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//h2[text()='ELIGIBILITY DETAILS']")));
            }
            ThinkTime(2);

            IWebElement element7 = driver.FindElement(By.XPath(" //label[text()='Eligibility Results']"));


            js.ExecuteScript("arguments[0].scrollIntoView(true);", element7);
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", " Eligibilty checked successfully", "Eligibilty checked successfully");
        



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

            driver.FindElement(By.XPath("//select[@title='Preferred Method of Contact']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Drop down successfully launched", "Drop down successfully launched");
            driver.FindElement(By.XPath("//option[text()='Email']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Email selected successfully", "Email selected successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("//select[@title='Preferred Method of Contact']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Drop down successfully launched", "Drop down successfully launched");
            driver.FindElement(By.XPath("//option[text()='Phone']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Phone selected successfully", "Phone selected successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("//select[@title='Preferred Method of Contact']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Drop down successfully launched", "Drop down successfully launched");
            driver.FindElement(By.XPath("//option[text()='Fax']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Fax selected successfully", "Fax selected successfully");
            ThinkTime(2);
            driver.FindElement(By.XPath("//select[@title='Preferred Method of Contact']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Drop down successfully launched", "Drop down successfully launched");
            driver.FindElement(By.XPath("//option[text()='Mail']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Mail selected successfully", "Mail selected successfully");
            ThinkTime(2);
            
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
            IWebElement element2 = driver.FindElement(By.XPath("//h2[text()='MARKETING INFORMATION']"));
            

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

            //search functionality when works
            //string newFrstname = Firstname + " newauto";
            //Console.WriteLine(newFrstname);
            //driver.FindElement(By.XPath("///a[text()='" + newFrstname + "']")).Click();
            
            //ThinkTime(3);
           // AddLog(driver, testInReport, testName, testDataIteration, "Pass", "successfully Opportunity created", "successfully navigated");
            //Element(driver, Control("Oppertunitysearch", "SalesProspect")).SendKeys(IDnumber);
            //ThinkTime(2);
            //Element(driver, Control("Searchbutton", "SalesProspect")).Click();
            //ThinkTime(2);/

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
   