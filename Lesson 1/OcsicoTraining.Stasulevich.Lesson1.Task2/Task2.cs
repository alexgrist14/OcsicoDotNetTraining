﻿using System;

namespace OcsicoTraining.Stasulevich.Lesson1.Task2
{
    public class BinarySearch
    {
        public static int BinaryGCD(int a, int b)
        {
            var shift = 0;
            if (a == 0) return b;
            if (b == 0) return a;

            while (((a | b) & 1) == 0)
            {
                shift++;
                a >>= 1;
                b >>= 1;
            }

            while ((a & 1) == 0)
            {
                a >>= 1;
            }

            do
            {
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    var t = b; 
                    b = a; 
                    a = t;
                }

                b -= a;
            } while (b != 0);

            return a << shift;
        }
    }
}
