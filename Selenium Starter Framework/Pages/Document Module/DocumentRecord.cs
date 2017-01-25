using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Selenium_Starter_Framework.Pages
{
    public class DocumentRecord
    {
        private IWebDriver driver;

        public static string documentURL;

        [FindsBy(How = How.Id, Using = "recordLayout")]
        public IWebElement documentRecordLayout;

        public DocumentRecord(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        public string DocumentURL
        {
            get { return documentURL; }
            set { documentURL = value; }
        }
    }
}