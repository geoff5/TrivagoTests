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
    public class Driver
    {
        string url = String.Empty;
        string browser = String.Empty;
        IWebDriver myDriver;

        public void initialise()
        {
            url = ConfigurationManager.AppSettings["TrivagoURL"].ToString();

            driverChoice(ConfigurationManager.AppSettings["Browser"].ToString().ToLower());
            myDriver.Manage().Window.Maximize();
            myDriver.Navigate().GoToUrl(url);
        }

        private void driverChoice(string browser)
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
