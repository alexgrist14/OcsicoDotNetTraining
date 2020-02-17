using NUnit.Framework;

namespace OcsicoTraining.Stasulevich.Lesson6.TestsOfFactorial
{
    public class TestsOfFactorial
    {
        [Test]
        public void FactorialOfNumber_Input3_ShouldReturn6()
        {
            //Arrange
            var number = 3;
            var expected = 6;

            //Act
            var actual = FactorialCalculator.FactorialCalculator.FactorialOfNumber(number);

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "factorial of 3 is equal to 6");
        }

        [Test]
        public void FactorialOfNumber_Input3_ShouldReturn3628800()
        {
            //Arrange
            var number = 10;
            var expected = 3628800;

            //Act
            var actual = FactorialCalculator.FactorialCalculator.FactorialOfNumber(number);

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "factorial of 10 is equal to 3628800");
        }

        [Test]
        public void FactorialOfNumber_InputMinus5_Should_Exeption()
        {
            //Arrange
            var number = -5;

            //Act
            //Assert
            Assert.Throws<System.ArgumentException>(() => FactorialCalculator.FactorialCalculator.FactorialOfNumber(number));
        }

        [Test]
        public void FactorialOfNumber_Input0_Should_Exeption()
        {
            //Arrange
            var number = 0;

            //Act
            //Assert
            Assert.Throws<System.ArgumentException>(() => FactorialCalculator.FactorialCalculator.FactorialOfNumber(number));
        }
    }
}
