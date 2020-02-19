using System;

namespace OcsicoTraining.Stasulevich.Lesson6.FactorialCalculator
{
    public class FactorialCalculator
    {
        public static int FactorialOfNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("number should be more than 0");
            }
            if (number == 1)
            {
                return number;
            }

            return number * FactorialOfNumber(number - 1);
        }
    }
}
