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
    class UserInformationPage
    {
        IWebDriver driver;

        [FindsBy(How =How.XPath, Using = "//input[@class='t_last_name wg-textinput']")]
        IWebElement LastName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='t_name wg-textinput']")]
        IWebElement Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='t_middle_name wg-textinput']")]
        IWebElement MiddleName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='wg-textinput t_birth_date -metrika-nokeys']")]
        IWebElement BirthDay { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='wg-textinput t_doc_num -metrika-nokeys']")]
        IWebElement Document { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='wg-button wg-button_always-big t_next_button']")]
        IWebElement NextButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@class='t_sex']/option[2]")]
        IWebElement Gender { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@class='wg-textinput t_email']")]
        IWebElement Mail { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@class='wg-textinput t_phone']")]
        IWebElement Phone { get; set; }

        public UserInformationPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='t_last_name wg-textinput']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='wg-button wg-button_always-big t_next_button']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='t_name wg-textinput']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='t_middle_name wg-textinput']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='wg-textinput t_birth_date -metrika-nokeys']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='wg-textinput t_doc_num -metrika-nokeys']")));
        }

        public UserInformationPage WriteUserInformationAndClickSubmit(User user)
        {
            LastName.SendKeys(user.LastName);
            Name.SendKeys(user.Name);
            MiddleName.SendKeys(user.MiddleName);
            Gender.Click();
            for (int i = 0; i < 10; i++)
                BirthDay.SendKeys(Keys.Left);
            BirthDay.SendKeys(user.BirthDay);
            Thread.Sleep(3000);
            Document.SendKeys(user.DocumentNumber);
            Mail.SendKeys(user.Mail);
            Phone.SendKeys(user.Phone);
            NextButton.Click();
            Thread.Sleep(5000);
            return this;
        }
        //public bool IsEnabledInformationFields()
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='t_last_name wg-textinput']")));
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@class='wg-button wg-button_always-big t_next_button']")));
        //    bool a = LastName.Enabled;
        //    NextButton.Click();
        //    string h = "ds";
        //    return ;
        //}
    }
}
