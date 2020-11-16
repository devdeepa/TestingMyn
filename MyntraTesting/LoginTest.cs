using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.IE;

namespace MyntraTesting
{
    [TestFixture]
    public class LoginTest
    {
        [Test]
        public void MyntraTitle()
        {
            InternetExplorerDriverService driverService = InternetExplorerDriverService.CreateDefaultService(@"D:\Setups\IEDriverServer_x64_3.14.0\");
            IWebDriver driver = new InternetExplorerDriver(driverService);
            String strExpectedOutPut = "Online Shopping for Women, Men, Kids Fashion & Lifestyle - Myntra";
           
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.myntra.comjkkhkkjl";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            //IWebElement title = driver.FindElement(By.TagName("title"));
            String strTitle = driver.Title;
            Console.WriteLine(strTitle);
            Assert.AreEqual(strExpectedOutPut, strTitle);


            
        }
    }
}
