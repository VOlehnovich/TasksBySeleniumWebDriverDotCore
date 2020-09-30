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
using System.Threading;

namespace TasksBySeleniumWebDriver
{
    class Health
    {
        IWebDriver driver;

        private readonly By weightInputField = By.Name("wg");
        private readonly By heightInputField = By.Name("ht");
        private readonly By calculateButton = By.Name("cc");
        private readonly By siUnitsField = By.Name("si");
        private readonly By usUnitsField = By.Name("us");
        private readonly By ukUnitsField = By.Name("uk");
        private readonly By statusField = By.XPath("//input[@class='content']");

        private const int weightFieldValue = 40;
        private const int heightFieldValue = 158;

        private const double siUnitsFieldValueExpected = 16.02;
        private const double usUnitsFieldValueExpected = 16.29;
        private const double ukUnitsFieldValueExpected = 101.73;
        private const string statusFieldValueExpected = "Your category is Underweight";

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("D:\\chromedriver_win32");
            driver.Url = "https://healthunify.com/bmicalculator/";
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void test()
        {

            var weightField = driver.FindElement(weightInputField);
            weightField.SendKeys($"{weightFieldValue}");

            IWebElement unit = driver.FindElement(By.Name("opt1"));
            SelectElement sex_dropdown = new SelectElement(unit);
            sex_dropdown.SelectByIndex(1);

            var heightField = driver.FindElement(heightInputField);
            heightField.SendKeys($"{heightFieldValue}");

            var calculate_button = driver.FindElement(calculateButton);
            calculate_button.Click();

            var siUnits = driver.FindElement(siUnitsField);
            double siUnitsValueActual = Convert.ToDouble(siUnits.GetAttribute("value"));

            var usUnits = driver.FindElement(usUnitsField);
            double usUnitsValueActual = Convert.ToDouble(usUnits.GetAttribute("value"));

            var ukUnits = driver.FindElement(ukUnitsField);
            double ukUnitsValueActual = Convert.ToDouble(ukUnits.GetAttribute("value"));

            var statusActual = driver.FindElement(statusField).GetAttribute("value");

            Assert.AreEqual(siUnitsFieldValueExpected, siUnitsValueActual);
            Assert.AreEqual(usUnitsFieldValueExpected, usUnitsValueActual);
            Assert.AreEqual(ukUnitsFieldValueExpected, ukUnitsValueActual);
            Assert.AreEqual(statusFieldValueExpected, statusActual);

        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
