using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Selenium_Starter_Framework.Pages
{
    public class DocumentsRegister
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//button[@tourid='tourAddDocument']")]
        public IWebElement newDocumentButton;

        [FindsBy(How = How.Id, Using = "cloned-draftDocumentLink")]
        public IWebElement selectDraftDocument;

        [FindsBy(How = How.Id, Using = "cloned-activeDocumentLink")]
        public IWebElement selectActiveDocument;

        public DocumentsRegister(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        public void NewDraftDocument()
        {
            newDocumentButton.Click();
            selectDraftDocument.Click();
        }

        public void NewActiveDocument()
        {
            newDocumentButton.Click();
            selectActiveDocument.Click();
        }
    }
}