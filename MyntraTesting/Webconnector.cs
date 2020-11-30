using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;

namespace MyntraTesting
{
    public class Webconnector
    {
        public IWebDriver driver = null;
        private readonly IObjectContainer objectContainer;

        public Webconnector(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }
        public void openbrowser(string strBrowserType)
        {
            if (strBrowserType.Equals("Mozilla"))
            {
                FirefoxDriverService driverService = FirefoxDriverService.CreateDefaultService(@"D:\Setups\geckodriver-v0.27.0-win64\");
                driverService.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                driver = new FirefoxDriver(driverService);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void click(string objct)
        {
            getElement(objct).Click();
        }

        public void type(string objct, string data)
        {
            getElement(objct).SendKeys(data);
        }

        public void navigate(string url)
        {
           
            driver.Url = ConfigurationManager.AppSettings[url];
        }

        public bool isElementPresent(string objct)
        {
            int count = driver.FindElements(By.LinkText(ConfigurationManager.AppSettings[objct])).Count;
            if (count == 0) //not found
                return false;
            else
                return true;
        }
        public IWebElement getElement(string objct)
        {
            IWebElement e = null;
            if (objct.EndsWith("_xpath"))
                e = driver.FindElement(By.XPath(ConfigurationManager.AppSettings[objct]));
            else if (objct.EndsWith("_id"))
                e = driver.FindElement(By.Id(ConfigurationManager.AppSettings[objct]));
            else if (objct.EndsWith("_name"))
                e = driver.FindElement(By.Name(ConfigurationManager.AppSettings[objct]));
            else if (objct.EndsWith("_linkText"))
                e = driver.FindElement(By.LinkText(ConfigurationManager.AppSettings[objct]));
            else if (objct.EndsWith("_class"))
                e = driver.FindElement(By.ClassName(ConfigurationManager.AppSettings[objct]));
            return e;
        }
    }
}
