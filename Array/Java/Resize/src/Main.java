import java.lang.reflect.Array;
import java.util.Arrays;

public class Main {
    public static void main(String[] args) {

        Integer[] arr = new Integer[] { 10, 20, 30 };
        MyArray myArr = new MyArray();
        arr = myArr.ResizeArr(arr, 6);
        System.out.println(Arrays.toString(arr));
    }
}

@SuppressWarnings("unchecked")
class MyArray {

    public <T> T[] ResizeArr(T[] Source, int NewSize) {
        if (Source == null || Source.length >= NewSize) {
            return Source;
        }
        T[] newArray = (T[]) Array.newInstance(Source.getClass().getComponentType(), NewSize);
        System.arraycopy(Source, 0, newArray, 0, Source.length);
        return newArray;
    }
}