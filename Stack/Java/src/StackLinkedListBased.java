class Stack{
    private LinkedList dateList ;
    Stack(boolean unique){
        this.dateList = new LinkedList((unique));
    }
    public void Push(int _data){
        this.dateList.InsertHead(_data);
    }
    public int Pop(){
        int headData = this.dateList.Head.data;
        this.dateList.DeleteHead();
        return headData;
    }
    public int peek(){
        return this.dateList.Head.data;
    }
    public boolean isEmpty(){
        return this.dateList.getSize() <= 0;
    }
    public void printStack(){
        this.dateList.printList();
    }
    public int GetLen(){
        return this.dateList.getSize();
    }
}