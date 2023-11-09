using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Unit_test
{
    public class Task_17
    {
        [Test]
        public void Test1()   //Testas “žalias” jeigu 995 dalijasi iš 3(be liekanos)
        {

            int expectedResult = 0;
            int actualResult = 995 % 3;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test2() //Testas “žalias” jeigu šiandien trečiadienis
        {
            DayOfWeek expectedResult = DayOfWeek.Wednesday;
            DateTime today = DateTime.Today;
            DayOfWeek actualResult = today.DayOfWeek;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Test3() //Testas “žalias” jeigu dabar yra 13h 
        {
            int expectedResult = 13;
            DateTime now = DateTime.Now;
            int actualResult = now.Hour;

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}
