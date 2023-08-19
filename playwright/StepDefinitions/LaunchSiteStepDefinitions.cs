using Microsoft.Playwright;
using playwright.Support;

namespace playwright.StepDefinitions;

[Binding]
public class LaunchSiteStepDefinitions
{
    private IPage _page;

    public LaunchSiteStepDefinitions(PlayWrightContext context)
    {
        _page = context.Page;
    }

    [Given(@"the site of the url")]
    public async Task GivenTheSiteOfTheUrl()
    {
        await _page.GotoAsync("https://thinking-tester-contact-list.herokuapp.com/");
    }

    [Then(@"the title of the page is '([^']*)'")]
    public async Task ThenTheTitleOfThePageIs(string p0)
    {
        var title = await _page.TitleAsync();
        title.Should().Be(p0);
    }
}