import static java.lang.System.arraycopy;

class StackArrayBased<T> {
    private T[] dataList;
    private int topIndex;
    private int initialSize = 50;
    private int currentSize;
    private boolean isFixed = false;

    @SuppressWarnings("unchecked")
    public StackArrayBased() {
        dataList = (T[]) new Object[this.initialSize];
        this.currentSize = initialSize;
        this.topIndex = -1;
    }

    @SuppressWarnings("unchecked")
    public StackArrayBased(int size) {
        this.dataList = (T[]) new Object[this.initialSize];
        this.initialSize = size;
        this.currentSize = initialSize;
        this.topIndex = -1;
        this.isFixed = true;
    }

    @SuppressWarnings("unchecked")
    public void resizeOrNot() {
        if (topIndex < currentSize - 1)
            return;
        System.out.println("Will be Resized");
        currentSize += initialSize;
        T[] newArray = (T[]) new Object[currentSize];
        System.arraycopy(dataList, 0, newArray, 0, dataList.length);
        dataList = newArray;
    }

    public void push(T _data) {
        if (!isFixed) {
            resizeOrNot();
        } else if (isFull()) {
            System.out.println("Stack is full. Cannot push " + _data);
            return;
        }
        dataList[++topIndex] = _data;
    }

    public boolean isFull() {
        return this.topIndex == this.currentSize - 1;
    }

    public T peek() {
        if (isEmpty()) {
            System.out.println("Stack is empty. Nothing to peek.");
            return null;
        }
        return dataList[topIndex];
    }

    public T pop() {
        if (isEmpty())
            return null;
        return dataList[topIndex--];
    }

    public int size() {
        return topIndex + 1;
    }

    public boolean isEmpty() {
        return topIndex == -1;
    }
}