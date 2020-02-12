using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson2.NewtonMethod
{
    public static class NewtonMethod
    {
        public static double Pow(double power, double epsilon, double initValue, int accuracy)
        {
            var root = initValue;
            double function;

            do
            {
                function = (root * root) - power;
                var differential = -function / (2.0 * root);
                root += differential;
            }
            while ((Math.Abs(function) < epsilon) != true);

            return Math.Round(root, accuracy);
        }
    }
}
