using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace OnlinerTest.PageObjects
{
    class MainPage
    {
        private readonly IWebDriver _driver;
        
        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        
        public String GetPageTitle()
        {
            return _driver.Title;
        }

        public void VerifyTitleIs(String titleExpected)
        {
            String titleActual = GetPageTitle();
            Assert.AreEqual(titleExpected, titleActual);
        }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='userbar']//div[@class='auth-bar__item auth-bar__item--text']")]
        public IWebElement SignInLink;

        [FindsBy(How = How.XPath, Using = "//*[@id='fast-search']//input[@class='fast-search__input']")]
        public IWebElement SearchField;

        [FindsBy(How = How.XPath, Using = "//*[@class='modal-iframe']")]
        public IWebElement Frame;

        [FindsBy(How = How.XPath, Using = "(//*[@class='product__details'])[1]")]
        public IWebElement SelectBookFromList;

        [FindsBy(How = How.XPath, Using = "//a[@class='button button_orange button_big offers-description__button']")]
        public IWebElement SelectOffer;

        [FindsBy(How = How.XPath, Using = "(//*[@id='product-prices-primary-positions']//*[@class='b-cell-3']//a)[1]")]
        public IWebElement PutInCart;
                



        public void GoToLoginPage()
        {
            SignInLink.Click();
        }

        public void SelectBook()
        {
            SearchField.SendKeys("MacBook Air 13\" 2018");
            _driver.SwitchTo().Frame(Frame);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(SelectBookFromList));
            SelectBookFromList.Click();
            _driver.SwitchTo().DefaultContent();
            wait.Until(ExpectedConditions.ElementToBeClickable(SelectOffer));
            SelectOffer.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(PutInCart));
            PutInCart.Click();       
        }


        
    }
}
