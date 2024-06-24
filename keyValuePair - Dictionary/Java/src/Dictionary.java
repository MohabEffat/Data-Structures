import static java.lang.System.*;

public class Dictionary <TKey, TValue>{

    private KeyValuePair [] entries;
    private int initialSize;
    private int entriesCount;
    public Dictionary(){
        this.initialSize = 3;
        this.entries = createArray(this.initialSize);
        this.entriesCount = 0;
    }
    @SuppressWarnings("unchecked")
    private KeyValuePair[] createArray(int size) {
        return (KeyValuePair[]) new Dictionary<?, ?>.KeyValuePair[size];
    }

    public void ResizeOrNOt(){
        if(entriesCount < entries.length ){
            return;
        }
        int newSize = entries.length + initialSize;
        System.out.println("[resize] from " + entries.length + " to " + newSize);
        KeyValuePair[] newEntries  = createArray(newSize);

        arraycopy(entries, 0, newEntries, 0, entries.length);
        entries = newEntries;

    }
    public int Size(){
        return entriesCount;
    }
    public void Set(TKey key, TValue value){
        for (KeyValuePair entry : entries) {
            if (entry!= null && entry._Key == key) {
                entry._value = value;
                return;
            }
        }
        ResizeOrNOt();
        KeyValuePair newPair = new KeyValuePair(key, value);
        entries[entriesCount] = newPair;
        entriesCount++;
    }
    public TValue Get(TKey key){
        for (KeyValuePair entry : entries) {
            if (entry!= null && entry._Key == key) {
                return entry._value;
            }
        }
        return null;
    }
    public void Remove(TKey key){
        for (int i = 0; i < entries.length; i++) {
            if (entries[i]!= null && entries[i]._Key == key){
                entries[i] = entries[entriesCount - 1];
                entries[entriesCount - 1] = null;
                entriesCount--;
                return;
            }
        }
    }
    public void Print(){
        System.out.println("-------------");
        System.out.println("[Size] : " + Size());
        if(Size() == 0 ){
            System.out.println("Dictionary is Empty");
            return;
        }
        for (int i = 0; i < entries.length; i++) {
            if(entries[i] == null){
                System.out.println("[" + i + "]");
            }
            else {
                System.out.println("[" + i + "]" + entries[i]._Key + " : " + entries[i]._value);
            }
        }
        System.out.println("============");
    }
    private class KeyValuePair{
        private TKey _Key;
        private TValue _value;
        public TKey getKey(){
            return _Key;
        }
        public TValue getValue(){
            return _value;
        }
        public void setValue(TValue _value){
            this._value = _value;
        }
        public KeyValuePair(TKey _key, TValue _value){
            this._value = _value;
            this._Key =_key;
        }
    }
}
