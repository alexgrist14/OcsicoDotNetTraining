using System;
using OcsicoTraining.Stasulevich.Lesson1.Task1;
using OcsicoTraining.Stasulevich.Lesson1.Task2;
using OscicoTraining.Stasulevich.Lesson1.Task3;
using enums;

namespace OcsicoTraining.Stasulevich.Lesson1.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[][]
            {
                new int[] {1,3,5,7,9},
                new int[] {0,1},
                new int[] {22,2,4,6}
             };

            Console.WriteLine("Greatest common divisor: " + euclideanAlgorithm.GDC(1071, 462));

            Console.WriteLine("Greatest common divisor: " + BinarySearch.BinaryGCD(10, 2));

            var newArr = BubbleSort.Sort(arr, ArrayComparisonBy.Min, OrderBy.Asc);

            for (int i = 0; i < newArr.Length; i++)
            {
                Console.Write("Element({0}): ", i);

                for (int j = 0; j < newArr[i].Length; j++)
                {
                    Console.Write("{0}{1}", newArr[i][j], j == (newArr[i].Length - 1) ? "" : " ");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
