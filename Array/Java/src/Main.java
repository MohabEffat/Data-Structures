import Resize.MyArray;

import java.util.Arrays;

public class Main {
    public static void main(String[] args) {

        Integer[] arr = new Integer[] { 10, 20, 30 };
        MyArray myArr = new MyArray();
        arr = myArr.ResizeArr(arr, 6);
        System.out.println(Arrays.toString(arr));
    }
}

