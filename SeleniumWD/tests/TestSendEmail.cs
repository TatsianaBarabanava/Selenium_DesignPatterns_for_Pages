using NUnit.Framework;


namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestSendEmail : BaseTest
    {
       
        [Test]
        public void SendEmail()
        {
           //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            Browser.SwitchToLastWindow();

            //Act
            var mailPage = new MailPage();
            mailPage.WaitForRecepientFieldIsVisible();
            mailPage.ComposeEmailWithRandomContent(gmailEmail, emailSubject);
            Browser.PressEscape();
            mailPage.WaitForResendLinkIsVisible();
            mailPage.ClickOnDraftLink();
            var draftPage = new DraftPage();
            draftPage.WaitForRecepientFieldIsVisible(gmailEmail);
            int actualNumberOfDrafts = draftPage.CountEmails(gmailEmail);
            draftPage.ClickOnRecepientField(gmailEmail);
            draftPage.ClickOnSendButton();
            draftPage.WaitForSendNotificationIsVisible();
            Browser.PressEscape();
            Browser.RefreshPage();

            //Assert
            bool expectedNumberOfDrafts = draftPage.CountEmails(gmailEmail).Equals(actualNumberOfDrafts - 1);
            Assert.IsTrue(expectedNumberOfDrafts);
        }
    }
}