using System;
using System.Linq;


namespace Lesson_1
{
    class Program
    {
        //public enum OrderBy1 { Asc, Desc }
        //public enum ArrayComparisonBy1 { Sum, Max, Min }
        
        static void Main(string[] args)
        {
            int[][] arr = new int[][]
    {
            new int[] {1,3,5,7,9},
            new int[] {11,22},
            new int[] {0,2,4,6}
    };

            Task1.euclideanAlgorithm(1071, 462);


            //Console.WriteLine("Наибольшее общее кратное: " + Task2.BinaryGCD(1071, 462));
            //Task3.bubbleSort(arr, Task3.ArrayComparisonBy.Max, Task3.OrderBy.Desc);
            Console.ReadKey();
        }

        
    }
}
