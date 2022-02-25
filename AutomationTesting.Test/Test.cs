using AutomationTesting.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationTesting.Test
{
    public class Test
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
        }

        [Test]
        public void TestLogIn()
        {
            LoginPage login=new LoginPage(driver);
            login.Login("temp1001@gmail.com", "temp1001");
            Console.WriteLine("Logged in");

            //checking if "MY ACCOUNT" is visible after successfull login.
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='center_column']/h1")).Displayed);

            //driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[2]/a")).Click();
        }
         [Test]
        public void TestSignUp()
        {
            SignUpPage signup = new SignUpPage(driver);
            signup.SignUp("temp10005@gmail.com","temp10005");
        }

        [Test]
        public void TestWorkflow() {
            LoginPage login = new LoginPage(driver);
            login.Login("temp1001@gmail.com", "temp1001");
            //checking if "MY ACCOUNT" is visible after successfull login.
            //Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='center_column']/h1")).Displayed);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(By.XPath("//*[@id='center_column']/h1")));

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?id_category=8&controller=category"); //dresses button

            //wait.Until(e => e.FindElement(By.ClassName("subcategory-heading")));
            Console.WriteLine("subcatagory");
            driver.FindElement(By.XPath("//*[@id='subcategories']/ul/li[1]/div[1]/a/img")).Click();//causal dress button
            
           // wait.Until(e => e.FindElement(By.XPath("//*[@id='center_column']/div[1]/div")));
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/ul/li/div/div[2]/div[2]/a[1]/span")).Click();//add causal dress

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?id_category=5&controller=category"); 
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div[2]/ul/li/div/div[2]/div[2]/a[1]/span")).Click();//add t shirt
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=order&step=1");

            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/form/p/button/span")).Click();
            driver.FindElement(By.Id("uniform-cgv")).Click();//accept terms
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/form/p/button/span")).Click();//proceed
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[3]/div[2]/div/p/a")).Click();//pay by check
            driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/form/p/button/span")).Click();//confirm order
            driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[2]/a")).Click();//SignOut



        }
        //[TearDown]
        public void Teardown()
        {
            driver.Close();
        }
    }
}