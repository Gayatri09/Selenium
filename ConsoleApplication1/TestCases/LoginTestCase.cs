using ConsoleApplication1.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ConsoleApplication1.Utility;
using log4net;

namespace ConsoleApplication1.TestCases
{
    class LoginTestCase
    {
        public static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [Test]
        public void LoginTest()
        {
            //IWebDriver d1 = new ChromeDriver();
            //d1.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            string status;
            var appURL=ConfigurationManager.AppSettings["URL"];
            //d1.Navigate().GoToUrl(appURL);
            var loginPage = new LoginPage(Driver.d1);
            bool val=loginPage.UserLogin("TC1");
            if (val == false)
            {
                status = "Falied";
                log.Info("User login Failed");
            }else
            {
                status = "Passed";
                log.Info("User login Passed");
            }
            Results.UpdateResults("TC1", status);

        }
    }
}
