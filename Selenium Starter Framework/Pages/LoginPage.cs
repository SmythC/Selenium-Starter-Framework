using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Selenium_Starter_Framework.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement txtUsername;

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//*[@class='g-btn g-btn--primary']")]
        private IWebElement btnLogin;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        public void LoginToEnlighten(string username, string password)
        {
            txtUsername.SendKeys(username);
            txtPassword.SendKeys(password);
            btnLogin.Click();
        }
    }
}