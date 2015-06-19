using MbUnit.Framework;
using UnitTestProject1.PageObjects;
using Utils.Util;

namespace UnitTestProject1.TestCases
{
    /// <summary>
    /// This class checks the Home page functionality
    /// </summary>
    [TestFixture,Parallelizable]
    public class HomeTestCases: TestBase
    {
        HomePage home;
        /// <summary>
        /// Login in the application
        /// </summary>
        [SetUp]
        public void InitHomeTestCases()
        {
            home = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password"));
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the Shopping Cart is displayed.
        /// </summary>
        [Test]
        public void UserSeesHisShoppingCart()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.AreMyDxElementsPresents());
        }

        /// <summary>
        //  TEST CASE ID = *****. This test case verify if Search Field Cart is displayed.
        /// </summary>
        [Test]
        public void UserSeesaSearchFieldCart()
        {
            Assert.IsTrue(home.IsSearchFieldPresent());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify the Username link behavior.
        /// </summary>
        [Test]
        public void UserClicksOnUsername()
        {
            MyDxPage myDx = home.ClickUserName();
            Assert.IsTrue(myDx.AreMyDxElementsPresents());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the DX link is displayed within the Facebook box.
        /// </summary>
        [Test]
        public void UserSeesTheDXLinkWithinTheFacebookBox()
        {
            Assert.IsTrue(home.isDxLInkPresentInFacebbox());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify the search functionality.
        /// </summary>
        [Test]
        public void UserPerformsaSearch()
        {
            SearchResultPage search = home.PerformaSearch("test");
            Assert.IsTrue(search.AreSearchResultElementPresents());
        }

        /// <summary>
        /// Logout from the application.
        /// </summary>
        [TearDown]
        public void HomeTestCasesCleanUp()
        {
            home.LogOut();
        }
    }
}
