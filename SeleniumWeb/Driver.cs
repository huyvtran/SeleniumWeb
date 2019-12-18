using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SeleniumWeb.Utility;

namespace SeleniumWeb
{
    public static class Driver
    {
        private static WebDriverWait browserWait;

        private static IWebDriver browser;

        public static IWebDriver Browser
        {
            get
            {
                if (browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method Start.");
                }
                return browser;
            }
            set => browser = value;
        }
        public static WebDriverWait BrowserWait
        {
            get
            {
                if (browserWait == null || browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized. You should first call the method Start.");
                }
                return browserWait;
            }
            private set
            {
                browserWait = value;
            }
        }

        public static void StartBrowser(BrowserTypes browserType = BrowserTypes.Chrome, int defaultTimeOut = 30)
        {
            switch (browserType)
            {
                case BrowserTypes.Chrome:
                    Driver.Browser = new ChromeDriver();
                    break;
                case BrowserTypes.Firefox:
                    Driver.Browser = new FirefoxDriver();
                    break;
                case BrowserTypes.InternetExplorer:
                    Driver.Browser = new InternetExplorerDriver();
                    break;
                default:
                    break;
            }
            BrowserWait=new WebDriverWait(Driver.Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }

        public static void StopBrowser()
        {
            Browser.Quit();
            Browser = null;
            BrowserWait = null;
        }
    }
}
