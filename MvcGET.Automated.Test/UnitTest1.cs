using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZeusAutomationSuite.Helper;
using ZeusAutomationSuite.ApplicationPages;
using System.IO;
using System.Reflection;
using Microsoft.TeamFoundation.TestManagement.Client;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using ZeusAutomationSuite.DataProviders;

namespace SampleUnitTest
{
    [TestClass]
    public class SampleUnitTest
    {

        ZeusAutomationSuite.Helper.TestCaseHelper TestCase = null;
        ApplicationFeatures feature = new ApplicationFeatures();
        RunAutomation.Helpers.PopulateCOnfigurations Config = new RunAutomation.Helpers.PopulateCOnfigurations();
        CommonUtilities Utilities = new CommonUtilities();
        SQLDataProvider SQLProvider = new SQLDataProvider();
        public SampleUnitTest()
        {
        }

        [TestInitialize]
        public void SetBrowserAsPerCOnfiguration()
        {
            if (Convert.ToString(TestContext.Properties["Module"]) == "TestData")
            {
                TestCase = new TestCaseHelper();
            }
            else
            {
                string ModuleName = Convert.ToString(TestContext.Properties["Module"]);
                TestCase = new TestCaseHelper(ModuleName);
            }

            try
            {
                TestContext.WriteLine(Environment.NewLine);
                TestContext.WriteLine("*************** Test Case Summary ***************");

                /*CHecking for MTM Configurations and Opening the browser accordingly*/
                if (TestContext.Properties["__Tfs_TestConfigurationName__"].ToString() != null)
                {

                    //BrowserWindow.CurrentBrowser = TestContext.Properties["__Tfs_TestConfigurationName__"].ToString();

                }

                if (TestContext.Properties["__Tfs_TestRunId__"].ToString() != null)
                {
                    int? testRunID = TestContext.Properties["__Tfs_TestRunId__"] as int?;
                    TestContext.WriteLine("Test Run ID: " + testRunID);
                    TestContext.WriteLine("Environment to Run the Test Cases: " + TFSHelper.GetTestRunTitle(testRunID));

                    //Setting the Environment to Run the test cases
                    ConfigHelper.Environment = TFSHelper.GetTestRunTitle(testRunID);
                    ConfigHelper.TestRunID = testRunID;

                    //Getting the Testing Tool from Configuration file
                    ConfigHelper.TestingTool = ConfigHelper.GetTestingTool();

                    /*Assign Role to Test User Accounts*/
                    //common.CreateUsers(testContextInstance);
                }
            }
            catch (Exception)
            {
                /*This code block will get executed while debugging/runing test locally or in case
                 Connection to TFS fails due any unknown reason*/
                ConfigHelper.TestingTool = "selenium";

                //common.CreateUsers(testContextInstance);
                Console.Error.WriteLine("We are here... in Catch box" + TestContext.TestName.ToString());
                ConfigHelper.TestRunID = -1;
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            //Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;
        }


        [TestCategory("Sanity")]
        [TestProperty("Module", "Enrollment")]
        [TestProperty("Role", "OfficeManager")]
        [TestProperty("BacklogItem", "VerifyUWPCalculatorAddFunctionality")]
        [TestProperty("TFSID", "63372")]
        [Priority(1)]
        [TestMethod]
        public void VerifyUWPCalculatorAddFunctionality()
        {
            string LoginPage = "";
            ConfigHelper.Browser = "uwp";
            ConfigHelper.IsWebTest = "true";
            Assert.IsTrue(TestCase.ExecuteTestCase("VerifyUwpCalculatorAddFeature.xlsx", ConfigHelper.TestingTool, LoginPage, testContextInstance));

        }

        [TestCategory("Sanity")]
        [TestProperty("Module", "Enrollment")]
        [TestProperty("Role", "District Admin")]
        [TestProperty("BacklogItem", "WebTestforMobileAndPC")]
        [TestProperty("TFSID", "26209")]
        [Priority(1)]
        [TestMethod]
        public void WebTestforDesktopHeadless()
        {
            string LoginPage = "";
            ConfigHelper.Browser = "headless";
            ConfigHelper.IsWebTest = "true";
            Assert.IsTrue(TestCase.ExecuteTestCase("WebTestforMobileAndPC.xlsx", ConfigHelper.TestingTool, LoginPage, testContextInstance));
        }

        [TestCategory("Sanity")]
        [TestProperty("Module", "Enrollment")]
        [TestProperty("Role", "District Admin")]
        [TestProperty("BacklogItem", "WebTestforMobileAndPC")]
        [TestProperty("TFSID", "26209")]
        [Priority(1)]
        [TestMethod]
        public void WebTestforDesktop()
        {
            string LoginPage = "";
            ConfigHelper.Browser = "chrome";
            ConfigHelper.IsWebTest = "true";
            Assert.IsTrue(TestCase.ExecuteTestCase("WebTestforMobileAndPC.xlsx", ConfigHelper.TestingTool, LoginPage, testContextInstance));
        }
        [TestCategory("Sanity")]
        [TestProperty("Module", "Enrollment")]
        [TestProperty("Role", "District Admin")]
        [TestProperty("BacklogItem", "WebTestforMobileAndPC")]
        [TestProperty("TFSID", "26209")]
        [Priority(1)]
        [TestMethod]
        public void WebTestforMobile()
        {
            string LoginPage = "";
            ConfigHelper.Browser = "android";
            ConfigHelper.IsWebTest = "true";
            Assert.IsTrue(TestCase.ExecuteTestCase("WebTestforMobileAndPC.xlsx", ConfigHelper.TestingTool, LoginPage, testContextInstance));
        }

        [TestCategory("Sanity")]
        [TestProperty("Module", "Enrollment")]
        [TestProperty("Role", "District Admin")]
        [TestProperty("BacklogItem", "VerifyAndroidNativeCalApp")]
        [TestProperty("TFSID", "26209")]
        [Priority(1)]
        [TestMethod]
        public void AndroidNativeAppTestForCalculator()
        {
            string LoginPage = "";
            ConfigHelper.Browser = "android";
            ConfigHelper.IsWebTest = "false";
            Assert.IsTrue(TestCase.ExecuteTestCase("VerifyAndroidNativeCalApp.xlsx", ConfigHelper.TestingTool, LoginPage, testContextInstance));
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

    }
}
