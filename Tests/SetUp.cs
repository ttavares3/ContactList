using Microsoft.Playwright;

namespace _202502PlaywrightExs.Tests
{
    public class SetUp
    {
        protected IBrowser _browser;
        protected IPage _page;
        protected IDialog? _dialog;
        protected TestData _testData;

        // Setup method to initialize Playwright and open the browser
        [SetUp]
        public async Task Setup()
        {
            var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }); // Set to false to see the browser
            _page = await _browser.NewPageAsync();

            // Bring data from JSON
            _testData = TestData.LoadFromJson(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", "Helper.json"));
        }
        
        // TearDown method to close the browser after the test completes
        [TearDown]
        public async Task TearDown()
        {
            await _browser.CloseAsync();
        }
    }
}
