using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OcsicoTraining.Stasulevich.Lesson2.Presentation
{
    public class Program
    {
        private static void Main()
        {
            var list = new List<GenericSort.Person>
            {
                new GenericSort.Person{Age = 20, Name = "Billy"},
                new GenericSort.Person{Age = 19, Name = "Van"},
                new GenericSort.Person{Age = 33, Name = "Kojima"},
                new GenericSort.Person{Age = 4, Name = "Kazuma"},
                new GenericSort.Person{Age = 12, Name = "Subaru"}
            };

            var byAge = list.Orderby("Age");
            Console.WriteLine("Ordered by Age");

            foreach (var item in byAge)
            {
                Console.WriteLine(item.Age + " - " + item.Name);
            }

            Console.WriteLine();
            Console.WriteLine("root of n degree: " + NewtonMethod.NewtonMethod.Pow(100, 0.0001, 2));
            Console.WriteLine(Math.Pow(2, 5));

            var arr = new List<int> { 1, 2, 3 };
            
            Console.WriteLine(GenericQueue.GenericQueue.Count(arr));
            GenericQueue.GenericQueue.Enqueue(arr, 4);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
