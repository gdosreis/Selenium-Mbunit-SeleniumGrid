using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects
{
    public class SearchResultPage : DxBasePage
    {
        [FindsBy(How = How.Id, Using = "content_plHaveProducts")]
        protected IWebElement ResultTable;

        [FindsBy(How = How.Id, Using = "J_Filter")]
        protected IWebElement filters;

        public SearchResultPage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Method to verify if be in Search Result Page.
        /// </summary>
        public bool AreSearchResultElementPresents()
        {
            return ResultTable.Displayed && ResultTable.Enabled && filters.Displayed && filters.Enabled;
        }
    }
}
