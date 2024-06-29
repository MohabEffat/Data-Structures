public class Main {
    public static void main(String[] args) {
        QueueLinkedBased<Integer> queueL = new QueueLinkedBased<>();
        QueueArrayBased<Integer> queueA = new QueueArrayBased<>(5);
        queueA.enqueue(5);
        queueA.enqueue(10);
        queueA.enqueue(15);
        queueA.enqueue(20);
        queueA.enqueue(25);
        queueA.printQueue();
    }
}