namespace _202502PlaywrightExs.Tests
{
    public class LoginUserTest : SetUp
    {
        // Test method for logging in
        [Test, Order(2)]
        public async Task Login()
        {
            // Navigate to the login page
            await _page.GotoAsync(_testData.BaseUrl);

            // Fill in the login form
            await _page.FillAsync(_testData.Credentials.EmailLocator, _testData.Credentials.EmailValue);
            await _page.FillAsync(_testData.Credentials.PasswordLocator, _testData.Credentials.PasswordValue);

            // Submit the login form
            await _page.ClickAsync(_testData.Buttons.Submit);

            await Task.Delay(2000);

            // Assert that the login was successful by checking the URL
            var currentUrl = _page.Url;
            Assert.That(currentUrl, Does.Contain(_testData.Urls.Contacts));

            await Task.Delay(2000);
        }
    }
}
