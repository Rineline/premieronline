using System.Diagnostics.CodeAnalysis;
using Microsoft.Playwright;
 
namespace PlaywrightTests.Components;
 
public class HeaderComponent
{
    public HeaderComponent(IPage page)
    {
        Root = page.Locator(".uk-navbar-container").First;
    }
 
    public ILocator Root { get; }
    private static string Base => TestConfig.BaseUrl;
 
    
    public ILocator Logo => Root.Locator("a.uk-logo");
    public ILocator LogoImage => Logo.GetByRole(AriaRole.Img);
 
   
    private ILocator NavLinks => Root.Locator(".uk-navbar-nav").GetByRole(AriaRole.Link);
    public ILocator EventsLink => NavLinks.GetByText("Events", new() { Exact = true });
    public ILocator RatingsLink => NavLinks.GetByText("Ratings", new() { Exact = true });
    public ILocator HelpLink => NavLinks.GetByText("Help", new() { Exact = true });
    public ILocator ArabicLink => NavLinks.GetByText("عربى", new() { Exact = true });
 
    
    public ILocator SignInButton => Root.GetByRole(AriaRole.Link, new() { Name = "Sign in" });
    public ILocator CreateAccountButton => Root.GetByRole(AriaRole.Link, new() { Name = "Create Account" });

    private ILocator Search => Root.Locator("#login_name");
 
    public async Task CheckLogoAsync()
    {
        await Expect(Logo).ToBeVisibleAsync;
        await Expect(LogoImage).ToHaveAttributeAsync("alt", "Premiere Online");
        await Expect(LogoImage).ToHaveAttributeAsync("src", "Base/assets/img/logo.svg");
    } 
    public async Task CheckLinksAsync()
    {
        await Expect(EventsLink).ToHaveAttributeAsync("href", "https://www.premieronline.com/calendar");
        await Expect(RatingsLink).ToHaveAttributeAsync("href", "https://www.premieronline.com/event_ratings.php");
        await Expect(HelpLink).ToHaveAttributeAsync("href", "https://www.premieronline.com/help");
        await Expect(ArabicLink).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/lang.php?lang=ar");
    } 

        public async Task ClickCreateAccountButton()
    {
        await CreateAccountButton.ClickAsync();
        await Expect(CreateAccountButton).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/register");
    }
    
            public async Task ClickSingInButton()
    {
        await SignInButton.ClickAsync();
        await Expect(SignInButton).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/dologin");
    }

        public async Task CheckSearchAsync()
    {
        await Expect(Search).ToBeVisibleAsync;
    } 

            public async Task CheckSearchInputAsync()
    {
        //
    } 
}