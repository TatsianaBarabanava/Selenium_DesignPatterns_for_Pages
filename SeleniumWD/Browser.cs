using System;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Interactions;


namespace SeleniumWebDriver
{
    public class Browser
    {
        private static Browser currentInstance;
        private static IWebDriver driver;
        public static BrowserFactory.BrowserType currentBrowser;
        public static int ImplWait;
        public static double timeoutForElement;
        private static string browser;

        public Browser()
        {
            InitParams();
            driver = BrowserFactory.GetDriver(currentBrowser, ImplWait);
        }
        
        private static void InitParams() 
        {
            ImplWait = Convert.ToInt32(Configuration.ElementTimeout);
            timeoutForElement = Convert.ToDouble(Configuration.ElementTimeout);
            browser = Configuration.Browser;
            Enum.TryParse(browser, out currentBrowser);
        }

        public static Browser Instance => currentInstance ?? (currentInstance = new Browser());
        public static void WindowMaximize()
        {
            driver.Manage().Window.Maximize();
        }

        public static void NavigateTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public static IWebDriver GetDriver()
        {
            return driver;
        }

        public static void Quit()
        {
            driver.Close();
            driver.Quit();
            currentInstance = null;
            driver = null;
            browser = null;
        }

        public static void SwitchToLastWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void PressEscape()
        {
            Actions performEscape = new Actions(driver);
            performEscape.SendKeys(Keys.Escape).Perform();
        }

        public static void RefreshPage()
        {
            driver.Navigate().Refresh();
        }
    }
}