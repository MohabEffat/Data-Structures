using LinkedListImpl.Classes;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> myList = new MyLinkedList<int>();
            myList.InsertLast(1);
            myList.InsertLast(2);
            myList.InsertLast(3);
            myList.InsertLast(4);
            myList.InsertLast(5);
            myList.InsertLast(6);
            myList.PrintList();
            myList.InsertAfter(5, 10);
            myList.PrintList();
            myList.InsertBefore(1, 20);
            myList.PrintList();
            myList.InsertBefore(10, 30);
            myList.PrintList();

            Console.WriteLine("Head : " + myList.head.data);
            myList.PrintList();

            myList.DeleteHead();
            Console.WriteLine("Head : " + myList.head.data);
            myList.PrintList();
            Console.WriteLine(myList.GetSize());
            myList.DeleteNode(30);
            Console.WriteLine(myList.GetSize());





        }
    }
}
