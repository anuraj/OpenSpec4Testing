using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace TestDemo.Tests;

public class ResponsiveLayoutTests : PageTest
{
    private const string BaseUrl = "http://localhost:5243/";

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            ColorScheme = ColorScheme.Light
        };
    }

    [Theory]
    [InlineData(375, 667)]
    [InlineData(768, 1024)]
    [InlineData(1280, 800)]
    [InlineData(667, 375)]
    public async Task MainPageFitsViewport(int width, int height)
    {
        await OpenHomePageAsync(width, height);

        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome" })).ToBeVisibleAsync();
        Assert.True(await Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome" }).BoundingBoxAsync() is not null);
        Assert.True(await Page.EvaluateAsync<int>("() => document.documentElement.scrollWidth") <= width);
    }

    [Fact]
    public async Task MobileNavigationCanBeOpened()
    {
        await OpenHomePageAsync(375, 667);

        var menuButton = Page.GetByRole(AriaRole.Button, new() { Name = "Toggle navigation" });
        await Expect(menuButton).ToBeVisibleAsync();
        await menuButton.ClickAsync();

        var navigation = Page.Locator(".navbar-collapse");
        await Expect(navigation).ToBeVisibleAsync();
        await Expect(navigation.GetByRole(AriaRole.Link, new() { Name = "Home" })).ToBeVisibleAsync();
        await Expect(navigation.GetByRole(AriaRole.Link, new() { Name = "Privacy" })).ToBeVisibleAsync();
    }

    [Fact]
    public async Task DesktopNavigationIsAvailableWithoutExpansion()
    {
        await OpenHomePageAsync(1280, 800);

        await Expect(Page.GetByRole(AriaRole.Button, new() { Name = "Toggle navigation" })).ToBeHiddenAsync();
        var navigation = Page.Locator(".navbar-collapse");
        await Expect(navigation.GetByRole(AriaRole.Link, new() { Name = "Home" })).ToBeVisibleAsync();
        await Expect(navigation.GetByRole(AriaRole.Link, new() { Name = "Privacy" })).ToBeVisibleAsync();
        await Expect(navigation.Locator("#themeDropdown")).ToBeVisibleAsync();
    }

    private async Task OpenHomePageAsync(int width, int height)
    {
        await Page.SetViewportSizeAsync(width, height);
        await Page.GotoAsync(BaseUrl);
        await Expect(Page).ToHaveTitleAsync("Home Page - TestDemo");
    }
}