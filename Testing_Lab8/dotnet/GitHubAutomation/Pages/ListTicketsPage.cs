using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Pages
{
    class ListTicketsPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='route_block']/div[@class='buy_button']")]
        IWebElement BuyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='train_count']/span")]
        public IWebElement CountRoute { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='inner_left']/p")]
        public IWebElement TextException { get; set; }

        public ListTicketsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='train_count']/span")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='tc3 inp inp3']")));

        }

        public TypeTrainPage ClickBuyFirstTicket()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='route_block']/div[@class='buy_button']")));
            BuyButton.Click();
            return new TypeTrainPage(driver);     
        }

    }
}
