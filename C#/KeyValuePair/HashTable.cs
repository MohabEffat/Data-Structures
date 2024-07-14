using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyValuePair
{
    public class HashTable<Tkey, Tvalue> where Tkey : class
    {
        KeyValuePair[] entries;
        int initialSize;
        int entriesCount;

        public HashTable()
        {
            initialSize = 3;
            entriesCount = 0;
            entries = new KeyValuePair[initialSize];
        }
        int GetHash(Tkey key)
        {
            uint FnvOffsetBasis = 2166136261;
            uint FNVPrime = 16777619;

            byte[] data = Encoding.ASCII.GetBytes(key.ToString());

            uint hash = FnvOffsetBasis;

            for (int i = 0; i < data.Length; i++)
            {
                hash = hash ^ data[i];
                hash = hash * FNVPrime;
            }

            Console.WriteLine("[hash] " + key.ToString()
                + " " + hash + " " + hash.ToString("x")
                    + " " + hash % (uint)entries.Length);

            return (int)(hash % (uint)entries.Length);
        }
        int CollisionHandling(Tkey key, int hash, bool Set)
        {
            int newHash;
            for (int i = 0; i < entries.Length; i++)
            {
                newHash = (hash + i) % entries.Length;
                Console.WriteLine("[coll] " + key.ToString()
                  + " " + hash + ", new hash: " + newHash);
                if (Set && ( entries[newHash] == null || entries[newHash].Key == key))
                    return newHash;
                else if(!Set && entries[newHash].Key == key)
                    return newHash;
                else continue;
            }
            return -1;

        }
        void addToEntries(Tkey key, Tvalue value)
        {
            int hash = GetHash(key);
            if (entries[hash] != null && entries[hash].Key != key)
                hash = CollisionHandling(key, hash, true);
            if (hash == -1)
                throw new Exception("Invalid HashTable");
            if (entries[hash] == null)
            {
                KeyValuePair newPair = new KeyValuePair(key, value);
                entries[hash] = newPair;
                entriesCount++;
            }
            else if(entries[hash].Key == key)
                entries[hash].Value = value;
            else throw new Exception("Invalid HashTable");
        }

        public void Set(Tkey key, Tvalue value)
        {
            ResizeOrNot();
            addToEntries(key, value);
        }
        public Tvalue Get(Tkey key)
        {
            int hash = GetHash(key);
            if (entries[hash] != null && entries[hash].Key != key)
            {
                hash = CollisionHandling(key, hash, false);
            }
            if (hash == -1 || entries[hash] == null)
            {
                return default;
            }

            if (entries[hash].Key == key)
            {
                return entries[hash].Value;
            }
            else
            {
                throw new Exception("Invalid Hashtable!!!!");
            }

        }

        public void ResizeOrNot()
        {
            if (entriesCount < entries.Length)
            {
                return;
            }
            int newSize = entries.Length * 2;

            Console.WriteLine("[resize] from " +
                entries.Length + " to " + newSize);
            KeyValuePair[] newEntries = new KeyValuePair[entries.Length];
            Array.Copy(entries, newEntries, newEntries.Length);
            entries = new KeyValuePair[newSize];
            entriesCount = 0;
            for (int i = 0; i < newEntries.Length; i++)
            {
                if (newEntries[i] == null) continue;
                addToEntries(newEntries[i].Key, newEntries[i].Value);

            }
        }
        public int Size()
        {
            return entriesCount;
        }
        public void Print()
        {
            Console.WriteLine("-----------");
            Console.WriteLine("[Size] " + Size());

            for (int i = 0; i < entries.Length; i++)
            {
                if (entries[i] == null)
                {
                    Console.WriteLine("[" + i + "] null");
                }
                else
                {
                    Console.WriteLine("[" + i + "] " +
                      entries[i].Key + ":" +
                        entries[i].Value);
                }
            }

            Console.WriteLine("============");
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
