using System;
using enums;

namespace OcsicoTraining.Stasulevich.Lesson1.Presentation
{
    public class Program
    {
        private static void Main()
        {
            var arr = new int[][]
            {
                new int[] {1,3,5,7,9},
                new int[] {0,1},
                new int[] {22,2,4,6}
             };

            Console.WriteLine("Greatest common divisor: " + Gdc.Gdc.Calculate(1071, 462));

            Console.WriteLine("Greatest common divisor: " + BinaryGdc.BinaryGdc.Calculate(10, 2));

            var newArr = BubbleSort.BubbleSort.Sort(arr, ArrayComparisonBy.Min, OrderBy.Asc);

            for (var i = 0; i < newArr.Length; i++)
            {
                Console.Write("Element({0}): ", i);

                for (var j = 0; j < newArr[i].Length; j++)
                {
                    Console.Write("{0}{1}", newArr[i][j], j == (newArr[i].Length - 1) ? "" : " ");
                }

                Console.WriteLine();
            }

        }
    }

}
