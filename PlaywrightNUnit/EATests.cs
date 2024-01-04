using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightNUnit
{
    [TestFixture]
    internal class EATests:PageTest
    {
        [SetUp]
        public async Task SetUp()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("http://eaapp.somee.com/",
                new PageGotoOptions
                { Timeout=3000,WaitUntil=WaitUntilState.DOMContentLoaded});
            Console.WriteLine("Page Loaded");
        }
        [Test]
        public async Task LoginTest()
        {
            // await Page.GetByText("Login").ClickAsync();//await-since it is asynchronous operation.
            //var lnkLogin= Page.Locator(selector: "text=Login");
            //await lnkLogin.ClickAsync();//if we want to do more than one action on an element 

            await Page.ClickAsync(selector: "text=Login", new PageClickOptions
            { Timeout=1000});
            await Console.Out.WriteLineAsync("Login Link Clicked");
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");

            //way 1
            //await Page.GetByLabel("UserName").FillAsync(value:"admin");
            //await Page.GetByLabel("Password").FillAsync(value:"password");
            //await Console.Out.WriteLineAsync("Typed");

            //way2
            //await Page.Locator("#UserName").FillAsync(value: "admin");//instead of # we can write css=button.
            //await Page.Locator("#Password").FillAsync(value: "password");
            //await Console.Out.WriteLineAsync("Typed");

            //way3
            await Page.FillAsync(selector: "#UserName", "admin");
            await Page.FillAsync(selector: "#Password", "password");
            await Console.Out.WriteLineAsync("Typed");

            //await Page.Locator("//input[@value='Log in']").ClickAsync();
            var btnLogin = Page.Locator(selector: "input",
               new PageLocatorOptions { HasTextString="Log in"} );//here locating th element so no need of await
            await btnLogin.ClickAsync();
            await Console.Out.WriteLineAsync("Login button clicked");

            //way 1 for expect(page).
            await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");

            //way 2 for expect(locator).
            await Expect(Page.Locator(selector: "text='Hello admin!'")).ToBeVisibleAsync();

            //to check multiple conditions-multiple expect
            await Expect(Page.Locator(selector: "text='Hello admin!'"))
                .ToBeVisibleAsync();
        }
    }
}
