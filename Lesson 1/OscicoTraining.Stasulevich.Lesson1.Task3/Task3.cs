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
                    if (CheckIfNeedSwap(arr[j], arr[j + 1], arrComparisonBy, orderBy))
                    {
                        int[] temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            return arr;
        }

        public static bool CheckIfNeedSwap(int[] arrayToSwapFirst, int[] arrayToSwapSecond, ArrayComparisonBy arrComparisonBy, OrderBy orderBy)
        {
            var res = 0;
            var temp = 0; ;
            var needSwap = false;

            switch (arrComparisonBy)
            {
                case ArrayComparisonBy.Sum:
                    res = arrayToSwapFirst.Sum() - arrayToSwapSecond.Sum();
                    temp = (orderBy == OrderBy.Asc) ? res : -res;
                    break;
                case ArrayComparisonBy.Max:
                    res = arrayToSwapFirst.Max() - arrayToSwapSecond.Max();
                    temp = (orderBy == OrderBy.Asc) ? res : -res;
                    break;
                case ArrayComparisonBy.Min:
                    res = arrayToSwapFirst.Min() - arrayToSwapSecond.Min();
                    temp = (orderBy == OrderBy.Asc) ? res : -res;
                    break;
            }

            if (temp > 0)
            {
                needSwap = true;
            }

            return needSwap;
        }
    }
}
