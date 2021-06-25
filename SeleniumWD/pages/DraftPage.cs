using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumWebDriver
{
    public class DraftPage : BaseMailPage
    {
        public static readonly String url = "https://mail.yandex.by/u2709/?uid=1437990165#draft";
        private static readonly By draftMail = (By.XPath("//span[text()='Создать шаблон']"));
        public DraftPage() : base(draftMail, "Draft Mail") 
        {
            PageFactory.InitElements(Browser.GetDriver(),this);
        }

        [FindsBy(How = How.XPath, Using = "//span[contains(@class,'js-toolbar-item-title-delete')]")]
        private IWebElement deleteButton;

        public void ClickOnDeleteButton()
        {
            deleteButton.Click();
        }
    }
}