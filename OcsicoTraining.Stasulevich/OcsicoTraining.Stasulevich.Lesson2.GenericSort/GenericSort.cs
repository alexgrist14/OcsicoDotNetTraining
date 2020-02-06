using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OcsicoTraining.Stasulevich.Lesson2.Presentation
{
    public static class GenericSort
    {
        public static IEnumerable<T> Orderby<T>(this IEnumerable<T> enumerable, string property) => enumerable.OrderBy(x => GetProperty(x, property));

        private static object GetProperty(object o, string propertyName) => o.GetType().GetProperty(propertyName).GetValue(o, null);

        public class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }
        }

    }
}
