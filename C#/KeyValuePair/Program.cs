namespace KeyValuePair
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, string> dictionary = new Dictionary<string, string>();
            //dictionary.Print();

            //dictionary.Set("a", "b");
            //dictionary.Set("c", "d");
            //dictionary.Print();

            //dictionary.Set("d", "e");
            //dictionary.Set("e", "f");
            //dictionary.Set("f", "g");
            //dictionary.Print();

            //dictionary.Set("g", "h");
            //dictionary.Print();


            //dictionary.Set("h", "i");
            //dictionary.Print();
            //Hash hash = new Hash();
            //hash.Hash32("This is Original Text");
            //hash.Hash64("This is Original Text");
            HashTable<string, string> hashTable = new HashTable<string, string>();
            hashTable.Print();

            hashTable.Set("Mohab", "Mohab@mail.com");
            hashTable.Set("Effat", "Effat@mail.com");
            hashTable.Set("Mahmoud", "Mahmoud@mail.com");
            hashTable.Set("Farah", "Farah@mail.com");
            hashTable.Set("Kimo", "Kimo@mail.com");



            hashTable.Print();

        }
    }
}
