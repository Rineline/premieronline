using System.Runtime.CompilerServices;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework.Internal.Execution;

namespace PlaywrightTests;

[TestFixture]

public class Tests : PageTest
{
    private ILocator Header => Page.Locator(".uk-navbar-container").First;
    private ILocator Logo => Header.Locator("a.uk-logo");
    private ILocator LogoImage => Logo.GetByRole(AriaRole.Img);
    private ILocator NavBar => Header.Locator(".uk-navbar-nav");
    private ILocator Links => NavBar.GetByRole(AriaRole.Link);
    private ILocator EventsLink => Links.GetByText("Events");
    private ILocator RatingsLink => Links.GetByText("Ratings");
    private ILocator HelpLink => Links.GetByText("Help");
    private ILocator ArLink => Links.GetByText("عربى");
    //private ILocator Buttons => NavBar.GetByRole(AriaRole.Button);

    private ILocator ButtonSignIn => Header.GetByRole(AriaRole.Link, new() { Name = "Sign in" });
   
    private ILocator ButtonCreateAccount => Header.GetByRole(AriaRole.Link, new() { Name = "Create Account" });



    [SetUp]

    public async Task OpenHome()
    {
        await Page.GotoAsync("https://www.premieronline.com/");
    }


    [Test]
    public async Task OpenPage()
    {

        //await Expect(Page).ToHaveURLAsync("https://www.premieronline.com/");
        await Expect(Page).ToHaveTitleAsync("Premier Online - leading provider of online event registration for sports events");

    }

    [Test]
    public async Task HeaderVisible()
    {
        await Expect(Header).ToBeVisibleAsync();
        await Expect(Logo).ToHaveAttributeAsync("href", "https://www.premieronline.com");
        await Expect(LogoImage).ToHaveAttributeAsync("alt", "Premiere Online");
        await Expect(LogoImage).ToHaveAttributeAsync("src", "https://www.premieronline.com/assets/img/logo.svg");

    }

    [Test]
    public async Task HeaderLinks()
    {
        await Expect(EventsLink).ToHaveAttributeAsync("href", "https://www.premieronline.com/calendar");
        await Expect(RatingsLink).ToHaveAttributeAsync("href", "https://www.premieronline.com/event_ratings.php");
        await Expect(HelpLink).ToHaveAttributeAsync("href", "https://www.premieronline.com/help");
        await Expect(ArLink).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/lang.php?lang=ar");

    }

    [Test]
    public async Task HeaderButtons()
    {
        await Expect(ButtonSignIn).ToBeVisibleAsync();
        await Expect(ButtonSignIn).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/dologin");
        await ButtonSignIn.ClickAsync();

    }


}
