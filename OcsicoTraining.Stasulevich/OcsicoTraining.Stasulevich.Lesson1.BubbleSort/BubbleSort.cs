using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using enums;

namespace OcsicoTraining.Stasulevich.Lesson1.BubbleSort
{
    public static class BubbleSort
    {
        public static int[][] Sort(int[][] arr, ArrayComparisonBy arrComparisonBy, OrderBy orderBy)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr.Length - i - 1; j++)
                {
                    if (CheckIfNeedSwap(arr[j], arr[j + 1], arrComparisonBy, orderBy))
                    {
                        var temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            return arr;
        }

        public static bool CheckIfNeedSwap(int[] arrayToSwapFirst, int[] arrayToSwapSecond, ArrayComparisonBy arrComparisonBy, OrderBy orderBy)
        {
            var temp = 0;
            var needSwap = false;

            int res;
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
