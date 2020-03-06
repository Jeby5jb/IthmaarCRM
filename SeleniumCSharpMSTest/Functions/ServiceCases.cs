using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharpMSTest.ObjectRepository;

namespace SeleniumCSharpMSTest.Functions
{
    public class ServiceCases : MarketingObjects
    {

        string newCase;
        /// <summary>
        /// Method to Create a new Campaign
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="testInReport"></param>
        /// <param name="testName"></param>
        /// <param name="name"></param>
        /// <param name="campaignCode"></param>
        /// <param name="campaignType"></param>
        /// <param name="expectedResponse"></param>
        /// <param name="proposedStart"></param>
        /// <param name="proposedEnd"></param>
        /// <param name="actualStart"></param>
        /// <param name="actualEnd"></param>
        /// <param name="offer"></param>
        /// <param name="allocatedBudget"></param>
        /// <param name="miscCost"></param>
        /// <param name="description"></param>
        /// <param name="expectedRevenue"></param>
        /// <param name="statusDetails"></param>
        public void NewCase(IWebDriver driver, ExtentTest testInReport, string testName, string testDataIteration, string ctitle, string cname, string csname)
        {
            DateTime date = DateTime.Now;
            newCase = ctitle + date.ToString("ddMMyy HHmmss");
            //try
            //{
            // Navigate to Service - Campaign
            WaitUntil(driver, tabDropdownMainmenu, 15);
            Element(driver, tabDropdownMainmenu).Click();
            ThinkTime(2);
            Element(driver, services).Click();
            ThinkTime(3);
            AddLog(driver, testInReport, testName, testDataIteration, "Cases", "Case creation intiated", "Tab Drop Down for New Case through Service ");
            ThinkTime(1);
            Element(driver, cases).Click();
            WaitUntil(driver, dynamicNewCases, 30);
            Element(driver, dynamicNewCases).Click();
            WaitUntil(driver, Control("saveAndClose", "ServiceNew"), 30);
            ThinkTime(5);
            driver.SwitchTo().Frame("contentIFrame1");
            // AutomaticFrameSwitch(driver, Control("caseTitle", "ServiceNew"), 30);
            WaitUntil(driver, Control("caseTitle", "ServiceNew"), 30);

            // SwitchToFrame(driver, "contentIFrame1");
            //ThinkTime(2);

            // Enter the Details for the New Case
            //Select(Element(driver, Control("activeUser", "ServiceNew"))).SelectByText("Adventure Works");

            Element(driver, Control("caseTitleLabel", "ServiceNew")).Click();
            ThinkTime(1);

            Element(driver, Control("caseTitle", "ServiceNew")).SendKeys(newCase);
            //AddLog(driver, testInReport, testName, testDataIteration, "NewCases", "Case title intiated", "Case Title provided, Mandatory");
           // SetLookupField(driver, "customerLabel", "ServiceNew", cname);
            //Element(driver, Control("customerLabel", "ServiceNew")).Click();
            //Select(Element(driver, Control("customerId", "ServiceNew"))).SelectByText("Adventure Works");
            ThinkTime(1);
            AddLog(driver, testInReport, testName, testDataIteration, "NewCasesdone", "New Case Creation", "New Case Form Mandatory Fields filled");
            driver.SwitchTo().DefaultContent();
            Element(driver, Control("saveBtn", "ServiceNew")).Click();
            ThinkTime(10);
            driver.SwitchTo().Frame("contentIFrame1");
            if (Element(driver, verifyCreatedCase(newCase)).Displayed)
            {
                ThinkTime(1);
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Case successfully created", "Case successfully created");
            }
            else
            {
                ThinkTime(1);
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Case creation failed", "Case creation failed");
                Assert.IsTrue(false);
            }
            driver.SwitchTo().DefaultContent();
          //  Element(driver, Control("headerCases", "ServiceNew")).Click();
            //WaitUntil(driver, Control("dynamicNewCase", "ServiceNew"), 30);
        }
        public void AssignCase( IWebDriver driver,  ExtentTest testInReport,    string testName,    string testDataIteration, string csname ,string assignee,string ctitle)
        {
            //try
            //{
                // Navigate to Service - Campaign
                //WaitUntil(driver, tabDropdownMainmenu, 15);
                //Element(driver, tabDropdownMainmenu).Click();
                //ThinkTime(2);
                //Element(driver, services).Click();
                //ThinkTime(3);
                //AddLog(driver, testInReport, testName, testDataIteration, "Cases", "Case creation intiated", "Tab Drop Down for New Case through Service ");
                //ThinkTime(1);
                //Element(driver, cases).Click();
                //WaitUntil(driver, dynamicNewCases, 30);
                //Element(driver, dynamicNewCases).Click();
                //WaitUntil(driver, Control("saveAndClose", "ServiceNew"), 30);
                //ThinkTime(5);
                //driver.SwitchTo().Frame("contentIFrame0");
                // AutomaticFrameSwitch(driver, Control("caseTitle", "ServiceNew"), 30);
                //WaitUntil(driver, Control("caseTitle", "ServiceNew"), 30);

                // SwitchToFrame(driver, "contentIFrame1");
                //ThinkTime(2);

                // Enter the Details for the New Case
                //Select(Element(driver, Control("activeUser", "ServiceNew"))).SelectByText("Adventure Works");
            
             //   Element(driver, Control("caseSelect",newCase, "ServiceNew")).Click();
               // ThinkTime(1);
                //driver.SwitchTo().DefaultContent();
                Element(driver, Control("assign3", "ServiceNew")).Click();
                ThinkTime(5);
                driver.SwitchTo().Frame("InlineDialog_Iframe");
                ThinkTime(5);
                Element(driver, Control("assignToFld", "ServiceNew")).Click();
                Element(driver, Control("userLabel", "ServiceNew")).Click();
                ThinkTime(2);

                Element(driver, Control("userLookUp", "ServiceNew")).Click();
                Element(driver, Control("lookUpMore", "ServiceNew")).Click();
                ThinkTime(8);
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame("InlineDialog1_Iframe");

                Element(driver, Control("lookUpView", "ServiceNew")).Click();
                 ThinkTime(4);
            // Element(driver, Control("lookUpViewSelect", "ServiceNew")).Click();
               Select(Element(driver,Control("lookUpViewSelect", "ServiceNew"))).SelectByText("All Project Members");
            ThinkTime(4);
               Element(driver, Control("selectAssignee", assignee, "ServiceNew")).Click();
               Element(driver, Control("add", "ServiceNew")).Click();
            ThinkTime(2);

            //SetLookupField(driver, "customerLabel", "ServiceNew", cname);
            //Element(driver, Control("customerLabel", "ServiceNew")).Click();
            //Select(Element(driver, Control("customerId", "ServiceNew"))).SelectByText("Adventure Works");
            ThinkTime(1);
                AddLog(driver, testInReport, testName, testDataIteration, "CaseAssign", "New Case Assigning", "New Case is being assigned.");
            driver.SwitchTo().Frame("InlineDialog_Iframe");
            Element(driver, Control("assignBtn2", "ServiceNew")).Click();
            WaitForElementNotExists(driver,Control("crmDialogForm", "ServiceNew"));
            driver.SwitchTo().Frame("contentIFrame1");
            ThinkTime(2);
            if (Element(driver, Control("ownerVerify",assignee, "ServiceNew")).Displayed)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Case successfully Assigned to "+ assignee, "Case successfully assigned");
            
           }
            else
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Case assignment failed", "Case assignment failed");
            }
        
