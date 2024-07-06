using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class MyStackArrayBased<T>
    {
        T[] dataList;
        int topIndex = -1 ;
        int intialSize;
        int currentSize;
        bool isFixed = false;
        public MyStackArrayBased()
        {
            intialSize = 5;
            dataList = new T[intialSize];
            currentSize = intialSize;
        }
        public MyStackArrayBased(int size)
        {
            intialSize = size;
            dataList = new T[intialSize];
            currentSize = intialSize;
            isFixed = true;
        }
        void ResizeOrNot()
        {
            if(currentSize -1 > topIndex) return;
            Console.WriteLine("Will be Resized");
            T[] newArray = new T[currentSize + intialSize];
            Array.Copy(dataList, newArray, dataList.Length);
            dataList = newArray;
            currentSize += intialSize;

        }
        public void push (T _data)
        {
            if(!isFixed)
                ResizeOrNot();
            if (isFull())
            {
                Console.WriteLine("Stack Is Full Can Not Insert : " + _data);
                return;
            }
            dataList[++topIndex] = _data;
        }
        public T peek()
        {
            if (topIndex == -1) return default;
            return dataList[topIndex];
        }
        public T pop()
        {
            if (topIndex == -1) return default;
            T item = dataList[topIndex];
            dataList[topIndex--] = default;
            return item;
        }
        public int GetSize()
        {
            return topIndex +1 ;
        }
        public bool isEmpty(T item)
        {
            return (topIndex == -1);
        }
        public void PrintStack()
        {
            for (int i = topIndex; i >= 0; i--)
            {
                Console.Write(dataList[i] + " -> ");
            }
            Console.WriteLine();
        }
        public bool isFull()
        {
                return topIndex == intialSize - 1 && isFixed;

        }
        public bool Find(T _data)
        {
            for (int i = topIndex; i >= 0; i--)
            {
                if (dataList[i].Equals(_data))
                    return true;
            }
            return false;
        }


    }
    
}
