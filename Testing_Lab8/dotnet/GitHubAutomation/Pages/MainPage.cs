using Framework.Models;
using Framework.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Framework.Pages
{
    class MainPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@class='slide_tcal tc1']")]
        IWebElement DepartureCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='slide_tcal tc2']")]
        IWebElement ArrivalCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='slide_tcal tc3']")]
        IWebElement DateFiled { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='search_button']")]
        IWebElement SearchButton { get; set; }

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public ListTicketsPage InputRouteDateAndClickSearch(Route route)
        {
            DepartureCity.SendKeys(route.DepartureCity);
            ArrivalCity.SendKeys(route.ArrivalCity);
            DateFiled.Clear();
            DateFiled.SendKeys(DateTime.Now.AddDays(1).ToString("dd.MM.yyyy"));
            SearchButton.Click();
            return new ListTicketsPage(driver);
        }

        public bool CheckCitiesBackground()
        {
            SearchButton.Click();
            return (DepartureCity.GetCssValue("background-color") == "#FFFFFF"
                && ArrivalCity.GetCssValue("background-color") == "#FFFFFF");
        }
    }
}
