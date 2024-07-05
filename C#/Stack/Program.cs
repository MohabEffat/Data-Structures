namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyStackLinkedList<int> myStack = new MyStackLinkedList<int>(true);
            myStack.push(1);
            myStack.push(2);
            myStack.push(3);
            myStack.push(4);
            myStack.push(5);
            myStack.PrintStack();
            Console.WriteLine(myStack.isEmpty());
            Console.WriteLine(myStack.pop());
            myStack.PrintStack();
            Console.WriteLine(myStack.GetSize());
            myStack.push(4);



        }
    }
}
