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
        
        //Search bar elements
        [FindsBy(How = How.Id, Using = "horus-querytext")]
        private IWebElement searchBar;

        [FindsBy(How = How.ClassName, Using = "horus-btn-search__label")]
        private IWebElement searchBtn;

        //Check in date picker elements
        [FindsBy(How = How.ClassName, Using = "btn-horus--checkin")]
        private IWebElement checkInCalendar;

        [FindsBy(How = How.XPath, Using = "//th[starts-with(@id, 'cal-heading-mon')]")]
        private IWebElement datePickerMonthYear;

        [FindsBy(How = How.ClassName, Using = "cal-btn-next")]
        private IWebElement datePickerNextBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='js-fullscreen-hero']/div/form/div[2]/div[2]/div/table[1]/tbody")]
        private IWebElement datePickerDaysTable;

        //Room type picker elements 
        [FindsBy(How = How.ClassName, Using = "btn-horus--roomtype")]
        private IWebElement roomTypeBtn;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Double Room')]")]
        private IWebElement doubleRoomBtn;

        //Filter elements
        [FindsBy(How = How.XPath, Using = "//*[@title = 'Free WiFi']")]
        private IWebElement freeWifiBtn;

        [FindsBy(How = How.XPath, Using = "//*[@title = 'Spa']")]
        private IWebElement spaBtn;

        //Constructor
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Search bar methods
        public void enterSearchLocation(string location)
        {
            searchBar.Clear();
            searchBar.SendKeys(location);
        }

        public void clickSearchBtn()
        {
            searchBtn.Click();
        }

        //Date picker methods
        public void clickCheckInDatePicker()
        {
            checkInCalendar.Click();
        }

        public string getDatePickerMonthYear()
        {
            return datePickerMonthYear.Text;
        }

        public void clickDatePickerNextBtn()
        {
            datePickerNextBtn.Click();
        }

        public void clickCurrentDayElement(string currentDay)//Finds the element for the passed in date and clicks on it
        {
            List<IWebElement> days = datePickerDaysTable.FindElements(By.XPath("//td[@class='cal-day-wrap']")).ToList();
            foreach (IWebElement day in days)
            {
                if (day.Text.Equals(currentDay))
                {
                    day.Click();
                    break;
                }
            }
        }

        //Room type selector methods
        public void clickRoomTypeBtn()
        {
            roomTypeBtn.Click();
        }

        public void clickDoubleRoomBtn()
        {
            doubleRoomBtn.Click();
        }

        //Filter selection methods
        public void clickFreeWifiBtn()
        {
            freeWifiBtn.Click();
        }

        public void clickSpaBtn()
        {
            spaBtn.Click();
        }
       
        //Method to return a list of the hotel search results
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
