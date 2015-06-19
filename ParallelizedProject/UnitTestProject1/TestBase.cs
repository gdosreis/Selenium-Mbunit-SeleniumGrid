using System;
using MbUnit.Framework;
using OpenQA.Selenium;
using Utils.Util;
using OpenQA.Selenium.Remote;

namespace UnitTestProject1
{
    /// <summary>
    /// It is the base class for the test cases. Will setup the initials conditions to run the corresponding test cases.
    /// </summary>
    [TestFixture]
    public class TestBase
    {
        protected IWebDriver driver;

        /// <summary>
        /// It's class will be executed before to execute each test case. Will initialize the remote driver and goes to the base page.
        /// </summary>
        [SetUp]
        public void InitBrowser()
        {           
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.Platform, PlatformType.Vista); // Set the OS in that will be run the test cases.
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");// Set the browser in that will be run the test cases.
            driver = new RemoteWebDriver(new Uri("http://192.168.6.83:5555/wd/hub"), capabilities);//Instance a remote webdriver with the remote machine direction. 
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(ConfigUtil.GetString("base.url"));
        }

        /// <summary>
        /// It's class will be executed after to execute each test case. Will restart the seted conditions.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            try
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Quit();
            }
            catch (Exception)
            {
                driver.Quit();
            }
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
    }
}
