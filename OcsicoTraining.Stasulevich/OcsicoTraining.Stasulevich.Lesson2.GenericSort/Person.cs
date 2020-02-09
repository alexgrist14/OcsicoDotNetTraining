using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson2.GenericSort
{
    public class Person : IComparable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.Age.CompareTo(other.Age);
        }
    }
}
