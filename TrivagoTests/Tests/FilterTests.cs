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
        public void initialise()
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
        public void wifiFilterTest()
        {
            searchPage.clickFreeWifiBtn();
            Thread.Sleep(2000);
            searchResults = searchPage.getSearchResults();
            Assert.IsTrue(searchResults.Contains(SearchText.CorkInter), "Cork International not in search results");
            Assert.IsFalse(searchResults.Contains(SearchText.Jurys), "Jurys Inn is in search results");
        }

        [TestMethod, TestCategory("Filter Test")]
        public void spaFilterTest()
        {
            searchPage.clickSpaBtn();
            Thread.Sleep(2000);
            searchResults = searchPage.getSearchResults();
            Assert.IsTrue(searchResults.Contains(SearchText.RiverLee), "Cork International not in search results");
            Assert.IsFalse(searchResults.Contains(SearchText.Jurys), "Jurys Inn is in search results");
        }

        [TestCleanup]
        public void cleanUpTest()
        {
            Driver.myDriver.Quit();
        }

        private void selectCheckInDate()
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
