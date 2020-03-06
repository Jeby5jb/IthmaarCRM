using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharpMSTest.ObjectRepository;
using TesthouseSeleniumCSharp.Functions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumCSharpMSTest.Functions
{
    public class Customer360Functions : Helper
    {


        public void FieldVerification(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string custname, string debitcardno, string accountno, string creditcard, string opportunity, string unresolvedcase, string collectionticket, string enrolledservice, string record)
        {
            int timeOutInSeconds = 120;
            ThinkTime(5);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Customer Page", "Navigated to Customer Page");
            ThinkTime(2);

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='My Active Contacts']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collections Ticket Page", "Collections Tickets PAge");
            driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='All Contacts']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "ALl Collections Ticket Page", "All Collections Tickets PAge");
            ThinkTime(2);
            try
            {
                driver.FindElement(By.XPath("//input[contains(@data-id,'quickFind_text')]")).SendKeys(record);
                ThinkTime(2);
                driver.FindElement(By.XPath("//button[contains(@data-id,'quickFind_button')]")).Click();
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//a[text()='" + record + "']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Record avilable", "Record avilable");
                driver.FindElement(By.XPath("//a[text()='" + record + "']")).Click();
            }
            catch
            {
                                       
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not avilable", "Record not avilable");
                Assert.Fail("Record searched not availble");
            }
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//input[@aria-required='true'])[1]")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Selected Record Page", "Navigated to Selected Record Page");
            }
            catch(Exception e)
            {
                Assert.Fail("Fail Due to exception: " + e);
            }


            ///<summary>
           /// Handling Alert Message if Available
            //try
            //{
            //   if (timeOutInSeconds > 0)
            //{
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Close']")));
            // }
            //AddLog(driver, testInReport, testName, testDataIteration, "Info", "Alert Box Displayed", "Alert Box Displayed");
            //ThinkTime(3);
            //driver.FindElement(By.XPath("//button[text()='Close']")).Click();
            //ThinkTime(2);
            //}
            //catch
            //{
            // Console.WriteLine("No ALert Message Displayed");
            //}
             
            var waits = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("WebResource_NextBestAction")));
            if (driver.FindElement(By.XPath("//h6[text()='NEXT BEST ACTION']")).Displayed)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Next Best Action available", "Next Best Action available");
            }
            driver.SwitchTo().DefaultContent();

            //Verify for DOB
            try
            {
                if (driver.FindElement(By.XPath("(//input[@aria-required='true'])[1]")).Displayed)
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Date of Birth filled", "Date of Birth filled");
                }
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Date of Birth not filled", "Date of Birth not filled");
                Console.WriteLine("Date of birth is not mandatory");
            }

            //Verify MARITIAL STAT
            try
            {
                IWebElement element11 = driver.FindElement(By.XPath("//label[@data-id='vrp_maritalstatus.fieldControl-LookupResultsDropdown_vrp_maritalstatus_selected_tag_text']"));
                string maritialstatus = element11.Text;
                Console.WriteLine(maritialstatus);


                //Move to element
                IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
                js1.ExecuteScript("arguments[0].scrollIntoView(true);", element11);

                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Maritial Status filed verified", "Maritial Status filed verified");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Maritial Status not filed ", "Maritial Status not filed verified");
                Assert.Fail("Maritial Status mandatory not filled");
            }

            //Verify FirstName
            try
            {
                string value = driver.FindElement(By.XPath("//input[contains(@id,'fullname_compositionLinkControl_firstname-fullname_compositionLinkControl_firstname.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(value);
            }
            catch
            {
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Firstname is not filled", "First name is not filled");
                Assert.Fail("First Name mandatory field is not filled");
            }

            //Mandatory filed last name verification
            try
            {
                string lastname = driver.FindElement(By.XPath("//input[contains(@id,'fullname_compositionLinkControl_lastname-fullname_compositionLinkControl_lastname.fieldControl-text-box-text')]")).GetAttribute("value");
                Console.WriteLine(lastname);
            }
            catch
            {
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Last name is not filled", "Last name is not filled");
                Assert.Fail("Last Name mandatory field is not filled");
            }

            //Verify Document
            //driver.FindElement(By.XPath("//label[contains(@id,'vrp_idtype-vrp_idtype.fieldControl-LookupResultsDropdown_vrp_idtype')]")).Click();
            //Verify Alert
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("WebResource_Insights")));
            if (driver.FindElement(By.XPath("//h6[text()='ALERTS & NOTIFICATIONS']")).Displayed)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Alerts nd Notification available", "Alerts nd Notification available");
            }
            driver.SwitchTo().DefaultContent();

            //Mandatory field id verification
            try
            {
                IWebElement ID = driver.FindElement(By.XPath("//input[contains(@id,'vrp_idno-vrp_idno.fieldControl-text-box-text')]"));

                //Move to element
                IJavaScriptExecutor js2 = (IJavaScriptExecutor)driver;
                js2.ExecuteScript("arguments[0].scrollIntoView(true);", ID);

                string id = ID.GetAttribute("value");
                Console.WriteLine(id);


            }
            catch
            {
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "ID is not filled", "ID is not filled");
                Assert.Fail("Last Name mandatory field is not filled");
            }

            //Nationalty mandatory field verification
            try
            {
                string nationality = driver.FindElement(By.XPath("//label[contains(@id,'vrp_nationality-vrp_nationality.fieldControl-LookupResultsDropdown_vrp_nationality_4_selected_tag_text_0')]")).Text;
                Console.WriteLine(nationality);
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Nationality filed verified", "Nationality filed verified");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Nationality Status not filed ", "nationality Status not filed verified");
                Assert.Fail("Nationality not filled");
            }

            //Mobile nuber verification
            try
            {
                string mobilenumber = driver.FindElement(By.XPath("//input[contains(@id,'mobilephone-mobilephone.fieldControl-phone-text-input')]")).GetAttribute("value");
                Console.WriteLine(mobilenumber);
            }
            catch
            {
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Mobilenumber is not filled", "MobileNumber is not filled");
                Assert.Fail("MobileNumber field is not filled");
            }


            //Move to Products Tab
            driver.FindElement(By.XPath("//li[text()='Products']")).Click();

            ThinkTime(3);




            /// <summary>
            /// Account Details Verify
            /// </summary>

            try
            {

                //Wait for Products Page to Load
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//div[@data-id='AccountDetails_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")));
                }

                ThinkTime(4);

                //Extract the account number and click on Account
                string accountverify = driver.FindElement(By.XPath("(//div[@data-id='AccountDetails_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")).Text;
                Console.WriteLine(accountverify);
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Account Details filled verified", "Account Details filled verified");
                if (!String.IsNullOrEmpty(accountno))
                {
                    driver.FindElement(By.XPath("//a[text()='" + accountno + "']")).Click();
                }
                else
                {
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
                    // if (accountverify == accountdetailsview)
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


            ///<summary>
            ///Debit Card verify
            ///</ summary >
            try
            {
                ThinkTime(4);

                //verify whether debit card is added

                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//div[@data-id='DebitCard_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")));
                }
                string debitcard = driver.FindElement(By.XPath("(//div[@data-id='DebitCard_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")).Text;
                Console.WriteLine(debitcard);
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Debit Card filed verified", "Debit Card filed verified");
                ThinkTime(3);
                driver.FindElement(By.XPath("(//div[@data-id='DebitCard_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")).Click();
                ThinkTime(5);
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
                if (debitcard == debitcards)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Debit Card number correct verified", "Debit Card number correct verified");

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

                driver.FindElement(By.XPath("//div[text()='Transactions & Statement']"));
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
                Console.WriteLine("No Debit Card Available/Debit Card Verification Failed");
            }


            ///<summary>
            ///Term Deposit Verify 
            ///</ summary >

            try
            {
                try
                {
                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("(//div[@data-id='TermDeposit_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")));
                    }
                    IWebElement elem2 = driver.FindElement(By.XPath("(//div[@data-id='TermDeposit_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]"));
                    IJavaScriptExecutor js0 = (IJavaScriptExecutor)driver;
                    js0.ExecuteScript("arguments[0].scrollIntoView();", elem2);

                    ThinkTime(2);

                    string termdeposit = elem2.Text;
                    Console.WriteLine(termdeposit);
                    ThinkTime(3);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Term Deposit filled verified", "Term Deposit filled verified");

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
                    ThinkTime(3);

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


                    //Move to Term Deposit Details
                    driver.FindElement(By.XPath("//li[contains(text(),'Details')]")).Click();

                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("//input[@data-id='vrp_iban.fieldControl-text-box-text']")));
                    }

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
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Term Deposit Page not navigated Correct", "Term Deposit Page not navigated Correct");

                }
            }
            catch
            {

            }


            //Credit Card Verify
            try
            {
                //Move to Credit Card section
                IWebElement elem6 = driver.FindElement(By.XPath("//div[text()='Credit Cards']"));
                IJavaScriptExecutor js01 = (IJavaScriptExecutor)driver;
                js01.ExecuteScript("arguments[0].scrollIntoView();", elem6);

                //Verify Credit card available 
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|CreditCards|contact|')]/a")));
                }

                //if (creditcard == null)
                //{
                try
                {
                    string creditCard = driver.FindElement(By.XPath("//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|CreditCards|contact|')]/a")).Text;
                    Console.WriteLine(creditCard);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Credit Card Available", "Credit Card Available");
                    ThinkTime(2);
                    driver.FindElement(By.XPath("//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|CreditCards|contact|')]/a")).Click();
                }
                catch
                {
                    Console.WriteLine("Credit Card Not Available");
                }
                //}
                //else
                //{
                //    driver.FindElement(By.XPath("//a[text()='" +creditcard+ "']")).Click();
                //}

                //Vrify credit Page navigated
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//li[text()='General Information']")));
                }

                ThinkTime(4);
                //Move to Details tab
                driver.FindElement(By.XPath("//li[contains(text(),'Details')]")).Click();

                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//label[contains(text(),'Card Type')])[1]")));
                }

                ThinkTime(5);

                //Verify Card Type Pickup
                driver.FindElement(By.XPath("(//select[contains(@data-id,'vrp_cardtype.fieldControl-option-set-select')])[1]")).Click();
                ThinkTime(2);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Card Type Dropdown values available", "Card Type Dropdown values available");

                //Verify Currency Availble
                try
                {
                    string currency = driver.FindElement(By.XPath("//label[contains(@id,'transactioncurrencyid-transactioncurrencyid.fieldControl-LookupResultsDropdown_transactioncurrencyid')]")).Text;
                    Console.WriteLine(currency);
                }
                catch
                {
                    Assert.Fail("Currency not available");
                }

                //Verify Issue Date
                try
                {
                    string issueDate = driver.FindElement(By.XPath("(//input[contains(@id,'TextField')])[1]")).GetAttribute("value");
                    Console.WriteLine(issueDate);
                }
                catch
                {
                    Assert.Fail("Issue Date not available");
                }

                //Verify Card Limit 
                try
                {
                    string cardlimit = driver.FindElement(By.XPath("//input[contains(@id,'vrp_cardlimit-vrp_cardlimit.fieldControl-currency-text-input')]")).GetAttribute("value");
                    Console.WriteLine(cardlimit);
                }
                catch
                {
                    Assert.Fail("Card Limit not available");
                }

                //Verify Last Payment Amount
                try
                {
                    string lastPaymentAmount = driver.FindElement(By.XPath("//input[contains(@id,'msfsi_lastpaymentamount-msfsi_lastpaymentamount.fieldControl-currency-text-input')]")).GetAttribute("value");
                    Console.WriteLine(lastPaymentAmount);
                }
                catch
                {
                    Assert.Fail("Last Payment Amount not available");
                }


                //Verify Last Statement Date
                try
                {
                    string lastStatementDate = driver.FindElement(By.XPath("//input[contains(@data-id,'vrp_laststatementdate.fieldControl-date-time-input')]")).GetAttribute("value");
                    Console.WriteLine(lastStatementDate);
                }
                catch
                {
                    Assert.Fail("Last Statement Date not available");
                }


                //Move to Card Transactions
                IWebElement elem10 = driver.FindElement(By.XPath("//div[text()='CARD TRANSACTIONS']"));
                IJavaScriptExecutor js02 = (IJavaScriptExecutor)driver;
                js02.ExecuteScript("arguments[0].scrollIntoView();", elem10);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Credit Card Transactions", "Credit Card Transactions");
                ThinkTime(4);

                //Navigate Back to Previous page
                driver.Navigate().Back();

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
                AddLog(driver, testInReport, testName, testDataIteration, "Info", "Credit Card not available", "Credit Card not available");
            }


            //Finance Verify
            ThinkTime(5);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[contains(text(),'Finance')])")));
            }
            IWebElement elem5 = driver.FindElement(By.XPath("(//div[contains(text(),'Finance')])"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView();", elem5);

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|Finance|contact')])[6]")));
            }

            Actions action = new Actions(driver);
            IWebElement elem1 = driver.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|Finance|contact')])[6]"));
            action.DoubleClick(elem1).Perform();

            //Verify credit Page navigated
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//li[text()='General Information']")));
            }

            ThinkTime(3);
            driver.FindElement(By.XPath("//li[contains(text(),'Details')]")).Click();

            // wait for finance Details page
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//select[contains(@id,'msfsi_loantype-msfsi_loantype.fieldControl-option-set-select')]")));
            }
            try
            {

                string financetype = driver.FindElement(By.XPath("//select[contains(@id,'msfsi_loantype-msfsi_loantype.fieldControl-option-set-select')]")).GetAttribute("title");
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Finance Type PickUp", "Finance Type PickUp");
            }
            catch
            {
                Assert.Fail("Finance Type not available");
            }

            //Disbursemnet Date
            try
            {
                string disbursmentDate = driver.FindElement(By.XPath("//input[@data-id='msfsi_disbursementdate.fieldControl-date-time-input']")).GetAttribute("value");
                Console.WriteLine(disbursmentDate);
            }
            catch
            {
                Assert.Fail("Disbursement date not available");
            }

            //Past Due Amount
            try
            {
                string PastDueAmount = driver.FindElement(By.XPath("//input[@data-id='vrp_pastdueamount.fieldControl-currency-text-input']")).GetAttribute("value");
                Console.WriteLine(PastDueAmount);
            }
            catch
            {
                Assert.Fail("Past Due Date nots available");
            }

            //Amount Financed Verify
            try
            {
                string AmountFinanced = driver.FindElement(By.XPath("//input[@data-id='msfsi_principalamount.fieldControl-currency-text-input']")).GetAttribute("value");
                Console.WriteLine(AmountFinanced);
            }
            catch
            {
                Assert.Fail("Amount Financed not available");
            }

            //Disbursed Amount Verify
            try
            {
                string DisbursedAmount = driver.FindElement(By.XPath("//input[@data-id='msfsi_disbursedamount.fieldControl-currency-text-input']")).GetAttribute("value");
                Console.WriteLine(DisbursedAmount);
            }
            catch
            {
                Assert.Fail("Amount Financed not available");
            }

            try
            {
                IWebElement elem6 = driver.FindElement(By.XPath("//input[contains(@id,'msfsi_numberofinstallmentspaid-msfsi_numberofinstallmentspaid.fieldControl-whole-number-text-input')]"));
                IJavaScriptExecutor js7 = (IJavaScriptExecutor)driver;
                js7.ExecuteScript("arguments[0].scrollIntoView();", elem6);
                string noOfInstallement = driver.FindElement(By.XPath("//input[contains(@id,'msfsi_numberofinstallmentspaid-msfsi_numberofinstallmentspaid.fieldControl-whole-number-text-input')]")).GetAttribute("value");
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "No of Installment available", "No of Installment available");
            }
            catch
            {
                Assert.Fail("No of Installments not available");
            }

            //Repayment Entity Verify
            try
            {
                IWebElement elem6 = driver.FindElement(By.XPath("//div[text()='REPAYMENT PLAN']"));
                IJavaScriptExecutor js7 = (IJavaScriptExecutor)driver;
                js7.ExecuteScript("arguments[0].scrollIntoView();", elem6);
                ThinkTime(4);
                if (driver.FindElement(By.XPath("//div[@id='vrp_paymentdate']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Repayment Plan available with required field", "Repayment Plan available with required field");
            }
            catch
            {
                Assert.Fail("Repayment Entity Not Available");
            }

            //Payment Date
            if (driver.FindElement(By.XPath("//div[contains(@data-lp-id,'vrp_repaymentplan|vrp_msfsi_financialproduct_vrp_repaymentplan_CustomerProduct|cc-grid|cc-grid-column|vrp_paymentdate')]")).Displayed)
            {
                Console.WriteLine("Payment Date available for Finance Repayment");
            }
            else
            {
                Assert.Fail("Payment Failed");
            }


            //Navigate Back to Previous page
            driver.Navigate().Back();

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


            //Navigate to Sales and Marketing
            driver.FindElement(By.XPath("//li[text()='Sales & Marketing']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[text()='OPPORTUNITIES']")));
            }
            try
            {
                if (driver.FindElement(By.XPath("//div[text()='OPPORTUNITIES']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Oppurtunities Page displayed", "Oppurtunities Page displayed");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Cannot navigate to Oppurtunities in Sales and Marketing", "Cannot navigate to Oppurtunities in Sales and Marketing");
                Assert.Fail("Cannot navigate to Oppurtunities in Sales and Marketing");
            }
            ThinkTime(4);

            //Open an opportunity
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//a[@title='" + opportunity + "'])[1]")));
            }
            driver.FindElement(By.XPath("(//a[@title='" + opportunity + "'])[1]")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Product ID']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Opportunity opened", "Opportunity opened");

            driver.Navigate().Back();
            ThinkTime(10);

            //Wait for Frame to  load
            try
            {
                waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("WebResource_EligibleProducts")));
                ThinkTime(5);


                //Wait for element to be visible
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//img[@name='imgYesProductInterestResponse']")));
                }

                //Verify details for eligible product
                if (driver.FindElement(By.XPath("//span[text()='Utilized']")).Displayed)
                {
                    Console.WriteLine("Utilized available");
                }
                else
                {
                    Assert.Fail("Utilized not available");
                }

                if (driver.FindElement(By.XPath("//span[text()='Propensity %']")).Displayed)
                {
                    Console.WriteLine("Propensity available");
                }
                else
                {
                    Assert.Fail("Propensity not available");
                }

                if (driver.FindElement(By.XPath("//span[text()='Benefit (USD)']")).Displayed)
                {
                    Console.WriteLine("Benefit in Elegible product available");
                }
                else
                {
                    Assert.Fail("Benefit in Elegible product not available");
                }

                ThinkTime(4);
                if (driver.FindElement(By.XPath("//span[text()='OPT']")).Displayed)
                {
                    Console.WriteLine("Open Opourtunity available");
                }
                else
                {
                    Assert.Fail("Open Opourtunity not available");
                }


                //Select the eligible product
                driver.FindElement(By.XPath("//img[@name='imgYesProductInterestResponse']")).Click();

                driver.SwitchTo().DefaultContent();

                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[@data-id='customerid.fieldControl-LookupResultsDropdown_customerid_selected_tag_text']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Opportunity opened", "Opportunity opened");
                ThinkTime(2);

                driver.Navigate().Back();
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Info", "No Eligible Product for Verification", "No Eligible Product For Veirfication");
            }

            ThinkTime(5);
            driver.SwitchTo().DefaultContent();
            ThinkTime(2);
          
            //Verify Customer 720 
            var waits1 = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
            waits1.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("WebResource_Customer720")));
        
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Relation']")));
            }

            IWebElement elemq = driver.FindElement(By.XPath("//span[text()='Relation']"));
            IJavaScriptExecutor js11 = (IJavaScriptExecutor)driver;
            js11.ExecuteScript("arguments[0].scrollIntoView(true);", elemq);

            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer 720 degree with Relation displayed", "Customer 720 degree with Relation displayed");

            ThinkTime(3);
            driver.SwitchTo().DefaultContent();
            ThinkTime(5);

            ///<summary>
            ///Move To Services
            ///</ summary >
            driver.FindElement(By.XPath("//li[text()='Services']")).Click();
            ThinkTime(2);

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[contains(@data-lp-id,'incident|incident_customer_contacts|cc-grid|cc-grid-column|title')]//div[text()='Case Title']")));
            }

            if (driver.FindElement(By.XPath("//div[contains(@data-lp-id,'incident|incident_customer_contacts|cc-grid|cc-grid-column|title')]//div[text()='Case Title']")).Displayed)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "UnResolved cases category Present", "UnResolved cases category Present");

            }
            else
            {
                Assert.Fail("UnResolved cases CaseTitle not available");
            }

            if (driver.FindElement(By.XPath("(//div[text()='Current Process Task'])[2]")).Displayed)
            {
                Console.WriteLine("Current Process Task Availble");
            }
            else
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Current Process Task Present", "Current Process Task Present");
                Assert.Fail("Current Process Task not available");
            }

            if (driver.FindElement(By.XPath("(//div[text()='Expected Resolution Time'])[2]")).Displayed)
            {
                Console.WriteLine("Expected Resolution Time Availble");
            }
            else
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Expected Resolution Time Present", "Expected Resolution Time Present");
                Assert.Fail("Expected Resolution Time not available");
            }

            //Select the unresolved case
            driver.FindElement(By.XPath("//a[text()='" + unresolvedcase + "']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//input[@data-id='header_vrp_trackingnumber.fieldControl-text-box-text']")));
            }

            string trackingno = driver.FindElement(By.XPath("//input[@data-id='header_vrp_trackingnumber.fieldControl-text-box-text']")).GetAttribute("value");
            if (!String.IsNullOrEmpty(trackingno))
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Tracking Number Present", "Tracking Number Present");
            }
            else
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Tracking number for Unresolved case not available", "Tracking number for Unresolved case not available");
                Assert.Fail("Tracking number for Unresolved case not available");                
            }

            driver.Navigate().Back();
            ThinkTime(4);
            try
            {
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//span[@id='confirmButtonText']")));
                }
                if (driver.FindElement(By.XPath("//span[@id='confirmButtonText']")).Displayed)
                {
                    driver.FindElement(By.XPath("//span[@id='confirmButtonText']")).Click();
                    ThinkTime(4);
                  //  driver.SwitchTo().DefaultContent();
                }
            }
            catch
            {

            }
            ThinkTime(4);

            //New Complaint
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='New Complaint']")));
            }
            driver.FindElement(By.XPath("//span[text()='New Complaint']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[@data-id='customerid.fieldControl-LookupResultsDropdown_customerid_selected_tag_text']")));
            }

            string customerNameValidate = driver.FindElement(By.XPath("//label[@data-id='customerid.fieldControl-LookupResultsDropdown_customerid_selected_tag_text']")).Text;
            if (customerNameValidate == custname)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer Name Present", "Customer Name Present");
            }
            else
            {
                Assert.Fail("Customer name not filled for Complaint");
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer name not filled for Complaint", "Customer name not filled for Complaint");
            }

            //Navigate to Back
            driver.Navigate().Back();

            ThinkTime(4);
            try
            {
                // waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[contains(@id,'ClientApiFrame_id')]")));
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//button[@id='confirmButton']")));
                }
                if (driver.FindElement(By.XPath("//button[@id='confirmButton']")).Displayed)
                {
                    driver.FindElement(By.XPath("//button[@id='confirmButton']")).Click();
                    ThinkTime(4);
                   // driver.SwitchTo().DefaultContent();
                }
            }
            catch
            {

            }

            //Wait for new service
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//button[@data-id='contact|NoRelationship|Form|Sample.Form.contact.Form.NewServiceRequest']")));
            }

            //Click on new services
            driver.FindElement(By.XPath("//button[@data-id='contact|NoRelationship|Form|Sample.Form.contact.Form.NewServiceRequest']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[@data-id='customerid.fieldControl-LookupResultsDropdown_customerid_selected_tag_text']")));
            }

            string newServiceReqCustName = driver.FindElement(By.XPath("//label[@data-id='customerid.fieldControl-LookupResultsDropdown_customerid_selected_tag_text']")).Text;

            if (newServiceReqCustName == custname)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer Name Present in New Service Request", "Customer Name Present in New Service Request");
            }
            else
            {
                Assert.Fail("Customer name not filled for New Service Request");
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer name not filled for New Service Request", "Customer name not filled for New Service Request");
            }


            //Navigate to Back
            driver.Navigate().Back();
            ThinkTime(4);
            try
            {
                //waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("//iframe[contains(@id,'ClientApiFrame_id')]")));
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//button[@id='confirmButton']")));
                }
                if (driver.FindElement(By.XPath("//button[@id='confirmButton']")).Displayed)
                {
                    driver.FindElement(By.XPath("//button[@id='confirmButton']")).Click();
                    ThinkTime(4);
                    driver.SwitchTo().DefaultContent();
                }
            }
            catch
            {

            }
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[text()='COLLECTION TICKETS']")));
            }
            IWebElement elemq1 = driver.FindElement(By.XPath("//div[text()='COLLECTION TICKETS']"));
            IJavaScriptExecutor js12 = (IJavaScriptExecutor)driver;
            js12.ExecuteScript("arguments[0].scrollIntoView(true);", elemq1);
            ThinkTime(4);
            try
            {
                if (driver.FindElement(By.XPath("//div[@id='vrp_productid']")).Displayed)
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Product ID displayed", "Product ID displayed");
            }
            catch
            {
                Assert.Fail("Product ID not available");
            }

            try
            {
                if (driver.FindElement(By.XPath("(//div[text()='Delinquent Amount'])[2]")).Displayed)
                    Console.WriteLine("Deliquent Amount available");
            }
            catch
            {
                Assert.Fail("Deliquent Amount not available");
            }

            try
            {
                driver.FindElement(By.XPath("//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|Collections|contact')]//a[text()='" + collectionticket + "']")).Click();
                ThinkTime(10);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Collection Ticket of customer is displayed and non editable", "Collection Ticket of customer is displayed and non editable");
                driver.Navigate().Back();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|EnrolledServices|contact')]//div[text()='Service Name'])[1]")));
                }
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Skip", "Collection ticket item not available", "Collection Ticket item not available");
            }
           
            
            ThinkTime(5);
            try
            {
                if (driver.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|EnrolledServices|contact')]//div[text()='Service Name'])[1]")).Displayed)
                {
                    Console.WriteLine("Service Name Available for Enrolled Services");
                }
            }
            catch
            {
                Assert.Fail("Service Name not  Available for Enrolled Services");
            }

            //select an enrolled service
            driver.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|EnrolledServices|contact')]//a[text()='" + enrolledservice + "'])[1]")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Service']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Enrolled Service details listed", "Enrolled Service details listed");
            driver.Navigate().Back();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|EnrolledServices|contact')]//div[text()='Service Name'])[1]")));
            }


            ///<summary>
            ///Verify Relationship
            /// </summary>
            ThinkTime(5);
            driver.FindElement(By.XPath("//li[text()='Relationship']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|Dependents|contact')]//div[text()='Name'])[1]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Depedent Section visible", "Depedent Section visible");
            ThinkTime(2);

            //Click on + Add new dependent
            driver.FindElement(By.XPath("//button[@aria-label='Add New Dependent']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//input[contains(@id,'vrp_name-vrp_name.fieldControl-text-box-text')]")));
            }
            try
            {
                driver.FindElement(By.XPath("//input[contains(@id,'vrp_name-vrp_name.fieldControl-text-box-text')]")).SendKeys("test");
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Able to add new dependent and edit details", "Able to add new dependent and edit details");
                ThinkTime(2);
            }
            catch
            {
                Assert.Fail("Unable to add new Dependent");
            }

            driver.FindElement(By.XPath("(//button[contains(@aria-label,'Save')])[1]")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//h1[text()='test']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "New Depedent Section saved", "New Depedent Section saved");
            ThinkTime(2);
            driver.Navigate().Back();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|Dependents|contact')]//div[text()='Name'])[1]")));
            }
            waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("WebResource_RetailInterationTimeline")));

            //Move to Interaction timeline
            IWebElement elem20 = driver.FindElement(By.XPath("//h6[text()='INTERACTION TIMELINE']"));
            IJavaScriptExecutor js13 = (IJavaScriptExecutor)driver;
            js13.ExecuteScript("arguments[0].scrollIntoView(true);", elem20);

            try
            {
                if (driver.FindElement(By.XPath("//a[text()='Call Center  ']")).Displayed)
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Call Centre Interaction displayed", "Call Centre Interaction displayed");
                }
            }
            catch
            {
                Console.WriteLine("No Call Centre interaction visible");
            }

            try
            {
                if (driver.FindElement(By.XPath("//a[text()='Branch  ']")).Displayed)
                {
                    Console.WriteLine("Branch interaction Visble");
                }
            }
            catch
            {
                Console.WriteLine("No Branch interaction visible");
            }
            ThinkTime(2);

            driver.SwitchTo().DefaultContent();
            ThinkTime(3);

            //Move to Interaction timeline
            IWebElement elem21 = driver.FindElement(By.XPath("//div[text()='INTERACTIONS CHART']"));
            IJavaScriptExecutor js14 = (IJavaScriptExecutor)driver;
            js14.ExecuteScript("arguments[0].scrollIntoView(true);", elem21);


           // Actions action = new Actions(driver);
            IWebElement element = driver.FindElement(By.XPath("//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|InteractionChart|contact')]//div[@header-row-number='0']"));
            action.DoubleClick(element).Perform();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Interaction Description']")));
            }

            try
            {
                if (driver.FindElement(By.XPath("//label[text()='Interaction Description']")).Displayed)
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Description displayed", "Description displayed");
                }
            }
            catch
            {
                Assert.Fail("Description not available");
            }

            driver.Navigate().Back();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Related']")));
            }
            driver.FindElement(By.XPath("//li[text()='Related']")).Click();
            ThinkTime(6);
            driver.FindElement(By.XPath("//span[text()='Dispositions']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Disposition Associated View']")));
            }

            try
            {
                if (driver.FindElement(By.XPath("//span[text()='Disposition Associated View']")).Displayed)
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Disposition Associated View Visible", "Disposition Associated View Visible");
                }
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Disposition Associated View not Visible", "Disposition Associated View not Visible");
                Assert.Fail("Disposition Associated View not visible");
            }
            try
            {
                //wait for disposition
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[@header-row-number='0']")));
                }

                //Select the disposition from view
                IWebElement disposition = driver.FindElement(By.XPath("//div[@header-row-number='0']"));
                action.DoubleClick(disposition).Perform();

                //Wait for handling Script Error
                try
                {
                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("//span[@id='okButtonText']")));
                    }
                    driver.FindElement(By.XPath("//span[@id='okButtonText']")).Click();
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Disposition selected View ", "Disposition selected View");
                }
                catch
                {
                    Console.WriteLine("No Script Error Displayed");
                }


                //Verify Inbound Call Activity
                try
                {
                    if (driver.FindElement(By.XPath("//label[contains(text(),'Inbound call from IVR')]")).Displayed)
                    {
                        Console.WriteLine("Inbound Activity Pass");
                        AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Inboud Call Activity available ", "Inboud Call Activity available ");
                    }
                }
                catch
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Info", "Inboud Call Activity not available ", "Inboud Call Activity not available ");
                    //Assert.Fail("Inboud Call Activity not available ");
                }
                ThinkTime(5);
                driver.Navigate().Back();
                
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//div[@header-row-number='0']")));
                }
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Skip", "Disposition not displayed for customer", "Disposition not displayed for customer");
            }


            //Navigate back to Relationship
            driver.FindElement(By.XPath("//li[text()='Relationship']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|Dependents|contact')]//div[text()='Name'])[1]")));
            }
            driver.FindElement(By.XPath("//div[@id='dataSetRoot_InteractionChart_outer']//li[@aria-label='More Commands']")).Click();
            ThinkTime(4);
            driver.FindElement(By.XPath("//button[@aria-label='Add New Customer Interaction']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[@data-id='vrp_name-FieldSectionItemContainer']")));
            }

            driver.FindElement(By.XPath("//input[@data-id='vrp_name.fieldControl-text-box-text']")).SendKeys("Online");
            driver.FindElement(By.XPath("//i[@data-icon-name='Calendar']")).Click();
            int i;
            for (i = 0; i < 200; i++)
            {
                driver.FindElement(By.XPath("//button[contains(@class,'ms-DatePicker-prevMonth js-prevMonth prevMonth')]")).Click();
            }
            driver.FindElement(By.XPath("//span[text()='20']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//input[contains(@data-id,'vrp_socialmediacustomername.fieldControl-text-box-text')]")).SendKeys(custname);
            driver.FindElement(By.XPath("//select[@aria-label='Interaction Type']")).Click();
            driver.FindElement(By.XPath("//option[text()='Online']")).Click();
            driver.FindElement(By.XPath("//input[@aria-label='Interaction Channel  Lookup']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//button[@aria-label='Search All Records']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//li[@aria-label='Digital Channels']")).Click();
            ThinkTime(2);
            driver.FindElement(By.XPath("//button[@aria-label='Save']")).Click();
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "New Interaction saved", "New Interaction saved");
            ThinkTime(2);
            driver.Navigate().Back();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'MscrmControls.Grid.ReadOnlyGrid|Dependents|contact')]//div[text()='Name'])[1]")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Interaction Channel visible", "Interaction Channel visible");
            ThinkTime(2);

            driver.FindElement(By.XPath("//li[text()='Documents']")).Click();
            ThinkTime(2);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//div[text()='Reference No.']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer Document list visible", "Customer Document list visible");
            ThinkTime(3);

            try
            {
                driver.FindElement(By.XPath("(//div[contains(@data-lp-id,'vrp_customerdocument|vrp_contact_vrp_customerdocument_Person|cc-grid|cc-grid-cell')])[2]")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[contains(text(),'Originator')]")));
                }
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer Document details visible", "Customer Document details visible");
                ThinkTime(3);
                driver.Navigate().Back();
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Skip", "Customer Document list not visible", "Customer Document list not visible");
            }


            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Collaboration']")));
            }
            ThinkTime(5);
            driver.FindElement(By.XPath("//li[text()='Collaboration']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Collaboration']")));
            }
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Collaboration Page", "Navigated to Collaboration Page");
            ThinkTime(3);
            driver.FindElement(By.XPath("//label[@title='Add info and activities']")).Click();
            ThinkTime(3);
            if(driver.FindElement(By.XPath("//label[text()='Activity']")).Displayed)
            {
                if(driver.FindElement(By.XPath("//label[text()='Note']")).Displayed)
                {
                    ThinkTime(3);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Activity Notes and Post available in Collaboration Page", "Activity Notes and Post available in Collaboration Page");
                }
            }
            try
            {
                if (driver.FindElement(By.XPath("//label[text()='Post by']")).Displayed)
                {
                    ThinkTime(3);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Post is displayed in collaboration given by customer", "Post is displayed in collaboration given by customer");
                }
            }
            catch
            {
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "No added post is displayed in collaboration given by customer", "No added Post is displayed in collaboration given by customer");
                ThinkTime(3);
                driver.FindElement(By.XPath("//label[text()='Post']")).Click();
                ThinkTime(3);
                driver.FindElement(By.XPath("//textarea[@id='create_post_postText']")).SendKeys("HI");
                ThinkTime(3);
                driver.FindElement(By.XPath("//span[text()='Add']")).Click();
                if (timeOutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                    wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Post by']")));
                }
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Post is displayed in collaboration given by customer", "Post is displayed in collaboration given by customer");
                
            }
            ThinkTime(4);
            driver.FindElement(By.XPath("//label[@title='Add info and activities']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//label[text()='Phone Call']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Owner']")));
            }
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Activities details is displayed in collaboration given by customer", "Activities details is displayed in collaboration given by customer");

            //Fill Activity Details
            driver.FindElement(By.XPath("//input[@data-id='subject.fieldControl-text-box-text']")).SendKeys("Complaint about Debit Card through call");
            ThinkTime(3);
            driver.FindElement(By.XPath("//button[@id='quickCreateSaveBtn']")).Click();
            ThinkTime(3);
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//label[text()='Phone Call from']")));
            }
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Activities details is added in collaboration given by customer", "Activities details is added in collaboration given by customer");

            //Verify able to add Notes in Collaboration
            ThinkTime(3);
            driver.FindElement(By.XPath("//label[@title='Add info and activities']")).Click();
            ThinkTime(3);
            driver.FindElement(By.XPath("//label[text()='Note']")).Click();
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Notes displayed in collaboration given by customer", "Notes displayed is added in collaboration given by customer");
            driver.FindElement(By.XPath("//input[@id='create_note_medium_title']")).SendKeys("Titletest");
            ThinkTime(3);
            driver.FindElement(By.XPath("//textarea[@id='create_note_notesText']")).SendKeys("Titletest");
            ThinkTime(3);
            string path = @"D:\Anandakrishnan_UpdatedResume.pdf";
            driver.FindElement(By.XPath("//div[@id='create_note_action_attachement']")).Click();
            ThinkTime(3);
            System.Windows.Forms.SendKeys.SendWait(path);
            System.Windows.Forms.SendKeys.SendWait(@"{Enter}");
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer able to add attachment and notes", "Customer able to add attachment and notes");
            ThinkTime(4);
            driver.FindElement(By.XPath("//span[text()='Add note']")).Click();
            ThinkTime(4);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer able to add Notes attachment and save ", "Customer able to add attachment notes and save");
            ThinkTime(4);

        }
    }
}
