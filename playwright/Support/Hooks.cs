using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;

namespace playwright.Support;

[Binding]
public sealed class Hooks
{
    private PlayWrightContext _context;

    public Hooks(PlayWrightContext context)
    {
        _context = context;
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        var browser = Environment.GetEnvironmentVariable("Browser");
        _context.Page = await CreatePageInstance(browser);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _context.Page = null;
    }

    private async Task<IPage> CreatePageInstance(string browser)
    {
        IBrowser _browser = default;
        var playwright = await Playwright.CreateAsync();
        if (browser == "firefox")
        {
            _browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
        }
        else
        {
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });

        }
        var context = await _browser.NewContextAsync();
        var page = await context.NewPageAsync();
        return page;
    }
}