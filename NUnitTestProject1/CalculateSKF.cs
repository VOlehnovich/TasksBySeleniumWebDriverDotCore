using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TasksBySeleniumWebDriver
{
    class CalculateSKF
    {
        IWebDriver driver;

        private readonly By creatininInputField = By.Id("oCr");
        private readonly By ageInputField = By.Id("oAge");
        private readonly By weightInputField = By.Id("oWeight");
        private readonly By heightInputField = By.Id("oHeight");
        private readonly By calculateButton = By.XPath("//input[@type='button']");
        private readonly By mdrdField = By.Id("txtMDRD");
        private readonly By hbpField = By.Id("txtMDRD1");
        private readonly By cgField = By.Id("txtCG");
        private readonly By bsaField = By.Id("txtBSA");

        private const int creatininValue = 80;
        private const int ageValue = 38;
        private const int weightValue = 55;
        private const int heightValue = 163;

        private const string mdrdExpectedResult = "MDRD: 74 (мл/мин/1,73кв.м)";
        private const string hbpExpectedResult = "ХБП: 2 стадия (при наличии почечного повреждения)";
        private const string cgExpectedResult = "Cockroft-Gault: 70 (мл/мин)";
        private const string bsaExpectedResult = "Поверхность тела:1.58 (кв.м)";

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\chromedriver_win32");
            driver.Url = "https://www.3crkp.by/%D0%B8%D0%BD%D1%84%D0%BE%D1%80%D0%BC%D0%B0%D1%86%D0%B8%D1%8F/%D0%BF%D0%BE%D0%BB%D0%B5%D0%B7%D0%BD%D0%BE-%D0%B7%D0%BD%D0%B0%D1%82%D1%8C/%D0%BC%D0%B5%D0%B4%D0%B8%D1%86%D0%B8%D0%BD%D1%81%D0%BA%D0%B8%D0%B5-%D0%BA%D0%B0%D0%BB%D1%8C%D0%BA%D1%83%D0%BB%D1%8F%D1%82%D0%BE%D1%80%D1%8B/%D1%80%D0%B0%D1%81%D1%87%D0%B5%D1%82-%D1%81%D0%BA%D1%84";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void test()
        {
            IWebElement sexField = driver.FindElement(By.Id("oSex"));
            SelectElement sex_dropdown = new SelectElement(sexField);
            sex_dropdown.SelectByIndex(1);

            var creatinin = driver.FindElement(creatininInputField);
            creatinin.SendKeys($"{creatininValue}");

            var age = driver.FindElement(ageInputField);
            age.SendKeys($"{ageValue}");

            var weight = driver.FindElement(weightInputField);
            weight.SendKeys($"{weightValue}");

            var height = driver.FindElement(heightInputField);
            height.SendKeys($"{heightValue}");

            var calculate_button = driver.FindElement(calculateButton);
            calculate_button.Click();

            var mdrdResult = driver.FindElement(mdrdField).Text;
            var hbpResult = driver.FindElement(hbpField).Text;
            var cgResult = driver.FindElement(cgField).Text;
            var bsaResult = driver.FindElement(bsaField).Text;

            Assert.AreEqual(mdrdExpectedResult, mdrdResult);
            Assert.AreEqual(hbpExpectedResult, hbpResult);
            Assert.AreEqual(cgExpectedResult, cgResult);
            Assert.AreEqual(bsaExpectedResult, bsaResult);

        }
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
