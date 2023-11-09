using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.BackgroundService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_test_02
{
    public class DemoQA_test_02
    {
        //2-ame teste įvesti neteisingo formato email ir patikrinti, kad email laukelis tapo apvestas raudonai.

        [Test]

        public void Test02()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://demoqa.com/text-box";

            string expectedResultTop = "rgba(255, 0, 0, 1)";
            string expectedResultLeft = "rgba(255, 0, 0, 1)";
            string expectedResultRight = "rgba(255, 0, 0, 1)";
            string expectedResultBottom = "rgba(255, 0, 0, 1)";

            //lauko uzpildymas
            IWebElement emailInput = driver.FindElement(By.XPath("//*[@id='userEmail']"));
            emailInput.SendKeys("test");

            //paskrolinti zemyn ir paspausti mygtuka
            var submitButton = driver.FindElement(By.XPath("//*[@id='submit']"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", submitButton);
            submitButton.Click();

            var emailInputField = driver.FindElement(By.ClassName("field-error"));
            var actualResultTop = emailInputField.GetCssValue("border-top-color");
            var actualResultLeft = emailInputField.GetCssValue("border-left-color");
            var actualResultRight = emailInputField.GetCssValue("border-right-color");
            var actualResultBottom = emailInputField.GetCssValue("border-bottom-color");

            Assert.AreEqual(expectedResultTop, actualResultTop);
            Assert.AreEqual(expectedResultLeft, actualResultLeft);
            Assert.AreEqual(expectedResultRight, actualResultRight);
            Assert.AreEqual(expectedResultBottom, actualResultBottom);

            //uzdaryti narsykles langa
            driver.Quit(); 
        }
    }
}

