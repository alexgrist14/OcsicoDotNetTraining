using System;
using System.Linq;


namespace Lesson_1
{
    class Program
    {
        public enum OrderBy { Asc, Desc }
        public enum ArrayComparisonBy { SumOfMembers, MaxMember, MinMember }

        static void Main(string[] args)
        {
            //euclideanAlgorithm(1071, 462);
            //bubbleSort(ArrayComparisonBy.MaxMember, OrderBy.Asc);
            Console.WriteLine("Наибольшее общее кратное: " + BinaryGCD(1071, 462));
            Console.ReadKey();
        }

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


        public static void bubbleSort(ArrayComparisonBy arrComparisonBy, OrderBy orderBy)
        {
            int[][] arr = new int[][]
        {
            new int[] {1,3,5,7,9},
            new int[] {11,22},
            new int[] {0,2,4,6}
        };


            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (Compare(arr[j], arr[j + 1], arrComparisonBy, orderBy) > 0)
                    {
                        int[] temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            // Display the array elements.
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Element({0}): ", i);

                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }
                Console.WriteLine();
            }
            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }//task3
        public static int Compare(int[] arr1, int[] arr2, ArrayComparisonBy arrComparisonBy, OrderBy orderBy)
        {
            int res = 0;
            switch (arrComparisonBy)
            {
                case ArrayComparisonBy.SumOfMembers:
                    res = arr1.Sum() - arr2.Sum();
                    return (orderBy == OrderBy.Asc) ? res : -res;

                case ArrayComparisonBy.MaxMember:
                    res = arr1.Max() - arr2.Max();
                    return (orderBy == OrderBy.Asc) ? res : -res;

                case ArrayComparisonBy.MinMember:
                    res = arr1.Min() - arr2.Min();
                    return (orderBy == OrderBy.Asc) ? res : -res;
            }

            return 0;
        }


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

        public static void mergeSort(int[] arr)
        {
            int[] left = new int[arr.Length / 2];
            int[] right = new int[arr.Length / 2];
            if (arr.Length <= 1)
            {
                return;
            }
            int middle = arr.Length / 2;

        }//task4
    }
}
