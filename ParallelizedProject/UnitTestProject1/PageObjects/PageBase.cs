using Utils.Util;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects
{
    public class PageBase
    {
        protected IWebDriver driver;

        public PageBase(IWebDriver d)
        {
            driver = d;
            PageFactory.InitElements(this.driver, this);
        }

        /// <summary>
        /// Method to maximaze the page
        /// </summary>
        public void MaximazePage()
        {
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Method to close the page.
        /// </summary>
        public void ClosePage()
        {
            driver.Close();
        }

        /// <summary>
        /// Method to clear all coockies.
        /// </summary>
        public void ClearAllCoockies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        /// <summary>
        ///  Switch to principal page content.
        /// </summary>
        public void SwitchToDefaultContent()
        {
            driver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Method to refresh the current page.
        /// </summary>
        public void RefreshPage() 
        {
            driver.Navigate().Refresh();
        }

        /// <summary>
        /// Method to take a screenshot in the page.
        /// </summary>
        public void TakeScreenshot(string baseFileName) 
        {
            try
            {
                string screenshotsPath = ConfigUtil.GetString("screenshots.path");
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(
                    screenshotsPath + baseFileName + ".png",
                    System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception) { }
        }
    }
}
