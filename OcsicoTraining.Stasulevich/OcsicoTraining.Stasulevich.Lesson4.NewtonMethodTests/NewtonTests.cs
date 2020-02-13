using System;
using NUnit.Framework;

namespace NewTonMethodTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Pow_22And5_4_69Should()
        {
            //Arrange
            const int power = 22;
            const double epsilon = 0.0001;
            const int root = 5;
            const int accuracy = 2;

            //Act
            var actual = NewtonMethod.Pow(power, epsilon, root, accuracy);
            var expected = 4.69;

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "Pow 22 and 5 power should return 4,69");
        }

        [Test]
        public void Pow_5And10_2_236Should()
        {
            //Arrange
            const int power = 5;
            const double epsilon = 0.0001;
            const int root = 10;
            const int accuracy = 3;

            //Act
            var actual = NewtonMethod.Pow(power, epsilon, root, accuracy);
            var expected = 2.236;

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "Pow 5 and 10 power should return 2,236");
        }

        [Test]
        public void Pow_56232And23453_237_1328741444Should()
        {
            //Arrange
            const int power = 56232;
            const double epsilon = 0.0001;
            const int root = 23453;
            const int accuracy = 10;

            //Act
            var actual = NewtonMethod.Pow(power, epsilon, root, accuracy);
            var expected = 237.1328741444;

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "Pow 56232 and 23453 power should return 237,1328741444");
        }

        [Test]
        public void Pow_2And0Should_Exeption()
        {
            //Arrange
            const int power = 2;
            const double epsilon = 0.0001;
            const int root = 0;
            const int accuracy = 1;

            //Assert
            Assert.Throws<ArgumentException>(() => NewtonMethod.Pow(power, epsilon, root, accuracy));
        }

        [Test]
        public void Pow_5AndMinus5Should_Exeption()
        {
            //Arrange
            const int power = 5;
            const double epsilon = 0.0001;
            const int root = -5;
            const int accuracy = 1;

            //Assert
            Assert.Throws<ArgumentException>(() => NewtonMethod.Pow(power, epsilon, root, accuracy));
        }
    }
}
