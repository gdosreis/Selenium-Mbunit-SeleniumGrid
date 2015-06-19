using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects
{
    public class HomePage : DxBasePage
    {
        [FindsBy(How = How.Id)]
        protected IWebElement categoryPanel;

        [FindsBy(How = How.LinkText, Using ="Consumer Electronics")]
        protected IWebElement consumerElectronics;

        [FindsBy(How = How.CssSelector, Using = "a[href='http://www.dx.com/c/car-accessories-799']")]
        protected IWebElement carAccessories;

        [FindsBy(How = How.CssSelector, Using = "#categoryPanel li:nth-child(2) a[class='menu_title']")]
        protected IWebElement computersTabletsNetworking;


        public HomePage(IWebDriver d) : base(d) { }

        /// <summary>
        /// Method to verify if be in Home Page.
        /// </summary>
        public bool AreHomeElementPresents()
        {
            return categoryPanel.Displayed && consumerElectronics.Displayed && carAccessories.Displayed && computersTabletsNetworking.Displayed;
        }

        /// <summary>
        /// Method to verify DX link within Facebook box.
        /// Switch To iframe, because the Facebook box is a iframe.
        /// </summary>
        public bool isDxLInkPresentInFacebbox()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[src='//www.facebook.com/plugins/likebox.php?href=http%3A%2F%2Fwww.facebook.com%2FDealExtremeFans&width=210&colorscheme=light&show_faces=true&stream=false&header=true&height=313&connections=9']")));
            bool result = driver.FindElement(By.CssSelector("a[href='https://www.facebook.com/DealExtremeFans']")).Displayed;
            driver.SwitchTo().DefaultContent();
            return result;
        }
    }
}
