using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;


namespace PlaywrightTests;

[TestFixture]
public class Tests : PageTest
{
    public override BrowserNewContextOptions ContextOptions() => new()
    {
        ViewportSize = new() { Width = 1280, Height = 720 },
    };

    private ILocator Header => Page.Locator(".uk-navbar-container").First;
    private ILocator Logo => Header.Locator("a.uk-logo");
    private ILocator LogoImage => Logo.GetByRole(AriaRole.Img);
    private ILocator NavBar => Header.Locator(".uk-navbar-nav");
    private ILocator Links => NavBar.GetByRole(AriaRole.Link);
    private ILocator EventsLink => NavBar.GetByRole(AriaRole.Link, new() { Name = "Events", Exact = true });
    private ILocator RatingsLink => NavBar.GetByRole(AriaRole.Link, new() { Name = "Ratings", Exact = true });
    private ILocator HelpLink => NavBar.GetByRole(AriaRole.Link, new() { Name = "Help", Exact = true });
    private ILocator ArabicLink => NavBar.GetByRole(AriaRole.Link, new() { Name = "عربى", Exact = true });
    private ILocator ButtonSignIn => Header.GetByRole(AriaRole.Link, new() { Name = "Sign in" });
    private ILocator ButtonCreateAccount => Header.GetByRole(AriaRole.Link, new() { Name = "Create Account" });
    private ILocator FirstName => Page.Locator("#first_name");
    private ILocator LastName => Page.Locator("#last_name");
    private ILocator Email => Page.Locator("#email");
    private ILocator Password => Page.Locator("#password");
    private ILocator PasswordRepeat => Page.Locator("#password_repeat");
    private ILocator LoginName => Page.Locator("#login_name");
    private ILocator ButtonContinue => Page.GetByRole(AriaRole.Button, new() { Name = "Continue" });
    private ILocator ButtonSignInConfirm => Page.GetByRole(AriaRole.Button, new() { Name = "Sign in" });



    [SetUp]

    public async Task OpenHome()
    {
        await Page.GotoAsync("https://www.premieronline.com/");

    }


    [Test]
    public async Task OpenPage()
    {
        await Expect(Page).ToHaveURLAsync("https://www.premieronline.com/");
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
        await Expect(ArabicLink).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/lang.php?lang=ar");
    }

    [Test]
    public async Task HeaderButtons()
    {
        await Expect(ButtonSignIn).ToBeVisibleAsync();
        await Expect(ButtonSignIn).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/dologin");
        await ButtonSignIn.ClickAsync();
        await Expect(ButtonSignIn).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/dologin");
    }


    [Test]
    public async Task CreateAccount()
    {
        await ButtonCreateAccount.ClickAsync();
        await Expect(ButtonCreateAccount).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/register");

        await Expect(FirstName).ToBeVisibleAsync();
        await Expect(LastName).ToBeVisibleAsync();
        await Expect(Email).ToBeVisibleAsync();
        await Expect(Password).ToBeVisibleAsync();
        await Expect(PasswordRepeat).ToBeVisibleAsync();

        await Expect(FirstName).ToBeEnabledAsync();
        await Expect(LastName).ToBeEnabledAsync();
        await Expect(Email).ToBeEnabledAsync();
        await Expect(Password).ToBeEnabledAsync();
        await Expect(PasswordRepeat).ToBeEnabledAsync();


        await FirstName.FillAsync("Test");
        await LastName.FillAsync("User");
        await Email.FillAsync("test.usernew@example.com");
        await Password.FillAsync("*****");
        await PasswordRepeat.FillAsync("*****");

        await Expect(FirstName).ToHaveValueAsync("Test");
        await Expect(LastName).ToHaveValueAsync("User");
        await Expect(Email).ToHaveValueAsync("test.usernew@example.com");
        await Expect(Password).ToHaveValueAsync("*****");
        await Expect(PasswordRepeat).ToHaveValueAsync("*****");

        Console.WriteLine($"First name: {await FirstName.InputValueAsync()}");
        Console.WriteLine($"Last name: {await LastName.InputValueAsync()}");
        Console.WriteLine($"Email: {await Email.InputValueAsync()}");
        Console.WriteLine($"Password: {await Password.InputValueAsync()}");
        Console.WriteLine($"PasswordRepeat: {await PasswordRepeat.InputValueAsync()}");
    }

    [Test]
    public async Task SignIn()
    {
        await ButtonSignIn.ClickAsync();
        await Expect(ButtonSignIn).ToHaveAttributeAsync("href", "https://www.premieronline.com/action/dologin");
        await Expect(LoginName).ToBeVisibleAsync();
        await Expect(Password).ToBeVisibleAsync();

        await Expect(LoginName).ToBeEnabledAsync();
        await Expect(Password).ToBeEnabledAsync();

        await LoginName.FillAsync("test.usernew@example.com");
        await Password.FillAsync("*****");

        //await Expect(ButtonSignInConfirm).ToBeVisibleAsync();
        //await ButtonSignInConfirm.ClickAsync();

        Console.WriteLine($"LoginName: {await LoginName.InputValueAsync()}");
        Console.WriteLine($"Password: {await Password.InputValueAsync()}");
    }
}



