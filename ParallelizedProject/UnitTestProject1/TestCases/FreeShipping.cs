using MbUnit.Framework;
using UnitTestProject1.PageObjects;
using Utils.Util;

namespace UnitTestProject1.TestCases
{
    /// <summary>
    /// This class checks the FreeShipping page functionality
    /// </summary>
    [TestFixture,Parallelizable]
    public class FreeShipping : TestBase
    {
        FreeShippingPage freeShipping;

        /// <summary>
        /// Login in the application and directs to FreeShipping section.
        /// </summary>
        [SetUp]
        public void InitFreeShipping()
        {
            freeShipping = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password")).ClickFreeShippingButton();
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the users is directs to Free Shiping page.
        /// </summary>
        [Test]
        public void UserDirectsToFreeShippingPageTCXXXX()
        {
            freeShipping.TakeScreenshot("UserDirectsToFreeShippingPageTCXXXX");
            Assert.IsTrue(freeShipping.AreFreeShipingElementsPresents());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the YES option is selected by default.
        /// </summary>
        [Test]
        public void UserSeeYesAsDefaultCheckedOptionTCXXXX()
        {
            freeShipping.TakeScreenshot("UserSeeYesAsDefaultCheckedOptionTCXXXX");
            Assert.IsTrue(freeShipping.IsCheckedYesOption());
            Assert.IsFalse(freeShipping.IsCheckedNoOption());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if the NO option could be select.
        /// </summary>
        [Test]
        public void UserCheckesNoOptionTCXXXX()
        {
            freeShipping.TakeScreenshot("UserCheckesNoOptionTCXXXX_1");
            freeShipping.CheckNoOption();
            freeShipping.TakeScreenshot("UserCheckesNoOptionTCXXXX_2");
            Assert.IsFalse(freeShipping.IsCheckedYesOption());
            Assert.IsTrue(freeShipping.IsCheckedNoOption());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify the Submit respons functionality.
        /// </summary>
        [Test]
        public void UserSubmitsYourResponseTCXXXX()
        {
            freeShipping.TakeScreenshot("UserSubmitsYourResponseTCXXXX_1");
            Assert.IsFalse(freeShipping.IsSubmitedRespons());
            freeShipping.CheckNoOption();
            freeShipping.TakeScreenshot("UserSubmitsYourResponseTCXXXX_2");
            freeShipping.ClickSubmitButton();
            freeShipping.TakeScreenshot("UserSubmitsYourResponseTCXXXX_3");
            Assert.IsTrue(freeShipping.IsSubmitedRespons());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify the Close dialog box functionality.
        /// </summary>
        [Test]
        public void UserClosesDialogBoxTCXXXX()
        {
            freeShipping.TakeScreenshot("UserClosesDialogBoxTCXXXX_1");
            freeShipping.ClickCloseDialogButton();
            freeShipping.TakeScreenshot("UserClosesDialogBoxTCXXXX_2");
            Assert.IsFalse(freeShipping.IsDialogPresent());
        }

        /// <summary>
        /// Logout of application
        /// </summary>
        [TearDown]
        public void FreeShippingCleanUp()
        {
            freeShipping.LogOut();
        }
    }
}
