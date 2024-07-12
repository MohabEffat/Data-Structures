using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImpl.Classes
{
    public class LinkedListNode<T>
    {
        public T data;
        public LinkedListNode<T> next;
        public LinkedListNode(T _data)
        {
            data = _data;
            next = null;
        }   
    }
    public class LinkedListIterator<T>
    {
        LinkedListNode<T> CurrentNode;
        public LinkedListIterator()
        {
            CurrentNode = null;
        }
        public LinkedListIterator(LinkedListNode<T> node)
        {
            CurrentNode = node;
        }
        public T Data()
        {
            return CurrentNode.data;
        }
        public LinkedListIterator<T> MoveNext()
        { 
            CurrentNode = CurrentNode.next;
            return this;
        } 
        public LinkedListNode<T> Current()
        {
        return CurrentNode; 
        }
        
    }
    public class MyLinkedList<T>
    {

        public LinkedListNode<T> head = null;
        public LinkedListNode<T> tail = null;
        int Length = 0;
        bool unique = false;
        public MyLinkedList(bool _unique)
        {
            head = null;
            tail = null;
            Length = 0;
            unique = _unique ? true : false;
        }
        public LinkedListIterator<T> begin()
        {
           return new LinkedListIterator<T>(head);
        }
        bool isExist(T _date)
        {
            return Find(_date) != null;
        }
        bool CanInsert(T _date)
        {
            if(unique && isExist(_date))
            {
                Console.WriteLine($"{_date} : Data Already Exists");
                return false;
            }
            return true;    
        }
        LinkedListNode<T> Find(T _data)
        {
            for(LinkedListIterator<T> itr = begin(); itr.Current() != null; itr.MoveNext())
            {
                if(EqualityComparer<T>.Default.Equals(itr.Data(), _data))
                    return itr.Current();
            }
            return null;
        }
        LinkedListNode<T> FindParent(LinkedListNode<T> node)
        {
            for (LinkedListIterator<T> itr = begin(); itr.Current() != null; itr.MoveNext())
            {
                if (itr.Current().next == node)
                    return itr.Current();
            }
            return null;
        }
        public void PrintList()
        {
            for (LinkedListIterator<T> itr = begin(); itr.Current() != null; itr.MoveNext())
            {
                Console.Write(itr.Data() + " -> ");
            }
            Console.WriteLine();
        }
        public void InsertLast(T _data)
        {
            if(!CanInsert(_data)) return;
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }
            Length++;
        }
        public void InsertAfter(T CurrentData, T _data)
        {
            if (!CanInsert(_data)) return;
            if (Find(CurrentData) == null)
                return;
            LinkedListNode<T> node = Find(CurrentData);
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            newNode.next = node.next;
            node.next = newNode;
            if (newNode.next == null)
                tail = newNode;
            Length++;

        }
        public void InsertBefore(T CurrentData, T _data)
        {
            if (!CanInsert(_data)) return;
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            LinkedListNode<T> node = Find(CurrentData);
            newNode.next = node;
            LinkedListNode<T> parent = FindParent(node);
            if (parent == null)
                head = newNode;
            else
                parent.next = newNode;
            Length++;

        }
        public void DeleteNode(T _data)
        {
            LinkedListNode<T> node = Find(_data);
            if(node == null)
                return;
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else if (head == node)
                head = node.next;
            else
            {
                LinkedListNode<T> parent = FindParent(node);
                if (tail == node)
                {
                    tail = parent;
                     parent.next = null;
                }

                else
                    parent.next = node.next;
            }
            Length--;


        }
        public int GetSize()
        {
            return Length;
        }
        public void DeleteHead()
        {
            if (head == null)
                return ;
            head = head.next;
            Length--;
        }

        public void InsertFirst(T _data)
        {
            if (!CanInsert(_data)) return;
            LinkedListNode<T> newNode = new LinkedListNode<T>(_data);
            if(head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.next = head;
                head = newNode;
            }

            Length++;
        }

    }
}
