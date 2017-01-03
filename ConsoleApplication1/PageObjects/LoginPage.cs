using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using ConsoleApplication1.Utility;

namespace ConsoleApplication1.PageObjects
{
    class LoginPage
    {
        public bool flag;
        private IWebDriver driver;
        [FindsBy(How=How.Name,Using= "USER")][CacheLookup]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "PASSWORD")]
        [CacheLookup]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "login_button")]
        [CacheLookup]
        public IWebElement Submit { get; set; }

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public bool UserLogin(String testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);

            if (UserName.Displayed)
            {
                UserName.SendKeys(userData.Username);
                //Passed
            }else
            {
                //failed
                flag = false;
            }
            if (Password.Displayed)
            {
                Password.SendKeys(userData.Password);
                //Passed
            }
            else
            {
                //failed
                flag = false;
            }
            if (Submit.Displayed && Submit.Enabled)
            {
                Submit.Submit();
                //Passed
            }
            else
            {
                //failed
                flag = false;
            }
            if (flag == false)
            {
                return false;
            }else
            {
                return true;
            }
        }
    }
}
