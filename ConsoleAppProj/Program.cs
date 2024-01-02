
using Microsoft.Playwright;
//using is a keyword in c#,it will be automatically handled by the garbage collector after the use.
//Generally we use using For localized instances.We can also decalre globally.
//await-foy async operation.
//we care creating an aynchronous instnaces for playwright.
using var playwright = await Playwright.CreateAsync();

//chrominum-ms edge and google chrome both works on chromium.
//launch browser
await using var browser=await playwright.Chromium.LaunchAsync();

//page instance
var context=await browser.NewContextAsync();
var page=await context.NewPageAsync();

Console.WriteLine("Opened Browser");
await page.GotoAsync("https://www.google.com");
Console.WriteLine("Page Loaded");

string title=await page.TitleAsync();
Console.WriteLine(title);

await page.GetByTitle("Search").FillAsync("hp laptop");
//await page.Locator("#APjFgb").FillAsync("hp laptop");//another method,# for id,. for class
Console.WriteLine("Typed");
await page.Locator("(//input[@value='Google Search'])[2]").ClickAsync();
Console.WriteLine("Clicked");

title=await page.TitleAsync();
Console.WriteLine(title);


