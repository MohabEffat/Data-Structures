import static java.lang.System.arraycopy;

class stackArray{
    private int[] dataList;
    private int topIndex;
    private int initialSize = 50;
    private int currentSize;
    public stackArray(){
        this.dataList = new int [this.initialSize];
        this.currentSize = initialSize;
        this.topIndex = -1;
    }
    public void resizeOrNot() {
        if (topIndex < currentSize - 1) return;
        System.out.println("Will be Resized");
        currentSize += initialSize;
        int[] newArray = new int[currentSize];
        arraycopy(dataList, 0, newArray, 0, dataList.length);
        dataList = newArray;
    }
    public void push(int _data){
        resizeOrNot();
        dataList[++topIndex] = _data;
    }
    public int peek(){
        if(isEmpty()){
            System.out.println("Stack is empty. Nothing to peek.");
            return -1;
        }
        return dataList[topIndex];
    }
    public int pop(){
        if(isEmpty()) return -1;
        return dataList[topIndex--];
    }
    public int size(){
        return topIndex +1;
    }
    public boolean isEmpty(){
        return topIndex == -1;
    }
}