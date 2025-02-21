namespace _202502PlaywrightExs.Tests
{
    public class CreateContactAndLogoutTest : LoginUserTest
    {
        // Test method to add a contact, verify it, and logout
        [Test, Order(3)]
        public async Task CreateContactAndLogout()
        {
            // Call Login before Add a New Contact
            await Login();

            // Click on the "Add a New Contact" button
            await _page.ClickAsync(_testData.Buttons.AddContact);

            // Fill the fields in the contact form
            await _page.FillAsync(_testData.FormCreateUserAndContact.FirstNameLocator, _testData.FormCreateContact.FirstNameValue);
            await _page.FillAsync(_testData.FormCreateUserAndContact.LastNameLocator, _testData.FormCreateContact.LastNameValue);
            await _page.FillAsync(_testData.Credentials.EmailLocator, _testData.FormCreateContact.EmailValue);
            //...

            await Task.Delay(1000);

            // Click the "Submit" button to create the contact
            await _page.ClickAsync(_testData.Buttons.Submit);

            // Verify that the new contact appears in the table
            var newContactRow = await _page.InnerTextAsync(_testData.TableLocator);
            Assert.That(newContactRow, Does.Contain(_testData.FormCreateContact.FullNameValue));

            // Log out from the application
            await _page.ClickAsync(_testData.Buttons.LogOut);

            await Task.Delay(2000);

            // Assert that the redirection was successful by checking the URL
            var currentUrl = _page.Url;
            Assert.That(currentUrl, Does.Not.Contain(_testData.Urls.Login));

            await Task.Delay(2000);
        }
    }
}
