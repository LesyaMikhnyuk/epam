using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirportTest
{

    public class Page : IDisposable
    {
        private const string BaseUrl = "https://www.turkishairlines.com/";

        private const string DriverPath = @"C:\Users\dimys\Desktop\AirportTest\Resource";
        private const string ChromeDriver = "chromedriver";
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Click to find departure point.']")]
        private IWebElement buttonInputFrom;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Click to find destination.']")]
        private IWebElement buttonInputTo;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Click to find departure point.']/..//input")]
        private IWebElement inputFrom;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Click to find destination.']/..//input")]
        private IWebElement inputTo;

        [FindsBy(How = How.XPath, Using = "//label[@class='checkbox metro-checkbox normal img-align-left']")]
        private IWebElement checkboxOneWay;

        [FindsBy(How = How.XPath, Using = "//a[@class='hidden-xs btn btn-danger done-btn pull-right toggle-popup ml-20 focusable-calendar-item']")]
        private IWebElement buttonSubmitDate;

        [FindsBy(How = How.Id, Using = "choosePerson_btn1")]
        private IWebElement buttonSubmitPerson;

        [FindsBy(How = How.Id, Using = "executeSingleCitySubmit")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.Id, Using = "calendarTrigger")]
        private IWebElement buttonCalendarTrigger;

        [FindsBy(How = How.XPath, Using = "//input[@id='customSpnr1CHILD']/../a[@name='upperCountSpinner']")]
        private IWebElement increaseChildren;

        [FindsBy(How = How.XPath, Using = "//input[@id='customSpnr0ADULT']/../a[@name='upperCountSpinner']")]
        private IWebElement increaseAdults;

        [FindsBy(How = How.XPath, Using = "//input[@id='customSpnr2INFANT']/../a[@name='upperCountSpinner']")]
        private IWebElement increaseInfants;

        [FindsBy(How = How.XPath, Using = "//a[@class='white mini-booker-link mb-5']")]
        private IWebElement multiCityLink;

        [FindsBy(How = How.XPath, Using = "//a[@data-bind='click: $root.executeMultiCityFlightSearch']")]
        private IWebElement multiCitySearch;

        public Page()
        {
            driver = new ChromeDriver(DriverPath);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            PageFactory.InitElements(driver, this);
        }

        public void TestCase1()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(buttonInputFrom)).Click();
            inputFrom.SendKeys("mxp");
            var selectedAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find departure point.']/..//ul/li[@rel='2']/a"));
            var action = new Actions(driver);
            action.MoveToElement(selectedAirport, 1, 1).Build().Perform();
            action.Click().Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@aria-label='Click to find destination.']/..//input")));
            inputTo.SendKeys("cdg");
            var toAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find destination.']/..//ul/li[@rel='1']/a"));
            var action2 = new Actions(driver);
            action2.MoveToElement(toAirport, 1, 1).Build().Perform();
            action2.Click().Perform();
            var date = DateTime.Now.AddDays(7);
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                string.Format("//td[@data-month='{0}'][@data-year='{1}']/a[text()='{2}']", date.Month - 1, date.Year, date.Day))))
                .Click();
            date = date.AddDays(7);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                string.Format("//td[@data-month='{0}'][@data-year='{1}']/a[text()='{2}']", date.Month - 1, date.Year, date.Day))))
                .Click();
            buttonSubmitDate.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("choosePerson_btn1"))).Click();
            buttonSubmit.Click();
        }

        public void TestCase2()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(buttonInputFrom)).Click();
            inputFrom.SendKeys("msq");
            var selectedAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find departure point.']/..//ul/li[@rel='1']/a"));
            var action = new Actions(driver);
            action.MoveToElement(selectedAirport, 1, 1).Build().Perform();
            action.Click().Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@aria-label='Click to find destination.']/..//input")));
            inputTo.SendKeys("vko");
            var toAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find destination.']/..//ul/li[@rel='1']/a"));
            var action2 = new Actions(driver);
            action2.MoveToElement(toAirport, 1, 1).Build().Perform();
            action2.Click().Perform();
            var date = DateTime.Now.AddDays(7);
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                string.Format("//td[@data-month='{0}'][@data-year='{1}']/a[text()='{2}']", date.Month - 1, date.Year, date.Day))))
                .Click();
            var action3 = new Actions(driver);
            action3.MoveToElement(checkboxOneWay).Build().Perform();
            action3.Click().Perform();
            buttonSubmitDate.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                "//input[@id='customSpnr1CHILD']/../a[@name='upperCountSpinner']"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                "//input[@id='customSpnr2INFANT']/../a[@name='upperCountSpinner']"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("choosePerson_btn1"))).Click();
            buttonSubmit.Click();
        }

        public void TestCase3()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(buttonInputFrom)).Click();
            inputFrom.SendKeys("msq");
            var selectedAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find departure point.']/..//ul/li[@rel='1']/a"));
            var action = new Actions(driver);
            action.MoveToElement(selectedAirport, 1, 1).Build().Perform();
            action.Click().Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@aria-label='Click to find destination.']/..//input")));
            inputTo.SendKeys("vko");
            var toAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find destination.']/..//ul/li[@rel='1']/a"));
            var action2 = new Actions(driver);
            action2.MoveToElement(toAirport, 1, 1).Build().Perform();
            action2.Click().Perform();
            var date = DateTime.Now.AddDays(7);
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                string.Format("//td[@data-month='{0}'][@data-year='{1}']/a[text()='{2}']", date.Month - 1, date.Year, date.Day))))
                .Click();
            var action3 = new Actions(driver);
            action3.MoveToElement(checkboxOneWay).Build().Perform();
            action3.Click().Perform();
            buttonSubmitDate.Click();
            for (int i = 0; i < 7; i++)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                    "//input[@id='customSpnr1CHILD']/../a[@name='upperCountSpinner']"))).Click();
            for (int i = 0; i < 6; i++)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                    "//input[@id='customSpnr0ADULT']/../a[@name='upperCountSpinner']"))).Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("choosePerson_btn1"))).Click();
            buttonSubmit.Click();
        }

        public void TestCase4()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(buttonInputFrom)).Click();
            inputFrom.SendKeys("msq");
            var selectedAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find departure point.']/..//ul/li[@rel='1']/a"));
            var action = new Actions(driver);
            action.MoveToElement(selectedAirport, 1, 1).Build().Perform();
            action.Click().Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@aria-label='Click to find destination.']/..//input")));
            inputTo.SendKeys("msq");
            var toAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find destination.']/..//ul/li[@rel='1']/a"));
            var action2 = new Actions(driver);
            action2.MoveToElement(toAirport, 1, 1).Build().Perform();
            action2.Click().Perform();
            var date = DateTime.Now.AddDays(7);
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                string.Format("//td[@data-month='{0}'][@data-year='{1}']/a[text()='{2}']", date.Month - 1, date.Year, date.Day))))
                .Click();
            date = date.AddDays(7);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                string.Format("//td[@data-month='{0}'][@data-year='{1}']/a[text()='{2}']", date.Month - 1, date.Year, date.Day))))
                .Click();
            buttonSubmitDate.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("choosePerson_btn1"))).Click();
            buttonSubmit.Click();
        }

        public void TestCase5()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            wait.Until(ExpectedConditions.ElementToBeClickable(buttonInputFrom)).Click();
            inputFrom.SendKeys("msq");
            var selectedAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find departure point.']/..//ul/li[@rel='1']/a"));
            var action = new Actions(driver);
            action.MoveToElement(selectedAirport, 1, 1).Build().Perform();
            action.Click().Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@aria-label='Click to find destination.']/..//input")));
            inputTo.SendKeys("vko");
            var toAirport = driver.FindElement(By.XPath("//button[@aria-label='Click to find destination.']/..//ul/li[@rel='1']/a"));
            var action2 = new Actions(driver);
            action2.MoveToElement(toAirport, 1, 1).Build().Perform();
            action2.Click().Perform();
            var date = DateTime.Now.AddDays(7);
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                string.Format("//td[@data-month='{0}'][@data-year='{1}']/a[text()='{2}']", date.Month - 1, date.Year, date.Day))))
                .Click();
            var action3 = new Actions(driver);
            action3.MoveToElement(checkboxOneWay).Build().Perform();
            action3.Click().Perform();
            buttonSubmitDate.Click();
            for (int i = 0; i < 5; i++)
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                    "//input[@id='customSpnr2INFANT']/../a[@name='upperCountSpinner']"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(
                "//input[@id='customSpnr0ADULT']/../a[@name='upperCountSpinner']"))).Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("choosePerson_btn1"))).Click();
            buttonSubmit.Click();
        }

        public void TestCase6()
        {
            driver.Navigate().GoToUrl(BaseUrl);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            Thread.Sleep(10000);
            multiCityLink.Click();
            var buttonInputToCollections = driver.FindElements(By.XPath("//button[@aria-label='Click to find destination.']"));
            var inputToCollections = driver.FindElements(By.XPath("//button[@aria-label='Click to find destination.']/..//input"));
            var buttonInputFromCollections = driver.FindElements(By.XPath("//button[@aria-label='Click to find departure point.']"));
            var inputFromCollections = driver.FindElements(By.XPath("//button[@aria-label='Click to find departure point.']/..//input"));
            string[] airports = new string[] { "msq", "vko", "ecn" };
            for (int i = 0; i < 2; i++)
            {
                buttonInputFromCollections[i].Click();
                inputFromCollections[i].SendKeys(airports[i]);
                var listItemsFrom = driver.FindElements(By.XPath("//button[@aria-label='Click to find departure point.']/..//ul/li[@rel='1']/a"));
                listItemsFrom[i].Click();
                buttonInputToCollections[i].Click();
                inputToCollections[i].SendKeys(airports[i+1]);
                var listItemsTo = driver.FindElements(By.XPath("//button[@aria-label='Click to find destination.']/..//ul/li[@rel='1']/a"));
                listItemsTo[i].Click();
                var selectDateButton = driver.FindElement(By.XPath($"//a[@href='#multiCityCalendarHolder{i}']"));
                selectDateButton.Click();
                var date = DateTime.Now.AddDays(7 * i);
                wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript("return jQuery.active == 0"));
                wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
                var tableDate = driver.FindElements(By.XPath(
                    string.Format("//td[@data-month='{0}'][@data-year='{1}']/a[text()='{2}']", date.Month - 1, date.Year, date.Day)));
                tableDate[i].Click();
                var submitDateButton = driver.FindElement(By.XPath($"//a[@href='#multiCityCalendarHolder{i}']"));
                var action = new Actions(driver);
                action.MoveToElement(submitDateButton, 1, 1).Build().Perform();
                action.Click().Perform();
            }
            multiCitySearch.Click();            
        }

        public void TestCase7()
        {

        }



        public void Dispose()
        {
            driver.Quit();
            driver = null;

            foreach (var process in Process.GetProcessesByName(ChromeDriver))
            {
                process.Kill();
            }
        }
    }
}
