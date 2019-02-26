using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstVuelingExam.Common.Library.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstVuelingExam.Common.Library.Models;

namespace FirstVuelingExam.Common.Library.Utils.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [DataRow("9,36", 49, "5,235")]
        [DataRow("5,33", 49, "9,193")]
        [DataTestMethod]
        public void calculateStocksTest(string p0, int p1, string result)
        {
            Assert.IsTrue(Calculator.calculateStocks(decimal.Parse(p0), p1) == decimal.Parse(result));
        }

    }
}