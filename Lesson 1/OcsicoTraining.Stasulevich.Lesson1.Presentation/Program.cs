using System;
using OcsicoTraining.Stasulevich.Lesson1.Task1;
using OcsicoTraining.Stasulevich.Lesson1.Task2;
using OscicoTraining.Stasulevich.Lesson1.Task3;
namespace OcsicoTraining.Stasulevich.Lesson1.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[][]
            {
            new int[] {1,3,5,7,9},
            new int[] {11,22},
            new int[] {0,2,4,6}
             };

            //euclideanAlgorithm.GDC(1071, 462);

            Console.WriteLine("Наибольшее общее кратное: " + BinarySearch.BinaryGCD(1071, 462));
            //BubbleSort._sort(arr, BubbleSort.ArrayComparisonBy.Min, BubbleSort.OrderBy.Asc);
            Console.ReadKey();
        }
    }
}
