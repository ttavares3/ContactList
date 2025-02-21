namespace _202502PlaywrightExs.Tests
{
    public class UpdateContactTest : LoginUserTest
    {
        // Test method to update an existing contact
        [Test, Order(4)]
        public async Task UpdateContact()
        {
            // Call Login before Update the Contact
            await Login();

            // Click on the first contact in the table
            await _page.ClickAsync(_testData.TableLocator);

            // Click on the "Edit Contact" button
            await _page.ClickAsync(_testData.Buttons.EditContact);

            // Edit the contact details
            await _page.FillAsync(_testData.FormCreateUserAndContact.FirstNameLocator, _testData.UpdateContact.FirstNameValue);
            await _page.FillAsync(_testData.FormCreateUserAndContact.LastNameLocator, _testData.UpdateContact.LastNameValue);
            //...

            // Click the "Submit" button
            await _page.ClickAsync(_testData.Buttons.Submit);

            // Click on the "Return to Contact List" button
            await _page.ClickAsync(_testData.Buttons.Return);

            // Verify that the contact is updated in the table
            var updatedContactRow = await _page.InnerTextAsync(_testData.TableLocator);
            Assert.That(updatedContactRow, Does.Contain(_testData.UpdateContact.FirstNameValue));
            Assert.That(updatedContactRow, Does.Contain(_testData.UpdateContact.LastNameValue));
            //...

            await Task.Delay(2000);
        }
    }
}
