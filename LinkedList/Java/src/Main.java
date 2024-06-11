class LinkedListNode{
    public int data;
    public LinkedListNode next;
    LinkedListNode(int _data){
        this.data = _data;
        this.next = null;
    };
}

class LinkedList{
    public LinkedListNode Head = null;
    public LinkedListNode Tail = null;
    public void InsertLast(int _data){
        LinkedListNode newNode = new LinkedListNode(_data);
        if(this.Head == null){
           this.Head = newNode;
        }
        else{
            this.Tail.next = newNode;
        }
        this.Tail = newNode;
    }
    public void InsertAfter(int data, int _data){
        LinkedListNode newNode = new LinkedListNode(_data);
        LinkedListNode node = this.Find(data);
        if(node != null){
            newNode.next = node.next;
            node.next = newNode;
            if(newNode.next == null) {
                this.Tail = newNode;
            }
        }
    }
    public void InsertBefore(int data, int _data){
        LinkedListNode newNode = new LinkedListNode(_data);
        LinkedListNode node = this.Find(data);
        if(node != null){
            newNode.next = node;
            LinkedListNode parent = this.findParent(node);
            if(parent == null){
                this.Head = newNode;
            }
            else{
                parent.next = newNode;
            }
        }
    }
    public void deleteNode(int _data){
        LinkedListNode node = this.Find(_data);
        if(node != null) {
            if (this.Head == this.Tail) {
                this.Head = null;
                this.Tail = null;
            } else if (this.Head == node) {
                this.Head = node.next;
            } else {
                LinkedListNode parent = this.findParent(node);
                if (this.Tail == node) {
                    this.Tail = parent;
                    parent.next = null;
                } else {
                    parent.next = node.next;
                }
            }
        }
    }
    public LinkedListNode findParent(LinkedListNode node){
        for (LinkedListIterator itr = this.begin(); itr.Current() != null; itr.Next()) {
            if(itr.Current().next == node){
                return itr.Current();
            }
        }
        return null;
    }
    public LinkedListIterator begin() {
        return new LinkedListIterator(this.Head);
    }
    public void printList() {
        for (LinkedListIterator itr = this.begin(); itr.Current() != null; itr.Next()) {
            System.out.print(itr.Data() + " -> ");
        }
        System.out.println();
    }
    public LinkedListNode Find(int _data) {
        for (LinkedListIterator itr = this.begin(); itr.Current() != null; itr.Next()) {
            if(_data == itr.Data()){
                return itr.Current();
            }
        }
        return null;
    }
}
class LinkedListIterator{
    private LinkedListNode CurrentNode;
    public LinkedListIterator(){
        this.CurrentNode = null;
    }
    public LinkedListIterator (LinkedListNode node){
        this.CurrentNode = node;
    }
    int Data(){
        return this.CurrentNode.data;
    }
    public void Next(){
            this.CurrentNode = this.CurrentNode.next;
    }
    public LinkedListNode Current(){
        return this.CurrentNode;
    }
}




public class Main {
    public static void main(String[] args) {
        LinkedList List = new LinkedList();
        List.InsertLast(1);
        List.InsertLast(2);
        List.InsertLast(3);
        List.printList();
        List.InsertLast(5);
        List.InsertAfter(5,16320);
        List.printList();
        List.InsertLast(2000);
        List.printList();
        List.InsertBefore(1,6000);
        List.printList();
        List.deleteNode(2000);
        List.printList();


    }
}