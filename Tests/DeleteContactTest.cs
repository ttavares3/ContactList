namespace _202502PlaywrightExs.Tests
{
    public class DeleteContactTest : LoginUserTest
    {
        // Test method to delete a contact
        [Test, Order(5)]
        public async Task DeleteContact()
        {
            await Login();

            // Click on the first contact in the table
            await _page.ClickAsync(_testData.TableLocator);

            // Call the alert to accept
            _page.Dialog += async (sender, dialog) =>
            {
                await _page.WaitForTimeoutAsync(1000);
                await dialog.AcceptAsync();
            };

            await Task.Delay(1000);

            // Click on the "Delete Contact" button
            await _page.ClickAsync(_testData.Buttons.Delete);

            await Task.Delay(1000);

            // Assert that the redirection was successful by checking the URL
            var currentUrl = _page.Url;
            Assert.That(currentUrl, Does.Contain(_testData.Urls.Contacts));

            await Task.Delay(2000);
        }
    }
}
