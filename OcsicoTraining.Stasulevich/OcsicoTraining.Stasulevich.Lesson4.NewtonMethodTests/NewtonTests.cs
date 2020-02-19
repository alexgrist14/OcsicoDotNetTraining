using System;
using NUnit.Framework;
using OcsicoTraining.Stasulevich.Lesson2.NewtonMethod;

namespace NewtonMethodTests
{
    [TestFixture]
    public class NewtonTests
    {
        [Test]
        public void Pow_22And_Number5_ShouldReturnCorrectValue()
        {
            //Arrange
            var power = 22;
            var epsilon = 0.0000001;
            var number = 5;
            var expected = Math.Pow(5, (double)1 / 22);

            //Act
            var actual = NewtonMethod.Pow(power, number, epsilon);

            //Assert
            Assert.AreEqual(expected, actual, epsilon, "Pow 22 and number 5 test is successful");
        }

        [Test]
        public void Pow_5And_Number10_ShouldReturnCorrectValue()
        {
            //Arrange
            var power = 5;
            var epsilon = 0.0000001;
            var number = 10;
            var expected = Math.Pow(10, (double)1 / 5);

            //Act
            var actual = NewtonMethod.Pow(power, number, epsilon);

            //Assert
            Assert.AreEqual(expected, actual, epsilon, "Pow 5 and number 10 test is successful");
        }

        [Test]
        public void Pow_2And_Number0_ShouldThrowExeption()
        {
            //Arrange
            var power = 2;
            var epsilon = 0.0000001;
            var number = 0;

            //Act
            void GetException() => NewtonMethod.Pow(power, number, epsilon);

            //Assert
            Assert.Throws<ArgumentException>(GetException);
        }

        [Test]
        public void Pow_5And_NegativeNumber5_ShouldThrowExeption()
        {
            //Arrange
            var power = 5;
            var epsilon = 0.0000001;
            var number = 0;

            //Act
            void GetException() => NewtonMethod.Pow(power, number, epsilon);

            //Assert
            Assert.Throws<ArgumentException>(GetException);
        }
    }
}
