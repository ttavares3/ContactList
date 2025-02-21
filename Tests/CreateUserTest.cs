namespace _202502PlaywrightExs.Tests
{
    public class CreateUserTest : SetUp
    {
        // Test method for filling the signup form
        [Test, Order(1)]
        public async Task Signup()
        {
            // Navigate to the 'login' page
            await _page.GotoAsync(_testData.BaseUrl);

            // Click the signup button
            await _page.ClickAsync(_testData.Buttons.SignUp);

            // Fill fields inside the form
            await _page.FillAsync(_testData.FormCreateUserAndContact.FirstNameLocator, _testData.FormCreateUserAndContact.FirstNameValue);
            await _page.FillAsync(_testData.FormCreateUserAndContact.LastNameLocator, _testData.FormCreateUserAndContact.LastNameValue);
            await _page.FillAsync(_testData.Credentials.EmailLocator, _testData.Credentials.EmailValue);
            await _page.FillAsync(_testData.Credentials.PasswordLocator, _testData.Credentials.PasswordValue);

            // Submit the form
            await _page.ClickAsync(_testData.Buttons.Submit);

            await Task.Delay(2000);

            // Assert that the redirection was successful by checking the URL
            var currentUrl = _page.Url;
            Assert.That(currentUrl, Does.Contain(_testData.Urls.Contacts));

            await Task.Delay(2000);
        }
    }
}
