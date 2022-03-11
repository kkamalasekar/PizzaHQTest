using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PizzaHQTest
{
    internal class ToolBar
    {
        // The IDE suggested the readonly modifiers to me. You don't always have to do what it suggests,
        // but where it makes sense you might as well. Here it makes sense.
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public ToolBar(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        public IWebElement LoginNavigationButton => driver.FindElement(By.ClassName("nav-login-signup"));
        public IWebElement LoginDialog => driver.FindElement(By.Id("loginDialog"));

        internal void NavigateToLoginSection()
        {
            // SUGGESTION: I don't have a huge issue with this line, but typically we would wait *after*
            // something, not before. We should know the LoginNavigationButton is already displayed
            // (perhaps because we have already waited for it when opening the homepage, for example.)
            // This is not a hard and fast rule, but a more reliable approach, generally.
            wait.Until(d => LoginNavigationButton.Displayed);
            LoginNavigationButton.Click();
            wait.Until(d => LoginDialog.Displayed);
        }
    }
}