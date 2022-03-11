using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PizzaHQTest
{
    internal class LoginPage
    {
        private readonly ChromeDriver driver;
        private readonly WebDriverWait wait;
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
            // Oh? Did normal Selenium clicking not work? This is good if there was something blocking you
            // I am just surprised normal clicks didn't work.
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", LoginButton);
        }

        // SUGGESTION: A bit of formatting here.
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