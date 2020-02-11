using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson2.GenericQueue
{
    public class GenericQueue<T>
    {
        private int front = 1;
        private int back = -1;
        private readonly T[] array;

        public int Size { get; }
        public int Count { get; private set; } = 0;

        public GenericQueue(int size)
        {
            this.Size = size;
            this.array = new T[size];
        }

        public bool IsFull() => back == Size - 1;

        public bool IsEmpty() => Count == 0;

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                throw new Exception("Queue is full");
            }

            array[++back] = item;
            Count++;
        }

        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            var value = array[++front];
            Count--;

            if (front == back)
            {
                front = 1;
                back = -1;
            }
            return value;
        }

        public T Peek()
        {
            if (this.IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            var value = array[front + 1];
            return value;
        }

        public void Clear()
        {
            if (this.IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            Count = 0;
            front = 1;
            back = -1;
        }

        public bool Contains<T>(T item, IComparer comparer)
        {
            var isContains = false;
            if (this.IsEmpty())
            {
                return false;
            }

            foreach (var str in array)
            {
                if (comparer.Compare(str, item) == 0)
                {
                    isContains = true;
                }
            }

            return isContains;
        }

    }
}
