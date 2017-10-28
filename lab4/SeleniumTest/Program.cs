using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class Program
    {
        private static IWebDriver webDriver;
        static void Main(string[] args)
        {
            try
            {
                webDriver = new ChromeDriver(@"C:\Users\Alesya Mikhnyuik\Downloads\CGD");
                webDriver.Navigate().GoToUrl("https://vk.com/");
                webDriver.FindElement(By.Id("index_email")).SendKeys("MikhnuykAlesya");
                webDriver.FindElement(By.Id("index_pass")).SendKeys("Time4Dead");
                webDriver.FindElement(By.XPath("//button[@id='index_login_button']")).Click();
                System.Threading.Thread.Sleep(3000);
                if (webDriver != null)
                    webDriver.Quit();
            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
            }
        }
    }
}
