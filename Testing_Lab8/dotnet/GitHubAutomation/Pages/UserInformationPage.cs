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

        [FindsBy(How = How.XPath, Using = "//input[@class='t_last_name wg-textinput']")]
        IWebElement lastName;

        [FindsBy(How = How.XPath, Using = "//input[@class='t_name wg-textinput']")]
        IWebElement name;

        [FindsBy(How = How.XPath, Using = "//input[@class='t_middle_name wg-textinput']")]
        IWebElement middleName;

        [FindsBy(How = How.XPath, Using = "//input[@class='wg-textinput t_birth_date -metrika-nokeys']")]
        IWebElement birthDay;

        [FindsBy(How = How.XPath, Using = "//input[@class='wg-textinput t_doc_num -metrika-nokeys']")]
        IWebElement document;

        [FindsBy(How = How.XPath, Using = "//button[@class='wg-button wg-button_always-big t_next_button']")]
        IWebElement nextButton;

        [FindsBy(How = How.XPath, Using = "//select[@class='t_sex']/option[2]")]
        IWebElement gender;

        [FindsBy(How = How.XPath, Using = "//input[@class='wg-textinput t_email']")]
        IWebElement mail;

        [FindsBy(How = How.XPath, Using = "//input[@class='wg-textinput t_phone']")]
        IWebElement phone;

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

        public CheckUserInformationPage WriteUserInformationAndClickSubmit(User user)
        {
            lastName.SendKeys(user.LastName);
            name.SendKeys(user.Name);
            middleName.SendKeys(user.MiddleName);
            gender.Click();
            for (int i = 0; i < 10; i++)
                birthDay.SendKeys(Keys.Left);
            birthDay.SendKeys(user.BirthDay);
            document.SendKeys(user.DocumentNumber);
            mail.SendKeys(user.Mail);
            phone.SendKeys(user.Phone);
            nextButton.Click();
            return new CheckUserInformationPage(driver);
        }

        public UserInformationPage ClickWithoutInforamtion()
        {
            nextButton.Click();
            return this;
        }

        public bool WriteFailDate(User user)
        {
            for (int i = 0; i < 10; i++)
                birthDay.SendKeys(Keys.Left);
            birthDay.SendKeys(user.BirthDay);
            nextButton.Click();
            return IsDisplayFailBirthDate();
        }

        public bool IsDisplayFailBirthDate()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='wg-form__label wg-form__label_error']")));
            return driver.FindElement(By.XPath("//span[@class='wg-form__label wg-form__label_error']")).Displayed;
        }
    }
}
