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
    class CheckUserInformationPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//button[@class='wg-button wg-button_always-big t_next_button']")]
        IWebElement nextButton;

        public CheckUserInformationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='wg-button wg-button_always-big t_next_button']")));
        }

        public PayPage ClickButtonNext()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            nextButton.Click();
            return new PayPage(driver);
        }

        public bool VisibleNextButton()
        {
            return nextButton.Displayed;
        }
    }
}
