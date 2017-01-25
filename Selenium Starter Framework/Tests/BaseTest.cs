using Selenium_Starter_Framework.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Drawing.Imaging;
using System.Configuration;

namespace Selenium_Starter_Framework.Tests
{
    [SetUpFixture]
    public abstract class BaseTest
    {
        protected IWebDriver driver;

        protected ExtentReports extent;
        protected ExtentTest test;

        protected string tenantURL = ConfigurationManag‌​er.AppSettings["tenantURL"];
        protected string username = ConfigurationManag‌​er.AppSettings["username"];
        protected string password = ConfigurationManag‌​er.AppSettings["password"];
        protected string extentReportPath = ConfigurationManag‌​er.AppSettings["extentReportPath"];
        protected string extentScreenshotPath = ConfigurationManager.AppSettings["extentScreenshotPath"];

        public DocumentRecord documentRecord;
        public DocumentsRegister documentRegister;
        public DocumentWorkflow documentWorkflow;
        public NewDraftDocument newDraftDocument;
        public Homepage homePage;
        public LoginPage loginPage;

        [OneTimeSetUp]
        public void CreateExtentReport()
        {
            extent = new ExtentReports(extentReportPath, DisplayOrder.OldestFirst);
        }

        [SetUp]
        public void BeforeEachTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));

            documentRecord = new DocumentRecord(driver);
            documentRegister = new DocumentsRegister(driver);
            documentWorkflow = new DocumentWorkflow(driver);
            newDraftDocument = new NewDraftDocument(driver);
            homePage = new Homepage(driver);
            loginPage = new LoginPage(driver);

            driver.Navigate().GoToUrl(tenantURL);
            driver.Manage().Window.Maximize();

            loginPage.LoginToEnlighten(username, password);
        }

        [TearDown]
        public void AfterEachTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;
            var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? ""
                : string.Format("<pre>{0}</pre>", TestContext.CurrentContext.Result.Message);

            LogStatus logStatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logStatus = LogStatus.Fail;
                    ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(extentScreenshotPath + testName + ".png", ImageFormat.Png);
                    test.Log(LogStatus.Fail, test.AddScreenCapture(extentScreenshotPath + testName + ".png"));
                    break;
                default:
                    logStatus = LogStatus.Pass;
                    break;
            }
            test.Log(logStatus, "Test " + logStatus + stackTrace);
            extent.EndTest(test);
            driver.Quit();
        }

        [OneTimeTearDown]
        public void WriteToExtentReport()
        {
            extent.Flush();
        }

        public static void Main(string[] args) { }
    }
}