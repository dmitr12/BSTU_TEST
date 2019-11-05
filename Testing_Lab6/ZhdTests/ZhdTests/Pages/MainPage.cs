using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZhdTests.Pages
{
    class MainPage
    {
        [FindsBy(How=How.XPath, Using= "//INPUT[@class='slide_tcal tc1']")]
        IWebElement DepartureCity { get; set; }
        [FindsBy(How = How.XPath, Using = "//INPUT[@class='slide_tcal tc2']")]
        IWebElement ArrivalCity { get; set; }

        [FindsBy(How = How.XPath, Using = "//INPUT[@class='search_button']")]
        IWebElement SearchButton { get; set; }

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainPage InputRouteDateAndClickSearch(string departureCity, string arrivalCity)
        {
            DepartureCity.SendKeys(departureCity);
            ArrivalCity.SendKeys(arrivalCity);
            SearchButton.Click();
            return this;
        }

    }
}
