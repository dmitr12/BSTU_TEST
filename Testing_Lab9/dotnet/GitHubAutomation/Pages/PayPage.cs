using Framework.Models;
using Framework.Services;
using GitHubAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace GitHubAutomation.Pages
{
    class PayPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='submit']/input")]
        IWebElement payButton;

        public PayPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='submit']/input")));
        }

        public bool IsVisibleErrorField()
        {
            payButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='error']")));
            return driver.FindElement(By.XPath("//div[@class='error']")).Displayed;
        }

    }
}
