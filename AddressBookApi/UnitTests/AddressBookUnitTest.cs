using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace AddressBookApi.Tests
{
    [TestFixture]
    public class Driver
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            /*string currentFile = new System.Diagnostics.StackTrace(true).GetFrame(0).GetFileName();
            IWebDriver driver = new ChromeDriver(new FileInfo(currentFile).Directory.FullName);*/

            // Create a new instance of the driver - Firefox works out of the box ,chrome needs to be set up
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [Test]
        public void T1_ItChecksInitialValuesOfContactList()
        {
            driver.Navigate().GoToUrl("http://localhost:41985/");
            IWebElement NameElement = WebDriverExtensions.FindElement(driver,By.Id("Name1"),1,true);
            IWebElement AddressElement = WebDriverExtensions.FindElement(driver,By.Id("Address1"),1,true);

            Assert.AreEqual("Dileepa", NameElement.GetAttribute("value"));
            Assert.AreEqual("Earth", AddressElement.GetAttribute("value"));
        }

        [Test]
        public void T2_ItAddsNewContactToList()
        {
            driver.Navigate().GoToUrl("http://localhost:41985/");

            driver.FindElement(By.Id("Nameundefined")).SendKeys("Darth Vader");
            driver.FindElement(By.Id("Addressundefined")).SendKeys("North Pole");
            driver.FindElement(By.Id("AddEntry")).Click();
        }




    }
       
}
