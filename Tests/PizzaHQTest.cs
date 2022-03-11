using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PizzaHQTest
{
    [TestClass]
    public class PizzaHQTest
    {
        ChromeDriver driver;
        WebDriverWait wait;

        [TestMethod]
        public void LoginFieldErrorMessageValidation()
        {
            //Arrange
            ToolBar toolBar = new ToolBar(driver, wait);
            LoginPage loginPage = new LoginPage(driver, wait);

            //Act
            toolBar.NavigateToLoginSection();
            loginPage.ClickLoginButton();

            //Assert
            // SUGGESTION: wrap so it doesn't go longer than 110 characters. Also aligning expected and
            // actual reads well. If we're going to wrap some arguments, we should wrap them all.
            Assert.AreEqual(expected: "Your login was unsuccessful - please try again",
                            actual: loginPage.GetAlertContent(),
                            "Alert content did not match");
            loginPage.CloseAlert();

            // SUGGESTION: I would break these assertions into 2 tests. Generally I base this on whether
            // we have to do more actions. In this case, you have to close the alert. It tightly binds these
            // two things together. Would be better as 2 separate tests that aren't related.
            Assert.AreEqual(expected: false,
                            actual: loginPage.IsAlertContentDisplayed(),
                            "Alert message is not closed and still being displayed");
        }

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://d2ju5vf8ca0qio.cloudfront.net/#/");
        }
        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
