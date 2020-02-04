using System;

namespace OcsicoTraining.Stasulevich.Lesson1.Task2
{
    public class BinarySearch
    {
        public static int BinaryGCD(int u, int v)
        {
            int shift = 0;
            if (u == 0) return v;
            if (v == 0) return u;

            while (((u | v) & 1) == 0)
            {
                shift++;
                u >>= 1;
                v >>= 1;
            }

            while ((u & 1) == 0)
            {
                u >>= 1;
            }

            do
            {
                while ((v & 1) == 0)
                {
                    v >>= 1;
                }

                if (u > v)
                {
                    int t = v; v = u; u = t;
                }

                v -= u;
            } while (v != 0);

            return u << shift;
        }
    }
}
