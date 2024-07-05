using LinkedListImpl.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    internal class MyStackLinkedList<T>
    {
        MyLinkedList<T> dataList;
        public MyStackLinkedList(bool _unique)
        {
            dataList = new MyLinkedList<T> (_unique);
        }
        public void push(T _data)
        {
            dataList.InsertFirst(_data);
        }
        public T pop()
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
            return dataList.GetSize() <= 0;
        }
        public void PrintStack()
        {
            dataList.PrintList();
        }
        public int GetSize()
        {
            return dataList.GetSize();
        }
    }
}
