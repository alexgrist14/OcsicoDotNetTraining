using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson2.NewtonMethod
{
    public static class NewtonMethod
    {
        public static double Pow(double n, double eps, double initValue)
        {
            var x = initValue;

            do
            {
                var f = (x * x) - n;

                if (Math.Abs(f) < eps)
                {
                    break;
                }

                var dx = -f / (2.0 * x);
                x += dx;
            } while (true);

            return x;
        }
    }
}
