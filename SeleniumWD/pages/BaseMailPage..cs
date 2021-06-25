using OpenQA.Selenium;


namespace SeleniumWebDriver
{
    public class BaseMailPage : BasePage
    {
        private static readonly By inboxLinkXpath = By.XPath("//span[text()='Входящие']");
        private static readonly BaseElement inboxLink = new BaseElement(inboxLinkXpath);
        public BaseMailPage() : base(inboxLinkXpath, "Inbox Mail") { }
        private static readonly BaseElement sendLink = new BaseElement(By.XPath("//span[text()='Отправленные']"));
        private static readonly BaseElement deletedLink = new BaseElement(By.XPath("//span[text()='Удалённые']"));
        private static readonly BaseElement draftLink = new BaseElement(By.XPath("//span[text()='Черновики']"));
        private static readonly BaseElement resendLink = new BaseElement(By.XPath("//div[@title='Переслать (f)']"));
        private static readonly BaseElement createDraftIcon = new BaseElement(By.XPath("//span[text()='Создать шаблон']"));
        private static readonly BaseElement mailTopicField = new BaseElement(By.XPath("//span[contains(@class,'mail-MessageSnippet-Item_subject')]"));
        private static readonly BaseElement contentField = new BaseElement(By.XPath("//span[contains(@class,'mail-MessageSnippet-Item_firstline')]"));
        private static readonly BaseElement sendButton = new BaseElement(By.XPath("//button[contains(@class,'ComposeControlPanelButton-Button_action')]"));
        private static readonly BaseElement sendNotification = new BaseElement(By.XPath("//span[text()='Письмо отправлено']"));
        private static readonly BaseElement checkboxEmailsList = new BaseElement(By.XPath("//div[@class=' js-messages-item-checkbox mail-MessageSnippet-CheckboxNb-Container']"));

        protected BaseMailPage(By TitleLocator, string Title) : base(TitleLocator, Title)
        {
            titleLocator = TitleLocator;
            title = titleForm = Title;
            AssertIsOpen();
        }

        public void selectEmailByNumber(int Number)
        {
            checkboxEmailsList.GetElements()[Number].Click();
        }

        public void WaitForSendNotificationIsVisible()
        {
            sendNotification.WaitForIsVisible();
        }

        public void WaitForRecepientFieldIsVisible(string Email)
        {
            GetRecepientFieldXPath(Email).WaitForIsVisible();
        }

        public void WaitForCreateDraftIconIsVisible()
        {
            createDraftIcon.WaitForIsVisible();
        }

        public void WaitForDeletedEmailIsVisible()
        {
            contentField.WaitForIsVisible();
        }

        public void WaitForResendLinkIsVisible()
        {
            resendLink.WaitForIsVisible();
        }

        private BaseElement GetRecepientFieldXPath(string Email)
        {
            return new BaseElement(By.XPath("//span[contains(@title,'" + Email + "')]"));
        }

        public string GetTextFromRecepientField(string Email)
        {
            return GetRecepientFieldXPath(Email).GetText();
        }

        public string GetTextFromMailTopicField()
        {
            return mailTopicField.GetText();
        }

        public string GetTextFromContentField()
        {
            return contentField.GetText();
        }

        public void ClickOnSendButton()
        {
            sendButton.Click();
        }
        
        public void ClickOnRecepientField(string Email)
        {
            GetRecepientFieldXPath(Email).Click();
        }

        public void ClickOnDeleteFolder()
        {
            deletedLink.Click();
        }

        public void ClickOnSendFolder()
        {
            sendLink.Click();
        }

        public void ClickOnInboxFolder()
        {
            inboxLink.Click();
        }

        public void ClickOnDraftLink()
        {
            draftLink.Click();
        }

        public int CountEmails(string Email)
        {
            return GetRecepientFieldXPath(Email.Split('@')[0]).Count();
        }

        public int CountEmailsWWithWait(string Email)
        {
            return GetRecepientFieldXPath(Email.Split('@')[0]).Count();
        }
    }
}