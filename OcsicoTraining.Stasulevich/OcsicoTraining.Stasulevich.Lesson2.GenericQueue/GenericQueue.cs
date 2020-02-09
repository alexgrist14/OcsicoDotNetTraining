using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OcsicoTraining.Stasulevich.Lesson2.GenericQueue
{
    public class GenericQueue<T>: IEnumerable
    {
        private int front = 1;
        private int rear = -1;
        private readonly T[] array;

        public GenericQueue(int size)
        {
            this.Size = size;
            this.array = new T[size];
        }

        public bool IsFull() => rear == Size - 1;

        public bool IsEmpty() => Count == 0;

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                throw new Exception("Queue is full");
            }

            array[++rear] = item;
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

            if(front == rear)
            {
                front = -1;
                rear = -1;
            }
            return value;
        }

        public int Size { get; }

        public int Count { get; private set; } = 0;

        public T Peek()
        {
            if(this.IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            var value = array[front + 1];
            return value;
        }

        public IEnumerator GetEnumerator()
        {
            if (this.IsEmpty())
            {
                throw new Exception("Queue is empty");
            }

            for (var i = front + 1; i <= rear; i++)
            {
                yield return array[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
