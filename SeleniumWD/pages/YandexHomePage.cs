﻿using System;
using OpenQA.Selenium;


namespace SeleniumWebDriver
{
    public class YandexHomePage : BaseMailPage
    {
        public static readonly String url = "https://yandex.by";
        private static readonly By diskLinkXpath = By.XPath("//a[contains(@href, 'disk')]");
        public YandexHomePage() : base(diskLinkXpath, "Home Page") { }
        private static readonly BaseElement loginButton = new BaseElement(By.XPath("//div[@class='desk-notif-card__login-new-item-title']"));
        private static readonly BaseElement composeLink = new BaseElement(By.XPath("//a[contains(@href,'/compose')]"));

        public void ClickOnLoginButton()
        {
            loginButton.Click();
        }

        public void WaitForComposeLinkIsVisible()
        {
            composeLink.WaitForIsVisible();
        }

        public string GetTextFromComposeLink()
        {
            return composeLink.GetText();
        }

        public void ClickOnComposeLink()
        {
            composeLink.Click();
        }
    }
}