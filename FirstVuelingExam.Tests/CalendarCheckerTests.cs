using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstVuelingExam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstVuelingExam.Common.Library.Utils;

namespace FirstVuelingExam.Tests
{
    [TestClass()]
    public class CalendarCheckerTests
    {

        [DataRow(1, 2020, 30)]
        [DataRow(6, 2000, 29)]
        [DataTestMethod]
        public void getLastThursdayTest(int month, int year, int dayOfMonthLastThursday)
        {
            DateTime lastThursday = CalendarChecker.getLastThursday(month, year);

            Assert.AreEqual(dayOfMonthLastThursday, lastThursday.Day);
        }
    }
}