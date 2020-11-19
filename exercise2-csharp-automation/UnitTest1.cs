using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

namespace exercise2_csharp_automation
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void FacebookSingUp()
        {
            // Go to the "Facebook" homepage 
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            
            // Validate text 
            var expectedTitle = "Facebook - Log In or Sign Up";
            var actualTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);
            
            //Fill up the sing up section
            BrowserCreation setUp = new BrowserCreation(driver);
            setUp.TypeInfoUser();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            //Select different default birthday 
            setUp.ClickBirthdayButton();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            //Select Female gender input
            setUp.SelectGender();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            
            //Verify text ----> Connect with friends and the world around you on Facebook.
            setUp.CloseModalAndVerifyText();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Close();
        }
    }
}