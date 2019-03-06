using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace automationpractice
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class SignIn
    {
        IWebDriver driver;
        WebDriverWait wait;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
        }

        [TestMethod]
        public void RegisterTest()
        {

            driver.Url = "http://automationpractice.com/index.php";
            driver.FindElement(By.ClassName("header_user_info")).Click();

            driver.FindElement(By.Id("email")).SendKeys("anEmail3@fake.com");
             driver.FindElement(By.Id("passwd")).SendKeys("Password");

            driver.FindElement(By.Id("SubmitLogin")).Click();

            String msg = driver.FindElement(By.ClassName("info-account")).Text;

            Assert.AreEqual("Welcome to your account. Here you can manage all of your personal information and orders.", msg);
            
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
