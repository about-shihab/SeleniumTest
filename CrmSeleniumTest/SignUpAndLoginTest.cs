using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CrmSeleniumTest
{
    [TestClass]
    public class SignUpAndLoginTest
    {
        private IWebDriver driver;
        private string baseUrl = "http://test.sistem.argusmedya.com";

        [TestInitialize]
        public void TestSetup()
        {
            driver=new ChromeDriver();
            driver.Navigate().GoToUrl(baseUrl);
        }

        [TestMethod]
        public void LoginTest()
        {
            var email =driver.FindElement(By.CssSelector("#Email"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].setAttribute('value', 'serdar@argusmedya.com')", email);
//            email.Click();
//            email.Clear();
//            email.SendKeys("serdar@argusmedya.com");
            

            var password = driver.FindElement(By.Id("Password"));
//            password.Click();
//            password.Clear();
//            password.SendKeys("password");
            js.ExecuteScript("arguments[0].setAttribute('value', 'password')", password);

            
           var login= driver.FindElement(By.CssSelector("body > div:nth-child(3) > form > div:nth-child(4) > button"));
            js.ExecuteScript("arguments[0].click();", login);

            Assert.AreEqual("Serdar Büyüktemiz", driver.FindElement(By.CssSelector("body > header > div.userName > a")).Text);
        }

        [TestMethod]
        public void SignUp()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
           var signuplink=driver.FindElement(By.CssSelector("body > div:nth-child(3) > div.form-group > a:nth-child(1)"));
            js.ExecuteScript("arguments[0].click();", signuplink);
            driver.FindElement(By.Id("FirstName")).SendKeys("Abdulla");
            driver.FindElement(By.Id("LastName")).SendKeys("Al Mamun");
            driver.FindElement(By.Id("Email")).SendKeys("a.shihab@gmail.com");
            driver.FindElement(By.Id("Phone")).SendKeys("8801813570430");
            driver.FindElement(By.Id("Password")).SendKeys("a12345678");
            driver.FindElement(By.XPath("/html/body/div[2]/form/div[6]/button")).Click();

            var singnupText = driver.FindElement(By.CssSelector("body > div:nth-child(3) > h4")).Text;
           Assert.AreEqual("Sisteme üye olduğunuz için teşekkür ederiz", singnupText); 

        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
