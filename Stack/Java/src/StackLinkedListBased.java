class StackLinkedListBased<T> {
    private LinkedList<T> dateList;

    StackLinkedListBased(boolean unique) {
        this.dateList = new LinkedList<>((unique));
    }

    public void Push(T _data) {
        this.dateList.InsertHead(_data);
    }

    public T pop() {
        T headData = this.dateList.Head.data;
        this.dateList.DeleteHead();
        return headData;
    }

    public T peek() {
        return this.dateList.Head.data;
    }

    public boolean isEmpty() {
        return this.dateList.getSize() <= 0;
    }

    public void printStack() {
        this.dateList.printList();
    }

    public int getSize() {
        return this.dateList.getSize();
    }
}