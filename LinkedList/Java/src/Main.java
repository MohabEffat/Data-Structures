class LinkedListNode<T> {
    public T data;
    public LinkedListNode<T> next;

    LinkedListNode(T _data) {
        this.data = _data;
        this.next = null;
    }
}

class LinkedList<T> {
    private int size;
    public boolean unique;
    public LinkedListNode<T> Head ;
    public LinkedListNode<T> Tail ;
    LinkedList(boolean unique){
        this.Tail = null;
        this.Head = null;
        this.size = 0;
        this.unique = (unique);
    }
    public boolean isExist(T _date){
        return this.Find(_date) != null;
    }
    public boolean canInsert(T _data){
        if(this.unique && this.isExist(_data)){
            System.out.println("Date Exists");
            return false;
        }
        else
            return true;
    }
    public void InsertLast(T _data) {
        if(!this.canInsert(_data)) return;
        LinkedListNode<T> newNode = new LinkedListNode<>(_data);
        if (this.Head == null) {
            this.Head = newNode;
        } else {
            this.Tail.next = newNode;
        }
        this.Tail = newNode;
        this.size ++;
    }

    public void InsertAfter(T data, T _data) {
        if(!this.canInsert(_data)) return;
        LinkedListNode<T> newNode = new LinkedListNode<>(_data);
        LinkedListNode<T> node = this.Find(data);
        if (node != null) {
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null) {
                this.Tail = newNode;
            }
        }
        this.size ++;
    }

    public void InsertBefore(T data, T _data) {
        if(!this.canInsert(_data)) return;
        LinkedListNode<T> newNode = new LinkedListNode<>(_data);
        LinkedListNode<T> node = this.Find(data);
        if (node != null) {
            newNode.next = node;
            LinkedListNode<T> parent = this.findParent(node);
            if (parent == null) {
                this.Head = newNode;
            } else {
                parent.next = newNode;
            }
        }
        this.size ++;
    }

    public void deleteNode(T _data) {
        LinkedListNode<T> node = this.Find(_data);
        if (node != null) {
            if (this.Head == this.Tail) {
                this.Head = null;
                this.Tail = null;
            } else if (this.Head == node) {
                this.Head = node.next;
            } else {
                LinkedListNode<T> parent = this.findParent(node);
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

    public LinkedListNode<T> findParent(LinkedListNode<T> node) {
        for (LinkedListIterator<T>  itr = this.begin(); itr.Current() != null; itr.Next()) {
            if (itr.Current().next == node) {
                return itr.Current();
            }
        }
        return null;
    }

    public LinkedListIterator<T>  begin() {
        return new LinkedListIterator<> (this.Head);
    }

    public void printList() {
        for (LinkedListIterator<T>  itr = this.begin(); itr.Current() != null; itr.Next()) {
            System.out.print(itr.Data() + " -> ");
        }
        System.out.println();
    }

    public LinkedListNode<T> Find(T _data) {
        for (LinkedListIterator<T>  itr = this.begin(); itr.Current() != null; itr.Next()) {
            if (_data == itr.Data()) {
                return itr.Current();
            }
        }
        return null;
    }
    public void InsertHead(T _data){
        if(!this.canInsert(_data)) return;
        LinkedListNode<T> newNode = new LinkedListNode<>(_data);
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

class LinkedListIterator<T> {
    private LinkedListNode<T> CurrentNode;

    public LinkedListIterator() {
        this.CurrentNode = null;
    }

    public LinkedListIterator(LinkedListNode<T> node) {
        this.CurrentNode = node;
    }

    T Data() {
        return this.CurrentNode.data;
    }

    public void Next() {
        this.CurrentNode = this.CurrentNode.next;
    }

    public LinkedListNode<T> Current() {
        return this.CurrentNode;
    }
}

public class Main {
    public static void main(String[] args) {
        LinkedList<String> List = new LinkedList<>(true);
        List.InsertLast("Mohab");
        List.InsertLast("Effat");
        List.InsertLast("Mahmoud");
        List.printList();
        List.InsertAfter("Mahmoud","Habeb");
        List.printList();
    }
}