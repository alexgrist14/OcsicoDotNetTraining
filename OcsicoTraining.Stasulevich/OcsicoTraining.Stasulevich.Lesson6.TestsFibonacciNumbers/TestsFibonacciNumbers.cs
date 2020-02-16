using NUnit.Framework;

namespace OcsicoTraining.Stasulevich.Lesson6.TestsFibonacciNumbers
{
    [TestFixture]
    public class TestsFibonacciNumbers
    {
        [Test]
        public void Input7_ShouldReturnCorrectValue()
        {
            //Arrange
            var number = 7;
            var expected = 13;

            //Act
            var actual = FibonacciNumbers.FibonacciNumbers.FibonacciSequence(number);

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "fibonacci number of 7 test is successful");
        }

        [Test]
        public void Input12_ShouldReturnCorrectValue()
        {
            //Arrange
            var number = 20;
            var expected = 6765;

            //Act
            var actual = FibonacciNumbers.FibonacciNumbers.FibonacciSequence(number);

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "fibonacci number of 20 test is successful");
        }

        [Test]
        public void InputMinus1_Should_Exepction()
        {
            //Arrange
            var number = -1;

            //Act
            //Assert
            Assert.Throws<System.ArgumentException>(() => FibonacciNumbers.FibonacciNumbers.FibonacciSequence(number));
        }
    }
}
