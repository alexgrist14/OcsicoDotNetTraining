using System;

using System.Linq;

using enums;

namespace OscicoTraining.Stasulevich.Lesson1.Task3
{
    public class BubbleSort
    {

        public static int[][] Sort(int[][] arr, ArrayComparisonBy arrComparisonBy, OrderBy orderBy)
        {
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

            return arr;
        }
        public static int Compare(int[] arr1, int[] arr2, ArrayComparisonBy arrComparisonBy, OrderBy orderBy)
        {
            var res = 0;
            switch (arrComparisonBy)
            {
                case ArrayComparisonBy.Sum:
                    res = arr1.Sum() - arr2.Sum();
                    return (orderBy == OrderBy.Asc) ? res : -res;

                case ArrayComparisonBy.Max:
                    res = arr1.Max() - arr2.Max();
                    return (orderBy == OrderBy.Asc) ? res : -res;

                case ArrayComparisonBy.Min:
                    res = arr1.Min() - arr2.Min();
                    return (orderBy == OrderBy.Asc) ? res : -res;
            }

            return 0;
        }
    }
}
