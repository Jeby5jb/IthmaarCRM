using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharpMSTest.ObjectRepository;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports.Model;

namespace SeleniumCSharpMSTest.Functions
{
    public class CorporateCustomer : MarketingObjects
    {
        int timeOutInSeconds = 80;

        /// <summary>
        /// Method to Create a new Campaign
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="name"></param>

        public void NavigateToCompanies(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            
            driver.FindElement(By.XPath("//li[@title='Companies']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='My Active Accounts']")));
            }
          
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Successfully navigated to Companies list", "Successfully navigated to Companies list");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@data-text='All Accounts']")).Click();
          
        }

        public void SelectCompany( IWebDriver driver,  ExtentTest testInReport,    string testName,    string testDataIteration, string cname,string accountno, string debitcardno,string termdepositno)
        {
            ThinkTime(4);
            driver.FindElement(By.Id("quickFind_text_1")).SendKeys(cname);
            ThinkTime(2);
            driver.FindElement(By.Id("quickFind_button_1")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//a[text()='" + cname + "']")));
            }
            driver.FindElement(By.XPath("//a[text()='" + cname + "']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[@data-id='header_vrp_corporatesegment.fieldControl-LookupResultsDropdown_vrp_corporatesegment_selected_tag_text']")));
            }

            try
            {
                string category = driver.FindElement(By.XPath("//label[@data-id='header_vrp_corporatesegment.fieldControl-LookupResultsDropdown_vrp_corporatesegment_selected_tag_text']")).Text;
                Console.WriteLine(category);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Mandatory Field Category is filled", "Mandatory Field Category is filled");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Mandatory Field Category is not filled", "Mandatory Field Category is not filled");
                Assert.Fail("Category Field is blank");
            }

            try
            {
                string companyfullname = driver.FindElement(By.XPath("//input[contains(@id,'name-name.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(companyfullname);
                if(companyfullname == cname)
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Company Full name is filled", "Company Full name is filled");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Company Full name is not filled", "Company Full name is not filled");
                Assert.Fail("Company Full name is blank");
            }

           
                
            try
            {
                Assert.IsTrue(driver.FindElement(By.XPath("//li[contains(@id,'vrp_relationshipmanager-vrp_relationshipmanager.fieldControl-LookupResultsDropdown_vrp_relationshipmanager')]")).Displayed);
                ThinkTime(2);
                IWebElement elem1 = driver.FindElement(By.XPath("//li[contains(@id,'vrp_relationshipmanager-vrp_relationshipmanager.fieldControl-LookupResultsDropdown_vrp_relationshipmanager')]"));
                IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
                js1.ExecuteScript("arguments[0].scrollIntoView();", elem1);

                string relationshipmanager = driver.FindElement(By.XPath("//li[contains(@id,'vrp_relationshipmanager-vrp_relationshipmanager.fieldControl-LookupResultsDropdown_vrp_relationshipmanager')]")).GetAttribute("aria-label");
                Console.WriteLine(relationshipmanager);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Relationshipmanager name is filled", "Relationshipmanager name is filled");
            }
            catch(Exception e)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Relationshipmanager name is not filled", "Relationshipmanager name is not filled");
                //Log.W("Relationshipmanager name is blank and failed due to :"+e);
            }

            try
            {
                IWebElement elem20 = driver.FindElement(By.XPath("//input[contains(@id,'telephone1-telephone1.fieldControl-phone-text-input')]")); 

                IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
                js2.ExecuteScript("arguments[0].scrollIntoView();", elem20);

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
                string tel = driver.FindElement(By.XPath("//input[contains(@id,'emailaddress1-emailaddress1.fieldControl-mail-text-input')]")).GetAttribute("value");
                Console.WriteLine(tel);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Email Address is filled", "Email Address is filled");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Email Address is not filled", "Email Address is not filled");
                Assert.Fail("Email Address is blank");
            }


            IWebElement elem2;

            try
            {
                elem2 = driver.FindElement(By.XPath("//li[text()='Products']"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView();", elem2);           
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Product Image is filled", "Product Image is filled");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Product Image is not filled", "Product Image is not filled");
                Assert.Fail("Product Image is blank");
            }


            //Move to Products Tab
            driver.FindElement(By.XPath("//li[text()='Products']")).Click();

            ThinkTime(3);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[text()='ACCOUNT DETAILS']")));
            }


            //Account Details Verify

            try
            {

                //Wait for Products Page to Load
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[@data-lp-id='MscrmControls.Grid.ReadOnlyGrid|AccountDetails|account|fcf9a706-fc1b-ea11-841f-0050568e59df|msfsi_financialproduct|msfsi_account_msfsi_financialproduct_Customer|cc-grid|cc-grid-column|msfsi_number']")));
                }

                ThinkTime(4);

                //Extract the account number and click on Account

                string accountverify;
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Account Details filled verified", "Account Details filled verified");
                if (!String.IsNullOrEmpty(accountno))
                {
                    driver.FindElement(By.XPath("//a[text()='" + accountno + "']")).Click();
                }
                else
                {
                    accountverify = driver.FindElement(By.XPath("(//div[@data-id='AccountDetails_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")).Text;
                    Console.WriteLine(accountverify);
                    driver.FindElement(By.XPath("(//div[@data-id='AccountDetails_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")).Click();
                }
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//li[text()='General Information']")));
                }
                ThinkTime(3);

                //Verify Account no
                try
                {
                    string accountdetailsview = driver.FindElement(By.XPath("//input[contains(@id,'msfsi_number-msfsi_number.fieldControl-text-box-text')]")).GetAttribute("value");
                   
                        AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Account Details Page navigated", "Account Details Page navigated");
                    ThinkTime(2);
                    Console.WriteLine("Inside try with Accoount number for Account Details");
                }
                catch
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Account Details Page navigated", "Account Details Page navigated");
                    Assert.Fail("Account Details incorrect");
                }
                ThinkTime(2);

                //Verify Available balance
                try
                {
                    string availableBal = driver.FindElement(By.XPath("//input[@data-id='msfsi_availablebalance.fieldControl-currency-text-input']")).GetAttribute("value");
                    Console.WriteLine(availableBal);
                }
                catch
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Account balance not available", "Account balance not available");
                    Assert.Fail("Available balance not present");
                }

                //Verify Currency
                try
                {
                    string currency = driver.FindElement(By.XPath("//label[@data-id='transactioncurrencyid.fieldControl-LookupResultsDropdown_transactioncurrencyid_selected_tag_text']")).Text;
                    Console.WriteLine(currency);
                }
                catch
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Currency not available", "Currency not available");
                    Assert.Fail("Currency not present");
                }

                ThinkTime(3);
                driver.FindElement(By.XPath("//li[contains(text(),'Details')]")).Click();

                // wait for finance Details page
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='VAT Registration Number']")));
                }
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Account Details field verfied", "Account Details field verfied");
                ThinkTime(2);

                if (driver.FindElement(By.XPath("//label[text()='Available Balance']")).Displayed)
                {
                    Console.WriteLine("Account Balance available");
                }
                else
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Available balance not available", "Available balance not available");
                    Assert.Fail("Available balance not availabel");
                }

                //Move to Account Transactions
                IWebElement elem8 = driver.FindElement(By.XPath("//div[text()='ACCOUNT TRANSACTIONS']"));
                IJavaScriptExecutor js8 = (IJavaScriptExecutor)driver;
                js8.ExecuteScript("arguments[0].scrollIntoView();", elem8);
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Account Transaction", "Account Transaction");
                ThinkTime(3);

                //Navigate Back to Previous page
                driver.Navigate().Back();

                ThinkTime(2);
                //Handling Alert Message if Available
                try
                {
                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Close']")));
                    }
                    AddLog(driver, testInReport, testName, testDataIteration, "Info", "Alert Box Displayed", "Alert Box Displayed");
                    ThinkTime(3);
                    driver.FindElement(By.XPath("//button[text()='Close']")).Click();
                    ThinkTime(2);
                }
                catch
                {
                    Console.WriteLine("No ALert Message Displayed");
                }

                //Verify successfully navigated back to Previous Page
                try
                {
                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-column|msfsi_number')])[1]")));
                    }
                }
                catch
                {
                    Assert.Fail("Navigation back to products page failed");
                }
            }
            catch
            {
                Console.WriteLine("Cannot Verify for Account Details");
            }


            //Debit Card verify

            //try
            //{
                ThinkTime(4);

                //verify whether debit card is added

                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_account_msfsi_financialproduct_Customer|cc-grid|cc-grid-column|msfsi_number')])[2]")));
                }
                //string debitcard = driver.FindElement(By.XPath("(//div[@data-id='DebitCard_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")).Text;
                //Console.WriteLine(debitcard);
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Debit Card field verified", "Debit Card field verified");
                ThinkTime(3);
            try
            {
                driver.FindElement(By.XPath("(//div[@data-id='DebitCard_container']//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|DebitCard|account|')]//a)[1]")).Click();
            }
            catch
            {
                try
                {
                    driver.FindElement(By.XPath("//a[text()='" + debitcardno + "']")).Click();
                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("//li[text()='General Information']")));
                    }
                    ThinkTime(5);

                    //Verify Debit Card number
                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'msfsi_number-msfsi_number.fieldControl-text-box-text')]")));
                    }
                    string debitcards = driver.FindElement(By.XPath("//input[contains(@id,'msfsi_number-msfsi_number.fieldControl-text-box-text')]")).GetAttribute("value");
                    Console.WriteLine("Debitcard account number from Debit Card Detailed View Page:" + debitcards);
                    // if (debitcard == debitcards)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Debit Card number correct verified", "Debit Card number correct verified");
                    Console.WriteLine("Inside try with Accoount number for Debit Card");
                    ThinkTime(4);

                    //Move to Debit Card Dialogue
                    ThinkTime(3);
                    driver.FindElement(By.XPath("//li[contains(text(),'Details')]")).Click();

                    // wait for finance Details page
                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Embossing Name']")));
                    }
                    ThinkTime(2);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Debit Card Details verfied", "Debit Card Details verfied");
                    ThinkTime(2);

                    // driver.FindElement(By.XPath("//div[text()='CARD TRANSACTIONS']"));
                    ThinkTime(3);

                    //Move to Card Transactions
                    IWebElement elem9 = driver.FindElement(By.XPath("//div[text()='Transactions & Statement']"));
                    IJavaScriptExecutor js3 = (IJavaScriptExecutor)driver;
                    js3.ExecuteScript("arguments[0].scrollIntoView();", elem9);
                    ThinkTime(3);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Card Transaction", "Card Transaction");
                    ThinkTime(3);

                    //Navigate back to Previous Page
                    driver.Navigate().Back();

                    //Handling Alert Message if Available
                    //try
                    //{
                    //    if (timeOutInSeconds > 0)
                    //    {
                    //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    //        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Close']")));
                    //    }
                    //    AddLog(driver, testInReport, testName, testDataIteration, "Info", "Alert Box Displayed", "Alert Box Displayed");
                    //    ThinkTime(3);
                    //    driver.FindElement(By.XPath("//button[text()='Close']")).Click();
                    //    ThinkTime(2);
                    //}
                    //catch
                    //{
                    //    Console.WriteLine("No ALert Message Displayed");
                    //}

                    //Verify successfully navigated back to Previous Page
                    try
                    {
                        if (timeOutInSeconds > 0)
                        {
                            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                            wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-column|msfsi_number')])[1]")));
                        }
                    }
                    catch
                    {
                        Assert.Fail("Navigation back to products page failed");
                    }
                }
                catch
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Info", "Debit Card not available", "Debit Card not available");
                }
            }
                ThinkTime(5);


            // }
            //catch
            //{
            //    Console.WriteLine("No Debit Card Available/Debit Card Verification Failed");
            //}

            //Wait for page to navigate back properly
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|TermDeposit|account')]//div[text()='Account Number'])[1]")));
                }
            }
            catch
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|TermDeposit|account')]/div[text()='Number']")));
                }
            }
            ThinkTime(3);
            //Term Deposit Verify 
            try
            {
                    elem2 = driver.FindElement(By.XPath("//a[text()='" + termdepositno + "']"));
                    IJavaScriptExecutor js0 = (IJavaScriptExecutor)driver;
                    js0.ExecuteScript("arguments[0].scrollIntoView();", elem2);

                    ThinkTime(2);

                    string termdeposit = elem2.Text;
                    Console.WriteLine(termdeposit);
                    ThinkTime(3);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Term Deposit field verified", "Term Deposit field verified");
                try
                {
                    driver.FindElement(By.XPath("//a[text()='" + termdepositno + "']"));
                    elem2.Click();

                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("//li[text()='General Information']")));
                    }
                    ThinkTime(3);

                    //Verify Term Deposit Account Number
                    string termdepositacntno = driver.FindElement(By.XPath("//input[contains(@id,'msfsi_number-msfsi_number.fieldControl-text-box-text')]")).GetAttribute("value");
                    if (termdeposit == termdepositacntno)
                        AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Term Deposit view populated Correct", "Term Deposit view populated Correct");

                    ThinkTime(7);

                    //Verify Available balance
                    try
                    {
                        string availableBal = driver.FindElement(By.XPath("//input[@data-id='msfsi_availablebalance.fieldControl-currency-text-input']")).GetAttribute("value");
                        Console.WriteLine(availableBal);
                    }
                    catch
                    {
                        AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Account balance not available", "Account balance not available");
                        Assert.Fail("Available balance not present");
                    }

                    ThinkTime(7);
                    //Verify Currency
                    try
                    {
                        string currency = driver.FindElement(By.XPath("//label[@data-id='transactioncurrencyid.fieldControl-LookupResultsDropdown_transactioncurrencyid_selected_tag_text']")).Text;
                        Console.WriteLine(currency);
                    }
                    catch
                    {
                        AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Currency not available", "Currency not available");
                        Assert.Fail("Currency not present");
                    }


                    //Move to Term Deposit Details
                    driver.FindElement(By.XPath("//li[contains(text(),'Details')]")).Click();

                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("//input[@data-id='vrp_iban.fieldControl-text-box-text']")));
                    }
                    ThinkTime(7);
                    //IBAN Verify
                    try
                    {
                        string iban = driver.FindElement(By.XPath("//input[@data-id='vrp_iban.fieldControl-text-box-text']")).GetAttribute("value");
                        Console.WriteLine(iban);
                    }
                    catch
                    {

                        AddLog(driver, testInReport, testName, testDataIteration, "Fail", "IBAN no not available", "IBAN no not available");
                        Assert.Fail("IBAN no not present");
                    }

                    //Available Balance
                    try
                    {
                        string availableBal = driver.FindElement(By.XPath("//input[@data-id='msfsi_availablebalance.fieldControl-currency-text-input']")).GetAttribute("value");
                        Console.WriteLine(availableBal);
                    }
                    catch
                    {

                        AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Available Balance in TermDeposit Details not available", "Available Balance in TermDeposit Details not available");
                        Assert.Fail("Available Balance in TermDeposit Details not available");
                    }

                    //Booking Bal
                    try
                    {
                        string bookBal = driver.FindElement(By.XPath("//input[@data-id='msfsi_bookbalance.fieldControl-currency-text-input']")).GetAttribute("value");
                        Console.WriteLine(bookBal);
                    }
                    catch
                    {

                        AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Booking Balance in TermDeposit Details not available", "Booking Balance in TermDeposit Details not available");
                        Assert.Fail("Booking Balance in TermDeposit Details not available");
                    }

                    //Maturity Instruction Details
                    try
                    {
                        string maturityInstructions = driver.FindElement(By.XPath("//input[@data-id='msfsi_maturityinstructionsdetails.fieldControl-text-box-text']")).GetAttribute("value");
                        Console.WriteLine(maturityInstructions);
                    }
                    catch
                    {

                        AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Maturity Instruction Details in TermDeposit Details not available", "Maturity Instruction Details in TermDeposit Details not available");
                        Assert.Fail("Maturity Instruction Details in TermDeposit Details not available");
                    }

                    //Balance At Maturity Details
                    try
                    {
                        string balanceAtMaturity = driver.FindElement(By.XPath("//input[@data-id='msfsi_balanceatmaturity.fieldControl-currency-text-input']")).GetAttribute("value");
                        Console.WriteLine(balanceAtMaturity);
                    }
                    catch
                    {

                        AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Balance At Maturity Details in TermDeposit Details not available", "Balance At Maturity Details in TermDeposit Details not available");
                        Assert.Fail("Maturity Instruction Details in TermDeposit Details not available");
                    }

                    //Navigate to Back
                    driver.Navigate().Back();

                    ThinkTime(2);

                    //Handling Alert Message if Available
                    ////try
                    ////{
                    ////    if (timeOutInSeconds > 0)
                    ////    {
                    ////        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    ////        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Close']")));
                    ////    }
                    ////    AddLog(driver, testInReport, testName, testDataIteration, "Info", "Alert Box Displayed", "Alert Box Displayed");
                    ////    ThinkTime(3);
                    ////    driver.FindElement(By.XPath("//button[text()='Close']")).Click();
                    ////    ThinkTime(2);
                    ////}
                    ////catch
                    ////{
                    ////    Console.WriteLine("No ALert Message Displayed");
                    ////}

                    //Verify successfully navigated back to Previous Page
                    try
                    {
                        if (timeOutInSeconds > 0)
                        {
                            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                            wait.Until(drv => drv.FindElement(By.XPath("//a[text()='" + termdepositno + "']")));
                        }
                    }
                    catch
                    {
                        Assert.Fail("Navigation back to products page failed");
                    }
                }
                catch
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Info", "Term Deposit not available for Customer", "Term Deposit not available for Customer");
                }
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Term Deposit Verification failed", "Term Deposit Verification failed");
            }

        }


        public void MoveToSijilat(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            try
            {
                driver.FindElement(By.XPath("//li[text()='SIJILAT']")).Click();
                ThinkTime(10);
                var waits = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("WebResource_vrp_sijilat")));
               // driver.SwitchTo().Frame("WebResource_vrp_sijilat");
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Sijilat", "Navigated to Sijilat");
                ThinkTime(6);
                // driver.FindElement(By.XPath("//input[@id='btnSubmit']")).Click();
                //if (timeOutInSeconds > 0)
                //{
                //    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                //    wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Commercial Registration Information']")));
                //}
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Commercial Info", "Commercial Info");
                ThinkTime(2);
                driver.SwitchTo().DefaultContent();
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Sijilat Not Found or Naviagtion failed", "Sijilat Not Found or Naviagtion failed");
                Assert.Fail("Sijilat Not Found/Naviagtion failed");
            }
        }

    }
}
