using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharpMSTest.ObjectRepository;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpMSTest.Functions
{
    public class CollectionFunctions : MarketingObjects
    {

        string newCase;
        /// <summary>
        /// Method to Create a new Campaign
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="name"></param>
        public int timeOutInSeconds = 80;
        public void NavigateToCollection(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            driver.FindElement(By.XPath("//button[@title='Site Map']/div")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Collection Tickets']")));
            }
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Successfully navigated to Companies list", "Successfully navigated to Companies list");
            driver.FindElement(By.XPath("//span[text()='Collection Tickets']")).Click();

        }

        public void NavigateToDashboard(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            Element(driver, Control("hamburgerMenu", "Generic")).Click();
            WaitUntil(driver, Control("dashboard", "Collections"), 60);
            ThinkTime(3);
            Element(driver, Control("dotmenu", "Collections")).Click();
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Successfully navigated to Dashboard", "Successfully navigated to Dashboard");
        }
        public void SearchRecord(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }
        }
        public void SelectAllCollectionTicketAndRequiredTicket(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration,string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" +record+ "']")).Displayed)
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'vrp_uniquereferenceno-vrp_uniquereferenceno.fieldControl-text-box-text')]")));
            }
            ThinkTime(10);
            try
            {
                string uniquerefno = driver.FindElement(By.XPath("//input[contains(@id,'vrp_uniquereferenceno-vrp_uniquereferenceno.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(uniquerefno);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Unique Reference number available", "Unique Reference number available");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unique Reference number not available", "Unique Reference number not available");
                Assert.Fail("Unique Refernce Number not available");
            }

            try
            {
                string product = driver.FindElement(By.XPath("//label[contains(@id,'vrp_productid-vrp_productid.fieldControl-LookupResultsDropdown_vrp_productid')]")).Text;
                Console.WriteLine(product);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Product Detail available", "Product Detail available");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Product Detail not available", "Product Detail not available");
                Assert.Fail("Product Detail not available");
            }

            try
            {
                string debtor = driver.FindElement(By.XPath("//li[contains(@id,'vrp_debtorid.fieldControl-LookupResultsDropdown_vrp_debtorid')]")).GetAttribute("title");
                Console.WriteLine(debtor);

            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Debtor Detail not available", "Debtor Detail not available");
                Assert.Fail("Debtor Detail not available");
            }


            try
            {
                IWebElement elem1 = driver.FindElement(By.XPath("//input[contains(@id,'delinquentperiod-vrp_delinquentperiod.fieldControl-whole-number-text-input')]"));

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", elem1);

                string daysoutstanding = driver.FindElement(By.XPath("//input[contains(@id,'delinquentperiod-vrp_delinquentperiod.fieldControl-whole-number-text-input')]")).GetAttribute("value");
                Console.WriteLine(daysoutstanding);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Days Outstanding  Detail  available", "Days Outstanding  Detail available");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Days Outstanding  Detail not available", "Days Outstanding  Detail not available");
                Assert.Fail("Days Outstanding  Detail not available");
            }


            try
            {
                string contractnumber = driver.FindElement(By.XPath("//input[contains(@id,'vrp_contractnumber-vrp_contractnumber.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(contractnumber);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Contract Number available", "Contract Number available");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Contract Number not available", "Contract Number not available");
                Assert.Fail("Contract Number not available");
            }


            try
            {
                string contractnumber = driver.FindElement(By.XPath("//li[contains(@id,'ownerid-ownerid.fieldControl-LookupResultsDropdown_ownerid')]")).GetAttribute("title");
                Console.WriteLine(contractnumber);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Owner available", "Owner available");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Owner not available", "Owner not available");
                Assert.Fail("Owner not available");
            }

            try
            {
                string bucket = driver.FindElement(By.XPath("//li[contains(@id,'bucket-vrp_bucket.fieldControl-LookupResultsDropdown_vrp_bucket')]")).GetAttribute("title");
                Console.WriteLine(bucket);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Bucket field available", "Bucket Field available");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Bucket field not available", "Bucket field not available");
                Assert.Fail("Bucket field available");
            }
        }

        public void VerifyForRetail(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration,string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[contains(@id,'vrp_customertype-vrp_customertype.fieldControl-checkbox-inner-first')]")));
            }
            ThinkTime(6);
            try
            {
                string custtype = driver.FindElement(By.XPath("//label[contains(@id,'vrp_customertype-vrp_customertype.fieldControl-checkbox-inner-first')]")).Text;
                Console.WriteLine(custtype);
                if (custtype == "Retail")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer is Retail", "Customer is Retail");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer is not Retail", "Customer is not Retail");
                Assert.Fail("Customer is not Retail");
            }

            driver.FindElement(By.XPath("//li[contains(@id,'vrp_debtorid.fieldControl-LookupResultsDropdown_vrp_debtorid')]")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='ID Type']")));
            }
            ThinkTime(6);
            try
            {
                string customerview = driver.FindElement(By.XPath("//span[contains(@id,'text-value')]")).Text;
                Console.WriteLine(customerview);
                if(customerview == "Person: 360 *")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer is 360 view", "Customer is having 360 degree");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer is not having 360 view", "Customer is not having 360 view");
                Assert.Fail("Customer view not Perosn 360");
            }
            ThinkTime(5);
            try
            {
                IWebElement element = driver.FindElement(By.XPath("//label[@data-id='vrp_maritalstatus.fieldControl-LookupResultsDropdown_vrp_maritalstatus_selected_tag_text']"));
                string maritialstatus = driver.FindElement(By.XPath("//label[@data-id='vrp_maritalstatus.fieldControl-LookupResultsDropdown_vrp_maritalstatus_selected_tag_text']")).Text;
                Console.WriteLine(maritialstatus);


                //Move to element
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", element);

                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Maritial Status filed verified", "Maritial Status filed verified");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Maritial Status not filed ", "Maritial Status not filed verified");
                Assert.Fail("Maritial Status mandatory not filled");
            }

            //Mandatory field id verification
            try
            {
                IWebElement ID = driver.FindElement(By.XPath("//input[contains(@id,'vrp_idno-vrp_idno.fieldControl-text-box-text')]"));

                //Move to element
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", ID);

                string id = driver.FindElement(By.XPath("//input[contains(@id,'vrp_idno-vrp_idno.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(id);


            }
            catch
            {
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "ID is not filled", "ID is not filled");
                Assert.Fail("Last Name mandatory field is not filled");
            }

            //Move to Products Tab
            driver.FindElement(By.XPath("//li[text()='Products']")).Click();

            ThinkTime(3);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[text()='Number'])[1]")));
            }


        }

        public void ServiceCollectionItemVerify(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            ThinkTime(6);
            driver.FindElement(By.XPath("(//div[@id='dataSetRoot_Collections']//div[contains(@data-lp-id,'vrp_collectionitem|vrp_contact_vrp_collectionitem_Debtor|cc-grid|cc-grid-cell|cell')]/a)[1]")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@id,'productnumber-FieldSectionItemContainer')]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ServicePageDisplayed", "Service Page Displayed");
            ThinkTime(6);
            try
            {
                string status =  driver.FindElement(By.XPath("//select[contains(@id,'header_statecode-header_statecode.fieldControl-option-set-select')]")).GetAttribute("title");
                Console.WriteLine(status);
                if(status == "Status")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "StatusDisplayed", "StatusDisplayed");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Status not Displayed", "Status not Displayed");
                Assert.Fail("Status is not displayed");
            }
            driver.Navigate().Back();
            ThinkTime(4);
        }

        public void VerifyForCorporate(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record, string cname)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            ThinkTime(5);
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'vrp_uniquereferenceno-vrp_uniquereferenceno.fieldControl-text-box-text')]")));
            }
            ThinkTime(5);
            //Verify Unique Ref 
            try
            {
                string uniqueref = driver.FindElement(By.XPath("//input[contains(@id,'vrp_uniquereferenceno-vrp_uniquereferenceno.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(uniqueref);

            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unique Ref not avilable", "Unique Ref not avilable");
                Assert.Fail("Unique Ref is not available");
            }

            //Verify Customer type is Corporate
            try
            {
                string custtype = driver.FindElement(By.XPath("//label[contains(@id,'vrp_customertype-vrp_customertype.fieldControl-checkbox-inner-first')]")).Text;
                Console.WriteLine(custtype);
                if (custtype == "Corporate")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer is Retail", "Customer is Retail");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer is not Retail", "Customer is not Retail");
                Assert.Fail("Customer is not Corporate");
            }

            //Verify overdue through days outstanding
            try
            {
                string outstandingDays = driver.FindElement(By.XPath("//input[contains(@id,'delinquentperiod-vrp_delinquentperiod.fieldControl-whole-number-text-input')]")).GetAttribute("value");
                Console.WriteLine(outstandingDays);
                if (outstandingDays != " ")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Days Outstanding verified", "Days Outstanding verified");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Outstanding Days is null", "Outstanding Days is null");
                Assert.Fail("Outstanding Days is null");
            }

            //Select the company for the corporate customer
            driver.FindElement(By.XPath("//ul[@aria-label='Company  Lookup']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Customer Type']")));
            }

            ThinkTime(4);
             //Verify the company view
            try
            {
                ThinkTime(5);
                string customerview = driver.FindElement(By.XPath("//span[contains(@id,'text-value')]")).Text;
                Console.WriteLine(customerview);
                if (customerview == "Company: Corporate 360*")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Corporate is 360 view", "Corporate is having 360 degree");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Corporate is not having 360 view", "Corporate is not having 360 view");
                Assert.Fail("Corporate view not Perosn 360");
            }
            ThinkTime(5);
            try
            {
                string companyfullname = driver.FindElement(By.XPath("//input[contains(@id,'name-name.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(companyfullname);
                if (companyfullname == cname)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Company Full name is filled", "Company Full name is filled");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Company Full name is not filled", "Company Full name is not filled");
                Assert.Fail("Company Full name is blank");
            }

            try
            {
                IWebElement elem2 = driver.FindElement(By.XPath("//li[contains(@id,'vrp_relationshipmanager-vrp_relationshipmanager.fieldControl-LookupResultsDropdown_vrp_relationshipmanager')]"));

                IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
                js1.ExecuteScript("arguments[0].scrollIntoView();", elem2);

                string relationshipmanager = driver.FindElement(By.XPath("//li[contains(@id,'vrp_relationshipmanager-vrp_relationshipmanager.fieldControl-LookupResultsDropdown_vrp_relationshipmanager')]")).GetAttribute("aria-label");
                Console.WriteLine(relationshipmanager);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Relationshipmanager name is filled", "Relationshipmanager name is filled");
            }
            catch
            {
                
            }

            try
            {
                //IWebElement elem1 = driver.FindElement(By.XPath("//li[contains(@id,'vrp_relationshipmanager-vrp_relationshipmanager.fieldControl-LookupResultsDropdown_vrp_relationshipmanager')]"));

                //IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
                //js2.ExecuteScript("arguments[0].scrollIntoView();", elem1);

                string tel = driver.FindElement(By.XPath("//input[contains(@id,'telephone1-telephone1.fieldControl-phone-text-input')]")).GetAttribute("value");
                Console.WriteLine(tel);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Telephone number is filled", "Telephone number is filled");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Telephone number is not filled", "Telephone number is not filled");
                Assert.Fail("Telephone number is blank");
            }

            try
            {
                string tele = driver.FindElement(By.XPath("//input[contains(@id,'emailaddress1-emailaddress1.fieldControl-mail-text-input')]")).GetAttribute("value");
                Console.WriteLine(tele);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Email Address is filled", "Email Address is filled");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Email Address is not filled", "Email Address is not filled");
                Assert.Fail("Email Address is blank");
            }


            ThinkTime(5);

            //try
            //{
            IWebElement el = driver.FindElement(By.XPath("//input[contains(@id,'name-name.fieldControl-text-box-text')]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", el);

            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Product Image is filled", "Product Image is filled");
            //}
            //catch
            //{
            //    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Product Image is not filled", "Product Image is not filled");
            //    Assert.Fail("Product Image is blank");
            //}

            //Move to Products Tab
            driver.FindElement(By.XPath("//li[text()='Products']")).Click();

            ThinkTime(3);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[text()='Number'])[1]")));
            }


        }


        public void SelectCollectionRecord(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }
        }

        public void APRCalculator(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            ThinkTime(6);
            driver.FindElement(By.XPath("(//button[@data-id='OverflowButton'])[1]")).Click();          
            ThinkTime(2);

            //Click on Overflow button & click on useful links
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//button[@data-id='vrp_collectionitem|NoRelationship|Form|vrp.vrp_collectionitem.UsefulLinks.Button']")));
                }
                driver.FindElement(By.XPath("//button[@data-id='vrp_collectionitem|NoRelationship|Form|vrp.vrp_collectionitem.UsefulLinks.Button']")).Click();
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to UsefulLinks", "Navigated to UsefulLinks");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", " Cannot Navigate to UsefulLinks", "Cannot Navigated to UsefulLinks");
                Assert.Fail("UsefulLink not available");
            }

            ThinkTime(2);

            string parentwindow = driver.CurrentWindowHandle;

            driver.FindElement(By.XPath("//button[@data-id='vrp_collectionitem|NoRelationship|Form|vrp.vrp_collectionitem.aprcalculatorbtn.Button']")).Click();
            ThinkTime(5);

            //Switch control to new window for selenium driver
            foreach(string windows in driver.WindowHandles)
            {
                if(parentwindow != windows)
                {
                    string secondwindow = windows;
                    driver.SwitchTo().Window(secondwindow);

                }
            }

            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//a[@title='Close']")));
                }

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to APRCalculator Page", "Navigated to APRCalculator Page");

                driver.FindElement(By.XPath("//a[@title='Close']")).Click();

                ThinkTime(3);

                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to APRCalculator Page", "Navigated to APRCalculator Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Cannot Navigated to APRCalculator Page", "Cannot Navigated to APRCalculator Page");
                Assert.Fail("Navigation to APRCalculator Page Failed");
            }

            driver.SwitchTo().Window(parentwindow);
        }

        public void VerifyProductRetail(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets Page");
            ThinkTime(4);
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }

            ThinkTime(5);
            //Verify Product
            driver.FindElement(By.XPath("//li[contains(@id,'vrp_productid-vrp_productid.fieldControl-LookupResultsDropdown_vrp_productid')]")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[@title='Status- Status of the product.']")));
            }
            ThinkTime(3);
            try
            {
                if (driver.FindElement(By.XPath("//div[contains(@id,'productnumber-FieldSectionItemContainer')]")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Product ID available", "Product ID available");
                if (driver.FindElement(By.XPath("//div[contains(@id,'name-FieldSectionItemContainer')]")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Product name available", "Product name available");
                if (driver.FindElement(By.XPath("//div[contains(@id,'productstructure-FieldSectionItemContainer')]")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Product structure available", "Product structure available");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Product Details not available", "Product Details not  available");
                Assert.Fail("Product Details not available");
            }
        }

        public void SortAndSelectCollectionByStatus(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration,string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }

            ThinkTime(4);
            //Verify Collection ticket is Retail
            try
            {
                string custtype = driver.FindElement(By.XPath("//label[contains(@id,'vrp_customertype-vrp_customertype.fieldControl-checkbox-inner-first')]")).Text;
                Console.WriteLine(custtype);
                if (custtype == "Retail")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer is Retail", "Customer is Retail");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer is not Retail", "Customer is not Retail");
                Assert.Fail("Customer is not Retail");
            }

            //Verify Outstanding date is within range
            string dayoutstanding = driver.FindElement(By.XPath("//input[contains(@id,'delinquentperiod-vrp_delinquentperiod.fieldControl-whole-number-text-input')]")).GetAttribute("value");
            Console.WriteLine(dayoutstanding);
            int result = Int32.Parse(dayoutstanding);
            try
            {
                if (result >= 1 && result <= 30)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Outstanding days in range", "Outstanding days in range");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Outstanding days in range", "Outstanding days in range");
                Assert.Fail("Outstanding Days not in range");
            }

        }

        public void SortAndSelectCollectionByStatus_Corp(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "All Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }

            //Verify Collection ticket is Retail
            ThinkTime(4);
                string custtype = driver.FindElement(By.XPath("//label[contains(@id,'vrp_customertype-vrp_customertype.fieldControl-checkbox-inner-second')]")).Text;
                Console.WriteLine(custtype);
            try
            {
                if (custtype == "Corporate")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer is Retail", "Customer is Retail");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer is not Retail", "Customer is not Retail");
                Assert.Fail("Customer is not Retail");
            }

            //Verify Outstanding date is within range
            string dayoutstanding = driver.FindElement(By.XPath("//input[contains(@id,'delinquentperiod-vrp_delinquentperiod.fieldControl-whole-number-text-input')]")).GetAttribute("value");
            Console.WriteLine(dayoutstanding);
            int result = Int32.Parse(dayoutstanding);
            try
            {
                if (result >= 1 && result <= 30)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Outstanding days in range", "Outstanding days in range");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Outstanding days in range", "Outstanding days in range");
                Assert.Fail("Outstanding Days not in range");
            }

        }

        public void CurrentDeliquncy_Retail(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);

            //Search the customer
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }

            //Verify Collection ticket is Corporate
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[contains(@id,'vrp_customertype-vrp_customertype.fieldControl-checkbox-inner-second')]")));
            }
            ThinkTime(4);
            string custtype = driver.FindElement(By.XPath("//label[contains(@id,'vrp_customertype-vrp_customertype.fieldControl-checkbox-inner-second')]")).Text;
            Console.WriteLine(custtype);
            try
            {
                if (custtype == "Corporate")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer is Retail", "Customer is Retail");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer is not Retail", "Customer is not Retail");
                Assert.Fail("Customer is not Corporate");
            }
        

            //Store Current Delinquency
            try
            {
                string deliquency = driver.FindElement(By.XPath("//input[contains(@id,'vrp_currentdelinquency-header_vrp_currentdelinquency.fieldControl-currency-text-input')]")).GetAttribute("value");
                ThinkTime(2);
                Console.WriteLine(deliquency);
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Current Delinquency stored", "Current Delinquency stored");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Current Delinquency not stored", "Current Delinquency not stored");
                Assert.Fail("Current Deliquency not available/Failed to store");
            }

            driver.FindElement(By.XPath("//li[text()='Collection Payment Promises']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[text()='Promised Payment Date']")));
            }
            ThinkTime(10);

            //Add new collection Promise
            driver.FindElement(By.XPath("//button[@data-id='vrp_collectionpaymentpromises|NoRelationship|SubGridStandard|Mscrm.SubGrid.vrp_collectionpaymentpromises.AddNewStandard']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'vrp_totaloverdueamount-vrp_totaloverdueamount.fieldControl-currency-text-input')]")));
            }
            ThinkTime(5);
            string deliq = driver.FindElement(By.XPath("//input[contains(@id,'vrp_totaloverdueamount-vrp_totaloverdueamount.fieldControl-currency-text-input')]")).GetAttribute("value");
            Console.WriteLine(deliq);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Current Delinquency same", "Current Delinquency same");
        }


        public void EmailVerification(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }
            ThinkTime(15);
            //Navigate to Notes
            driver.FindElement(By.XPath("//li[text()='Notes']")).Click();
             if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[@id='TimelineGroupsMainContainer']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Notes Page", "Navigated to Notesd Page");

            try
            {
                if(driver.FindElement(By.XPath("(//div[contains(@id,'timeline_record_container')])[1]")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Task created for customer", "Task created for customer");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "No Task created for collection ticket", "No Task created for customer");
                Assert.Fail("No task done for collection ticket created");
            }
        }

        public void BP2P1(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }


            //Click on BPTP1
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='BPTP 1 (Broken Promise to Pay)']")));
                }
                ThinkTime(5);
                driver.FindElement(By.XPath("//label[text()='BPTP 1 (Broken Promise to Pay)']")).Click();
                ThinkTime(4);
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Owner']")));
                }
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "BPTP 1 (Broken Promise to Pay) Displayed", "BPTP 1 (Broken Promise to Pay) Displayed");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "BPTP 1 (Broken Promise to Pay) not Displayed", "BPTP 1 (Broken Promise to Pay) not Displayed");
                Assert.Fail("BPTP 1 (Broken Promise to Pay) not Displayed");
            }
        }


        public void StageSelect(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record, string stage)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }


            //select Stage
            try
            {
                ThinkTime(3);
                driver.FindElement(By.XPath("//input[@aria-label='Stage  Lookup']")).Click();
                ThinkTime(4);
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//input[@aria-label='Stage  Lookup Look for Collection Stage']/parent::div/button[@aria-label='Search All Records']")));
                }
                ThinkTime(3);
                driver.FindElement(By.XPath("//input[@aria-label='Stage  Lookup Look for Collection Stage']/parent::div/button[@aria-label='Search All Records']")).Click();
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "All Records Displayed", "All Records Displayed");
                ThinkTime(2);
                driver.FindElement(By.XPath("//label[text()='" +stage+ "']")).Click();
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "PTP 2 (Promise to Pay)", "PTP 2 (Promise to Pay)");
                ThinkTime(3);
                driver.FindElement(By.XPath("//button[@data-id='vrp_collectionitem|NoRelationship|Form|Mscrm.Form.vrp_collectionitem.Save']")).Click();
                ThinkTime(6);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "PTP 2 (Promise to Pay)", "PTP 2 (Promise to Pay)");
                ThinkTime(3);
            }
            catch
            { 
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "PTP 2 (Promise to Pay) not dispalyed", "PTP 2 (Promise to Pay) not dispaled");
                if (driver.FindElement(By.XPath("//label[contains(@id,'vrp_categoryid-vrp_categoryid.fieldControl-LookupResultsDropdown_vrp_categoryid')]")).Displayed)
                {
                    Actions action = new Actions(driver);
                    IWebElement elem = driver.FindElement(By.XPath("//ul[@data-id='vrp_categoryid.fieldControl-LookupResultsDropdown_vrp_categoryid_SelectedRecordList']"));
                    action.MoveToElement(elem).Perform();
                    ThinkTime(4);
                    driver.FindElement(By.XPath("//button[contains(@data-id,'vrp_categoryid.fieldControl-LookupResultsDropdown_vrp_categoryid_selected_tag_delete')]")).Click();
                }
                
                ThinkTime(4);
                 if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//input[@aria-label='Stage  Lookup Look for Collection Stage']/parent::div/button[@aria-label='Search All Records']")));
                }
                ThinkTime(3);
                driver.FindElement(By.XPath("//input[@aria-label='Stage  Lookup Look for Collection Stage']/parent::div/button[@aria-label='Search All Records']")).Click();
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "All Records Displayed", "All Records Displayed");
                ThinkTime(2);
                driver.FindElement(By.XPath("//label[text()='" + stage + "']")).Click();
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "PTP 2 (Promise to Pay)", "PTP 2 (Promise to Pay)");
                ThinkTime(3);
                driver.FindElement(By.XPath("//button[@title='Save']")).Click();
                ThinkTime(6);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "PTP 2 (Promise to Pay)", "PTP 2 (Promise to Pay)");
                ThinkTime(3);              
            }
        }


        public void CustomerNonPaymentReason(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record, string reason)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            ThinkTime(5);
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }

            ThinkTime(4);
            IWebElement elem = driver.FindElement(By.XPath("//select[contains(@id,'vrp_customernonpaymentreason-vrp_customernonpaymentreason.fieldControl-option-set-select')]"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", elem);


            driver.FindElement(By.XPath("//select[contains(@id,'vrp_customernonpaymentreason-vrp_customernonpaymentreason.fieldControl-option-set-select')]")).Click();
            ThinkTime(2);
            if (driver.FindElement(By.XPath("//option[text()='OtherDefault: N/A']")).Displayed)
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ReasonList Displayed", "ReasonList Displayed");
            ThinkTime(3);

            driver.FindElement(By.XPath("//option[text()='OtherDefault: N/A']")).Click();

            if (reason == "OtherDefault: N/A")
            {
                try
                {
                    if (driver.FindElement(By.XPath("//label[text()='Customer Nonpayment Reason Text']")).Displayed)
                        AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Non Payment Reason Text field", "Non Payment Reason Text field");
                }
                catch
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Non Payment Reason Text field not displayed", "Non Payment Reason Text field not displayed");
                    Assert.Fail("Non Payment Reason Text field not displayed");
                }
            }
        }

        public void CustomerRelatedActivities(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            ThinkTime(3);
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }

            ThinkTime(4);
            driver.FindElement(By.XPath("//li[text()='Related']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Activities']")).Click();
            ThinkTime(2);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[@id='btnheaderselectcolumn']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Activities Page Navigated", "Activities Page Navigated");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Activities Page Navigation failed", "Activities Page Navigation failed");
                Assert.Fail("Activities page navigation failed");
            }
        }

        public void FinancialDetails(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            ThinkTime(3);
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }


            ThinkTime(4);
            driver.FindElement(By.XPath("//li[text()='Financials']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@id,'vrp_currentdelinquency-FieldSectionItemContainer')])[2]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Financials Details Available", "Financial Details available");
        }


        public void ExpenseDetails(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record,string expname,string amount)
        {

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            ThinkTime(3);
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }

            try
            {
                ThinkTime(4);
                driver.FindElement(By.XPath("//li[text()='Expenses']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//button[@data-id='vrp_collectionexpense|NoRelationship|SubGridStandard|Mscrm.SubGrid.vrp_collectionexpense.AddNewStandard']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Expense Details Page Available", "Expense Details page available");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Expense Details Page Available", "Expense Details page available");
                Assert.Fail("Expense Details Page not Available");
            }

            try
            {
                ThinkTime(4);
                driver.FindElement(By.XPath("//button[@data-id='vrp_collectionexpense|NoRelationship|SubGridStandard|Mscrm.SubGrid.vrp_collectionexpense.AddNewStandard']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//input[@data-id='vrp_name.fieldControl-text-box-text']")));
                }
                ThinkTime(6);
                driver.FindElement(By.XPath("//input[@data-id='vrp_name.fieldControl-text-box-text']")).Click();
                ThinkTime(3);
                driver.FindElement(By.XPath("//input[@data-id='vrp_name.fieldControl-text-box-text']")).SendKeys(expname);

                ThinkTime(2);
                driver.FindElement(By.XPath("//input[@data-id='vrp_expenseamount.fieldControl-decimal-number-text-input']")).Click();
                ThinkTime(2);
                driver.FindElement(By.XPath("//input[@data-id='vrp_expenseamount.fieldControl-decimal-number-text-input']")).SendKeys(amount);
                ThinkTime(2);
                driver.FindElement(By.XPath("//button[@data-id='vrp_collectionexpense|NoRelationship|Form|Mscrm.Form.vrp_collectionexpense.Save']")).Click();
                ThinkTime(6);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Expense for Collection saved", "Expense for Collection saved");

            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Cannot add new expense", "Cannot add new expense");
                Assert.Fail("Cannot add new expense");
            }
        }


        public void NewPaymentCollection(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string record,string amount)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Collection Tickets']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            ThinkTime(3);
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Collection Tickets']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.Id("quickFind_text_1")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.Id("quickFind_button_1")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Unique Reference No']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }

            ThinkTime(5);
            //Verify Collection ticket is Retail
            try
            {
                string custtype = driver.FindElement(By.XPath("//label[contains(@id,'vrp_customertype-vrp_customertype.fieldControl-checkbox-inner-second')]")).Text;
                Console.WriteLine(custtype);
                if (custtype == "Corporate")
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer is Corporate", "Customer is Corporate");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer is not Retail", "Customer is not Retail");
                Assert.Fail("Customer is not Retail");
            }

            //Store Current Delinquency
            try
            {
                string deliquency = driver.FindElement(By.XPath("//input[contains(@id,'vrp_currentdelinquency-header_vrp_currentdelinquency.fieldControl-currency-text-input')]")).GetAttribute("value");
                ThinkTime(2);
                Console.WriteLine(deliquency);
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Current Delinquency stored", "Current Delinquency stored");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Current Delinquency not stored", "Current Delinquency not stored");
                Assert.Fail("Current Deliquency not available/Failed to store");
            }

             driver.FindElement(By.XPath("//li[text()='Collection Payment Promises']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[text()='Promised Payment Date']")));
            }

            ThinkTime(8);
            Actions action = new Actions(driver);
            IWebElement elem = driver.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|CollectionPaymentPromises|vrp_collectionitem')])[6]"));
            action.DoubleClick(elem).Perform();
            ThinkTime(4);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Promised Payments']")));
            }
            driver.FindElement(By.XPath("//li[text()='Promised Payments']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[@id='vrp_installmentnumber']")));
            }

            try
            {
                ThinkTime(5);
                IWebElement elem1 = driver.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|PaymentPromises|vrp_collectionpaymentpromises')]/label)[1]"));
                action.DoubleClick(elem1).Perform();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@data-id,'vrp_installmentamount.fieldControl-decimal-number-text-input')]")));
                }
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "New Promised Repayment page displayed", "New Promised Repayment page displayed");
                try
                {
                  string installmentamount = driver.FindElement(By.XPath("//input[contains(@data-id,'vrp_installmentamount.fieldControl-decimal-number-text-input')]")).GetAttribute("value");
                  int instamont = Int32.Parse(installmentamount);
                   if(instamont <= 1000000000.00 && instamont >= 0.00)
                    {
                        driver.FindElement(By.XPath("//button[@title='Save']")).Click();
                        ThinkTime(3);
                        AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Promised Repayment successfulyy saved", "Promised Repayment successfulyy saved");
                    }
                }
                catch
                {
                    driver.FindElement(By.XPath("//input[contains(@data-id,'vrp_installmentamount.fieldControl-decimal-number-text-input')]")).Click();
                    ThinkTime(4);
                    driver.FindElement(By.XPath("//input[contains(@data-id,'vrp_installmentamount.fieldControl-decimal-number-text-input')]")).Clear();
                    ThinkTime(4);
                    driver.FindElement(By.XPath("//input[contains(@data-id,'vrp_installmentamount.fieldControl-decimal-number-text-input')]")).SendKeys(amount);
                    ThinkTime(3);
                    driver.FindElement(By.XPath("//button[@title='Save']")).Click();
                    ThinkTime(3);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Promised Repayment successfulyy saved", "Promised Repayment successfulyy saved");
                }
                
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Promised Repayment successfulyy saved", "Promised Repayment successfulyy saved");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Promised Repayment failed", "Promised Repayment failed");
                Assert.Fail("Promised Repayment failed");
            }
        }

        public void AddNotes(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string title, string notes)
        {
            ThinkTime(5);
            driver.FindElement(By.XPath("//li[text()='Notes']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[@aria-label='Create a new activity, note, or custom item.']")));
            }
            ThinkTime(5);
            driver.FindElement(By.XPath("//label[@aria-label='Create a new activity, note, or custom item.']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//li[contains(@id,'notescontrol-notes')]")));
            }
            driver.FindElement(By.XPath("//li[contains(@id,'notescontrol-notes')]")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//input[@id='create_note_medium_title']")).SendKeys(title);
            ThinkTime(2);
            driver.FindElement(By.XPath("//textarea[@id='create_note_notesText']")).SendKeys(notes);
            ThinkTime(2);
            driver.FindElement(By.XPath("//span[text()='Add note']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Note Successfully added", "Note Successfully added");
        }

        public void LatePayment(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string amount)
        {
            ThinkTime(4);
            driver.FindElement(By.XPath("//li[text()='Financials']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@id,'vrp_currentdelinquency-FieldSectionItemContainer')])[2]")));
            }
            ThinkTime(4);
            driver.FindElement(By.XPath("//input[contains(@id,'vrp_latepaymentinterestamount-vrp_latepaymentinterestamount.fieldControl-currency-text-input')]")).SendKeys(amount);
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Late payment amount added", "Late payment amount added");
            ThinkTime(2);
            driver.FindElement(By.XPath("//button[@title='Save']")).Click();
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Late payment amount added", "Late payment amount added");
        }


    }
}
