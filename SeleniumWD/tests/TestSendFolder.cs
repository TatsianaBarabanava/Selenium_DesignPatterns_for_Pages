using NUnit.Framework;


namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestSendFolder : BaseTest
    {
       
        [Test]
        public void SendFolder()
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
            draftPage.ClickOnRecepientField(gmailEmail);
            draftPage.ClickOnSendButton();
            draftPage.WaitForSendNotificationIsVisible();
            Browser.PressEscape();
            draftPage.WaitForCreateDraftIconIsVisible();
            draftPage.ClickOnSendFolder();
            var sendPage = new SendPage();

            //Assert
            var ExpectedSender = sendPage.GetTextFromRecepientField(gmailEmail);
            var ExpectedSubject = sendPage.GetTextFromMailTopicField();
            var ExpectedContent = sendPage.GetTextFromContentField();
            Assert.AreEqual(ExpectedSender, gmailEmail);
            Assert.AreEqual(ExpectedSubject, emailSubject);
            Assert.AreEqual(ExpectedContent, sendPage.GetTextFromContentField());
        }
    }
}