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
        public void TestName()
        {
            //This works ! but need to find out how to wait and test what we actually want to test 

            driver.Navigate().GoToUrl("http://localhost:41985/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            
            wait.Until(p => p.FindElements(By.TagName("input")).ElementAt(1).GetAttribute("value") == "Earth");
            
            /*                        
            var scripter = driver as IJavaScriptExecutor;

            var result = scripter.ExecuteScript("return $('input').eq(0).attr('value');").ToString();
            Assert.AreEqual("Dileepa", result);
            */
        }

        [Test]
        public void TestAddress()
        {
            driver.Navigate().GoToUrl("http://localhost:41985/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));

            wait.Until(p => p.FindElements(By.TagName("input")).ElementAt(0).GetAttribute("value") == "Dileepa");
        }

        [Test]
        public void TestAddRow()
        {
            driver.Navigate().GoToUrl("http://localhost:41985/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(7));
            //wait.Until(p => p.FindElements(By.TagName("input")).ElementAt(2).SendKeys("value") == "Dileepa");


        }
    }
       
}
