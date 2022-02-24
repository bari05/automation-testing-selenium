using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTesting.Pages
{
    public class LoginPage
    {
        By username = By.Id("email");
        By password = By.Id("passwd");
        By loginButton = By.Id("SubmitLogin");
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login()
        {
            driver.FindElement(username).SendKeys("temp1001@gmail.com");
            driver.FindElement(password).SendKeys("temp1001");
            driver.FindElement(loginButton).Click();
        }
    }
}
