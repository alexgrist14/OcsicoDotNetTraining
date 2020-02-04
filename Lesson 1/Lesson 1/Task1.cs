using System;

namespace Lesson_1
{
    public class Task1
    {

        public static void euclideanAlgorithm(int a, int b)
        {
            int NOD;
            int temp = a;
            int q = 0;
            while (temp != 0)
            {

                if (temp >= b)
                {
                    temp = temp - b;
                    q++;
                }

                else
                {
                    NOD = q * b + temp;
                    b = temp;
                    temp = NOD;
                    q = 0;
                }
            }

            Console.WriteLine("Наибольший общий делитель: " + b);

        } // task 1

    }
}