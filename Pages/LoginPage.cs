using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PizzaHQTest
{
    internal class LoginPage
    {
        private ChromeDriver driver;
        private WebDriverWait wait;
        public LoginPage(ChromeDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public IWebElement LoginButton => driver.FindElement(By.CssSelector("button[aria-label =\"login\"]"));
        public IWebElement LoginActionCard => driver.FindElement(By.CssSelector(".v-card__actions"));
        public IWebElement AlertContent => driver.FindElement(By.ClassName("v-alert__content"));
        public IWebElement AlertDismissButton => driver.FindElement(By.ClassName("v-alert__dismissible"));

        internal void ClickLoginButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", LoginButton);
        }

        internal bool IsAlertContentDisplayed()
        {
            return AlertContent.Displayed;
        }internal string GetAlertContent()
        {
            return AlertContent.Text;
        }

        internal void CloseAlert()
        {
            AlertDismissButton.Click();
        }

    }
}