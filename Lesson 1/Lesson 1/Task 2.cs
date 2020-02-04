using System;

namespace Lesson_1
{
    public class Task2
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
        }//task2
    }
}