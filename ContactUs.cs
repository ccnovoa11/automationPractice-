using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace automationpractice
{
    [TestClass]
    public class ContactUs
    {
        IWebDriver driver;
        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
        }

        [TestMethod]
        public void ContactUsTest()
        {
            driver.Url = "http://automationpractice.com/index.php";
            driver.FindElement(By.Id("contact-link")).Click();
            new SelectElement(driver.FindElement(By.Id("id_contact"))).SelectByValue("2");
            driver.FindElement(By.Id("email")).SendKeys("hola@mailinator.com");
            driver.FindElement(By.Id("id_order")).SendKeys("1012252");

            driver.FindElement(By.Id("message")).SendKeys("this is a test for automation");

            driver.FindElement(By.Id("submitMessage")).Click();
            string sucess = driver.FindElement(By.XPath("//*[@id=\"center_column\"]/p")).Text;

            Assert.AreEqual("Your message has been successfully sent to our team.", sucess);

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
