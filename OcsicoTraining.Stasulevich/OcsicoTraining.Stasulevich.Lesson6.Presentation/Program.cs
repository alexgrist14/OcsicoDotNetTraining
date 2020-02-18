using System;
using System.Collections.Generic;

namespace OcsicoTraining.Stasulevich.Lesson6.Presentation
{
    public class Program
    {
        private static void Main()
        {
            var collection = new GenericList.GenericList<int>(2) { 1, 2 };

            collection.Add(3);
            collection.Remove(1);

            foreach(var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
