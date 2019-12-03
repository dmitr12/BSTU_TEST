using GitHubAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace Framework.Pages
{
    class TypeTrainPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@class='wg-wagon-type']/div[1]")]                                 
        IWebElement TypeButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='wg-button']")]
        IWebElement NextButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='wg-block__section-label t_error']/span")]
        public IWebElement TextException { get; set; }

        [FindsBy(How=How.XPath, Using ="//span[@class='wg-link']")]
        public IWebElement Parameters { get; set; }

        public TypeTrainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public TypeTrainPage ClickTypeTrain()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='wg-wagon-type']/div[1]")));
            TypeButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='wg-button']")));
            NextButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='wg-block__section-label t_error']/span")));
            return this;
        }

        public UserInformationPage ChoseSeatAndClickUserInformation()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='wg-wagon-type']/div[1]")));
            TypeButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='wg-link']")));
            Parameters.Click();
            NextButton.Click();
            return new UserInformationPage(driver);
        }
    }
}
