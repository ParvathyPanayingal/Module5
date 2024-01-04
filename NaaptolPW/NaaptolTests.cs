using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;

namespace NaaptolPW
{
    [TestFixture]
    internal class NaaptolTests:PageTest
    {
        [SetUp]
        public async Task SetUp()
        {
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync("https://www.naaptol.com/");
            Console.WriteLine("Page Loaded");
        }

        [Test]
        public async Task SearchProduct()
        {
            await Page.Locator("#header_search_text").FillAsync("eyewear");
            
            await Console.Out.WriteLineAsync("Typed");
            //await Page.Locator(".search").ClickAsync();
            //await Console.Out.WriteLineAsync("Clicked on search button");
        }
    }
}
