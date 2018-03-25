using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;


namespace TrivagoTests
{
    public static class Driver
    {
        public static IWebDriver myDriver;

        public static void initialise()//Create a driver class that can be accessed from the test classes 
        {
            string url = String.Empty;
            string browser = String.Empty;

            url = ConfigurationManager.AppSettings["TrivagoURL"].ToString();//Pass in the Trivago URL 

            driverChoice(ConfigurationManager.AppSettings["Browser"].ToString().ToLower());
            myDriver.Manage().Window.Maximize();
            myDriver.Navigate().GoToUrl(url);
        }

        private static void driverChoice(string browser)//Check the config file for which browser to use and initialise it
        {
            switch(browser)
            {
                case "chrome":
                    myDriver = new ChromeDriver();
                    break;

                case "phantomjs":
                    myDriver = new PhantomJSDriver();
                    break;

                default:
                    throw new Exception("An invalid browser was specified in the config file");
            }
        }
    }
}
