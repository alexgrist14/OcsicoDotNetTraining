using System;
using System.Collections.Generic;
using System.Text;

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
            var secondNumber = 1 / power * (((power - 1) * firstNumber) + (initialValue / Math.Pow(firstNumber, (int)power - 1)));

            do
            {
                firstNumber = secondNumber;
                secondNumber = 1 / power * (((power - 1) * firstNumber) + (initialValue / Math.Pow(firstNumber, (int)power - 1)));
            }
            while (Math.Abs(secondNumber - firstNumber) > epsilon);

            return secondNumber;
        }
    }
}
