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
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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


        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }



}
