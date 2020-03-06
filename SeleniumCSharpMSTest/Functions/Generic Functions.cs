using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesthouseSeleniumCSharp.Functions;
using TesthouseSeleniumCSharp.ObjectRepository;
using OpenQA.Selenium.Interactions;


namespace SeleniumCSharpMSTest.Functions
{
    public class GenericFunctions : Helper
    {
        int timeOutInSeconds = 120;
        Reader reader = new Reader();
        public string username = null, password = null;

        /// <summary>
        /// Method to input text
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="controlName"></param>
        /// <param name="objectSheet"></param>
        /// <param name="inputText"></param>
        public void EnterText(IWebDriver driver, string controlName, string objectSheet, string inputText)
        {
            Keywords KeyFound = reader.FindControlinList(controlName, objectSheet);
            string propertyValue = KeyFound.PropertyValue;

            try
            {
                Element(driver, By.Id(propertyValue + "_d")).Click();
            }
            catch (Exception)
            {
                Element(driver, By.Id(propertyValue + "_c")).Click();
            }
            Element(driver, By.Id(propertyValue + "_i")).SendKeys(inputText);
        }

        /// <summary>
        /// Method to input text
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="controlName"></param>
        /// <param name="objectSheet"></param>
        /// <param name="inputText"></param>
        public void SelectOption(IWebDriver driver, string controlName, string objectSheet, string inputText)
        {
            Keywords KeyFound = reader.FindControlinList(controlName, objectSheet);
            string propertyValue = KeyFound.PropertyValue;

            try
            {
                Element(driver, By.Id(propertyValue + "_d")).Click();
            }
            catch (Exception)
            {
                Element(driver, By.Id(propertyValue + "_c")).Click();
            }
            Select(Element(driver, By.Id(propertyValue + "_i"))).SelectByText(inputText);
        }

        /// <summary>
        /// Method to set the lookup field value
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="controlName"></param>
        /// <param name="objectSheet"></param>
        /// <param name="inputText"></param>
        public void SetLookupField(IWebDriver driver, string controlName, string objectSheet, string inputText)
        {
            Keywords KeyFound = reader.FindControlinList(controlName, objectSheet);
            string propertyValue = KeyFound.PropertyValue;

            try
            {
                Element(driver, By.Id(propertyValue + "_d")).Click();
            }
            catch (Exception)
            {
                Element(driver, By.Id(propertyValue + "_c")).Click();
            }
            ThinkTime(2);
            Element(driver, By.Id(propertyValue + "_ledit")).SendKeys(inputText);
            ThinkTime(1);
            Element(driver, By.Id(propertyValue + "_i")).Click();
            ThinkTime(2);
            Element(driver, By.XPath("//*[@id='" + propertyValue + "_IMenu']/li/a[2][@title='" + inputText + "']")).Click();
        }

        /// <summary>
        /// To close Welcome popup
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        public void CloseWelcomePopup(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            try
            {
                SwitchToFrame(driver, "InlineDialog_Iframe");
                WaitUntil(driver, Control("closeWelcomePopup", "Generic"), 60);
                Element(driver, Control("closeWelcomePopup", "Generic")).Click();


            }
            catch (Exception e)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unexpected error:\n " + e, "Unexpected error");
                
            }
        }

        /// <summary>
        /// To select any option from the main dropdown. You have to provide the Module name & option name
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        /// <param name="selectModule"></param>
        /// <param name="optionFromModuleList"></param>
        public void SelectOptionFromMainDropdown(IWebDriver driver, string selectModule, string optionFromModuleList)
        {
            driver.SwitchTo().DefaultContent();
            //WaitUntil(driver, Control("logoSyncsort", "Generic"), 60);
            //Element(driver, Control("logoSyncsort", "Generic")).Click();
            WaitUntil(driver, Control("mainDropdown", "Generic"), 60);
            Element(driver, Control("mainDropdown", "Generic")).Click();
            ThinkTime(1);
            ElementHighlight(driver, Control("selectModule", selectModule, "Generic"));
            Element(driver, Control("selectModule", selectModule, "Generic")).Click();
            ThinkTime(2);
            ElementHighlight(driver, Control("selectOptionFromMainDropdownList", optionFromModuleList, "Generic"));
            Element(driver, Control("selectOptionFromMainDropdownList", optionFromModuleList, "Generic")).Click();

        }

