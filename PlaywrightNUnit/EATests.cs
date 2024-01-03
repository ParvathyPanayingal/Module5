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
        [Test]
        public async Task LoginTest()
        {

            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("http://eaapp.somee.com/");
            Console.WriteLine("Page Loaded");

           // await Page.GetByText("Login").ClickAsync();//await-since it is asynchronous operation.
            var lnkLogin= Page.Locator(selector: "text=Login");
            await lnkLogin.ClickAsync();//if we want to do more than one action on an element 
            await Console.Out.WriteLineAsync("Login Link Clicked");
            await Expect(Page).ToHaveURLAsync("http://eaapp.somee.com/Account/Login");

            //await Page.GetByLabel("UserName").FillAsync(value:"admin");
            //await Page.GetByLabel("Password").FillAsync(value:"password");
            //await Console.Out.WriteLineAsync("Typed");

            await Page.Locator("#UserName").FillAsync(value: "admin");
            await Page.Locator("#Password").FillAsync(value: "password");
            await Console.Out.WriteLineAsync("Typed");

            //await Page.Locator("//input[@value='Log in']").ClickAsync();
            var btnLogin = Page.Locator(selector: "input",
               new PageLocatorOptions { HasTextString="Log in"} );//here locating th element so no need of await
            await btnLogin.ClickAsync();
            await Console.Out.WriteLineAsync("Login button clicked");
            await Expect(Page).ToHaveTitleAsync("Home - Execute Automation Employee App");
        }
    }
}
