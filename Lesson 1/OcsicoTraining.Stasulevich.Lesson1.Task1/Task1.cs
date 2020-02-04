using System;

namespace OcsicoTraining.Stasulevich.Lesson1.Task1
{
    public class euclideanAlgorithm
    {
        public static int GDC(int a, int b)
        {
            int nod;

            int temp = a;

            int currentStep = 0;

            while (temp != 0)
            {
                if (temp >= b)
                {
                    temp = temp - b;
                    currentStep++;
                }
                else
                {
                    nod = currentStep * b + temp;
                    b = temp;
                    temp = nod;
                    currentStep = 0;
                }
            }

            return b;

        }
    }
}
