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
        public void GoogleSearch()
        {
            //Navigate to the site
            driver.Navigate().GoToUrl("http://www.google.com");
            // Find the text input element by its name
            IWebElement query = driver.FindElement(By.Name("q"));
            // Enter something to search for
            query.SendKeys("Selenium");
            // Now submit the form
            query.Submit();
            // Google's search is rendered dynamically with JavaScript.
            // Wait for the page to load, timeout after 5 seconds
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until((d) => { return d.Title.StartsWith("selenium"); });
            //Check that the Title is what we are expecting
            Assert.AreEqual("selenium - Google Search", driver.Title);
        }
        
        [Test]
        public void AddressBookTest()
        {
            //Navigate to the site
            driver.Navigate().GoToUrl("http://localhost:41985/api/AddressBookApi/");

        
        }
        
    }
}
