public class Main {
    public static void main(String[] args) {
        QueueL<Integer> queueL = new QueueL<>();
        System.out.println(queueL.getSize());
        queueL.enqueue(10);
        queueL.enqueue(30);
        queueL.enqueue(80);
        queueL.enqueue(50);
        queueL.enqueue(70);
        queueL.enqueue(60);
        queueL.print();
        System.out.println(queueL.getSize());
        queueL.dequeue();
        queueL.dequeue();
        queueL.dequeue();
        queueL.print();
    }
}