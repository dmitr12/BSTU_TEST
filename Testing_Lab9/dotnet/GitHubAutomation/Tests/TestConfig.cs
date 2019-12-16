using System;
using System.IO;
using Framework.Driver;
using GitHubAutomation.Log;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    public class TestConfig
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void Setter()
        {
            Logger.InitLogger();
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("https://zhd.online");
            Logger.Log.Debug("Navigated to https://zhd.online");
            Logger.Log.Debug("Starting test: "+TestContext.CurrentContext.Test.Name+"...");
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
                Logger.Log.Error("Error: " + TestContext.CurrentContext.Result.Message);
            }
            Logger.Log.Info("Test completed");
            DriverSingleton.CloseDriver();
            Logger.Log.Info("Driver closed");
        }

    }
}
