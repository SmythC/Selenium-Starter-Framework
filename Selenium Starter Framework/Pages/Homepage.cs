using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Selenium_Starter_Framework.Pages
{
    public class Homepage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "homeVideo")]
        public IWebElement homePageVideo;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }
    }
}