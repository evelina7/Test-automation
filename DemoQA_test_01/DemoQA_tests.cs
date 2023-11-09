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
    public class DemoQA_tests
    {
        //1-ame teste užpildyti visus 4 laukus, paspausti mygtuką ir patikrinti, kad įvesta informacija buvo atvaizduota po forma.

        [Test]

        public void Test01() 
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/text-box";

            string Name = "Evelina";
            string Email = "evelinad@test.com";
            string CurrentAddress = "Geras adresas";
            string PermanentAddress = "Dar geresnis adresas";

            string expectedName = $"Name:{Name}";
            string expectedEmail = $"Email:{Email}";
            string expectedCurrentAddress = $"Current Address :{CurrentAddress}";
            string expectedPermanentAddress = $"Permananet Address :{PermanentAddress}";

            //lauku uzpildymas
            IWebElement userNameInput = driver.FindElement(By.XPath("//*[@id='userName']"));
            userNameInput.SendKeys(Name);

            IWebElement emailInput = driver.FindElement(By.XPath("//*[@id='userEmail']"));
            emailInput.SendKeys(Email);

            IWebElement currentAddressInput = driver.FindElement(By.XPath("//*[@id='currentAddress']"));
            currentAddressInput.SendKeys(CurrentAddress);

            IWebElement permanentAddressInput = driver.FindElement(By.XPath("//*[@id='permanentAddress']"));
            permanentAddressInput.SendKeys(PermanentAddress);

            //paskrolinti zemyn ir paspausti mygtuka, nes kitaip jo neranda
            var submitButton = driver.FindElement(By.XPath("//*[@id='submit']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
            submitButton.Click();

            IWebElement userNameOutput = driver.FindElement(By.XPath("//*[@id='output']//*[@id='name']"));
            IWebElement emailOutput = driver.FindElement(By.XPath("//*[@id='output']//*[@id='email']"));
            IWebElement currentAddressOutput = driver.FindElement(By.XPath("//*[@id='output']//*[@id='currentAddress']"));
            IWebElement permanentAddressOutput = driver.FindElement(By.XPath("//*[@id='output']//*[@id='permanentAddress']"));

            string actualName = userNameOutput.Text;
            string actualEmail = emailOutput.Text;
            string actualCurrentAddress = currentAddressOutput.Text;
            string actualPermanentAddress = permanentAddressOutput.Text;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedEmail, actualEmail);
            Assert.AreEqual(expectedCurrentAddress, actualCurrentAddress);
            Assert.AreEqual(expectedPermanentAddress, actualPermanentAddress);

            //uzdaryti narsykles langa
            driver.Quit();
        }

        //2-ame teste įvesti neteisingo formato email ir patikrinti, kad email laukelis tapo apvestas raudonai.

        [Test]

        public void Test02()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/text-box";

            string expectedResult = "rgba(255, 0, 0, 1)";
            string expectedEmailFieldClassAttribute = "field-error";

            //lauko uzpildymas
            IWebElement emailInput = driver.FindElement(By.XPath("//*[@id='userEmail']"));
            emailInput.SendKeys("test");

            //paskrolinti zemyn ir paspausti mygtuka
            var submitButton = driver.FindElement(By.XPath("//*[@id='submit']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
            submitButton.Click();

            string actualEmailFieldClassAttribute = emailInput.GetAttribute("class"); 

            Assert.IsTrue(actualEmailFieldClassAttribute.Contains(expectedEmailFieldClassAttribute));

            Thread.Sleep(150);

            var actualResult = emailInput.GetCssValue("border-color");

            Assert.AreEqual(expectedResult, actualResult);

            //uzdaryti narsykles langa
            driver.Quit();
        }
    }
}
