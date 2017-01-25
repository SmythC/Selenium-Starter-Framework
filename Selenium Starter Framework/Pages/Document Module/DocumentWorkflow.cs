using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Selenium_Starter_Framework.Pages
{
    public class DocumentWorkflow
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Start')]")]
        public IWebElement startWorkflowButton;

        [FindsBy(How = How.XPath, Using = "//div[@id='workflow' and @class='InProgress']")]
        public IWebElement inProgressWorkflowStatus;

        [FindsBy(How = How.XPath, Using = "//tbody[contains(@id, 'approversTableBody')]//a[@class='dropdown-toggle']")]
        public IWebElement approveDropdownToggle;

        [FindsBy(How = How.XPath, Using = "//ul[@id='dropdown-menu-list']//i[@class='icon-thumbs-up']")]
        public IWebElement approveFromDropdown;

        public DocumentWorkflow(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }
    }
}
