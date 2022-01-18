using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using TaxCalculatorApp;
namespace TaxCalculatorAppTests
{
    [TestFixture]
    public class TaxCalculatorShould
    {
        TaxCalculator SUT;//system under test

        [SetUp]
        public void Init()
        {
            SUT = new TaxCalculator();
        }

        [Test]
        public void Return_2percent_Of_AnnualIncome_For_Upto_2LakhIncome()
        {
            double input = 200000;
            double expected = 4000;

            double actual = SUT.CalculateTaxAmount(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Return_5percent_Of_AnnualIncome_For_Upto_5LakhIncome()
        {
            double input = 400000;
            double expected = 20000;

            double actual = SUT.CalculateTaxAmount(input);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Throws_ArgumentException_On_Passing_Zero_As_AnnualIncome()
        {
            double input = 0;
            Assert.Throws<ArgumentException>(() => SUT.CalculateTaxAmount(input));
        }
    }
}
