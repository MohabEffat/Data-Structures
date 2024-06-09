package Resize;

import java.lang.reflect.Array;
import java.util.Arrays;
@SuppressWarnings("unchecked")
public class MyArray {

    public <T> T[] ResizeArr(T[] Source, int NewSize) {
        if (Source == null || Source.length >= NewSize) {
            return Source;
        }
        T[] newArray = (T[]) Array.newInstance(Source.getClass().getComponentType(), NewSize);
        System.arraycopy(Source, 0, newArray, 0, Source.length);
        return newArray;
    }
}