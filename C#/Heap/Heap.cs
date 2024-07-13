using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class MyHeap<Tdata> where Tdata : IComparable<Tdata>
    {
        Tdata[] dataList;
        int initialSize;
        public int currentSize;
        public int size = 0;

    public MyHeap()
        {
            initialSize = 5;
            dataList = new Tdata[initialSize];
            currentSize = initialSize;

        }
        
        public void Insert(Tdata _data)
        {
            ResizeOrNot();
            int i = size;
            size++;
            dataList[i] = _data;
            int parentIndex = (i - 1) / 2;
            while(i != 0 && dataList[i].CompareTo(dataList[parentIndex]) <0 )
            {
                dataList[i] = dataList[parentIndex];
                dataList[parentIndex] = _data;
                i = parentIndex;
                parentIndex = (i - 1) / 2;
            }
        }
        public void Print()
        {
            string printData = "";
            for (int i = 0; i < size; i++)
            {
                printData += dataList[i] + " - ";
            }
            Console.WriteLine(printData);
        }
        public Tdata Pop()
        {
            int i = 0;
            Tdata data = dataList[i];
            dataList[i] = dataList[size - 1];
            size --;
            int leftIndex = (2 * i) + 1;
            while(leftIndex < size) 
            {
                int rightIndex = (2 * i) + 2;
                int smallerIndex = leftIndex;
                if (dataList[rightIndex].CompareTo(dataList[leftIndex]) < 0)
                    smallerIndex = rightIndex;
                if (rightIndex < size && dataList[rightIndex].CompareTo(dataList[smallerIndex]) < 0)
                    break;
                Tdata temp = dataList[i];
                dataList [i] = dataList[smallerIndex];
                dataList [smallerIndex] = temp;
                i = smallerIndex;
                leftIndex = (2 * i) + 1;
            }
            return data;
        }
        public void Draw()
        {
            if (size == 0)
            {
                Console.WriteLine("Heap is empty");
                return;
            }

            int levelsCount = (int)Math.Log2(size) + 1;
            int lineWidth = (int)Math.Pow(2, levelsCount - 1);

            int j = 0;
            for (int i = 0; i < levelsCount; i++)
            {
                int nodesCount = (int)Math.Pow(2, i);
                int space = (int)Math.Ceiling((double)(lineWidth - nodesCount) / 2);
                int spaceBetween = (int)Math.Ceiling((double)lineWidth / nodesCount);
                spaceBetween = spaceBetween < 1 ? 1 : spaceBetween;
                int k = j;
                string str = new string(' ', space + spaceBetween);
                for (; j < k + nodesCount; j++)
                {
                    if (j == size)
                    {
                        break;
                    }
                    str += dataList[j] + new string(' ', spaceBetween);
                }
                str += new string(' ', space);
                Console.WriteLine(str);
            }
        }
        void ResizeOrNot()
        {
            if (currentSize - 1 > size) return;
            Console.WriteLine("Will be Resized");
            Tdata[] newArray = new Tdata[currentSize + initialSize];
            Array.Copy(dataList, newArray, dataList.Length);
            dataList = newArray;
            currentSize += initialSize;

        }
    }
}
