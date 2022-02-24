using AutomationTesting.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace AutomationTesting.Test
{
    public class LoginTest
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
        }

        [Test]
        public void Test1()
        {
            LoginPage login=new LoginPage(driver);
            login.Login();
            Console.WriteLine("Done");
            Assert.IsTrue(true);
        }
    }
}