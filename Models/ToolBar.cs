using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PizzaHQTest
{
    internal class ToolBar
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public ToolBar(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public IWebElement LoginNavigationButton => driver.FindElement(By.ClassName("nav-login-signup"));
        public IWebElement LoginDialog => driver.FindElement(By.Id("loginDialog"));

        internal void NavigateToLoginSection()
        {
            wait.Until(d => LoginNavigationButton.Displayed);
            LoginNavigationButton.Click();
            wait.Until(d => LoginDialog.Displayed);
        }
    }
}