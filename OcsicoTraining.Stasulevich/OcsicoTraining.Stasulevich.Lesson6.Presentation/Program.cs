using System;
using System.Collections.Generic;

namespace OcsicoTraining.Stasulevich.Lesson6.Presentation
{
    public class Program
    {
        private static void Main()
        {
            var collection = new GenericList.GenericList<int>(5)
            {
                1,
                2,
                3,
                5
            };

            foreach(var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
