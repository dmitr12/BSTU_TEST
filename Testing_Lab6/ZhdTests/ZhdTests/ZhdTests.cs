using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ZhdTests.Pages;

namespace WebDriver
{
    [TestClass]
    public class ZhdTests
    {
        IWebDriver driver = new ChromeDriver();
        [TestMethod]
        [Obsolete]
        public void FindTicketWithoutIndicateSeat()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://zhd.online");
            MainPage mainPage = new MainPage(driver).InputRouteDateAndClickSearch("Москва", "Казань");
            ListTicketsPage listTicketsPage = new ListTicketsPage(driver).ClickBuyFirstTicket();
            TypeTrainPage typeTrainPage = new TypeTrainPage(driver).ClickTypeTrain();
            Assert.AreEqual("Необходимо выбрать 1 место", typeTrainPage.TextException.Text);
            driver.Quit();
        }
        [TestMethod]
        [Obsolete]
        public void TrueRouteDate()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.zhd.online");
            MainPage mainPage = new MainPage(driver).InputRouteDateAndClickSearch("Москва", "Казань");
            Assert.AreNotEqual("0", new ListTicketsPage(driver).CountRoute.Text);
            driver.Quit();
        }
    }
}
