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
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> array, Func<T, T, bool> condition) where T : IComparable<T>
        {
            var sortArray = array.ToList();

            for (var i = sortArray.Count; i >= 1; i--)
            {
                for (var j = 0; j < i - 1; j++)
                {
                    if (condition(sortArray[j], sortArray[j + 1]))
                    {
                        (sortArray[j], sortArray[j + 1]) = (sortArray[j + 1], sortArray[j]);
                    }

                }
            }
            return sortArray;
        }
    }

}
