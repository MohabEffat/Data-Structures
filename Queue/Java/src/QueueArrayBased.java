public class QueueArrayBased<T> {
    private T[] queueArray;
    private int front;
    private int rear;
    private int size;
    private int capacity;

    // Constructor
    @SuppressWarnings("unchecked")
    public QueueArrayBased(int capacity) {
        this.capacity = capacity;
        queueArray = (T[]) new Object[capacity];
        front = 0;
        rear = -1;
        size = 0;
    }

    // Method to add an element to the queue
    public void enqueue(T data) {
        if (isFull()) {
            System.out.println("Queue is full, cannot enqueue " + data);
            return;
        }
        rear = (rear + 1) % capacity;
        queueArray[rear] = data;
        size++;
    }
    public T dequeue() {
        if (isEmpty()) {
            System.out.println("Queue is empty, cannot dequeue");
            return null;
        }
        T data = queueArray[front];
        queueArray[front] = null; // Clear the slot
        front = (front + 1) % capacity;
        size--;
        return data;
    }

    public T peek() {
        if (isEmpty()) {
            System.out.println("Queue is empty, nothing to peek");
            return null;
        }
        return queueArray[front];
    }
    public boolean isEmpty() {
        return size == 0;
    }
    public boolean isFull() {
        return size == capacity;
    }
    public int getSize() {
        return size;
    }
    public void printQueue() {
        if (isEmpty()) {
            System.out.println("Queue is empty");
            return;
        }
        System.out.print("Queue: ");
        for (int i = 0; i < size; i++) {
            System.out.print(queueArray[(front + i) % capacity] + " ");
        }
        System.out.println();
    }
}
