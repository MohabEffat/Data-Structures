namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyStackLinkedList<int> myStack = new MyStackLinkedList<int>(true);
            //myStack.push(1);
            //myStack.push(2);
            //myStack.push(3);
            //myStack.push(4);
            //myStack.push(5);
            //myStack.PrintStack();
            //Console.WriteLine(myStack.isEmpty());
            //Console.WriteLine(myStack.pop());
            //myStack.PrintStack();
            //Console.WriteLine(myStack.GetSize());
            //myStack.push(4);
            MyStackArrayBased<int> MyAstack = new MyStackArrayBased<int>(5);
            MyAstack.push(1);
            MyAstack.push(2);
            MyAstack.push(3);
            MyAstack.push(4);
            MyAstack.push(5);
            MyAstack.push(6);
            MyAstack.push(7);
            MyAstack.push(8);
            MyAstack.PrintStack();
            Console.WriteLine(MyAstack.Find(1));
            Console.WriteLine(MyAstack.Find(10));





        }
    }
}
