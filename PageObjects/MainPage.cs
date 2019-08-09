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
        private IWebDriver _driver;

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

        [FindsBy(How = How.XPath, Using = "//*[@class='modal-iframe']")]
        public IWebElement SelectBook;


        //*[@id="fast-search"]/form/input[1]
        public void BuyMacBook()
        {
            SearchField.SendKeys("MacBook Air 13\" 2018");
            _driver.SwitchTo().Frame(Frame);

        }



        By.XPath("(//*[@class='product__details'])[1]")
        driver.FindElement(By.XPath("//div[@class = 'result__item result__item_product']")).Click();



        driver.SwitchTo().DefaultContent();




    }
}
