using LinkedListImpl.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class MyQueueLinkedList<T>
    {
        MyLinkedList<T> dataList;
        public MyQueueLinkedList(bool _unique)
        {
            dataList = new MyLinkedList<T>(_unique);
        }
        public void enqueue(T _data)
        {
            dataList.InsertLast(_data);
        }
        public T dequeue()
        {
            T item = dataList.head.data;
            dataList.DeleteHead();
            return item;
        }
        public T peek()
        {
            return dataList.head.data;
        }
        public bool isEmpty()
        {
            return (dataList.GetSize() == 0);
        }
        public void PrintQueue()
        {
            dataList.PrintList();
        }
        public int GetSize()
        {
            return dataList.GetSize(); 
        }
    }
}
