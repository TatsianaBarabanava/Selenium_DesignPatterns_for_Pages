using NUnit.Framework;
using OpenQA.Selenium;


namespace SeleniumWebDriver
{
    [TestFixture]
    public class BaseTest : Browser
    {
        protected IWebDriver driver;
        protected string baseUrl;
        protected string gmailEmail = "snieczka@gmail.com";
        protected string sender = "Tatsiana Barabanava";
        protected string emailSubject = "Test Email";
        protected string emailContent = "Hello, My Gmail Mailbox";
        protected string yandexEmail = "snieczka@yandex.by";
        protected string composeLinkText = "Написать письмо";
        protected string login = "Snieczka";
        protected string password = "2020327abc";

        [SetUp]
        public void TestSetup()
        {
            this.driver = Browser.GetDriver();
            this.baseUrl = YandexHomePage.url;

            Browser.NavigateTo(this.baseUrl);
            Browser.WindowMaximize();
            
            var homePage = new YandexHomePage();
            homePage.ClickOnLoginButton();
            new YandexLoginPage().Login(login, password);
            homePage.WaitForComposeLinkIsVisible();
        }

        [TearDown]
          public void CleanUp()
         {
             Browser.Quit();
         }
    }
}