using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using CohortManagement.Core;
namespace CohortManagement.UnitTests
{
    [TestFixture]
    public class TraineeSpecs
    {

        [Test]
        public void Two_Trainees_With_Same_Ids_Must_Be_Equal()
        {
            var trainee1 = new Trainee("Jojo", "Jojo@cognizant.com", DateTime.Now.Date);
            var trainee2 = new Trainee("Jojo", "Jojo@cognizant.com", DateTime.Now.Date);

            trainee1.Id = 101;
            trainee2.Id = 101;

            var result = trainee1.Equals(trainee2);
            Assert.That(result, Is.True);
        }

        [Test]
        public void Create_New_Instance_Using_ValidValues()
        {
            var trainee1 = new Trainee("Jojo", "Jojo@cognizant.com", DateTime.Now.Date);
            Assert.That(trainee1, Is.Not.Null);
        }
        [Test]
        [TestCase(null, "jojo@cognizant.com", "2022/03/09")]
        [TestCase("", "jojo@cognizant.com", "2022/03/09")]
        [TestCase("Jojo", null, "2022/03/09")]
        [TestCase("Jojo", "", "2022/03/09")]
        [TestCase("Jojo", "jojo@wipro.com", "2022/03/09")]
        [TestCase("Jojo", "jojo@cognizant.com", "2021/03/09")]
        public void Throw_ArgumentException_For_Invalid_Input(string name, string email, DateTime doj)
        {
            Assert.Throws<ArgumentException>(() => new Trainee(name, email, doj));
        }

        [Test]
        public void Changes_TraineeName_To_NewName()
        {
            var trainee= new Trainee("Jojo", "Jojo@cognizant.com", DateTime.Now.Date);
            trainee.ChangeName("Jojo Jose");
            Assert.That(trainee.Name, Is.EqualTo("Jojo Jose"));
        }

        [Test]
        public void Throw_ArgumentException_When_Invalid_Name_Provided_To_ChangeName()
        {
            var trainee = new Trainee("Jojo", "Jojo@cognizant.com", DateTime.Now.Date);
            Assert.Throws<ArgumentException>(() => trainee.ChangeName(""));
            Assert.Throws<ArgumentException>(() => trainee.ChangeName(null));
        }
    }
}
