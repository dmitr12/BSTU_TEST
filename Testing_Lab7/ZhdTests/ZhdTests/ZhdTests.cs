using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ZhdTests.Driver;
using ZhdTests.Model;
using ZhdTests.Pages;
using ZhdTests.Services;

namespace WebDriver
{
    [TestClass]
    public class ZhdTests
    {
        [TestMethod]
        public void FindTicketWithoutIndicateSeat()
        {
            DriverSingleton.GetDriver().Navigate().GoToUrl("https://zhd.online");
            TypeTrainPage typeTrainPage = new MainPage(DriverSingleton.GetDriver())
                     .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties())
                     .ClickBuyFirstTicket()
                     .ClickTypeTrain();
            Assert.AreEqual("Необходимо выбрать 1 место", typeTrainPage.TextException.Text);
            DriverSingleton.CloseDriver();
        }
        [TestMethod]
        public void TrueRouteDate()
        {
            DriverSingleton.GetDriver().Navigate().GoToUrl("https://zhd.online");
            ListTicketsPage listTicketsPage = new MainPage(DriverSingleton.GetDriver())
                 .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties());
            Assert.AreNotEqual("0", listTicketsPage.CountRoute.Text);
            DriverSingleton.CloseDriver();
        }
    }
}
