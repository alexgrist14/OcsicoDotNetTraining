using System.Linq;
using NUnit.Framework;

namespace OcsicoTraining.Stasulevich.Lesson6.TestsFibonacciNumbers
{
    [TestFixture]
    public class TestsFibonacciNumbers
    {
        [Test]
        public void FibonacciSequence_InputCountOfNumbers7_ReturnCollectionWithSevenNumbers()
        {
            //Arrange
            var number = 7;
            var expected = 7;

            //Act
            var actual = FibonacciNumbers.FibonacciNumbers.FibonacciSequence(number).Count();

            //Assert
            Assert.AreEqual(expected, actual, "count of number should be seven");
        }

        [Test]
        public void FibonacciSequence_InputCountOfNumbers10_ReturnTenthNumberIs34()
        {
            //Arrange
            var number = 10;
            var expected = 34;

            //Act
            var actual = FibonacciNumbers.FibonacciNumbers.FibonacciSequence(number).Last();

            //Assert
            Assert.AreEqual(expected, actual, double.Epsilon, "tenth number should be 34");
        }

        [Test]
        public void FibonacciSequence_InputNegativeNumber1_ShouldExepction()
        {
            //Arrange
            var number = -1;

            //Act
            void GetException() => FibonacciNumbers.FibonacciNumbers.FibonacciSequence(number).ToList();

            //Assert
            Assert.Throws<System.ArgumentException>(GetException);
        }
    }
}
