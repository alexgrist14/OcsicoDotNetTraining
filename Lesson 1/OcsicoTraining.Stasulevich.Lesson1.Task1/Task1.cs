using System;

namespace OcsicoTraining.Stasulevich.Lesson1.Task1
{
    public class euclideanAlgorithm
    {
        public static void GDC(int a, int b)
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
