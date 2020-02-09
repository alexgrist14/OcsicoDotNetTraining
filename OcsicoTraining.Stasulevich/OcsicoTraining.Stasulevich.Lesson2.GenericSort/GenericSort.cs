using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using OcsicoTraining.Stasulevich.Lesson2.GenericSort;

namespace OcsicoTraining.Stasulevich.Lesson2.Presentation
{
    public static class GenericSort
    {
        public static IEnumerable<T> BubbleSortAsc<T>(this IEnumerable<T> array) where T : IComparable<T>
        {
            var sortArray = array.ToList();
            for (var i = sortArray.Count; i >= 1; i--)
            {
                for (var j = 0; j < i - 1; j++)
                {
                    if (sortArray[j].CompareTo(sortArray[j + 1]) > 0)
                    {
                        (sortArray[j], sortArray[j + 1]) = (sortArray[j + 1], sortArray[j]);
                    }

                }
            }
            return sortArray;
        }

        public static IEnumerable<T> BubbleSortDesc<T>(this IEnumerable<T> array) where T : IComparable<T>
        {
            var sortArray = array.ToList();
            for (var i = sortArray.Count; i >= 1; i--)
            {
                for (var j = 0; j < i - 1; j++)
                {
                    if (sortArray[j].CompareTo(sortArray[j + 1]) < 0)
                    {
                        (sortArray[j], sortArray[j + 1]) = (sortArray[j + 1], sortArray[j]);
                    }

                }
            }
            return sortArray;
        }
    }

}
