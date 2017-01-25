using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Selenium_Starter_Framework.Pages
{
    public class NewDraftDocument
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@data-ls-allow-clear='False']/a[@class='dropSelector']")]
        public IWebElement documentTypeDropdown;

        [FindsBy(How = How.XPath, Using = "//li[@data-list-type='DocumentType']")]
        public IWebElement documentTypeRoot;

        [FindsBy(How = How.Id, Using = "Title")]
        public IWebElement documentTitleTextbox;

        [FindsBy(How = How.Id, Using = "DocumentNumber")]
        public IWebElement documentNumberTextbox;

        [FindsBy(How = How.XPath, Using = "//div[@id='formButtons']//button[@type='submit']")]
        public IWebElement documentCreateButton;

        public NewDraftDocument(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        public void CreateDraftDocument(string documentTitle)
        {
            documentTypeDropdown.Click();
            documentTypeRoot.Click();
            documentTitleTextbox.SendKeys(documentTitle);
            documentCreateButton.Click();
        }
    }
}