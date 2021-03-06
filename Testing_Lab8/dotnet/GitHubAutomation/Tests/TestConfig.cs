﻿using System;
using System.IO;
using Framework.Driver;
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
            Driver = DriverSingleton.GetDriver();
            Driver.Navigate().GoToUrl("https://zhd.online");
        }

        [OneTimeTearDown]
        public void TimeTearDown()
        {
            if(TestContext.CurrentContext.Result.Outcome!=ResultState.Success)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\screen" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
            }
            DriverSingleton.CloseDriver();
        }
    }
}
