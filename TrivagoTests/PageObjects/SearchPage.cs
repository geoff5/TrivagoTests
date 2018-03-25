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

        [FindsBy(How = How.ClassName, Using = "btn-horus--roomtype")]
        private IWebElement roomTypeBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Double Room')]")]
        private IWebElement doubleRoomBtn;

        [FindsBy(How = How.XPath, Using = "//th[starts-with(@id, 'cal-heading-mon')]")]
        private IWebElement datePickerMonthYear;

        [FindsBy(How = How.ClassName, Using = "cal-btn-next")]
        private IWebElement datePickerNextBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='js-fullscreen-hero']/div/form/div[2]/div[2]/div/table[1]/tbody")]
        private IWebElement datePickerDaysTable;

        [FindsBy(How = How.XPath, Using = "//*[@title = 'Free WiFi']")]
        private IWebElement freeWifiBtn;

        [FindsBy(How = How.XPath, Using = "//*[@title = 'Spa']")]
        private IWebElement spaBtn;

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

        public void clickRoomTypeBtn()
        {
            roomTypeBtn.Click();
        }

        public void clickDoubleRoomBtn()
        {
            doubleRoomBtn.Click();
        }

        public void clickFreeWifiBtn()
        {
            freeWifiBtn.Click();
        }

        public void clickSpaBtn()
        {
            spaBtn.Click();
        }

        public string getDatePickerMonthYear()
        {
            return datePickerMonthYear.Text;
        }

        public void clickDatePickerNextBtn()
        {
            datePickerNextBtn.Click();
        }

        public void clickCurrentDayElement(string currentDay)
        {
            List<IWebElement> days = datePickerDaysTable.FindElements(By.XPath("//td[@class='cal-day-wrap']")).ToList();
            foreach(IWebElement day in days)
            {
                if(day.Text.Equals(currentDay))
                {
                    day.Click();
                    break;
                }
            }
        }

        public List<string> getSearchResults()
        {
            List<string> results = new List<string>();

            List<IWebElement> searchElements = driver.FindElements(By.XPath("//h3[@class='name__copytext m-0 item__slideout-toggle']")).ToList();
            foreach(IWebElement element in searchElements)
            {
                results.Add(element.Text);
            }

            return results;
        }
    }
}
