class LinkedListNode {
    public int data;
    public LinkedListNode next;

    LinkedListNode(int _data) {
        this.data = _data;
        this.next = null;
    };
}

class LinkedList {
    private int size;
    public boolean unique;
    public LinkedListNode Head ;
    public LinkedListNode Tail ;
    LinkedList(boolean unique){
        this.Tail = null;
        this.Head = null;
        this.size = 0;
        this.unique = (unique);
    }
    public boolean isExist(int _date){
        return this.Find(_date) != null;
    }
    public boolean canInsert(int _data){
        if(this.unique && this.isExist(_data)){
            System.out.println("Date Exists");
            return false;
        }
        else
            return true;
    }
    public void InsertLast(int _data) {
        if(!this.canInsert(_data)) return;
        LinkedListNode newNode = new LinkedListNode(_data);
        if (this.Head == null) {
            this.Head = newNode;
        } else {
            this.Tail.next = newNode;
        }
        this.Tail = newNode;
        this.size ++;
    }

    public void InsertAfter(int data, int _data) {
        if(!this.canInsert(_data)) return;
        LinkedListNode newNode = new LinkedListNode(_data);
        LinkedListNode node = this.Find(data);
        if (node != null) {
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null) {
                this.Tail = newNode;
            }
        }
        this.size ++;
    }

    public void InsertBefore(int data, int _data) {
        if(!this.canInsert(_data)) return;
        LinkedListNode newNode = new LinkedListNode(_data);
        LinkedListNode node = this.Find(data);
        if (node != null) {
            newNode.next = node;
            LinkedListNode parent = this.findParent(node);
            if (parent == null) {
                this.Head = newNode;
            } else {
                parent.next = newNode;
            }
        }
        this.size ++;
    }

    public void deleteNode(int _data) {
        LinkedListNode node = this.Find(_data);
        if (node != null) {
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
        this.size --;
    }
    public int getSize(){
        return this.size;
    }

    public LinkedListNode findParent(LinkedListNode node) {
        for (LinkedListIterator itr = this.begin(); itr.Current() != null; itr.Next()) {
            if (itr.Current().next == node) {
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
            if (_data == itr.Data()) {
                return itr.Current();
            }
        }
        return null;
    }
    public int getSum()
    {
        int sum = 0;
        for (LinkedListIterator itr = this.begin(); itr.Current() != null; itr.Next())
        {
            sum += itr.Data();
        }
        return sum;
    }
    public void InsertHead(int _data){
        if(!this.canInsert(_data)) return;
        LinkedListNode newNode = new LinkedListNode(_data);
        if(this.Head == null){
            this.Head = newNode;
            this.Tail = newNode;
        }else{
            newNode.next = this.Head;
            this.Head = newNode;
        }
        this.size++;
    }
    public void DeleteHead(){
        if(this.Head == null) return ;
        this.Head = this.Head.next;
        this.size--;
    }
}

class LinkedListIterator {
    private LinkedListNode CurrentNode;

    public LinkedListIterator() {
        this.CurrentNode = null;
    }

    public LinkedListIterator(LinkedListNode node) {
        this.CurrentNode = node;
    }

    int Data() {
        return this.CurrentNode.data;
    }

    public void Next() {
        this.CurrentNode = this.CurrentNode.next;
    }

    public LinkedListNode Current() {
        return this.CurrentNode;
    }
}

public class Main {
    public static void main(String[] args) {
        LinkedList List = new LinkedList(true);
        List.InsertLast(1);
        List.InsertLast(2);
        List.InsertLast(3);
        List.printList();
        List.InsertAfter(1,2);
        List.printList();
        List.DeleteHead();
        List.printList();
    }
}