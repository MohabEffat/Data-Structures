using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValuePair
{
    public class Dictionary<Tkey, Tvalue> where Tkey : class
    {
        KeyValuePair[] entries;
        int initialSize;
        int entriesCount;
        public Dictionary()
        {
            initialSize = 3;
            entries = new KeyValuePair[initialSize];
        }
        public void ResizeOrNot()
        {
            if (entriesCount < entries.Length - 1)
                return;
            int newSize = entries.Length + initialSize;
            Console.WriteLine($"Resize from {entries.Length} to {newSize}");
            KeyValuePair[] newArray = new KeyValuePair[newSize];
            Array.Copy(entries, newArray, entries.Length);
            entries = newArray;

        }
        public void Set(Tkey key, Tvalue value)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                if(entries[i]!= null && key == entries[i].Key)
                {
                    entries[i].Value = value;
                    return;
                }
            }
            ResizeOrNot();
            KeyValuePair newPair = new KeyValuePair(key, value);
            entries[entriesCount++] = newPair;
        }

        public Tvalue Get(Tkey key)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] != null && key == entries[i].Key)
                    return entries[i].Value;
            }
            return default;
        }
        public bool Remove(Tkey key)
        {
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] != null && key == entries[i].Key)
                {
                    entries[i] = entries[entriesCount - 1] ;
                    entries[entriesCount - 1] = null;
                    entriesCount--;
                    return true;
                }
            }
            return false;

        }
        public void Print()
        {
            Console.WriteLine("----------");
            Console.WriteLine("[size] " + Size());
            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] == null)
                {
                    Console.WriteLine("[" + i + "]");
                    continue;
                }
                else
                {
                    Console.WriteLine("[" + i + "]" + this.entries[i].Key
                      + ":" + this.entries[i].Value);
                }
            }
            Console.WriteLine("==========");
        }
        public int Size()
        {
            return entriesCount;
        }
        class KeyValuePair
        {
            Tkey _key;
            Tvalue _value;
            public Tkey Key
            {
                get { return _key; }
            }
            public Tvalue Value
            {
                get { return _value; }
                set { _value = value; }

            }
            public KeyValuePair(Tkey key, Tvalue val)
            {
                _key = key;
                _value = val;

            }

        }

    }
}
