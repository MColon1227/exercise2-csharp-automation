using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace exercise2_csharp_automation
{
    public class BrowserCreation
    {
        IWebDriver driver;
        //Create Account Button
        By CreateAccountButton = By.CssSelector("form#u_0_a  a[role='button']");
        //SingUP fill info
        By Firstname = By.Id("u_1_b");
        By Lastname = By.Id("u_1_d");
        By Email = By.Name("reg_email__");
        By ReEnterEmail = By.Name("reg_email_confirmation__");
        By Password = By.Name("reg_passwd__");

        //Select Birthday options input
        By month_button = By.CssSelector("#month > option:nth-child(4)");
        By date_button = By.CssSelector("#day > option:nth-child(16)");
        By year_button = By.CssSelector("#year > option:nth-child(39)");

        //Select Gender input
        By Female = By.CssSelector("span:nth-of-type(1) > ._58mt");
        By Male = By.CssSelector("span:nth-of-type(2) > ._58mt");
        
        //Verify text ----> Connect with friends and the world around you on Facebook.
        //Also I add extra step to close the modal
        By CloseModal = By.CssSelector("._8ien > img");
        By VerifyText = By.CssSelector("._8eso");
        private bool _contains;

        public BrowserCreation(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void TypeInfoUser()
        {
            driver.FindElement(CreateAccountButton).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(Firstname).SendKeys("Marisol");
            driver.FindElement(Lastname).SendKeys("Colon");
            driver.FindElement(Email).SendKeys("marisol.colon@test.com");
            driver.FindElement(ReEnterEmail).SendKeys("marisol.colon@test.com");
            driver.FindElement(Password).SendKeys("password");
        }

        public void ClickBirthdayButton()
        {
            //Wait for element visible
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            driver.FindElement(month_button).Click();
            driver.FindElement(date_button).Click();
            driver.FindElement(year_button).Click();
            
        }
        public void SelectGender()
        {
            driver.FindElement(Female).Click();
            //driver.FindElement(Male).Click();
        }

        public void CloseModalAndVerifyText()
        {
            driver.FindElement(CloseModal).Click();
            
            string actualText = driver.FindElement(VerifyText).Text;
            Assert.IsTrue(actualText.Contains("Connect with friends and the world around you on Facebook."), actualText + " doesn't contains 'Connect with friends and the world around you on Facebook.'");
        }
    }
}