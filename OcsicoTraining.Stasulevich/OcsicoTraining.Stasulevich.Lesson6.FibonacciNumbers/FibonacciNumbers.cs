using System;
using System.Collections.Generic;

namespace OcsicoTraining.Stasulevich.Lesson6.FibonacciNumbers
{
    public class FibonacciNumbers
    {
        public static IEnumerable<int> FibonacciSequence(int countOfNumbers)
        {
            if (countOfNumbers < 0)
            {
                throw new ArgumentException("countOfNumbers must be more than 0");
            }

            var firstNumber = 0;
            var secondNumber = 1;

            for (var i = 0; i < countOfNumbers; i++)
            {
                var current = firstNumber;

                firstNumber = secondNumber;
                secondNumber += current;

                yield return current;
            }
        }
    }
}
