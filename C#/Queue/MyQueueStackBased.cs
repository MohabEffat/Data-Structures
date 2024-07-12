using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    using System;

    public class MyQueueStackBased<T>
    {
        private T[] _elements;
        private int _front;
        private int _rear;
        private int _count;
        private int _capacity;

        public MyQueueStackBased(int capacity)
        {
            _capacity = capacity;
            _elements = new T[capacity];
            _front = 0;
            _rear = -1;
            _count = 0;
        }

        public bool IsEmpty()
        {
            return _count == 0;
        }

        public bool IsFull()
        {
            return _count == _capacity;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full, cannot enqueue " + item);
                return;
            }
            _rear = (_rear + 1) % _capacity;
            _elements[_rear] = item;
            _count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty, cannot dequeue");
            }
            T item = _elements[_front];
            _front = (_front + 1) % _capacity;
            _count--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty, cannot peek");
            }
            return _elements[_front];
        }

        public int Count
        {
            get { return _count; }
        }

        public void PrintQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            Console.Write("Queue: ");
            for (int i = 0; i < _count; i++)
            {
                Console.Write(_elements[(_front + i) % _capacity] + " ");
            }
            Console.WriteLine();
        }
    }

}
