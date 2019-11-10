using OpenQA.Selenium;
using System;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace ZhdTests.Driver
{
    class DriverSingleton
    {
        private static IWebDriver driver;
        private DriverSingleton() { }

        public static IWebDriver GetDriver()
        {
            if(driver==null)
            {
                new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            return driver;
        }
        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
