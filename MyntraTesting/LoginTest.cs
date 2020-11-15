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
        public void TestMethod()
        {
            InternetExplorerDriverService driverService = InternetExplorerDriverService.CreateDefaultService(@"D:\Setups\IEDriverServer_x64_3.14.0\");
            IWebDriver driver = new InternetExplorerDriver(driverService);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.myntra.com";

            
        }
    }
}
