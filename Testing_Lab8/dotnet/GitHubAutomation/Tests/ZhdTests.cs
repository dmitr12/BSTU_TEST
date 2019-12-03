using System;
using System.IO;
using Framework.Driver;
using Framework.Pages;
using Framework.Services;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;
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
            MakeScreenshotWhenFail(() =>
            {
                ListTicketsPage listTicketsPage = new MainPage(DriverSingleton.GetDriver())
                 .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties());
                Assert.AreNotEqual("0", listTicketsPage.CountRoute.Text);
            });        
        }

        [Test]
        [Category("SearchTest")]
        public void FindTicketWithEqualDepartureAndArrivalCities()
        {
            MakeScreenshotWhenFail(() =>
            {
                ListTicketsPage listTicketsPage = new MainPage(DriverSingleton.GetDriver())
                .InputRouteDateAndClickSearch(RouteCreator.WithEqualCities());
                Assert.AreEqual("Сожалеем, но поезда по данному маршруту отсутствуют.", listTicketsPage.TextException.Text);
            });
        }

        [Test]
        [Category("SearchTest")]
        public void FindTicketWithoutRoute()
        {
            MakeScreenshotWhenFail(() =>
            {
                Assert.IsFalse(new MainPage(DriverSingleton.GetDriver()).CheckCitiesBackground());
            });
        }

        [Test]
        [Category("UserTest")]
        public void FindTicketWithFailDocument()
        {
            MakeScreenshotWhenFail(() =>
            {
                UserInformationPage userInformationPage = new MainPage(Driver)
                   .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties())
                   .ClickBuyFirstTicket()
                   .ChoseSeatAndClickUserInformation()
                   .WriteUserInformationAndClickSubmit(UserCreator.WithFailDocument());
            });
        }

        //[Test]
        //[Category("UserTest")]
        //public void GetTicketWithoutUserInformation()
        //{
        //    MakeScreenshotWhenFail(() =>
        //    {
        //        UserInformationPage userInformationPage = new MainPage(Driver)
        //            .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties())
        //            .ClickBuyFirstTicket()
        //            .ChoseSeatAndClickUserInformation();
        //        Assert.IsFalse(userInformationPage.IsEnabledInformationFields());
        //    });
        //}
    }
}
