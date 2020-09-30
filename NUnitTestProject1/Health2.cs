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
    class Health2
    {
        IWebDriver driver;

        private readonly By weightInputField = By.Name("wg");
        private readonly By calculateButton = By.Name("cc");

        private readonly By siUnitsField = By.Name("si");
        private readonly By usUnitsField = By.Name("us");
        private readonly By ukUnitsField = By.Name("uk");
        private readonly By statusField = By.XPath("//input[@class='content']");

        private const int weightFieldValue = 70;

        private const double siUnitsFieldValueExpected = 11.27;
        private const double usUnitsFieldValueExpected = 11.46;
        private const double ukUnitsFieldValueExpected = 71.58;
        private const string statusFieldValueExpected = "Your category is Normal";

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

            IWebElement unit = driver.FindElement(By.Name("opt1"));
            SelectElement unitDropdown = new SelectElement(unit);
            unitDropdown.SelectByIndex(0);

            var weightField = driver.FindElement(weightInputField);
            weightField.Clear();
            weightField.SendKeys($"{weightFieldValue}");

            IWebElement heightMinutes = driver.FindElement(By.Name("opt2"));
            SelectElement heightMinutesDropdown = new SelectElement(heightMinutes);
            heightMinutesDropdown.SelectByValue("5");

            IWebElement heightSeconds = driver.FindElement(By.Name("opt3"));
            SelectElement heightSecondsDropdown = new SelectElement(heightSeconds);
            heightSecondsDropdown.SelectByValue("6");

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
