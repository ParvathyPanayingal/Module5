using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PWPOM.PWTests.Pages;
using PWPOM.Test_Data_Classes;
using PWPOM.Utilities;

namespace PWPOM.PWTests.Tests
{
    public class LoginPageTests : PageTest
    {
        Dictionary<string, string> Properties;
        string? currdir;
        public void ReadConfigSettings()
        {
            Properties = new Dictionary<string, string>();
            currdir = Directory.GetParent(@"../../../")?.FullName;

            string? fileName = currdir + "/configsettings/config.properties";
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains('='))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    Properties[key] = value;
                }
            }
        }
        [SetUp]
        public async Task Setup()
        {
            ReadConfigSettings();
            Console.WriteLine("Opened Browser");
            await Page.GotoAsync(Properties["baseUrl"]);
            Console.WriteLine("Page Loaded");
        }

        [Test]
        //[TestCase("admin","password")]
        //[TestCase("admin","qqq")]
        public async Task LoginTest()
        {
            //LoginPage loginPage = new(Page);
            NewLoginPage loginPage = new(Page);
            string? excelFilePath = currdir + "/Test Data/GoogleData.xlsx";
            string? sheetName = "Login Data";

            List<EAText> excelDataList = LoginCredDataRead.ReadLoginData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                string? username = excelData.UserName;
                string? password = excelData.Password;

                await loginPage.ClickLogInLink();
                await loginPage.Login(username, password);
                await Page.ScreenshotAsync(new()
                {
                    Path = currdir + "Screenshots/screenshot.png",
                    //FullPage=true,
                });
                Assert.IsTrue(await loginPage.CheckWelcomeMssg());//expect doesn't work here since it is a boolean value.

            }
        }
    }
}