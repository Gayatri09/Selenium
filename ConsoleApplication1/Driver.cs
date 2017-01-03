using log4net.Repository.Hierarchy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;

namespace ConsoleApplication1
{
    class Driver
    {
        public static IWebDriver d1;
        
        static void Main(string[] args)
        {
            d1 = new ChromeDriver();
        }
        [SetUp]
        public void Start()
        {
            d1.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            var appURL = ConfigurationManager.AppSettings["URL"];
            d1.Navigate().GoToUrl(appURL);
        }

    [TearDown]
        public void Stop()
        {
            d1.Close();
            d1.Quit();
        }
    }
}
