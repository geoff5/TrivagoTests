using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TrivagoTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrivagoTests;

namespace TrivagoTests.Tests
{
    [TestClass]
    public class FilterTests
    {
        WebDriverWait wait;
        SearchPage searchPage;

        [TestInitialize]
        public void initialise()
        {
            Driver.initialise();
            searchPage = new SearchPage(Driver.myDriver);
            wait = new WebDriverWait(Driver.myDriver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("horus-querytext")));
        }

        [TestMethod]
        public void wifiFilterTest()
        {
            searchPage.enterSearchLocation("Cork");
            searchPage.clickSearchBtn();
            Thread.Sleep(10000);
        }

        [TestCleanup]
        public void cleanUpTest()
        {
            Driver.myDriver.Quit();
        }
    }
}
