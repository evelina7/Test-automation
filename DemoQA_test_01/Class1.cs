using Microsoft.SqlServer.Server;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoQA_test_01
{
    public class Class1
    {
        //1-ame teste užpildyti visus 4 laukus, paspausti mygtuką ir patikrinti, kad įvesta informacija buvo atvaizduota po forma.

        [Test]

        public void Test01()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/text-box";

            string expectedResult1 = "Evelina";
            string expectedResult2 = "evelinad@test.com";
            string expectedResult3 = "Geras adresa";
            string expectedResult4 = "Dar geresnis adresas";

            //lauku uzpildymas
            IWebElement userNameInput = driver.FindElement(By.XPath("//*[@id='userName']"));
            userNameInput.SendKeys(expectedResult1);

            IWebElement emailInput = driver.FindElement(By.XPath("//*[@id='userEmail']"));
            emailInput.SendKeys(expectedResult2);

            IWebElement currentAddressInput = driver.FindElement(By.XPath("//*[@id='currentAddress']"));
            currentAddressInput.SendKeys(expectedResult3);

            IWebElement permanentAddressInput = driver.FindElement(By.XPath("//*[@id='permanentAddress']"));
            permanentAddressInput.SendKeys(expectedResult4);

            //paskrolinti zemyn ir paspausti mygtuka, nes kitaip jo neranda
            var submitButton = driver.FindElement(By.XPath("//*[@id='submit']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
            submitButton.Click();

            string actualResult1 = userNameInput.GetAttribute("value");
            string actualResult2 = emailInput.GetAttribute("value");
            string actualResult3 = currentAddressInput.GetAttribute("value");
            string actualResult4 = permanentAddressInput.GetAttribute("value");

            Assert.AreEqual(expectedResult1, actualResult1);
            Assert.AreEqual(expectedResult2, actualResult2);
            Assert.AreEqual(expectedResult3, actualResult3);
            Assert.AreEqual(expectedResult4, actualResult4);

            //uzdaryti narsykles langa
            driver.Quit();
        }
    }
}
