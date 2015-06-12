﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class MyDxPage : DxBasePage
    {
        [FindsBy(How = How.CssSelector, Using = "#member_info img")]
        protected IWebElement userImage;

        [FindsBy(How = How.CssSelector, Using = "a[href='/Points/MyPoints']")]
        protected IWebElement myPointsLink;

        [FindsBy(How = How.CssSelector, Using = "a[jtype='privateMessages']")]
        protected IWebElement privateMessageLink;

        [FindsBy(How = How.LinkText, Using = "My Store Credits")]
        protected IWebElement myStoreCreditsLink;

        [FindsBy(How = How.LinkText, Using = "Gift Card Redeem")]
        protected IWebElement giftCardRedeemLink;

        [FindsBy(How = How.CssSelector, Using = "#member_info strong")]
        protected IWebElement userName;

        [FindsBy(How = How.Id)]
        protected IWebElement imageupload;

        [FindsBy(How = How.CssSelector, Using = "a[mid='110']")]
        protected IWebElement myOrders;

        [FindsBy(How = How.LinkText, Using = "My Profile")]
        protected IWebElement myProfile;

        public MyDxPage(IWebDriver driver) : base(driver) { }

        //Method to verify if be in Home Page
        public bool AreMyDxElementsPresents()
        {
            return userName.Displayed && myPointsLink.Displayed && myStoreCreditsLink.Displayed && privateMessageLink.Displayed && giftCardRedeemLink.Displayed;
        }

        //Method to return the username
        public string GetUsername()
        {
            return userName.Text;
        }

        //Method to verify if My Orders Link is present
        public bool IsMyOrdersLinkPresent()
        {
            return myOrders.Displayed && myOrders.Enabled;
        }

        //Method to verify if My Profile Link is present
        public bool IsMyProfileLinkPresent()
        {
            return myOrders.Displayed && myOrders.Enabled;
        }

        //Method to uploads a file
        public void UploadImage(string path)
        {
            imageupload.SendKeys(path);
        }

        //Method to return the ulpload validation message 
        public string GetValidationAlert()
        {
            return driver.SwitchTo().Alert().Text;
        }

        //Method to return the ulpload validation message 
        public void SubmitAlert()
        {
             driver.SwitchTo().Alert().Accept();
        }
    }
}
