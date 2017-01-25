using NUnit.Framework;

namespace Selenium_Starter_Framework.Tests
{
    [TestFixture]
    public class DocumentPFT : BaseTest
    {
        [Test]
        public void CreateDraftDocument()
        {
            test = extent.StartTest("Create Draft Document");
            driver.Navigate().GoToUrl(tenantURL + "/Documents/DocumentManagement#!/register");
            documentRegister.NewDraftDocument();
            newDraftDocument.CreateDraftDocument("WebDriver");
            Assert.True(documentRecord.documentRecordLayout.Displayed, "");

            // Saving the URL of the document created for convenience.
            documentRecord.DocumentURL = driver.Url;

            //Assert.Multiple(() => { });
        }

        [Test]
        public void StartDocumentWorkflow()
        {
            test = extent.StartTest("Start Document Workflow");
            driver.Navigate().GoToUrl(documentRecord.DocumentURL);
            documentWorkflow.startWorkflowButton.Click();
            Assert.True(documentWorkflow.inProgressWorkflowStatus.Displayed, "The workflow does not have an inprogress status.");

            //Assert.Multiple(() => { });
        }
    }
}