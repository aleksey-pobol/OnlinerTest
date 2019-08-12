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
using OpenQA.Selenium.Interactions;

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
            SelectBookFromList.Click();
            _driver.SwitchTo().DefaultContent();
            SelectOffer.Click();
            PutInCart.Click();
        }

        [FindsBy(How = How.XPath, Using = "//h2//a[contains(text(),'Недвижимость')]")]
        public IWebElement realty;

        public void ScrollPageToRealty()
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(realty).Perform();

        }

        [FindsBy(How = How.XPath, Using = "//*[@class='g-middle-i']/*[contains(@class, 'b-main-page-news-2')][5]//ul[contains(@class, 'b-teasers-2')]/li[1]")]
        public IWebElement FirstNews;

        [FindsBy(How = How.XPath, Using = "//*[@id='comments-list']//div[@class='news-form']")]
        public IWebElement comments;

        [FindsBy(How = How.XPath, Using = "(//*[@class='news-form__field']//textarea)[1]")]
        public IWebElement commentField;

        [FindsBy(How = How.XPath, Using = "(//*[@class='news-form__control-flex']//a[@class])[1]")]
        public IWebElement buttonComment;

        public void OpenFirstNewsAndLeaveaAComment()
        {
            Actions actions = new Actions(_driver);
            FirstNews.Click();
            actions.MoveToElement(comments).Perform();
            commentField.SendKeys("Хорошая статья");                     
            //buttonComment.Click();
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='comments']//*[contains(text(),'Хорошая статья')]/../../..//a[contains(@class, 'up')]")]
        public IWebElement myComment;        

        public void DefineACommentAndLike()
        {
            myComment.Click();
        }


    }
}
