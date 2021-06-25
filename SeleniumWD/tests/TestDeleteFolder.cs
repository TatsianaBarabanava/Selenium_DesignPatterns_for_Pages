using NUnit.Framework;


namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestDeleteFolder : BaseTest
    {
        [Test]
        public void DeleteFolder()
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
            draftPage.selectEmailByNumber(0);
            draftPage.ClickOnDeleteButton();
            draftPage.ClickOnDeleteFolder();
            var deletePage = new DeletePage();

            //Assert
            var ExpectedSender = deletePage.GetTextFromRecepientField(yandexEmail);
            var ExpectedSubject = deletePage.GetTextFromMailTopicField();
            var ExpectedContent = deletePage.GetTextFromContentField();
            Assert.AreEqual(ExpectedSender, sender);
            Assert.AreEqual(ExpectedSubject, emailSubject);
            Assert.AreEqual(ExpectedContent, deletePage.GetTextFromContentField());
        }
    }
}