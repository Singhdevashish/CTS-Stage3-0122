using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using CalculatorApp;
using System.Collections;

namespace CalculatorAppTests
{
    [TestFixture]
    public class CalculatorTests
    {
        Calculator calculator;
        [SetUp]
        public void Initialize()
        {
            calculator = new Calculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator = null;
        }

        [Test]
        public void AddTest()
        {
            //Arrange
            //Calculator calculator = new Calculator();
            int input1 = 10;
            int input2 = 20;
            int expected = 30;

            //Act
            int actual = calculator.Add(input1, input2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SubstractTest()
        {
            //Arrange
            //Calculator calc = new Calculator();
            int input1 = 20;
            int input2 = 10;
            int expected = 10;

            //Act
            int actual = calculator.Substract(input1, input2);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Ignore("Divide not yet implemented")]
        public void DivideTest()
        {

        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(8, 2, 10)]
        [TestCase(9, 3, 12)]
        public void AddTest1(int input1, int input2, int expected)
        {
            int actual = calculator.Add(input1, input2);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        [TestCaseSource("AddTestData")]
        public void AddTest2(int input1, int input2, int expected)
        {
            int actual = calculator.Add(input1, input2);
            Assert.AreEqual(expected, actual);
        }

        public static object[] AddTestData =
        {
            new object[] { 1, 2, 3 },
            new object[] { 10, 20, 30 },
            new object[] { 5, 3, 8 }
        };
    }
}
