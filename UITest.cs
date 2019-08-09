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

        [SetUp]
        public void SetUpTest ()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.onliner.by/");
            _driver.Manage().Window.Maximize();
            mainPage = new MainPage(_driver);
            loginPage = new LoginPage(_driver);
        }

        [Test]
        public void OpenSiteAndCheckTitle()
        {
            mainPage.VerifyTitleIs("Onliner");
        }

        [Test]
        public void LoginAsUser()
        {
            loginPage.LoginAsUser();
        }



        [TearDown]
        public void TearDownTest()
        {
            _driver.Quit();
        }
    }
}
