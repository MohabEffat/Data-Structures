namespace Heap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHeap<int> myHeap = new MyHeap<int>();
            myHeap.Insert(24);
            myHeap.Insert(32);
            myHeap.Insert(16);
            myHeap.Insert(45);
            myHeap.Insert(20);
            myHeap.Insert(53);
            myHeap.Insert(14);
            myHeap.Insert(27);
            myHeap.Print();
            myHeap.Draw();
            Console.WriteLine("-----------------");
            myHeap.Pop();
            myHeap.Print();
            myHeap.Draw();
            Console.WriteLine("-----------------");

            myHeap.Pop();
            myHeap.Print();
            myHeap.Draw();
            Console.WriteLine("-----------------");

            myHeap.Pop();
            myHeap.Print();
            myHeap.Draw();
            Console.WriteLine("-----------------");

            myHeap.Pop();
            myHeap.Print();
            myHeap.Draw();
            Console.WriteLine("-----------------");

            myHeap.Pop();
            myHeap.Print();
            myHeap.Draw();
            Console.WriteLine("-----------------");

        }
    }
}
