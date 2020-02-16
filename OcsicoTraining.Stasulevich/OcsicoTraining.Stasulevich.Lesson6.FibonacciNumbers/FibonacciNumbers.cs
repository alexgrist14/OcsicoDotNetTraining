using System;

namespace OcsicoTraining.Stasulevich.Lesson6.FibonacciNumbers
{
    public class FibonacciNumbers
    {
        public static int FibonacciSequence(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number should be positive");
            }

            var a = 1;
            var b = 1;

            for (var i = 3; i <= number; i++)
            {
                var sum = a + b;
                a = b;
                b = sum;
            }

            return b;
        }
    }
}
