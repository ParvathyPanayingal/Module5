using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlaywrightNUnit
{
    public class GHPTests :PageTest
    {
        [SetUp]
        public void Setup()
        {
        }
       
        //[Test]
        //public async Task Test1()
        //{
        //    using var playwright = await Playwright.CreateAsync();

        //    //launch browser
        //    await using var browser = await playwright.Chromium.LaunchAsync();

        //    //page instance
        //    var context = await browser.NewContextAsync();
        //    var page = await context.NewPageAsync();

        //    Console.WriteLine("Opened Browser");
        //    await page.GotoAsync("https://www.google.com");
        //    Console.WriteLine("Page Loaded");

        //    string title = await page.TitleAsync();
        //    Console.WriteLine(title);

        //    await page.GetByTitle("Search").FillAsync("hp laptop");
        //    //await page.Locator("#APjFgb").FillAsync("hp laptop");//another method,# for id,. for class
        //    Console.WriteLine("Typed");
        //    await page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
        //    Console.WriteLine("Clicked");

        //    title = await page.TitleAsync();
        //    Console.WriteLine(title);



        //}

        //playwright managed instance
        [Test]
        public async Task Test2()
        {

            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("https://www.google.com");
            Console.WriteLine("Page Loaded");

            string title = await Page.TitleAsync();
            Console.WriteLine(title);

            await Page.GetByTitle("Search").FillAsync("hp laptop");
            //await page.Locator("#APjFgb").FillAsync("hp laptop");//another method,# for id,. for class
            Console.WriteLine("Typed");
            await Page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
            Console.WriteLine("Clicked");

            title = await Page.TitleAsync();
            Console.WriteLine(title);


            Assert.That(title, Does.Contain("hp laptop"));
            //Expect(Page.TitleAsync()).Equals(""hp laptop"));
        }
    }
}