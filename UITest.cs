using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OnlinerTest.PageObjects;

namespace OnlinerTest
{
    [TestFixture]
    public class UITest
    {
        private IWebDriver _driver;
        private MainPage mainPage;
        private LoginPage loginPage;
        private CartPage cartPage;
        

        [SetUp]
        public void SetUpTest ()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.onliner.by/");
            _driver.Manage().Window.Maximize();
            mainPage = new MainPage(_driver);
            loginPage = new LoginPage(_driver);
            cartPage = new CartPage(_driver);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void OpenSiteAndCheckTitle()
        {
            mainPage.VerifyTitleIs("Onliner");
        }

        [Test]
        public void LoginAsUser()
        {
            mainPage.GoToLoginPage();
            loginPage.LoginAsUser();
        }

        [Test]
        public void BuyMackBook()
        {
            mainPage.GoToLoginPage();
            loginPage.LoginAsUser();
            mainPage.SelectBook();            
            cartPage.OrderRegistration();
        }



        [TearDown]
        public void TearDownTest()
        {
            _driver.Quit();
        }
    }
}
