using NUnit.Framework;


namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestReceiveFolder : BaseTest
    {
        [Test]
        public void ReceiveFolder()
        {
            //Arrange
            var homePage = new YandexHomePage();
            homePage.ClickOnComposeLink();
            Browser.SwitchToLastWindow();

            //Act
            var mailPage = new MailPage();
            mailPage.WaitForRecepientFieldIsVisible();
            mailPage.ComposeEmailWithRandomContent(yandexEmail, emailSubject);
            Browser.PressEscape();
            mailPage.WaitForResendLinkIsVisible();
            mailPage.ClickOnDraftLink();
            var draftPage = new DraftPage();
            draftPage.WaitForRecepientFieldIsVisible(yandexEmail);
            draftPage.ClickOnRecepientField(yandexEmail); 
            draftPage.ClickOnSendButton();
            draftPage.WaitForSendNotificationIsVisible();
            Browser.PressEscape();
            draftPage.WaitForCreateDraftIconIsVisible();
            draftPage.ClickOnInboxFolder();
            var receivePage = new ReceivePage();
            Browser.RefreshPage();

            //Assert
            var ExpectedSender = receivePage.GetTextFromRecepientField(yandexEmail); 
            var ExpectedSubject = receivePage.GetTextFromMailTopicField();
            var ExpectedContent = receivePage.GetTextFromContentField();
            Assert.AreEqual(ExpectedSender, sender);
            Assert.IsTrue(ExpectedSubject.Contains(emailSubject));
            Assert.AreEqual(ExpectedContent, receivePage.GetTextFromContentField());
        }
    }
}