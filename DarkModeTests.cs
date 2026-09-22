using Microsoft.Playwright;
using Microsoft.Playwright.Xunit;

namespace TestDemo.Tests;

public class DarkModeTests : PageTest
{
    private const string BaseUrl = "http://localhost:5243";

    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            ColorScheme = ColorScheme.Light
        };
    }

    [Fact]
    public async Task DarkModeCanBeEnabled()
    {
        await OpenHomePageAsync();
        await SelectThemeAsync("Dark");

        Assert.Equal("dark", await Page.Locator("html").GetAttributeAsync("data-bs-theme"));
        Assert.Equal(1, await Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome" }).CountAsync());
    }

    [Fact]
    public async Task DarkModeKeepsContentAndControlsUsable()
    {
        await OpenHomePageAsync();
        await SelectThemeAsync("Dark");

        var heading = Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome" });
        var navigationLink = Page.GetByRole(AriaRole.Link, new() { Name = "Home" });

        await Expect(heading).ToBeVisibleAsync();
        await Expect(navigationLink).ToBeVisibleAsync();
        Assert.NotEqual(
            await Page.Locator("html").EvaluateAsync<string>("element => getComputedStyle(element).backgroundColor"),
            await Page.Locator("body").EvaluateAsync<string>("element => getComputedStyle(element).color"));
    }

    [Fact]
    public async Task DarkModeCanBeDisabled()
    {
        await OpenHomePageAsync();
        await SelectThemeAsync("Dark");
        await SelectThemeAsync("Light");

        Assert.Equal("light", await Page.Locator("html").GetAttributeAsync("data-bs-theme"));
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome" })).ToBeVisibleAsync();
    }

    [Fact]
    public async Task DefaultThemeAndControlsAreAvailableInitially()
    {
        await OpenHomePageAsync();

        Assert.Equal("light", await Page.Locator("html").GetAttributeAsync("data-bs-theme"));
        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Welcome" })).ToBeVisibleAsync();
        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "Home" })).ToBeVisibleAsync();
    }

    private async Task OpenHomePageAsync()
    {
        await Page.GotoAsync(BaseUrl);
        await Expect(Page).ToHaveTitleAsync("Home Page - TestDemo");
    }

    private async Task SelectThemeAsync(string theme)
    {
        var themeTrigger = Page.Locator("#themeDropdown");
        await themeTrigger.ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() { Name = theme }).ClickAsync();
    }
}