using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace OnlinerTest.PageObjects
{
    class CartPage
    {
        private readonly IWebDriver _driver;
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        /*[FindsBy(How = How.XPath, Using = "//*[@id='cart-desktop']")]
        public IWebElement CartElement;*/
        
        [FindsBy(How = How.XPath, Using = "//*[@class='cart-navigation']//a")]
        public IWebElement OderButton;

        [FindsBy(How = How.XPath, Using = "//h1[text()[contains(.,'Оформление заказа')]]")]
        public IWebElement CheckHeadline;        

        public void OrderRegistration()
        {
            /*WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(OderButton));*/
            OderButton.Click();
            Assert.IsTrue(CheckHeadline.Text.Equals("Оформление заказа"));
        }
    }
}
