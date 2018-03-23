using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TrivagoTests.PageObjects
{
    class SearchPage
    {
        private IWebDriver driver;
        

        [FindsBy(How = How.Id, Using = "horus-querytext")]
        private IWebElement searchBar;

        [FindsBy(How = How.ClassName, Using = "horus-btn-search__label")]
        private IWebElement searchBtn;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void enterSearchLocation(string location)
        {
            searchBar.Clear();
            searchBar.SendKeys(location);
        }

        public void clickSearchBtn()
        {
            searchBtn.Click();
        }
    }
}
