using MbUnit.Framework;
using UnitTestProject1.PageObjects;
using Utils.Util;

namespace UnitTestProject1.TestCases
{
    /// <summary>
    /// This class checks the MyDX page functionality
    /// </summary>
    [TestFixture,Parallelizable]
    public class MyDX : TestBase
    {
        MyDxPage myDxAccount;

        /// <summary>
        /// Login in the application and redirects to MyDX page.
        /// </summary>
        [SetUp]
        public void InitMyDx()
        {
            myDxAccount = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password")).ClickUserName();
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if My Orders link is displayed.
        /// </summary>
        [Test]
        public void IsMyOrdersLinkPresent()
        {
            Assert.IsTrue(myDxAccount.IsMyOrdersLinkPresent()); //Manejo de errores
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify if My Profile link is displayed.
        /// </summary>
        [Test]
        public void IsMyProfileLinkPresent()
        {
            Assert.IsTrue(myDxAccount.IsMyProfileLinkPresent());
        }

        /// <summary>
        /// TEST CASE ID = *****. This test case verify Upload validation.
        /// </summary>
        [Test]
        public void UserEntersInvalidFormatFile()
        {
            myDxAccount.UploadImage(@ConfigUtil.GetString("image.invalidpath"));
            Assert.AreEqual(myDxAccount.GetValidationAlert(), ConfigUtil.GetString("image.invalidtype"));
            myDxAccount.SubmitAlert();
        }

        /// <summary>
        /// Logout from the application
        /// </summary>
        [TearDown]
        public void MyDxCleanUp()
        {
            myDxAccount.LogOut();
        }
    }
}
