using System;
using OpenQA.Selenium;


namespace SeleniumWebDriver
{
    public class YandexLoginPage : BaseMailPage
    {
        public static readonly String url = "https://passport.yandex.by/auth/welcome";
        private static readonly By loginFieldXpath = (By.Id("passp-field-login"));
        public YandexLoginPage() : base(loginFieldXpath, "Login Field") { }
        private static readonly BaseElement loginField = new BaseElement(loginFieldXpath);
        private static readonly BaseElement confirmationButton = new BaseElement(By.ClassName("Button2_view_action"));
        private static readonly BaseElement passwordField = new BaseElement(By.Id("passp-field-passwd"));

        public void TypeLogin(string Login)
        {
            loginField.SendKeys(Login);
        }

        public void ClickConfirmationButton ()
        {
            confirmationButton.Click();
        }

        public void TypePassword(string Password)
        {
            passwordField.SendKeys(Password);
        }

        public void Login (string Login, string Password)
        {
            TypeLogin(Login);
            ClickConfirmationButton();
            TypePassword(Password);
            ClickConfirmationButton();
        }
    }
}