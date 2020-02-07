using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson2.GenericQueue
{
    public static class GenericQueue
    {
        public static int Count<T>(List<T> array) => array.Count();

        public static void Enqueue<T>(List<T> array, T value) => array.Add(value);

        public static void Dequeue<T>(List<T> array) => array.RemoveAt(0);

        public static T Peek<T>(List<T> array) => array.ElementAt(0);

        public static bool Contains<T>(List<T> array, T element) => array.Contains(element);

        public static void Clear<T>(List<T> array) => array.Clear();
    }
}
