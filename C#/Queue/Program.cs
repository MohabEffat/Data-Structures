namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyQueueLinkedList<int> myQueue = new MyQueueLinkedList<int>(true);
            myQueue.enqueue(1);
            myQueue.enqueue(2);
            myQueue.enqueue(3);
            myQueue.enqueue(4);
            myQueue.enqueue(5);
            myQueue.PrintQueue();
            myQueue.dequeue();
            myQueue.PrintQueue();
            myQueue.PrintQueue();



        }
    }
}
