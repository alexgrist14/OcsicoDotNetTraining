using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace OcsicoTraining.Stasulevich.Lesson2.Presentation
{

    public static class GenericSort
    {
        public static IEnumerable<T> BubbleSort<T>(this IEnumerable<T> array) where T : IComparable
        {
            var sortArray = array.ToList();
            for (var i = sortArray.Count; i >= 1; i--)
            {
                for (var j = 0; j < i - 1; j++)
                {
                    if (sortArray[j].CompareTo(sortArray[j + 1]) > 0)
                    {
                        var swap = sortArray[j];
                        sortArray[j] = sortArray[j + 1];
                        sortArray[j + 1] = swap;
                    }

                }
            }
            return sortArray;
        }
    }

}
