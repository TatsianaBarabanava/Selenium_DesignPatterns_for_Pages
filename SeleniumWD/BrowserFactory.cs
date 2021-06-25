using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver
{
    public class BrowserFactory
    {
        public enum BrowserType
        {
            Chrome,
            Firefox
        }

        public static IWebDriver GetDriver(BrowserType type, int timeOutSec)
        {
            IWebDriver driver = null;

            switch (type)
            {
                case BrowserType.Chrome:
                    {
                        var service = ChromeDriverService.CreateDefaultService();
                        var option = new ChromeOptions();
                        option.AddArgument("disable-infobars");
                        driver = new ChromeDriver(service, option, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
                case BrowserType.Firefox:
                    {
                        var service = FirefoxDriverService.CreateDefaultService();
                        var options = new FirefoxOptions();
                        driver = new FirefoxDriver(service, options, TimeSpan.FromSeconds(timeOutSec));
                        break;
                    }
            }
            return driver;
        }
    }
}