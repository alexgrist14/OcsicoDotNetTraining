using System;

namespace NewTonMethodTests
{
    public static class NewtonMethod
    {
        public static double Pow(double power, double epsilon, double initValue, int accuracy)
        {
            if(initValue == 0)
            {
                throw new ArgumentException("root must be not zero");
            }
            if(initValue < 0)
            {
                throw new ArgumentException("root should be more than 1");
            }

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
