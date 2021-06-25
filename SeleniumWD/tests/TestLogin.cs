using NUnit.Framework;


namespace SeleniumWebDriver
{
    [TestFixture]
    public class TestLogin : BaseTest
    {

        [Test]
        public void Login()
        {
            //Arrange
            var homePage = new YandexHomePage();
            var expectedExpression = homePage.GetTextFromComposeLink();

            //Assert
            Assert.AreEqual(expectedExpression, composeLinkText);
        }
    }
}