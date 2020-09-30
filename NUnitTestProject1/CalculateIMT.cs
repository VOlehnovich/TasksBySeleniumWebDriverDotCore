using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksBySeleniumWebDriver
{
    public class CalculateIMT
    {
        IWebDriver driver;

        private readonly By heightInputField = By.XPath("//input[@name='ht']");
        private readonly By weightInputField = By.XPath("//input[@name='mass']");
        private readonly By calculateButton = By.XPath("//ul[@class='ww_form']/li[3]/input");
        private readonly By imtField = By.XPath("//ul[@class='ww_form']/li[4]/input");
        private readonly By resultField = By.XPath("//*[@id='resline']");

        private const int heightValue = 183;
        private const int wrightValue = 58;
        private const double expectedResultImt = 17.32;
        private const string expectedResultStatus = "Пониженный вес";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver("D:\\chromedriver_win32");
            driver.Url = "https://www.3crkp.by/%D0%B8%D0%BD%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%86%D0%B8%D1%8F/%D0%BF%D0%BE%D0%BB%D0%B5%D0%B7%D0%BD%D0%BE-%D0%B7%D0%BD%D0%B0%D1%82%D1%8C/%D0%BC%D0%B5%D0%B4%D0%B8%D1%86%D0%B8%D0%BD%D1%81%D0%BA%D0%B8%D0%B5-%D0%BA%D0%B0%D0%BB%D1%8C%D0%BA%D1%83%D0%BB%D1%8F%D1%82%D0%BE%D1%80%D1%8B/%D1%80%D0%B0%D1%81%D1%87%D0%B5%D1%82-%D0%B8%D0%BC%D1%82";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var height = driver.FindElement(heightInputField);
            height.SendKeys($"{heightValue}");

            var weight = driver.FindElement(weightInputField);
            weight.SendKeys($"{wrightValue}");

            var calculate = driver.FindElement(calculateButton);
            calculate.Click();

            var imt = driver.FindElement(imtField);
            double imtFieldValue = Convert.ToDouble(imt.GetAttribute("value"));

            var statusResult = driver.FindElement(resultField);
            string status = statusResult.Text;

            Assert.AreEqual(expectedResultImt, imtFieldValue);
            Assert.AreEqual(expectedResultStatus, status);


        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }

    }
}
