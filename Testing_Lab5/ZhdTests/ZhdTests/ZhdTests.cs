using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriver
{
    [TestClass]
    public class ZhdTests
    {
        IWebDriver driver;
        [TestMethod]
        public void DepartureCityAndArrivalCityAreEqual()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://zhd.online");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[1]/div[2]/input")).SendKeys("Москва");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[2]/div[2]/input")).SendKeys("Москва");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/input")).Click();
            IWebElement error = GetElement(driver, "/html/body/div[1]/div[3]/div[1]/p");
            Assert.AreEqual("Сожалеем, но поезда по данному маршруту отсутствуют.", error.Text);
            driver.Quit();
        }
        [TestMethod]
        public void SearchWithWrongDate()
        {
            string day = DateTime.Now.AddDays(-1).Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.zhd.online");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[1]/div[2]/input")).SendKeys("Москва");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[2]/div[2]/input")).SendKeys("Казань");
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[3]/div[2]/input")).Clear();
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/div[3]/div[2]/input")).SendKeys(day + "." + month + "." + year);
            driver.FindElement(By.XPath("/html/body/div[1]/div[2]/div/div[2]/input")).Click();
            Assert.AreEqual("Дата устарела, в указанную дату поезд не ходит. Пожалуйста, выберите другую.",
                GetElement(driver, "/html/body/div[1]/div[3]/div[1]/p").Text);
            driver.Quit();
        }
        IWebElement GetElement(IWebDriver driver, string xPath)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                IWebElement webElement = d.FindElement(By.XPath(xPath));
                if (webElement.Displayed)
                    return webElement;
                return null;
            });
            return element;
        }
    }
}
