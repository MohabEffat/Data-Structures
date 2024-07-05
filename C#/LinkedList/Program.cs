using LinkedListImpl.Classes;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> myList = new MyLinkedList<int>(true);
            myList.InsertLast(1);
            myList.InsertLast(2);
            myList.InsertLast(3);
            myList.InsertLast(4);
            myList.InsertLast(5);
            myList.InsertLast(6);
            myList.PrintList();
            myList.InsertLast(6);
            myList.PrintList();







        }
    }
}
