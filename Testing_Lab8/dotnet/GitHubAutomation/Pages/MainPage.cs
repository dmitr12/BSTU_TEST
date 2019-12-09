using Framework.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Pages
{
    class MainPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//input[@class='slide_tcal tc1']")]
        IWebElement departureCity;

        [FindsBy(How = How.XPath, Using = "//input[@class='slide_tcal tc2']")]
        IWebElement arrivalCity;

        [FindsBy(How = How.XPath, Using = "//input[@class='slide_tcal tc3']")]
        IWebElement dateFiled;

        [FindsBy(How = How.XPath, Using = "//input[@class='search_button']")]
        IWebElement searchButton;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public ListTicketsPage InputRouteDateAndClickSearch(Route route)
        {
            departureCity.SendKeys(route.DepartureCity);
            arrivalCity.SendKeys(route.ArrivalCity);
            dateFiled.Clear();
            dateFiled.SendKeys(route.DepartureDate);
            searchButton.Click();
            return new ListTicketsPage(driver);
        }

        public bool CheckCitiesRedBackground()
        {
            searchButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='slide_tcal tc1 error_input']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='slide_tcal tc2 error_input']")));
            return (driver.FindElement(By.XPath("//input[@class='slide_tcal tc1 error_input']")).Displayed
                && driver.FindElement(By.XPath("//input[@class='slide_tcal tc2 error_input']")).Displayed);
        }
    }
}
