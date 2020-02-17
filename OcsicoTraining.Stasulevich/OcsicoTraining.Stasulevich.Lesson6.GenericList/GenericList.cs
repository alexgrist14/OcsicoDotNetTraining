using System;
using System.Runtime;
using System.Runtime.Versioning;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Security.Permissions;

namespace OcsicoTraining.Stasulevich.Lesson6.GenericList
{
    public class GenericList<T>
    {
        private readonly int defaultCapacity = 4;

        private T[] items;
        private int size;

        public void Add(T item)
        {
            if(size == items.Length)
        }

        private void EnsureCapacity(int min)
        {
            if(items.Length < min)
            {
                var newCapacity = items.Length == 0 ? defaultCapacity : items.Length * 2;
            }
        }


    }
}
