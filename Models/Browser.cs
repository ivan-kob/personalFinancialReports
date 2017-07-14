using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Threading;
using System.IO;

namespace Models
{
    public class Browser : IDisposable
    {
        private IWebDriver WebDriver { get; set; }
        private const string WEBDRIVER_FOLDER = "WebDrivers";
        private string WEBDRIVER_PATH = Path.Combine(Environment.CurrentDirectory, WEBDRIVER_FOLDER);

        public Browser(Browsers browserName)
        {
            WebDriver = GetWebDriver(browserName.ToString());
        }

        private IWebDriver GetWebDriver (string browserName)
        {
            if (browserName == "CHROME")
            {
                return new ChromeDriver(WEBDRIVER_PATH);
            }
            else if(browserName == "EDGE")
            {
                return new EdgeDriver(WEBDRIVER_PATH);
            }
            else if (browserName == "EXPLORER")
            {
                return new InternetExplorerDriver(WEBDRIVER_PATH);
            } 
            else
            {
                return new PhantomJSDriver(WEBDRIVER_PATH);
            }
        }

        public void GoToUrl(string URL)
        {
            WebDriver.Navigate().GoToUrl(URL);
        }

        public void MoveBack()
        {
            WebDriver.Navigate().Back();
        }

        public void MoveForward()
        {
            WebDriver.Navigate().Forward();
        }

        public void ChangeToNewWindow()
        {
            WebDriver.SwitchTo();
        }

        public void Refresh()
        {
            WebDriver.Navigate().Refresh();
        }

        public void SetTextToElement(string elementName, string text)
        {
            IWebElement query = WebDriver.FindElement(By.Name(elementName));
            query.SendKeys(text);
        }

        public void ClickElement(string elementName)
        {
            IWebElement query = WebDriver.FindElement(By.Name(elementName));
            query.Click();
        }

        public void SubmitButton(string submitElementText)
        {
            IWebElement query = WebDriver.FindElement(By.LinkText(submitElementText));
            query.Click();
        }

        public void Dispose()
        {
            WebDriver.Dispose();
        }

        public void WaitSeconds(int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        public enum Browsers
        {
            CHROME,
            EDGE,
            GHOST,
            EXPLORER
        };
    }
}
