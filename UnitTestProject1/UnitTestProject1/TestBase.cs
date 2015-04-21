﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Utils.Util;

namespace UnitTestProject1
{
    [TestClass]
    public class TestBase
    {
        protected IWebDriver driver;

        [TestInitialize]
        public void InitBrowser()
        {
            ChromeOptions chromeoptions = new ChromeOptions();
            chromeoptions.AddArgument("test-type");
            chromeoptions.AddArgument("no-sandbox");
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(ConfigUtil.GetString("base.url"));
        }

        [TestCleanup]
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
