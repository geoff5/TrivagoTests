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


        [FindsBy(How = How.ClassName, Using = "btn-horus--checkin")]
        private IWebElement checkInCalendar;

        [FindsBy(How = How.ClassName, Using = "btn-horus--checkout")]
        private IWebElement checkOutCalendar;

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

        public void clickCheckInDatePicker()
        {
            checkInCalendar.Click();
        }

        public void clickCheckOutDatePicker()
        {
            checkOutCalendar.Click();
        }

    }
}
