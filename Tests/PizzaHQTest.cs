using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
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
            Assert.AreEqual(expected: "Your login was unsuccessful - please try again", actual: loginPage.GetAlertContent(), "Alert content did not match");
            loginPage.CloseAlert();
            Assert.AreEqual(expected: false, actual: loginPage.IsAlertContentDisplayed(), "Alert message is not closed and still being displayed");
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
