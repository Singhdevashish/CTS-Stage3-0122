using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
namespace AssertionsDemo
{
    class Employee { }
    class SoftwareDeveloper : Employee { }
    class Customer { }

    [TestFixture]
    public class AssertionsTests
    {
        [Test]
        public void EqualityAsserts()
        {
            Assert.AreEqual(1, 1);
            //Assert.AreEqual(true, true);
            Assert.AreNotEqual(1, 1, "1 is not equal to 1");
        }

        [Test]
        public void ComparisionAsserts()
        {
            Assert.Greater(10, 5);
            Assert.GreaterOrEqual(10, 10);
            Assert.LessOrEqual(5, 10);
        }

        [Test]
        public void IdentityAsserts()
        {
            var e = new Employee();
            var e1 = e;

            Assert.AreSame(e, e1);

            var e2 = new Employee();
            //Assert.AreSame(e, e2);
            Assert.AreNotSame(e, e2);


            var oddnumbers = new int[] { 1, 3, 5, 7, 9, 11 };
            Assert.Contains(11, oddnumbers);

        }

        [Test]
        public void TypeAsserts()
        {
            var e = new Employee();
            Assert.IsInstanceOf<Employee>(e);

            var cust = new Customer();
            //Assert.IsInstanceOf<Employee>(cust);
            Assert.IsNotInstanceOf<Employee>(cust);

            var sw = new Employee();

            Assert.IsAssignableFrom<SoftwareDeveloper>(sw);
        }

        [Test]
        public void ConditionalAsserts()
        {
            bool bb = true;

            Assert.IsTrue(bb);
            //Assert.IsFalse(bb);

            Employee e = null;
            Assert.IsNull(e);
        }

        [Test]
        public void StringAsserts()
        {
            string trainername = "Khaleelullah Hussaini Syed";
            string trainername1 = "khaleelullah hussaini syed";

            StringAssert.Contains("Hussaini", trainername);
            StringAssert.AreEqualIgnoringCase(trainername, trainername1);
        }

        [Test]
        public void CollectionAsserts()
        {
            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var numbers1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            CollectionAssert.AreEqual(numbers, numbers);

            var numbers2 = new int[] { };

            //CollectionAssert.IsNotEmpty(numbers2);

            var nums = numbers.Where(n => n % 2 == 0).ToArray();
            CollectionAssert.IsSubsetOf(nums, numbers);

        }

        [Test]
        public void AssertThatTests()
        {
            var b = true;
            Assert.That(1, Is.EqualTo(1));
            Assert.That(b, Is.True); 
            
            
        }
    }
}
