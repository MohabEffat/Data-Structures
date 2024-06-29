class QueueLinkedBased<T> {
    private LinkedList<T> dataList;

    public QueueLinkedBased() {
        dataList = new LinkedList<T>(true);
    }

    public void enqueue(T _data) {
        dataList.InsertLast(_data);
    }

    public T dequeue() {
        T data = dataList.Head.data;
        dataList.DeleteHead();
        return data;
    }

    public T peek() {
        if (dataList.Head == null)
            return null;
        return dataList.Head.data;
    }

    public boolean hasData() {
        return dataList.getSize() > 0;
    }

    public int getSize() {
        return dataList.getSize();
    }

    public void print() {
        dataList.printList();
    }
}