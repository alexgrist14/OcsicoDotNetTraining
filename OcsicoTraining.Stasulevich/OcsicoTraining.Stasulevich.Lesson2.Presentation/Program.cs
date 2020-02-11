using System;
using System.Collections.Generic;
using OcsicoTraining.Stasulevich.Lesson2.GenericSort;
using System.Linq;
using System.Linq.Expressions;
using OcsicoTraining.Stasulevich.Lesson2.GenericQueue;

namespace OcsicoTraining.Stasulevich.Lesson2.Presentation
{
    public class Program
    {
        private static void Main()
        {
            var list = new List<Person>
            {
                new Person{Age = 20, Name = "Billy"},
                new Person{Age = 19, Name = "Van"},
                new Person{Age = 33, Name = "Kojima"},
                new Person{Age = 4, Name = "Kazuma"},
                new Person{Age = 12, Name = "Subaru"}
            };

            var sortedListAsc = list.BubbleSortAsc();

            foreach (var item in sortedListAsc)
            {
                Console.WriteLine(item.Age + " - " + item.Name);
            }

            Console.WriteLine();

            var sortedListDesc = list.BubbleSortDesc();

            foreach (var item in sortedListDesc)
            {
                Console.WriteLine(item.Age + " - " + item.Name);
            }

            Console.WriteLine();
            Console.WriteLine("root of n degree: " + NewtonMethod.NewtonMethod.Pow(56232, 0.0001, 23453,10));
            Console.WriteLine(Math.Pow(2, 5));

            var q = new GenericQueue<string>(5);
            q.Enqueue("First item");
            q.Enqueue("Second item");
            q.Enqueue("Third item");
            q.Enqueue("Fourth item");
            Console.WriteLine("Deleted: " + q.Dequeue());
            Console.WriteLine("Deleted: " + q.Dequeue());
        }
    }
}
