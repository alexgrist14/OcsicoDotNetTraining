using System;

namespace OcsicoTraining.Stasulevich.Lesson2.NewtonMethod
{
    public static class NewtonMethod
    {
        public static double Pow(double power, double initialValue, double epsilon = 0.0000001)
        {
            if (initialValue <= 0)
            {
                throw new ArgumentException("initialValue must be positive");
            }

            var firstNumber = initialValue / power;
            var secondNumber = InitializeSecondNumber(firstNumber, power, initialValue);

            do
            {
                firstNumber = secondNumber;
                secondNumber = InitializeSecondNumber(firstNumber, power, initialValue);
            }
            while (Math.Abs(secondNumber - firstNumber) > epsilon);

            return secondNumber;
        }

        private static double InitializeSecondNumber(double firstNumber, double power, double initialValue) => 1 / power * (((power - 1) * firstNumber) + (initialValue / Math.Pow(firstNumber, (int)power - 1)));
    }
}
