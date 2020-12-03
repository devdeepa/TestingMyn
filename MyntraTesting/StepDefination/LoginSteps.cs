using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using MyntraTesting;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Support;

namespace MyntraTesting.StepDefination
{
    [Binding]
    class LoginSteps
    {
        Webconnector web;
        public LoginSteps(Webconnector web)
        {
            this.web = web;        
        }

        [Given(@"I go to \""(.*)"" on \""(.*)""")]
        public void GivenIGoToHttpWww_Myntra_ComOnMozilla(String URL,String Browser)
        {
            web.startTest(FeatureContext.Current.FeatureInfo.Title);
            web.openbrowser(Browser);
            web.navigate(URL);
            
        }

        [When(@"I click on \""(.*)""")]
        public void WhenIClickOn(String obj)
        {
            web.click(obj);
        }

        [When(@"I enter \""(.*)"" as \""(.*)""")]
        public void WhenIEnterAs(String obj,String text)
        {
            web.type(obj, text);
        }          

        [Then(@"login should be \""(.*)""")]
        public void ThenLoginShouldBeSuccessful(string ExpectedResult)
        {
           WebDriverWait wait = new WebDriverWait(web.getDriver(),TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(ConfigurationManager.AppSettings["Home_linkText"])));
           bool result =  web.isElementPresent("Home_linkText");
            String strActualResult = null;
            if (result)
                strActualResult = "Success";
            else
                strActualResult = "Failure";
            Assert.AreEqual(ExpectedResult, strActualResult);
            if (ExpectedResult != strActualResult)
                web.reportFail("Login Failed");
            else
                web.reportPass("Login Passed");
        }

    }
}
