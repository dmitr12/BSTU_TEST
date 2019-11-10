using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZhdTests.Pages
{
    class ListTicketsPage
    {
        IWebDriver driver;
        [FindsBy(How=How.XPath, Using= "//DIV[@class='route_block']/div[4]")]
        IWebElement BuyButton { get; set; }
        [FindsBy(How=How.XPath, Using ="//DIV[@class='train_count']/span")]
        public IWebElement CountRoute { get; set; }
        public ListTicketsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//DIV[@class='train_count']/span")));
        }
        public TypeTrainPage ClickBuyFirstTicket()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//DIV[@class='route_block']/div[4]")));
            BuyButton.Click();
            return new TypeTrainPage(driver);
        }
    }
}
