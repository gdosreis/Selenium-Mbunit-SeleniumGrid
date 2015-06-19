using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1.PageObjects
{
    public class LoginPage : PageBase
    {
        [FindsBy(How = How.Id)]
        protected IWebElement email;

        [FindsBy(How = How.Name)]
        protected IWebElement Password;

        [FindsBy(How = How.CssSelector, Using = "div[class='error_tips23']")]
        protected IWebElement userNameError;

        [FindsBy(How = How.CssSelector, Using = "#loginForm > div:nth-child(5)")]
        protected IWebElement passwordError;

        [FindsBy(How = How.CssSelector, Using = "div.error_tips.all_error_tips")]
        protected IWebElement loginValidation;

        [FindsBy(How = How.Id)]
        protected IWebElement login_btn;

        private WebDriverWait wait;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver,this);
            wait = new WebDriverWait(this.driver, new TimeSpan(0, 0, 15));
        }

        /// <summary>
        /// Method to verify if the Email field is present.
        /// </summary>
        public bool IsEmailFieldPresent()
        {
            return email.Displayed && email.Enabled;
        }

        /// <summary>
        /// Method to verify if the Password field is present.
        /// </summary>
        public bool IsPasswordFieldPresent()
        {
            return Password.Displayed && Password.Enabled;
        }

        /// <summary>
        /// Method to verify if the Login button is present.
        /// </summary>
        public bool IsLoginButtonPresent()
        {
            return login_btn.Displayed && login_btn.Enabled;
        }

        /// <summary>
        /// Method to set the email value.
        /// </summary>
        public void SetEmail(string mail)
        {
            email.Clear();
            email.SendKeys(mail); 
            
        }

        /// <summary>
        /// Method to set the password value.
        /// </summary>
        public void SetPassword(string pass)
        { 
          Password.Clear();
          Password.SendKeys(pass); 
        }

        /// <summary>
        /// Method to click Login button.
        /// </summary>
        public void ClickLogingButton()
        { login_btn.Click(); }

        /// <summary>
        /// Method to verify if the Password validation is present.
        /// </summary>
        public bool IsPasswordValidationPresent() 
        { return passwordError.Displayed; }

        /// <summary>
        /// Method to verify if the username validation is present.
        /// </summary>
        public bool IsUsernameValidationPresent()
        { return userNameError.Displayed; }

        /// <summary>
        /// Method to verify if the login validation is present.
        /// </summary>
        public bool IsLoginValidationPresent() 
        { return loginValidation.Displayed; }

        /// <summary>
        /// Method to perform a login.
        /// </summary>
        public HomePage Login(string mail, string pass)
        {
            SetEmail(mail);
            SetPassword(pass);
            ClickLogingButton();
            return new HomePage(this.driver);
        }
    }
}
