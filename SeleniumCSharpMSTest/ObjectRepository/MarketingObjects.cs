using OpenQA.Selenium;
using SeleniumCSharpMSTest.Functions;
using TesthouseSeleniumCSharp.Functions;

namespace SeleniumCSharpMSTest.ObjectRepository
{
    /// <summary>
    /// Object repository for Marketing functions
    /// </summary>
    public class MarketingObjects : GenericFunctions
    {
        // Navigate to Marketing Campaigns
        public static By tabDropdownMainmenu = By.XPath("//div[@id='navTabGroupDiv']//span[@class='navBarTopLevelItem']//span[@class='navTabButtonArrowDown']");
        public static By services = By.XPath("//div[@id='actionGroupControl']//a[@id='CS']/span[@class='navActionButtonLabel']");
        public static By cases = By.Id("nav_cases");
        

        // Create New Marketing Campaign
        public static By dynamicNewCases = By.XPath("//li[@id='incident|NoRelationship|HomePageGrid|Mscrm.HomepageGrid.incident.NewRecord']//a[@class='ms-crm-Menu-Label']");

        //public static By campaignName = By.Id("name_d");
        //public static By campaignNameInput = By.Id("name_i");

        //public static By campaignCode = By.Id("codename_d");
        //public static By campaignCodeInput = By.Id("codename_i");

        //public static By campaignType = By.Id("typecode_d");
        //public static By campaignTypeDropDown = By.Id("typecode_i");
        //public static By campaignTypeLabel = By.Id("typecode_c");
        //public static string campaignTypeSelect(    string option   )
        //{
        //    return "document.querySelector(\"#typecode_i>option[title='" + option + "']\").selected=true;";
        //}

        //public static By expectedResponse = By.Id("expectedresponse_d");
        //public static By expectedResponseInput = By.Id("expectedresponse_i");

        //public static By proposedStart = By.Id("proposedstart_d");
        //public static By proposedStartInput = By.Id("proposedstart_i");
        //public static By proposedEnd = By.Id("proposedend_d");
        //public static By proposedEndInput = By.Id("proposedend_i");
        //public static By actualStart = By.Id("actualstart_d");
        //public static By actualStartInput = By.Id("actualstart_i");
        //public static By actualEnd = By.Id("actualend_d");
        //public static By actualEndInput = By.Id("actualend_i");
        //public static By offer = By.Id("objective_d");
        //public static By offerInput = By.Id("objective_i");
        //public static By allocatedBudget = By.Id("budgetedcost_d");
        //public static By allocatedBudgetInput = By.Id("budgetedcost_i");
        //public static By miscBudget = By.Id("othercost_d");
        //public static By miscBudgetInput = By.Id("othercost_i");
        //public static By description = By.Id("description_d");
        //public static By descriptionsInput = By.Id("description_i");

        //public static By expectedRevenue = By.Id("header_expectedrevenue_d");
        //public static By expectedRevenueInput = By.Id("header_expectedrevenue_i");

        //public static By statusDetails = By.Id("header_statuscode_d");
        //public static By statusDetailsSelectDropDown = By.Id("header_statuscode_i");

        //public static string statusDetailsSelect(   string option   )
        //{
        //    return "document.querySelector(\"#header_statuscode_i>option[title='" + option + "']\").selected=true;";
        //}

        //public static By saveButton = By.Id("campaign|NoRelationship|Form|Mscrm.Form.campaign.Save");
         
        public static By verifyCreatedCase( string caseName )
        {
            return By.XPath("//div[@id='FormTitle']/h1[text()='" + caseName + "']" );
        }
    }
}
