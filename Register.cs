using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace automationpractice
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class Register
    {
        IWebDriver driver;
        WebDriverWait wait;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0,0,5));
        }

        [TestMethod]
        public void RegisterTest()
        {

            driver.Url = "http://automationpractice.com/index.php";
            driver.FindElement(By.ClassName("header_user_info")).Click();
            driver.FindElement(By.Id("email_create")).SendKeys("anEmail3@fake.com");
            driver.FindElement(By.Id("SubmitCreate")).Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("id_gender1")));
            driver.FindElement(By.Id("id_gender1")).Click();

            driver.FindElement(By.Id("customer_firstname")).SendKeys("Santiago");
            driver.FindElement(By.Id("customer_lastname")).SendKeys("LaSwitch");
            driver.FindElement(By.Id("passwd")).SendKeys("Password");

            SelectElement dropdownDay = new SelectElement(driver.FindElement(By.Id("days")));
            dropdownDay.SelectByValue("4");

            SelectElement dropdownMonth = new SelectElement(driver.FindElement(By.Id("months")));
            dropdownMonth.SelectByValue("4");

            SelectElement dropdownYear = new SelectElement(driver.FindElement(By.Id("years")));
            dropdownYear.SelectByValue("1997");

            driver.FindElement(By.Id("firstname")).SendKeys("Santiago");
            driver.FindElement(By.Id("lastname")).SendKeys("LaSwitch");
            driver.FindElement(By.Id("address1")).SendKeys("Street Fake 123");
            driver.FindElement(By.Id("city")).SendKeys("New Fakeyork");

            SelectElement dropdownState = new SelectElement(driver.FindElement(By.Id("id_state")));
            dropdownState.SelectByValue("32");

            driver.FindElement(By.Id("postcode")).SendKeys("10013");

            SelectElement dropdownCountry = new SelectElement(driver.FindElement(By.Id("id_country")));
            dropdownCountry.SelectByValue("21");

            driver.FindElement(By.Id("phone_mobile")).SendKeys("500355689");
            driver.FindElement(By.Id("alias")).SendKeys("Fakedress");

            driver.FindElement(By.Id("submitAccount")).Click();

            String msg = driver.FindElement(By.ClassName("info-account")).Text;

            Assert.AreEqual("Welcome to your account. Here you can manage all of your personal information and orders.", msg);

            driver.FindElement(By.ClassName("logout")).Click();
            


            //driver.FindElement(By.Id("email_create")).SendKeys("anEmail@fake.com");



            /*
            string sucess = driver.FindElement(By.XPath("//*[@id=\"center_column\"]/p")).Text;

            Assert.AreEqual("Your message has been successfully sent to our team.", sucess);*/

        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
    }
}
