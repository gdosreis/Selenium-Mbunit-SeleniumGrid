﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects;
using Utils.Util;

namespace UnitTestProject1.TestCases
{
    [TestClass]
    public class MyDX : TestBase
    {
        MyDxPage myDxAccount;

        [TestInitialize]
        public void InitHomeTestCases()
        {
            myDxAccount = new LoginPage(GetDriver()).Login(ConfigUtil.GetString("user.username"), ConfigUtil.GetString("user.password")).ClickUserName();
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void IsMyOrdersLinkPresent()
        {
            Assert.IsTrue(myDxAccount.IsMyOrdersLinkPresent()); //Manejo de errores
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void IsMyProfileLinkPresent()
        {
            Assert.IsTrue(myDxAccount.IsMyProfileLinkPresent()); //Manejo de errores
        }

        // TEST CASE ID = *****. This test case verify if the email field is displayed.
        [TestMethod]
        public void UserEntersInvalidFormatFile()
        {
            myDxAccount.UploadImage(@ConfigUtil.GetString("image.invalidpath"));
            Assert.AreEqual(myDxAccount.GetValidationAlert(), ConfigUtil.GetString("image.invalidtype")); //Manejo de errores
        }
    }
}
