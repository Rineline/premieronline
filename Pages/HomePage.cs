using Microsoft.Playwright;
using PlaywrightTests.Config;

namespace PlaywrightTests.Pages;
public class HomePage
{
    private readonly IPage _page;
    public HomePage(IPage page)
    {
        _page = page;
    }

    public async Task OpenAsync()=>await _page.GotoAsync($"{TestConfig.BaseUrl}/");
}

