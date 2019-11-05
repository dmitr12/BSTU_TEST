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
    class TypeTrainPage
    {
        IWebDriver driver;
        [FindsBy(How = How.XPath, Using = "//*[@id='ufs-railway-app']/div/div[2]/div[2]/div[4]/div/div[3]/div/div[4]")]
        IWebElement TypeButton { get; set; }
        [FindsBy(How=How.XPath,Using ="//*[@id='ufs-railway-app']/div/div[2]/div[2]/div[4]/div/div[5]/div[3]/button")]
        IWebElement NextButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='ufs-railway-app']/div/div[2]/div[2]/div[4]/div/div[5]/div[2]/span/span")]
        public IWebElement TextException { get; set; }
        public TypeTrainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }
        public TypeTrainPage ClickTypeTrain()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ufs-railway-app']/div/div[2]/div[2]/div[4]/div/div[3]/div/div[4]")));
            TypeButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ufs-railway-app']/div/div[2]/div[2]/div[4]/div/div[5]/div[3]/button")));
            NextButton.Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='ufs-railway-app']/div/div[2]/div[2]/div[4]/div/div[5]/div[2]/span/span")));
            return this;
        }
    }
}
