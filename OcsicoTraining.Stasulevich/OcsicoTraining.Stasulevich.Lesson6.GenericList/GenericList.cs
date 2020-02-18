using System;
using System.Collections;
using System.Collections.Generic;

namespace OcsicoTraining.Stasulevich.Lesson6.GenericList
{
    public class GenericList<T> : IEnumerable<T>
    {
        private T[] items;
        private int size;

        public GenericList()
        {

        }

        public GenericList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("capacity must be not negative");
            }
            items = new T[capacity];
        }

        private void TrimToSize()
        {
            var newArray = new T[size * 2];

            Array.Copy(items, newArray, size);
            items = newArray;
        }

        public void Add(T item)
        {
            if (IsFull())
            {
                TrimToSize();
            }

            items[size++] = item;
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        private bool IsFull() => size == items.Length;

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < size; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Remove(T item)
        {
            var index = IndexOf(item);
            RemoveAt(index);
        }

        private void RemoveAt(int index)
        {
            Array.Copy(items, index + 1, items, index, size - index - 1);
            size--;
        }

        public void RemoveRange(int index, int count)
        {
            var length = size - index - count;

            if (index < 0 || index >= size || length < 0)
            {
                throw new IndexOutOfRangeException("Index was out of range");
            }

            Array.Copy(items, index + count, items, index, length);
            Array.Clear(items, size - count, count);
            size -= count;
        }

        private int IndexOf(T item) => Array.IndexOf(items, item);
    }
}