            driver.SwitchTo().DefaultContent();
            Element(driver, Control("headerCases", "ServiceNew")).Click();
            ThinkTime(2);
            driver.SwitchTo().Frame("contentIFrame0");
            Element(driver, Control("searchtitle", "ServiceNew")).Click();
            Element(driver, Control("searchtitle", "Login")).SendKeys(newCase);
            Element(driver, Control("caseSearchBtn", "ServiceNew")).Click();
          //  Element(driver, Control("sortCustomer", "ServiceNew")).Click();
          //  Element(driver, Control("sortCustomer", "ServiceNew")).Click();
            if (Element(driver, Control("caseVerify", newCase, "ServiceNew")).Displayed)
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Case successfully verified " + ctitle, "Case successfully verified");

            }
            else
            {
                AddLog(driver, testInReport, testName, testDataIteration, "Failed", "Case verification failed " + ctitle, "Case verification failed");
            }
            //Element(driver, Control("saveBtn", "ServiceNew")).Click();
            // ThinkTime(10);
            // driver.SwitchTo().Frame("contentIFrame1");
            //if (Element(driver, verifyCreatedCase(csname)).Displayed)
            //{
            // ThinkTime(1);
            // AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Case successfully created", "Case successfully created");
            //}
            //else
            //{
            //ThinkTime(1);
            //AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Case creation failed", "Case creation failed");
            //Assert.IsTrue(false);
            //}
            //driver.SwitchTo().DefaultContent();
            //Element(driver, campaignCode).Click();
            //Element(driver, campaignCodeInput).SendKeys(campaigncode);
            //ThinkTime(1);
            //Element(driver, campaignType).Click();
            //RunJavaScript(driver, "campaignTypeSelect", campaigntype, "Marketing");
            //Element(driver, campaignTypeLabel).Click();

            //ThinkTime(1);
            //Element(driver, proposedStart).Click();
            //ActionSendKeys(driver,  proposedStartInput, proposedstart);
            //ThinkTime(1);
            //Element(driver, proposedEnd).Click();
            //ActionSendKeys(driver,  proposedEndInput, proposedend);
            //ThinkTime(1);
            //Element(driver, actualStart).Click();
            //ActionSendKeys(driver,  actualStartInput, actualstart);
            //ThinkTime(1);
            //Element(driver, actualEnd).Click();
            //ActionSendKeys(driver,  actualEndInput, actualend);
            //ThinkTime(1);
            //Element(driver, expectedResponse).Click();
            //ActionSendKeys(driver,  expectedResponseInput, expectedresponse);
            //ThinkTime(1);
            //Element(driver, offer).Click();
            //ActionSendKeys(driver,  offerInput, offerData);
            //ThinkTime(1);
            //Element(driver, allocatedBudget).Click();
            //ActionSendKeys(driver,  allocatedBudgetInput, allocatedbudget);
            //ThinkTime(1);
            //Element(driver, miscBudget).Click();
            //ActionSendKeys(driver,  miscBudgetInput, miscCost);
            //ThinkTime(1);
            //Element(driver, description).Click();
            //ActionSendKeys(driver,  descriptionsInput, descriptionData);
            //ThinkTime(1);
            //Element(driver, expectedRevenue).Click();
            //ActionSendKeys(driver,  expectedRevenueInput, expectedrevenue);
            //ThinkTime(1);
            //Element(driver, statusDetails).Click();
            //((IJavaScriptExecutor)driver).ExecuteScript(statusDetailsSelect(statusdetails));
            //ThinkTime(1);
            //driver.SwitchTo().DefaultContent();
            //Element(driver, saveButton).Click();
            //ThinkTime(5);

            //           if (Element(driver, verifyCreatedCampaign(name)).Displayed)
            //           {
            //               ThinkTime(1);
            //               AddLog(driver, testInReport, testName, testDataIteration, "Pass", "Campaign successfully created", "Campaign successfully created");
            //           }
            //           else
            //           {
            //               ThinkTime(1);
            //               AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Campaign creation failed", "Campaign creation failed");
            //            Assert.IsTrue(false);
            //           }
            //}
            //catch (Exception e)
            //{
            //    AddLog(driver, testInReport, testName, testDataIteration, "Fail", "Unexpected error:\n "+e, "Unexpected error");
            //    throw;
            //}
        }
    }
}
