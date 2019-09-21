using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NCalc;
using System.Data;

namespace _001
{
    [TestClass]
    public class UnitTest1
    {

      

        [TestMethod]  
        [TestCategory("Navigation")]
        public void SeleniumNavigation()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://www.booking.com");
        }


        [TestMethod]
        [TestCategory("Manipulation")]
        public void SeleniumMenipulate()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms/");
            driver.Manage().Window.Maximize();

            var nameField = driver.FindElement(By.Id("et_pb_contact_name_0"));
            nameField.Clear();
            nameField.SendKeys("Hezi");

            var messageField = driver.FindElement(By.Id("et_pb_contact_message_0"));
            messageField.Clear();
            messageField.SendKeys("Hi everyone !!!!");

            var submitBtn = driver.FindElement(By.XPath("//*[@id='et_pb_contact_form_0']/div[2]/form/div/button"));
            submitBtn.Click();

        }

        [TestMethod]
        [TestCategory("Quiz_01")]
        public void SeleniumMenipulate2()
        {
            var driver = GetChromeDriver();
            driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms/");
            driver.Manage().Window.Maximize();

            var nameField = driver.FindElement(By.Id("et_pb_contact_name_1"));
            nameField.Clear();
            nameField.SendKeys("Hezi");

            var messageField = driver.FindElement(By.Id("et_pb_contact_message_1"));
            messageField.Clear();
            messageField.SendKeys("This is my quiz !!!!");

    

            //Captcha
            var capValues = driver.FindElement(By.ClassName("et_pb_contact_captcha_question"));
            var table = new DataTable();
            var captchaAnswer = (int)table.Compute(capValues.Text, "");

            var captchaTextBox = driver.FindElement(By.XPath("//*[@id='et_pb_contact_form_1']/div[2]/form/div/div/p/input"));
            captchaTextBox.SendKeys(captchaAnswer.ToString());



            var submitBtn2 = driver.FindElement(By.XPath("//*[@id='et_pb_contact_form_1']/div[2]/form/div/button"));
            
            submitBtn2.Click();


            var ifSuccessAns = driver.FindElement(By.XPath("//*[@id='et_pb_contact_form_1']/div"));

            Assert.AreEqual("Success", ifSuccessAns.Text);


        }






        private IWebDriver GetChromeDriver()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }
    }
}
