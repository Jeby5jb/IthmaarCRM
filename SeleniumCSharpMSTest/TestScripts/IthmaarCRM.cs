using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SeleniumCSharpMSTest.Functions;
using System;
using System.IO;
using System.Reflection;
using TesthouseSeleniumCSharp.Functions;

namespace SeleniumCSharpMSTest.TestScripts
{
    [TestClass]
    public class IthmaarCRM : BaseClass
    {

        /// /// <summary>
        /// Method to set report path
        /// </summary>

        [AssemblyInitialize]
        public static void StartReport(TestContext test)
        {
            AssemblyInitialize();
        }

        /// <summary>
        /// Method to start the driver and report
        /// </summary>
        
        [TestInitialize]
        public void Initialize()
        {
            TestInitialize();
        }

        /// /// <summary>
        /// Method to Different TestScript of Different Modules
        /// </summary>


        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "CustomerCreation$", DataAccessMethod.Sequential), TestMethod]
        public void NewCustomer360Creation()
        {
            DynamicFunctions login = new DynamicFunctions();
            CorporateCustomer cases = new CorporateCustomer();
            GenericFunctions generic = new GenericFunctions();

            //Attach timestamp with firstname of customer
            string timestamp = System.DateTime.Now.ToString("ddMMyyhhmmss");
            string frstname1 = TestContext.DataRow["First Name"].ToString() + timestamp;
           
            //Launch and Login to the Application
            login.Login(driver, extentTest,  testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigete to Customer 360
            generic.NavigateToPerson360(driver, extentTest, testName, testDataIteration);

            //Create a new Customer 360
            generic.NewCustomer360(driver, extentTest, testName, testDataIteration, TestContext.DataRow["TitleName"].ToString(), TestContext.DataRow["Nationality"].ToString(), TestContext.DataRow["DOB"].ToString(), 
                TestContext.DataRow["Mobile Number"].ToString(), frstname1, TestContext.DataRow["Maritial Status"].ToString(), TestContext.DataRow["Last Name"].ToString(), TestContext.DataRow["ID"].ToString(),
                TestContext.DataRow["Residence Mobile Number"].ToString());        

        }



        /// <summary>
        ///  Single Customer View -Retail_001 , Single Customer View -Retail_085 - 094, Single Customer View -Retail_096 -0111 ,Single Customer View -Retail_113 - 116, Single Customer View -Retail_118 - 131 , Single Customer View -Retail_136 - 139 ,Single Customer View -Retail_141 -142 , Single Customer View -Retail_145 - 148 , Single Customer View -Retail_153 , Single Customer View -Retail_158 
        ///  Single Customer View -Retail_160-168 , Single Customer View -Retail_181, 183 - 198 , Single Customer View -Retail_203 - 204,Single Customer View -Retail_206 -210,Single Customer View -Retail_212, Single Customer View -Retail_214 - 220, Single Customer View -Retail_242 - 247, Single Customer View -Retail_263
        /// </summary>

        [Priority(1),TestCategory("Retail Customer")]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "CustomerMandatoryFieldVerify$", DataAccessMethod.Sequential), TestMethod]
        public void Auto_RetailCustomer360FieldValidation()
        {
            DynamicFunctions login = new DynamicFunctions();
            CorporateCustomer cases = new CorporateCustomer();
            GenericFunctions generic = new GenericFunctions();
            Customer360Functions cust = new Customer360Functions();


            //Attach timestamp with firstname of customer
            string timestamp = System.DateTime.Now.ToString("ddMMyyhhmmss");
            string frstname1 = TestContext.DataRow["First Name"].ToString() + timestamp;

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigete to Customer 360
            generic.NavigateToPerson360(driver, extentTest, testName, testDataIteration);

            //Mandatory Field Verify
            cust.FieldVerification(driver, extentTest, testName, testDataIteration,TestContext.DataRow["CustomerName"].ToString(), TestContext.DataRow["DebitCardNo"].ToString(), 
            TestContext.DataRow["AccountNumber"].ToString(), TestContext.DataRow["CreditCard"].ToString(), TestContext.DataRow["Opportunity"].ToString(), TestContext.DataRow["UnresolvedCase"].ToString(),
            TestContext.DataRow["CollectionTicket"].ToString(), TestContext.DataRow["EnrolledService"].ToString(), TestContext.DataRow["CustomerName"].ToString());           
        }


        [Priority(11)]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "RejectionReasons$", DataAccessMethod.Sequential), TestMethod]
        public void RejectionReason()
        {
            DynamicFunctions login = new DynamicFunctions();
            CorporateCustomer cases = new CorporateCustomer();
            GenericFunctions generic = new GenericFunctions();
            Customer360Functions cust = new Customer360Functions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Configurations
            generic.NavigateToConfigurations(driver, extentTest, testName, testDataIteration);
        }

       
        
        /// <summary>
        /// Ithmaar_CRM_Corp_SingleCustomerView_058 - 065
        /// </summary>
        /// <summary>
        /// Ithmaar_CRM_Corp_SingleCustomerView_058 - 065
        /// </summary>

        [Priority(5)]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "CorporateCustomer$", DataAccessMethod.Sequential), TestMethod]
        public void CorporateCustomerAccountView()
        {
            DynamicFunctions login = new DynamicFunctions();           
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Corporate Companies
            corp.NavigateToCompanies(driver, extentTest, testName, testDataIteration);

            corp.SelectCompany(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Company"].ToString(), TestContext.DataRow["AccountNumber"].ToString(),
                TestContext.DataRow["DebitCardNo"].ToString(), TestContext.DataRow["TermDepositNo"].ToString());
        }


        //Ithmaar_CRM_Collections_1 to 3
        [Priority(6)]

        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collections$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionsFlow()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.SelectAllCollectionTicketAndRequiredTicket(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record Name"].ToString());

        }

        [Priority(3)]
        //Ithmaar_CRM_Collections_5 , Ithmaar_CRM_Collections_16 , Ithmaar_CRM_Collections_18 to 20 , Ithmaar_CRM_Collections_29
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "CollectionsRetail$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionsFlowForRetail()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.VerifyForRetail(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());

            generic.DebitCreditTermDepositVerify(driver, extentTest, testName, testDataIteration, TestContext.DataRow["AccountNo"].ToString());

            generic.MoveToServices(driver, extentTest, testName, testDataIteration);

            collections.ServiceCollectionItemVerify(driver, extentTest, testName, testDataIteration);

            generic.NavigateToSalesAndMarketing(driver, extentTest, testName, testDataIteration);
        }

        [Priority(2)]
        //Ithmaar_CRM_Collections_4 , Ithmaar_CRM_Collections_21 , Ithmaar_CRM_Collections_30 , Ithmaar_CRM_Collections_038 ,Ithmaar_CRM_Collections_050
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "CollectionsCorporate$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionsFlowForCorporate()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.VerifyForCorporate(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString(),
                TestContext.DataRow["Company Name"].ToString());

            generic.DebitCreditTermDepositVerify(driver, extentTest, testName, testDataIteration, TestContext.DataRow["AccountNo"].ToString());

            corp.MoveToSijilat(driver, extentTest, testName, testDataIteration);
        }

        [Priority(4)]
        //Ithmaar_CRM_Collections_033 , Ithmaar_CRM_Collections_036
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "ColectionsAPRCalculate_Corp$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionsAPRCalculator_Corporate()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.SelectCollectionRecord(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());

            collections.APRCalculator(driver, extentTest, testName, testDataIteration);
        }

        //Ithmaar_CRM_Collections_032 ,  Ithmaar_CRM_Collections_035
        [Priority(7)]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "ColectionsAPRCalculate_Retail$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionsAPRCalculator_Retail()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.SelectCollectionRecord(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());

            collections.APRCalculator(driver, extentTest, testName, testDataIteration);
        }


        //Ithmaar_CRM_Collections_039
        [Priority(8)]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_ProductVerify$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionsRetailProductDetails()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            //Verify Product for Customer
            collections.VerifyProductRetail(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }

        //Ithmaar_CRM_Collections_040
        [Priority(9)]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerify_Retail$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Retail()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.SortAndSelectCollectionByStatus(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }

        //Ithmaar_CRM_Collections_041
        [Priority(10)]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerify_Corp$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Corporate()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.SortAndSelectCollectionByStatus_Corp(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }

        //Ithmaar_CRM_Collections_043 , 
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerify_ret$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Retail_PartiallyCollect()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.CurrentDeliquncy_Retail(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }


        //Ithmaar_CRM_Collections_044
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerify_CorpPar$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Corporate_PartiallyCollect()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.CurrentDeliquncy_Retail(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }


        //Ithmaar_CRM_Collections_046
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerify_RetFuly$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Retail_FullyCollect()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.CurrentDeliquncy_Retail(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }

        //Ithmaar_CRM_Collections_047
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerify_CorFuly$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Corporate_FullyCollect()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.CurrentDeliquncy_Retail(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }

        //Ithmaar_CRM_Collections_052
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerifyPTP$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Retail_PTP()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.EmailVerification(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }

        //Ithmaar_CRM_Collections_053
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerifyBPTP$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Retail_BPTP1()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.BP2P1(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }

        //Ithmaar_CRM_Collections_054
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerifyPTP2$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Retail_PTP2()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.StageSelect(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString(), TestContext.DataRow["Stage"].ToString());
        }

        //Ithmaar_CRM_Collections_055 
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerifyBPTP2$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Retail_BPTP2()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.StageSelect(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString(), TestContext.DataRow["Stage"].ToString());
        }


        //Ithmaar_CRM_Collections_056 , Ithmaar_CRM_Collections_057 
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_StatusVerifyPTP3$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_Retail_PTP3()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.StageSelect(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString(), TestContext.DataRow["Stage"].ToString());
        }


        //Ithmaar_CRM_Collections_097 - 099 
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_NPR$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_NonPaymentReason()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.CustomerNonPaymentReason(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString(), TestContext.DataRow["Reason"].ToString());
        }


        //Ithmaar_CRM_Collections_100 
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_RelatedActivities$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_RelatedActivites()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.CustomerRelatedActivities(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }


        //Ithmaar_CRM_Collections_101
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_FinancialCollection$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_FinancialDetails()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.FinancialDetails(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());
        }


        //Ithmaar_CRM_Collections_102
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_Expense$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicketStatus_ExpenseDetails()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.ExpenseDetails(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString(), TestContext.DataRow["ExpName"].ToString(), TestContext.DataRow["Amount"].ToString());
        }


        //Ithmaar_CRM_Collections_0106 
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_PaymentPromise$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicket_CollectionPaymentPromise()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.NewPaymentCollection(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString(), TestContext.DataRow["Amount"].ToString());
        }



        //Ithmaar_CRM_Collections_0111 
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_AddNotes$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicket_AddNotes()
        {
            DynamicFunctions login = new DynamicFunctions();
            GenericFunctions generic = new GenericFunctions();
            CorporateCustomer corp = new CorporateCustomer();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.SearchRecord(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());

            collections.AddNotes(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Title"].ToString(), TestContext.DataRow["Notes"].ToString());
        }


        //Ithmaar_CRM_Collections_0112
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xlsx)};dbq=|DataDirectory|\\DataManager\\TestData.xlsx;defaultdir=.;driverid=1046;maxbuffersize=2048;pagetimeout=5", "Collection_LatePayment$", DataAccessMethod.Sequential), TestMethod]
        public void CollectionTicket_FinancialLatePayment()
        {
            DynamicFunctions login = new DynamicFunctions();
            CollectionFunctions collections = new CollectionFunctions();

            //Launch and Login to the Application
            login.Login(driver, extentTest, testName, testDataIteration, uRL, TestContext.DataRow["UserName"].ToString(), TestContext.DataRow["Password"].ToString());

            //Navigate to Collection Tickets
            collections.NavigateToCollection(driver, extentTest, testName, testDataIteration);

            collections.SearchRecord(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Record"].ToString());

            collections.LatePayment(driver, extentTest, testName, testDataIteration, TestContext.DataRow["Amount"].ToString());
        }



        /// <summary>
        /// Method to close the browsers and Write to Report
        /// </summary>
        [TestCleanup]
        public void GetResult()
        {
         TestCleanUp();
            extentReport.EndTest(extentTest);
        }
        /// <summary>
        /// Method to close the report
        /// </summary>
        [AssemblyCleanup]
        public static void EndReport()
        {
           AssemblyCleanup();
        }
    }
}