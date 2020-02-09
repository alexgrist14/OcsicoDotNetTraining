using System;
using System.Collections.Generic;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson2.GenericSort
{
    public class Person : IComparable
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompareTo(object other)
        {
            var otherPerson = other as Person;
            if (otherPerson.Age < Age)
            {
                return 1;
            }

            if (otherPerson.Age > Age)
            {
                return -1;
            }

            if (otherPerson.Age == Age)
            {
                return 0;
            }

            return 0;
        }
    }
}
