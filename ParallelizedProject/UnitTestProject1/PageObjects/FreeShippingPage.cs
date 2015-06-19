using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTestProject1.PageObjects
{
    public class FreeShippingPage : DxBasePage
    {
        [FindsBy(How = How.Id, Using = "dialog_box")]
        protected IWebElement dialogBox;

        [FindsBy(How = How.CssSelector, Using = "div.live_chat a[id^='lpChatBtnHref']")]
        protected IWebElement chatButton;

        [FindsBy(How = How.Id)]
        protected IWebElement FeedbackOK;

        [FindsBy(How = How.CssSelector, Using = "label:nth-child(2) input")]
        protected IWebElement FeedbackYes;

        [FindsBy(How = How.CssSelector, Using = "label:nth-child(3) input")]
        protected IWebElement FeedbackNo;

        [FindsBy(How = How.Id)]
        protected IWebElement FeedbackSuccess;

        [FindsBy(How = How.ClassName)]
        protected IWebElement close;


        public FreeShippingPage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// Method to verify if be in Free Shipping page
        /// </summary>
        public bool AreFreeShipingElementsPresents()
        {
            return dialogBox.Displayed && dialogBox.Enabled && chatButton.Displayed && chatButton.Enabled && FeedbackOK.Displayed && FeedbackOK.Enabled;
        }

        /// <summary>
        /// Method to verify if the corresponding option is selected.
        /// </summary>
        public bool IsCheckedYesOption()
        {
            return FeedbackYes.Selected;
        }

        /// <summary>
        /// Method to verify if the corresponding option is selected.
        /// </summary>
        public bool IsCheckedNoOption()
        {
            return FeedbackNo.Selected;
        }

        /// <summary>
        /// Method to select the YES option
        /// </summary>
        public void CheckYesOption()
        {
            FeedbackYes.Click();
        }

        /// <summary>
        /// Method to select the NO option.
        /// </summary>
        public void CheckNoOption()
        {
            FeedbackNo.Click();
        }

        /// <summary>
        /// Method to click Submit button.
        /// </summary>
        public void ClickSubmitButton()
        {
            FeedbackOK.Click();
        }

        /// <summary>
        /// Method to verify is the respons was submited
        /// </summary>
        public bool IsSubmitedRespons()
        {
            return FeedbackSuccess.Displayed;
        }

        /// <summary>
        /// Method to verify is the Dialog Box is present
        /// </summary>
        public bool IsDialogPresent()
        {
            return dialogBox.Displayed;
        }

        /// <summary>
        /// Method to close the dialog box.
        /// </summary>
        public void ClickCloseDialogButton() 
        {
            close.Click();
        }
    }
}
