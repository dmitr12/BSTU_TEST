using System;
using System.IO;
using Framework.Driver;
using Framework.Pages;
using Framework.Services;
using GitHubAutomation.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;

namespace Framework.Tests
{
    class ZhdTests:TestConfig
    {
        [Test]
        [Category("SearchTest")]
        public void FindTicketWithoutIndicateSeat()
        {
            MakeScreenshotWhenFail(() =>
            {
                Driver.Navigate().GoToUrl("https://zhd.online");
                TypeTrainPage typeTrainPage = new MainPage(Driver)
                         .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties())
                         .ClickBuyFirstTicket()
                         .ClickTypeTrain();
                Assert.AreEqual("Необходимо выбрать 1 место", typeTrainPage.TextException.Text);

            });           
        }
        [Test]
        [Category("DateTest")]
        public void TrueRouteDate()
        {
            Driver.Navigate().GoToUrl("https://zhd.online");
            MakeScreenshotWhenFail(() =>
            {
                ListTicketsPage listTicketsPage = new MainPage(DriverSingleton.GetDriver())
                 .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties());
                Assert.AreNotEqual("0", listTicketsPage.CountRoute.Text);
            });        
        }
    }
}
