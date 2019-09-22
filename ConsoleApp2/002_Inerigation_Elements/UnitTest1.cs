using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using System.Data;

namespace _002_Inerigation_Elements
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        [TestCategory("Driver interrogation")]
        public void driverInttrogation()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/");

            //GET WINDOW PROPERTIES
            //Get window id:
            var x = driver.CurrentWindowHandle;

            //Get the open windows detail
            //U can use id or index like: driver.WindowHandles[2]
            var y = driver.WindowHandles;

            //Get page source , lector never use it...
            x = driver.PageSource;
            x = driver.Title;
            x = driver.Url;
        }

        [TestMethod]
        [TestCategory("Elements interrogation")]
        public void elementsInttrogation()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/");

            var sampleElement = driver.FindElement(By.XPath("//*[@href='https://courses.ultimateqa.com']"));
        }

        [TestMethod]
        [TestCategory("Quiz # 2")]
        public void Quiz_2()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/");

            //1.Maximize the page
            driver.Manage().Window.Maximize();

            //2. Find button by id
            var btnElement = driver.FindElement(By.Id("menu-item-504"));

            //3. GetAttribute ("type") and assert that it equle the right value
            var btnType = btnElement.GetAttribute("type");
            Assert.AreEqual("", btnType);


            driver.Close();

        }


        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }



}
