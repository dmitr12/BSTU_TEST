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
            TypeTrainPage typeTrainPage = new MainPage(Driver)
                         .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties())
                         .ClickBuyFirstTicket()
                         .ClickTypeTrain();
            Assert.AreEqual("Необходимо выбрать 1 место", typeTrainPage.TextException.Text);
        }

        [Test]
        [Category("DateTest")]
        public void TrueRouteDate()
        {
            ListTicketsPage listTicketsPage = new MainPage(DriverSingleton.GetDriver())
                  .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties());
            Assert.AreNotEqual("0", listTicketsPage.CountRoute.Text);
        }

        [Test]
        [Category("SearchTest")]
        public void FindTicketWithEqualDepartureAndArrivalCities()
        {
            ListTicketsPage listTicketsPage = new MainPage(DriverSingleton.GetDriver())
                 .InputRouteDateAndClickSearch(RouteCreator.WithEqualCities());
            Assert.AreEqual("Сожалеем, но поезда по данному маршруту отсутствуют.", listTicketsPage.TextException.Text);
        }

        [Test]
        [Category("SearchTest")]
        public void FindTicketWithoutRoute()
        {
            Assert.IsTrue(new MainPage(DriverSingleton.GetDriver()).CheckCitiesRedBackground());
        }

        [Test]
        [Category("UserTest")]
        public void FindTicketWithFailDocument()
        {
            CheckUserInformationPage checkUserInformationPage = new MainPage(Driver)
                   .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties())
                   .ClickBuyFirstTicket()
                   .ChoseSeatAndClickUserInformation()
                   .WriteUserInformationAndClickSubmit(UserCreator.WithFailDocument());
            Assert.IsTrue(checkUserInformationPage.VisibleNextButton());
        }

        [Test]
        [Category("UserTest")]
        public void GetTicketWithoutUserInformation()
        {
            UserInformationPage userInformationPage = new MainPage(Driver)
                   .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties())
                   .ClickBuyFirstTicket()
                   .ChoseSeatAndClickUserInformation()
                   .ClickWithoutInforamtion();
            Assert.IsTrue(userInformationPage.IsDisplayFailBirthDate());
        }

        [Test]
        [Category("SearchTest")]
        public void PayForTicketWithoutInformationAboutCard()
        {
            PayPage payPage = new MainPage(Driver)
                    .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties())
                    .ClickBuyFirstTicket()
                    .ChoseSeatAndClickUserInformation()
                    .WriteUserInformationAndClickSubmit(UserCreator.WithAllProperties())
                    .ClickButtonNext();
            Assert.IsTrue(payPage.IsVisibleErrorField());
        }

        [Test]
        [Category("DateTest")]
        public void SearchTicketWithErrorDate()
        {
            ListTicketsPage listTicketsPage = new MainPage(DriverSingleton.GetDriver())
            .InputRouteDateAndClickSearch(RouteCreator.WithFailDate());
            Assert.AreEqual("Дата устарела, в указанную дату поезд не ходит. Пожалуйста, выберите другую.", listTicketsPage.TextException.Text);
        }

        [Test]
        [Category("UserTest")]
        public void FindTicketWithFailBithDate()
        {
            UserInformationPage userInformationPage = new MainPage(Driver)
                   .InputRouteDateAndClickSearch(RouteCreator.WithAllProperties())
                   .ClickBuyFirstTicket()
                   .ChoseSeatAndClickUserInformation();
            Assert.IsTrue(userInformationPage.WriteFailDate(UserCreator.WithFailBirthDay()));
        }

        [Test]
        [Category("DateTest")]
        public void SearchTicketWithoutDate()
        {
            ListTicketsPage listTicketsPage = new MainPage(DriverSingleton.GetDriver())
                  .InputRouteDateAndClickSearch(RouteCreator.WithoutDate());
            Assert.AreNotEqual("0", listTicketsPage.CountRoute.Text);
        }
    }
}