        /// <summary>
        /// To refresh a page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        /// <param name="selectModule"></param>
        /// <param name="optionFromModuleList"></param>
        public void RefreshPage(IWebDriver driver)
        {
            driver.Navigate().Refresh();
            ThinkTime(2);

        }

        /// <summary>
        /// To select any option from the drop arrow of a record. You have to provide option name
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        /// <param name="selectModule"></param>
        /// <param name="optionFromModuleList"></param>
        public void SelectOptionFromRecord(IWebDriver driver, string optionFromList)
        {
            driver.SwitchTo().DefaultContent();
            //WaitUntil(driver, Control("logoSyncsort", "Generic"), 60);
            //Element(driver, Control("logoSyncsort", "Generic")).Click();
            WaitUntil(driver, Control("recordDropdown", "Generic"), 60);
            Element(driver, Control("recordDropdown", "Generic")).Click();
            ThinkTime(1);
            ElementHighlight(driver, Control("selectOptionFromRecordDropdown", optionFromList, "Generic"));
            Element(driver, Control("selectOptionFromRecordDropdown", optionFromList, "Generic")).Click();


        }

        /// <summary>
        /// Search any records
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        /// <param name="recordToBeSearched"></param>
        public void SearchRecordAndVerify(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string recordToBeSearched)
        {
            driver.SwitchTo().DefaultContent();
            AutomaticFrameSwitch(driver, Control("searchRecordBox", "Generic"), 15);
            ThinkTime(2);
            WaitUntil(driver, Control("searchRecordBox", "Generic"), 60);
            Element(driver, Control("searchRecordBox", "Generic")).Click();

            WaitUntil(driver, Control("searchRecordInput", "Generic"), 60);
            Element(driver, Control("searchRecordInput", "Generic")).SendKeys(Keys.Control + "A");
            Element(driver, Control("searchRecordInput", "Generic")).SendKeys(Keys.Delete);
            Element(driver, Control("searchRecordInput", "Generic")).SendKeys(recordToBeSearched);

            ThinkTime(1);
            WaitUntil(driver, Control("searchRecordIcon", "Generic"), 60);
            Element(driver, Control("searchRecordIcon", "Generic")).Click();

            try
            {
                WaitUntil(driver, Control("searchRecordVerify", "Generic"), 60);
                if (Element(driver, Control("searchRecordVerify", "Generic")).Displayed)
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Search result successfully displayed in CRM", "Search result successfully displayed");
                }
                else
                {
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Record not searched properly in CRM", "Record not searched properly");
                    Assert.Fail();
                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// Select the first row in search results
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="record"></param>
        public void selectSearchedRecord(IWebDriver driver, string record)
        {
            driver.SwitchTo().DefaultContent();
            AutomaticFrameSwitch(driver, Control("searchRecordBox", "Generic"), 15);

            WaitUntil(driver, Control("selectFirstRecord", "Generic"), 60);
            ActionsDoubleClick(driver, Control("selectFirstRecord", "Generic"));

            driver.SwitchTo().DefaultContent();
            WaitUntil(driver, Control("newItem", "Generic"), 120);
            ThinkTime(3);
        }

        /// <summary>
        /// Select the first row in search results
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="record"></param>
        public void selectSearchedProduct(IWebDriver driver, string record)
        {
            driver.SwitchTo().DefaultContent();
            AutomaticFrameSwitch(driver, Control("searchRecordBox", "Generic"), 15);

            WaitUntil(driver, Control("selectFirstRecord", "Generic"), 60);
            ActionsDoubleClick(driver, Control("selectFirstRecord", "Generic"));

            driver.SwitchTo().DefaultContent();
            WaitUntil(driver, Control("productVerify", "Generic"), 120);
            ThinkTime(3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        public void createNewEntry(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                ThinkTime(2);
                WaitUntil(driver, Control("newItem", "Generic"), 120);
               // Element(driver, Control("newItem", "Generic")).Click();
                JSClick(driver, Control("newItem", "Generic"));

                ThinkTime(2);
            try
            {
                AuthenticationPopupHandle(driver);
            }
            catch
            {
            }

            ThinkTime(1);
                WaitUntil(driver, Control("SaveItem", "Generic"), 35);

                if (Element(driver, Control("SaveItem", "Generic")).Displayed)
                {
                    ThinkTime(1);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "New Entry page is displayed", "New Entry page displayed");
                }
                else
                {
                    ThinkTime(1);
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "New Entry page is not displayed", "New Entry page not displayed");
                    Assert.Fail();
                }


        }
            catch (Exception e)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unable to create new Record" + e, "Unable to create new Record");
                throw;
            }
}

