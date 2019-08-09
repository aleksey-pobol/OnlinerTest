using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace OnlinerTest.PageObjects
{
    class LoginPage
    {
        private IWebDriver _driver;
        private MainPage mainPage;       
        

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.XPath, Using = "(//*[@class='auth-form__field']//input)[1]")]
        public IWebElement UserField;

        [FindsBy(How = How.XPath, Using = "(//*[@class='auth-form__field']//input)[2]")]
        public IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//*[@id='auth-container']//button[@type='submit']")]
        public IWebElement LoginButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='cart-desktop']")]
        public IWebElement Cart;

        public void LoginAsUser()
        {
            mainPage = new MainPage(_driver);
            mainPage.SignInLink.Click();
            UserField.SendKeys("aleksey---pobol@mail.ru");
            PasswordField.SendKeys("aleksey96");
            LoginButton.Click();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(Cart));
            Assert.IsTrue(Cart.Displayed);

        }



    }
}
