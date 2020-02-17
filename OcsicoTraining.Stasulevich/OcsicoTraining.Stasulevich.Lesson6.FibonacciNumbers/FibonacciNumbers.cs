using System;
using System.Collections.Generic;

namespace OcsicoTraining.Stasulevich.Lesson6.FibonacciNumbers
{
    public class FibonacciNumbers
    {
        public static IEnumerable<int> FibonacciSequence(int countOfNumbers)
        {
            var a = 0;
            var b = 1;

            for (var i = 0; i < countOfNumbers; i++)
            {
                var current = a;

                a = b;
                b += current;

                yield return current;
            }
        }
    }
}