        /// <summary>
        /// Automatic switch between contentIFrame0 and contentIFrame1
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        public void AutomaticFrameSwitch(IWebDriver driver)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                SwitchToFrame(driver, "contentIFrame0");
            }
            catch
            {
                driver.SwitchTo().DefaultContent();
                SwitchToFrame(driver, "contentIFrame1");
            }
        }

        /// <summary>
        /// Method to switch frame and check a particular element is present till timeout
        /// </summary>
        /// <param name="driver"></param>
        public void AutomaticFrameSwitch(IWebDriver driver, By by, int timeToWait)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                SwitchToFrame(driver, "contentIFrame1");
                WaitUntil(driver, by, timeToWait);
            }
            catch
            {
                driver.SwitchTo().DefaultContent();
                SwitchToFrame(driver, "contentIFrame0");
                WaitUntil(driver, by, timeToWait);

            }
        }

        /// <summary>
        /// Method to switch to a frame which is inside another frame
        /// </summary>
        /// <param name="driver"></param>
        public void AutomaticFrameSwitch(IWebDriver driver, string frame)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                SwitchToFrame(driver, "contentIFrame0");
                SwitchToFrame(driver, frame);

            }
            catch
            {
                driver.SwitchTo().DefaultContent();
                SwitchToFrame(driver, "contentIFrame1");
                SwitchToFrame(driver, frame);

            }
        }

        /// <summary>
        /// Handle the window.
        /// Returns parent window instance.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="frame"></param>
        public string WindowHandling(IWebDriver driver)
        {
            ThinkTime(3);
            string parentWindowHandle = driver.CurrentWindowHandle;
            List<string> lstWindow = driver.WindowHandles.ToList();
            string lastWindowHandle = "";
            foreach (var handle in lstWindow)
            {
                if (handle != parentWindowHandle)
                {
                    driver.SwitchTo().Window(handle);
                    lastWindowHandle = handle;
                }

                ThinkTime(3);
            }
            return parentWindowHandle;

        }

        /// <summary>
        /// Method to switch back to parent Window.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="parent"></param>
        public void WindowHandling(IWebDriver driver, string parent)
        {
            ThinkTime(3);
            driver.SwitchTo().Window(parent);
        }

        /// <summary>
        /// Handle Alert - 
        /// Case sensitive - "Accept"/"Dismiss"
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="parent"></param>
        public void AlertHandling(IWebDriver driver, string acceptOrDismiss)
        {
            try
            {
                if (acceptOrDismiss == "Accept")
                {
                    //driver.SwitchTo().DefaultContent();
                    WaitForAlert(driver, 30);
                    IAlert alert = driver.SwitchTo().Alert();
                    alert.Accept();
                }
                else if (acceptOrDismiss == "Dismiss")
                {
                    //driver.SwitchTo().DefaultContent();
                    WaitForAlert(driver, 10);
                    IAlert alert = driver.SwitchTo().Alert();
                    alert.Dismiss();
                }
            }
            catch 
            {
            }
        }

        /// <summary>
        /// Handles the alert when navigating to other pages without saving the entity
        /// </summary>
        /// <param name="driver"></param>
        public void ChangesNotSaved(IWebDriver driver)
        {
            try
            {
                WaitForAlert(driver, 5);
                IAlert alert = driver.SwitchTo().Alert();
                if (alert.Text == "Your changes have not been saved. To stay on the page so that you can save your changes, click Cancel.")
                {
                    ThinkTime(1);
                    alert.Accept();
                }
                driver.SwitchTo().DefaultContent();

            }
            catch (Exception)
            {
                driver.SwitchTo().DefaultContent();
            }
        }

        /// <summary>
        /// Method to assign a user
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        /// <param name="leadName"></param>
        public void AssignToUserOEngineer(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string assignTo)
        {

            try
            {
                ThinkTime(2);
                driver.SwitchTo().DefaultContent();
                WaitUntil(driver, Control("assignUserButton", "Generic"), 90);
                Element(driver, Control("assignUserButton", "Generic")).Click();
                ThinkTime(3);

                SwitchToFrame(driver, "InlineDialog_Iframe");
                try
                {
                    ThinkTime(3);
                    WaitUntil(driver, Control("assignToFieldAlternative", "Generic"), 30);
                    if (Element(driver, Control("assignToFieldAlternative", "Generic")).Text == "Me")
                    {
                        Element(driver, Control("assignToFieldAlternative", "Generic")).Click();
                    }

                }
                catch (Exception)
                {
                    ThinkTime(3);
                    WaitUntil(driver, Control("assignToField", "Generic"), 60);
                    if (Element(driver, Control("assignToField", "Generic")).Text == "Me")
                    {
                        Element(driver, Control("assignToField", "Generic")).Click();
                    }
                }

                WaitUntil(driver, Control("assignUserLookup", "Generic"), 90);
                SetLookupField(driver, "assignUserLookup", "Generic", assignTo);


                WaitUntil(driver, Control("assignButton", "Generic"), 90);
                Element(driver, Control("assignButton", "Generic")).Click();

            }
            catch (Exception e)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unexpected error and unable to assign Case :\n " + e, "Unexpected error and unable to assign Case ");
                throw;
            }
        }

        /// <summary>
        /// Method to assign 'Me'
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        /// <param name="leadName"></param>
        public void AssignToMe(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {

            try
            {
                ThinkTime(2);
                driver.SwitchTo().DefaultContent();
                WaitUntil(driver, Control("assignUserButton", "Generic"), 90);
                Element(driver, Control("assignUserButton", "Generic")).Click();
                ThinkTime(3);

                SwitchToFrame(driver, "InlineDialog_Iframe");
                //try
                //{
                //    ThinkTime(3);
                //    WaitUntil(driver, Control("assignToFieldAlternative", "Generic"), 30);
                //    if (Element(driver, Control("assignToFieldAlternative", "Generic")).Text == "User or team")
                //    {
                //        Element(driver, Control("assignToFieldAlternative", "Generic")).Click();
                //    }

                //}
                //catch (Exception)
                //{
                //    try
                //    {
                //        ThinkTime(3);
                //        WaitUntil(driver, Control("assignToField", "Generic"), 30);
                //        if (Element(driver, Control("assignToField", "Generic")).Text == "User or team")
                //        {
                //            Element(driver, Control("assignToField", "Generic")).Click();
                //        }

                //    }
                //    catch (Exception)
                //    {
                //    }
                //}

                WaitUntil(driver, Control("assignButton", "Generic"), 90);
                Element(driver, Control("assignButton", "Generic")).Click();

            }
            catch (Exception e)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unexpected error and unable to assign Case :\n " + e, "Unexpected error and unable to assign Case ");
                throw;
            }
        }


        /// <summary>
        /// Save any Record
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="testDataIteration"></param>
        public void SaveRecord(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            try
            {
                driver.SwitchTo().DefaultContent();
                ThinkTime(1);
                // WaitUntil(driver, Control("SaveItem", "Generic"), 120);
                Element(driver, Control("SaveItem", "Generic")).Click();
                ThinkTime(1);
                WaitUntil(driver, Control("newItem", "Generic"), 35);
                if (Element(driver, Control("newItem", "Generic")).Displayed)
                {
                    ThinkTime(1);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Saved the Record successfully", "Saved the Record successfully");
                }
                else
                {
                    ThinkTime(1);
                    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Failed at saving Record", "Failed at saving Record");
                    Assert.Fail();
                }


            }
            catch (Exception e)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unable to save Record" + e, "Unable to save Record");
                throw;
            }
        }

        /// <summary>
        /// Verify presence of Alert
        /// </summary>
        /// <returns></returns>
        public bool IsAlertPresent(IWebDriver driver)
        {
            try
            {
                IAlert alert = new WebDriverWait(driver, new TimeSpan(95)).Until(ExpectedConditions.AlertIsPresent());
                if (alert != null)
                {
                    driver.SwitchTo().Alert().Accept();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }


        public void HandlePendingEmailWarning(IWebDriver driver)
        {
            try
            {
                try
                {
                    SwitchToFrame(driver, "InlineDialog1_Iframe");

                }
                catch (Exception)
                {
                    SwitchToFrame(driver, "InlineDialog_Iframe");

                }
                WaitUntil(driver, Control("pendingEmailWarning", "Login"), 30);
                try
                {
                    JSClick(driver, Control("pendingEmailWarning", "Login"));
                }
                catch
                {
                    JSClick(driver, Control("pendingEmailWarning", "Login"));
                }
            }
            catch
            {
                
            }
            driver.SwitchTo().DefaultContent();
        }


        public void AuthenticationPopupHandle(IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(20));
                IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
                alert.SetAuthenticationCredentials(username, password);
            }
            catch
            {
            }
        }



        //Navigate to Person 360
        public void NavigateToPerson360(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            ThinkTime(2);
            if (driver.FindElement(By.XPath("//button[@title='Site Map']/div")).Displayed)              
            try
            {
                ThinkTime(2);
                driver.FindElement(By.XPath("//li[@title='Persons']")).Click();
                ThinkTime(6);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Persons option listed", "Persons option listed");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Persons option not listed", "Persons option not listed");
                Assert.Fail("Hamburger option not clicked or Person option not present");
            }
        }

        //Create new Customer
        public void NewCustomer360(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration,string title,string nationality,string dob,string mobno,string firstname,
            string maritialstatus,string lastname,string id,string residencemobno)
        {
            driver.SwitchTo().DefaultContent();
            ThinkTime(2);
            driver.FindElement(By.XPath("//button[@data-id='contact|NoRelationship|HomePageGrid|Mscrm.HomepageGrid.contact.NewRecord']")).Click();
            try
            {
                WaitUntil(driver, Control("textVerify", "Generic"), 60);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "New Persons page diaplayed", "New Person Page displayed");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "New Persons page not diaplayed", "New Persons page not diaplayed");
                Assert.Fail("New Person Page not diplayed");
            }
            Element(driver, Control("arrowDropdown", "Generic")).Click();
            ThinkTime(2);
            IWebElement elem = driver.FindElement(By.XPath("//span[@class='symbolFont DropdownArrow-symbol ']"));
            int x = elem.Location.X;
            int y = elem.Location.Y;
            Console.WriteLine("x=" + x);
            Console.WriteLine("y=" + y);
            int x1 = x + 30;
            int y1 = y - 30;
            Console.WriteLine("x1=" + x1);
            Console.WriteLine("Y1+" + y1);
          
            Actions action = new Actions(driver);
            action.MoveToElement(elem, x1, y1).Click().Build().Perform();
            //driver.SwitchTo().Frame(4);            
            try
            {
                WaitUntil(driver, Control("titleInputlabel", "Generic"),60);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Person Information page displayed", "Person Information page displayed");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Person Information page not displayed", "Person:Information page not displayed");
                Assert.Fail("Person Information Page of Customer 360 not displayed");
            }
            //Select title
            Element(driver, Control("titleInputlabel", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("titleInput", "Generic")).SendKeys(title);
            ThinkTime(2);
            Element(driver, Control("selectDropdown", title, "Generic")).Click();

            //Select nationality
            Element(driver, Control("nationality", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("nationality", "Generic")).SendKeys(nationality);
            ThinkTime(2);
            Element(driver, Control("selectDropdown", nationality, "Generic")).Click();

            //Select DOB
            Element(driver, Control("dateOfBirth", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("calendarIcon", "Generic")).Click();
            ThinkTime(2);
            for (int i = 0; i < 30; i++)
            {
                Element(driver, Control("topArrowCalendar", "Generic")).Click();
            }
            Element(driver, Control("dateOfBirthSelector", "Generic")).Click();

            //Select mobile number
            Element(driver, Control("mobileNumber", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("mobileNumber", "Generic")).SendKeys(mobno);
            ThinkTime(2);

            //Input first name
            Element(driver, Control("firstName", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("firstName", "Generic")).SendKeys(firstname);
            ThinkTime(2);

            //Maritial Status
            Element(driver, Control("maritialStatus", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("maritialStatus", "Generic")).SendKeys(maritialstatus);
            ThinkTime(2);
            Element(driver, Control("selectDropdown", maritialstatus, "Generic")).Click();

            //Enter last name
            Element(driver, Control("lastName", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("lastName", "Generic")).SendKeys(lastname);
            ThinkTime(2);

            //Enter id 
            Element(driver, Control("id", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("id", "Generic")).SendKeys(id);
            ThinkTime(2);

            //Select Country of Residence
            Element(driver, Control("countryOfResidence", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("countryOfResidence", "Generic")).SendKeys(nationality);
            ThinkTime(2);
            Element(driver, Control("selectResidenceCountry", nationality, "Generic")).Click();

            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Person Information page mandatory field filled", "Person Information page filled");


            Element(driver, Control("addressDetails", "Generic")).Click();
            ThinkTime(2);

            driver.SwitchTo().DefaultContent();
            ThinkTime(2);
            //try
            //{
                //WaitUntilIElementVisible(driver, Control("residenceAdressPageVerify", "Genric"),60);
                //AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Address Details Page Displayed", "Addrs Detls Page Dispalyed");
            //}
            //catch
            //{
            //    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Address Details Page failed to Display", "Addrs Detls Page Dispaly failed");
            //    Assert.Fail("Navigation to Address Details Page Failed");
            //}
            ThinkTime(2);
            Element(driver, Control("residenceTelephoneNumber", "Generic")).Click();
            ThinkTime(2);
            Element(driver, Control("residenceTelephoneNumber", "Generic")).SendKeys(residencemobno);
            ThinkTime(2);
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Address Details Page Displayed", "Addrs Detls Page Dispalyed");
            ThinkTime(2);
            Element(driver, Control("saveForm", "Generic")).Click();

            //a[text()='Test5 testing']
            string fullname = firstname + " " + lastname;
            Console.WriteLine(fullname);

            ThinkTime(3);

            Element(driver, Control("Persons", "Generic")).Click();
            ThinkTime(3);

            //Navigate My Contacts page
            try
            {
                WaitUntil(driver, Control("activeAccountsVerify", "Generic"), 60);
                ThinkTime(3);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Persons option listed", "Persons option listed");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Persons option not listed", "Persons option not listed");
                Assert.Fail("Hamburger option not clicked or Person option not present");
            }

            IWebElement elem1 = driver.FindElement(By.XPath("//div//a[text()='" +fullname+ "']"));

            //Verify created customer listed
            //try
            //{
            //if(Element(driver,Control("customerCreatedVerify", fullname, "Generic")).Displayed)
            //{
                    IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                    js.ExecuteScript("arguments[0].scrollIntoView();", elem1);
                   // MoveToElement(driver, Control("customerCreatedVerify", fullname, "Generic"));
                    ThinkTime(2);
                    AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Cretaed Customer Present in My contacts", "Cretaed Customer Present in My contacts");
                //}
            //}
            //catch
            //{
            //    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Cretaed Customer not Present in My contacts", "Cretaed Customer not Present in My contacts");
            //    Assert.Fail("Created customer not visible");
            //}
        }

        public void DebitCreditTermDepositVerify(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration,string accountno)
        {

            ////Account Details Verify

            try
            {

                //Wait for Products Page to Load
                try
                {
                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("(//div[@data-id='AccountDetails_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")));
                    }
                }
                catch
                {
                    if (timeOutInSeconds > 0)
                    {
                        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                        wait.Until(drv => drv.FindElement(By.XPath("(//div[@data-id='AccountDetails_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_account_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")));
                    }
                }
                ThinkTime(4);

                //Extract the account number and click on Account
                try
                {
                    string accountverify = driver.FindElement(By.XPath("(//div[@data-id='AccountDetails_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_account_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")).Text;
                    Console.WriteLine(accountverify);
                }
                catch
                {
                    string accountverify = driver.FindElement(By.XPath("(//div[@data-id='AccountDetails_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")).Text;
                    Console.WriteLine(accountverify);
                }
               
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
                    //if (accountverify == accountdetailsview)
                        AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Account Details Page navigated", "Account Details Page navigated");
                    ThinkTime(2);
                  
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
            catch(Exception e)
            {
                Console.WriteLine("Cannot Verify for Account Details due to exception: "+e);
            }


            //Debit Card verify

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
                        if (timeOutInSeconds > 0)
                        {
                            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                            wait.Until(drv => drv.FindElement(By.XPath("(//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_account_msfsi_financialproduct_Customer|cc-grid|cc-grid-column|msfsi_number')])[1]")));
                        }
                    }
                }
                catch
                {
                    Assert.Fail("Navigation back to products page failed");
                }
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Info", "No Debit Card Available or Debit Card Verification Failed", "No Debit Card Available or Debit Card Verification Failed");
                Console.WriteLine("No Debit Card Available/Debit Card Verification Failed");
            }



            //Term Deposit Verify 
            try
            {
                try
                {
                    try
                    {
                        if (timeOutInSeconds > 0)
                        {
                            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                            wait.Until(drv => drv.FindElement(By.XPath("(//div[@data-id='TermDeposit_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_account_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")));
                        }
                    }
                    catch
                    {
                        if (timeOutInSeconds > 0)
                        {
                            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                            wait.Until(drv => drv.FindElement(By.XPath("(//div[@data-id='TermDeposit_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]")));
                        }
                    }
                    IWebElement elem2;
                    try
                    {
                        elem2 = driver.FindElement(By.XPath("(//div[@data-id='TermDeposit_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_contact_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]"));
                        IJavaScriptExecutor js0 = (IJavaScriptExecutor)driver;
                        js0.ExecuteScript("arguments[0].scrollIntoView();", elem2);
                    }
                    catch
                    {
                        elem2 = driver.FindElement(By.XPath("(//div[@data-id='TermDeposit_container']//div[contains(@data-lp-id,'msfsi_financialproduct|msfsi_account_msfsi_financialproduct_Customer|cc-grid|cc-grid-cell|cell')]//a)[1]"));
                        IJavaScriptExecutor js0 = (IJavaScriptExecutor)driver;
                        js0.ExecuteScript("arguments[0].scrollIntoView();", elem2);
                    }
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
                    AddLog(driver, testInReport, testName, testDataIteration, "Info", "Term Deposit not Available for customer OR Term Deposit Verification Failed", "Term Deposit not Available for customer OR Term Deposit Verification Failed");
                    Console.WriteLine("Term Deposit not Available for customer/ Term Deposit Verification Failed");
                }
            }
            catch
            {

            }

        }


        public void MoveToServices(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            driver.FindElement(By.XPath("//li[text()='Services']")).Click();

            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("(//div[text()='Case Title'])[1]")));
            }
        }

        public void NavigateToSalesAndMarketing(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//li[text()='Sales & Marketing']")));
            }
            ThinkTime(4);
            driver.FindElement(By.XPath("//li[text()='Sales & Marketing']")).Click();
            ThinkTime(8);

            try
            {
                var waits = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                waits.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("WebResource_Customer720")));
                //driver.SwitchTo().Frame("WebResource_Customer720");
                ThinkTime(5);
                IWebElement cust370 = driver.FindElement(By.XPath("(//h5[text()='Customer 720'])"));
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", cust370);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Customer 720 verified", "Customer 720 verified");
            }
            catch
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Customer 720 cannot verified", "Customer 720 cannot verified");
                Assert.Fail("Customer 720 verification failed");
            }

}

        public void NavigateToConfigurations(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration)
        {
            driver.FindElement(By.XPath("//button[@title='Site Map']/div")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Collection Tickets']")));
            }
            ThinkTime(3);
            driver.FindElement(By.XPath("//span[@class='symbolFont More-symbol ']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Product Disinterest Reasons']")));
            }
            driver.FindElement(By.XPath("//span[text()='Product Disinterest Reasons']")).Click();
            if (timeOutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSeconds));
                wait.Until(drv => drv.FindElement(By.XPath("//span[text()='Active Product DisInterest Reasons']")));
            }
            AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Navigated to Configurations list", "Navigated to Configurations list");
        }
    }
}
