class QueueL{
    private LinkedList dataList;
    public QueueL(){
        dataList = new LinkedList(true);
    }
    public void enqueue(int _data){
        dataList.InsertLast(_data);
    }
    public int dequeue(){
        int data = dataList.Head.data;
        dataList.DeleteHead();
        return data;
    }
    public int peek(){
        if(dataList.Head == null) return -1;
        return dataList.Head.data;
    }
    public boolean hasData(){
        return dataList.getSize() > 0;
    }
    public int getSize(){
        return dataList.getSize();
    }
    public void print(){
        dataList.printList();
    }
}