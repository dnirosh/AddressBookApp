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

        /*
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
        }*/
        
        [Test]
        public void AddressBookTest()
        {
            //Navigate to the site
            driver.Navigate().GoToUrl("http://localhost:41985/");
            //driver.FindElements(By.CssSelector("table tbody tr td:nth-child(1)").Select(td => td.Text).Should().Contain("Darth Vader"));
            //bool hasExpectedValueCheck = driver.FindElements(By.CssSelector("tbody#contacts tr td:nth-child(1)")).Select(td => td.Text).Single().Contains("aaa");
            //Assert.AreEqual(true, hasExpectedValueCheck);

            //IWebElement table = driver.FindElement(By.ClassName("list"));
            IWebElement table = driver.FindElement(By.Id("addressBookTable"));
            //IWebElement tbody = table.FindElement(By.TagName("tbody"));

            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            IList<IWebElement> tds = rows.ElementAt(1).FindElements(By.TagName("td"));

            IWebElement inputName ,inputAddress;
            if (tds.Count > 0)
            {
                /*WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(p => p.FindElement(By.TagName("input")).GetAttribute("value") == "Dileepa");
                */
                inputName = tds.ElementAt(0).FindElement(By.TagName("input"));
                inputAddress = tds.ElementAt(1).FindElement(By.TagName("input"));
                //Assert.AreEqual("input", input1.TagName);

                //this works
                //Assert.AreEqual(true, inputName.GetAttribute("data-bind")=="value:Name");
                
                //looks like following won't work unless we access the underlying javascript object of the input DOM node - how to do that ?
                Assert.AreEqual("Dileepa", inputName.GetAttribute("value"));

                //Assert.AreEqual("Earth", inputAddress.GetAttribute("value"));
            }
            else
                Assert.AreEqual("test", "fails");
            //IWebElement input2 = tds.ElementAt(1).FindElement(By.TagName("input"));

            

        }
        
    }
}
