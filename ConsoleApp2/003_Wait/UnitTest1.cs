using System;
using System.IO;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _003_Wait
{
    
    [TestClass]
    public class UnitTest1
    {
       
        //1. No such element mean the specific element not exist even in hidden mode, 
        //and the test check if this is the current exeption
        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void TestMethod1()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsTrue(driver.FindElement(By.Id("Success")).Displayed);
        }

        //2. THe element exist but not show (hidden)
        [TestMethod]
        [ExpectedException(typeof(ElementNotVisibleException))]
        public void TestMethod2()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Assert.IsTrue(driver.FindElement(By.Id("go")).Displayed);
        }


        //EXPLICIT WAIT
        //*******************************************************************************
        [TestMethod]
        public void explicitWait1()
        {
            Thread.SpinWait(1000);
        }

        [TestMethod]
        public void explicitWait2()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IWebElement element = wait.Until((d) =>
                {
                    return d.FindElement(By.Id("Success"));
                }
            );

        }

        [TestMethod]
        public void explicitWait4()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/");
         


        }


        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}
