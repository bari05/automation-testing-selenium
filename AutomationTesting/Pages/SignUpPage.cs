using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTesting.Pages
{
    public class SignUpPage
    {
        //email_create
        private IWebDriver driver;
        By email = By.Id("email_create");
        By password = By.Id("passwd");
        By loginButton = By.XPath("//*[@id='SubmitCreate']");

        By title = By.XPath("//*[@id='account-creation_form']/div[1]/div[1]/div[1]");

        public SignUpPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SignUp(string mailAddress, string passWord)
        {
            driver.FindElement(email).SendKeys(mailAddress);
            driver.FindElement(loginButton).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult = wait.Until(e => e.FindElement(By.Id("customer_firstname")));

            driver.FindElement(By.Id("customer_firstname")).SendKeys("Firstname");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("Lastname");
            driver.FindElement(By.Id("passwd")).SendKeys(passWord);

            new SelectElement(driver.FindElement(By.Id("days"))).SelectByIndex(1);
            new SelectElement(driver.FindElement(By.Id("months"))).SelectByIndex(1);
            new SelectElement(driver.FindElement(By.Id("years"))).SelectByIndex(1);

            driver.FindElement(By.Id("address1")).SendKeys("street1,po1,com1");
            driver.FindElement(By.Id("city")).SendKeys("city1");

            new SelectElement(driver.FindElement(By.Id("id_state"))).SelectByText("Alabama");
            driver.FindElement(By.Id("postcode")).SendKeys("98001");
            driver.FindElement(By.Id("phone_mobile")).SendKeys("01234567890");
            driver.FindElement(By.Id("alias")).SendKeys("street2,po2,ct2");


            driver.FindElement(By.Id("submitAccount")).Click();

            //waiting untill "MY ACCOUNT" is visible
            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement firstResult2 = wait2.Until(e => e.FindElement(By.XPath("//*[@id='center_column']/h1")));

            Console.WriteLine("Accunt Created Successfully");

            driver.FindElement(By.XPath("//*[@id='header']/div[2]/div/div/nav/div[2]/a")).Click();

            Console.WriteLine("Signed Out");
            /*IWebElement element = driver.FindElement(By.Id("id_state"));
            SelectElement select = new SelectElement(element); 
            select.SelectByText("Alabama");*/
        }
    }
}
