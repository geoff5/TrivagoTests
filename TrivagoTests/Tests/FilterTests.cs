using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TrivagoTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrivagoTests.Resources;
using TrivagoTests.Utils;


namespace TrivagoTests.Tests
{
    [TestClass]
    public class FilterTests
    {
        WebDriverWait wait;
        SearchPage searchPage;

        DateTime today;
        DateTime threeMonthsAhead;
        string monthYear = String.Empty;
        List<string> searchResults;

        [TestInitialize]
        public void initialise()//Runs common code to initialise driver and set up each test
        {
            Driver.initialise();
            searchPage = new SearchPage(Driver.myDriver);
            threeMonthsAhead = DateUtility.calculateThreeMonthsAhead();
            monthYear = DateUtility.getMonthText(threeMonthsAhead.Month);
            monthYear += " " + threeMonthsAhead.Year.ToString();
            wait = new WebDriverWait(Driver.myDriver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("horus-querytext")));
            searchPage.enterSearchLocation(SearchText.Location);
            searchPage.clickSearchBtn();
            selectCheckInDate();
            searchPage.clickRoomTypeBtn();
            searchPage.clickDoubleRoomBtn();
        }

        [TestMethod, TestCategory("Filter Test")]
        public void wifiFilterTest()//Tests the free WiFi filter.  Will fail as the Jurys Inn appears in search results
        {
            searchPage.clickFreeWifiBtn();
            Thread.Sleep(2000);
            searchResults = searchPage.getSearchResults();
            Assert.IsTrue(searchResults.Contains(SearchText.CorkInter), "Cork International not in search results");
            Assert.IsFalse(searchResults.Contains(SearchText.Jurys), "Jurys Inn is in search results");
        }

        [TestMethod, TestCategory("Filter Test")]
        public void spaFilterTest()//Tests the Spa filter.
        {
            searchPage.clickSpaBtn();
            Thread.Sleep(2000);
            searchResults = searchPage.getSearchResults();
            Assert.IsTrue(searchResults.Contains(SearchText.RiverLee), "River Lee Hotel not in search results");
            Assert.IsFalse(searchResults.Contains(SearchText.Jurys), "Jurys Inn is in search results");
        }

        [TestCleanup]
        public void cleanUpTest()//Closes down the driver after each test
        {
            Driver.myDriver.Quit();
        }

        private void selectCheckInDate()//private method to select the date of check in
        {
            while(searchPage.getDatePickerMonthYear() != monthYear)
            {
                searchPage.clickDatePickerNextBtn();
                Thread.Sleep(2000);
            }

            searchPage.clickCurrentDayElement(threeMonthsAhead.Day.ToString());
        }
    }
}
