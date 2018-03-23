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
        string month = String.Empty;

        [TestInitialize]
        public void initialise()
        {
            Driver.initialise();
            searchPage = new SearchPage(Driver.myDriver);
            threeMonthsAhead = DateUtility.calculateThreeMonthsAhead();
            month = DateUtility.getMonthText(threeMonthsAhead.Month);
            wait = new WebDriverWait(Driver.myDriver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("horus-querytext")));
        }

        [TestMethod]
        public void wifiFilterTest()
        {
            searchPage.enterSearchLocation(SearchText.Location);
            searchPage.clickSearchBtn();
            
        }

        [TestCleanup]
        public void cleanUpTest()
        {
            Driver.myDriver.Quit();
        }

        private void selectCheckInDate()
        {

        }
    }
}
