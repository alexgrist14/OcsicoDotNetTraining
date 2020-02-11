using System;
using NUnit.Framework;

namespace NUnitTestProject1
{
    public static class NewtonMethod
    {
        public static double Pow(double power, double epsilon, double initValue,int accuracy)
        {
            var root = initValue;

            _ = (root * root) - power;

            double function;
            do
            {
                function = (root * root) - power;
                var differential = -function / (2.0 * root);
                root += differential;
            }
            while ((Math.Abs(function) < epsilon) != true);
            return Math.Round(root,accuracy);
        }
    }
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        
        [Test]
        public void Pow_22And5_4_69Should()
        {
            var actual = NewtonMethod.Pow(22, 0.0001, 5,2);
            var expected = 4.69;
            Assert.AreEqual(expected, actual, double.Epsilon, "Pow 22 and 5 power should return 4,69");
        }

        [Test]
        public void Pow_5And10_2_236Should()
        {
            var actual = NewtonMethod.Pow(5, 0.0001, 10, 3);
            var expected = 2.236;
            Assert.AreEqual(expected, actual, double.Epsilon, "Pow 5 and 10 power should return 2,236");
        }

        [Test]
        public void Pow_56232And23453_237_1328741444Should()
        {
            var actual = NewtonMethod.Pow(56232, 0.0001, 23453, 10);
            var expected = 237.1328741444;
            Assert.AreEqual(expected, actual, double.Epsilon, "Pow 56232 and 23453 power should return 237,1328741444");
        }
    }
}
