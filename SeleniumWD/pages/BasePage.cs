using OpenQA.Selenium;


namespace SeleniumWebDriver
{
    public class BasePage
    {
        protected By titleLocator;
        protected string title;
        public static string titleForm;

        protected BasePage(By TitleLocator, string Title)
        {
            titleLocator = TitleLocator;
            title = titleForm = Title;
            AssertIsOpen();
        }

        public void AssertIsOpen()
        {
            var label = new BaseElement(titleLocator, title);
            label.WaitForIsVisible();
        }
    }
}