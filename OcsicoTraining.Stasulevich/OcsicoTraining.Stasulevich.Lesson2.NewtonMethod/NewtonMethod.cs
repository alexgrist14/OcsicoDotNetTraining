using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson2.NewtonMethod
{
    public static class NewtonMethod
    {
        public static double Pow(double degree, double epsilon, double initValue)
        {
            var root = initValue;

            while (true)
            {
                var function = (root * root) - degree;

                if (Math.Abs(function) < epsilon)
                {
                    break;
                }

                var differential = -function / (2.0 * root);
                root += differential;
            }

            return root;
        }
    }
}
