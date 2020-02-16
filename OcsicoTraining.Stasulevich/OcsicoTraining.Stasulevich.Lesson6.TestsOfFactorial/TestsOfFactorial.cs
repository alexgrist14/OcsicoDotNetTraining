using NUnit.Framework;

namespace OcsicoTraining.Stasulevich.Lesson6.TestsOfFactorial
{
    public class TestsOfFactorial
    {
        [Test]
        public void Factorial3_ShouldReturnCorrectValue()
        {
            //Arrange
            var number = 3;
            var expected = 6;

            //Act
            var actual = FactorialCalculator.FactorialCalculator.FactorialOfNumber(number);

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "factorial of 3 test is successfull");
        }

        [Test]
        public void Factorial10_ShouldReturnCorrectValue()
        {
            //Arrange
            var number = 10;
            var expected = 3628800;

            //Act
            var actual = FactorialCalculator.FactorialCalculator.FactorialOfNumber(number);

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "factorial of 10 test is successfull");
        }

        [Test]
        public void FactorialMinus5_Should_Exeption()
        {
            //Arrange
            var number = -5;

            //Act
            //Assert
            Assert.Throws<System.ArgumentException>(() => FactorialCalculator.FactorialCalculator.FactorialOfNumber(number));
        }

        [Test]
        public void Factorial0_Should_Exeption()
        {
            //Arrange
            var number = 0;

            //Act
            //Assert
            Assert.Throws<System.ArgumentException>(() => FactorialCalculator.FactorialCalculator.FactorialOfNumber(number));
        }
    }
}
