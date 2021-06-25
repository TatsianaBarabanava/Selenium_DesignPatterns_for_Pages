using NUnit.Framework;


namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestDraftFolder : BaseTest
    {

         [Test]
        public void DraftContent()
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

            //Assert
            var ExpectedSender = draftPage.GetTextFromRecepientField(gmailEmail);
            var ExpectedSubject = draftPage.GetTextFromMailTopicField();
            var ExpectedContent = draftPage.GetTextFromContentField();
            Assert.AreEqual(ExpectedSender, gmailEmail);
            Assert.AreEqual(ExpectedSubject, emailSubject);
            Assert.AreEqual(ExpectedContent, draftPage.GetTextFromContentField());
        }
    }
}