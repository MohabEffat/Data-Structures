
public class Main {
    public static void main(String[] args) {
        Dictionary<String, String> dic = new Dictionary<String, String>();
        dic.Print();
        dic.Set("Sinar", "Sinar@Gmail.com");
        dic.Set("Elvis", "Elvis@Gmail.com");
        dic.Set("Tane", "Tane@Gmail.com");
        dic.Print();
        dic.Set("Mohab", "Mohab@Gmail.com");
        dic.Set("Toqa", "Toqa@Gmail.com");
        dic.Print();
        dic.Remove("Sinar");
        dic.Remove("Elvis");
        dic.Remove("Tane");
        dic.Remove("Mohab");
        dic.Remove("Toqa");
        dic.Print();
    }
}