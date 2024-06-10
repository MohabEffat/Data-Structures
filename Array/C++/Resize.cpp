#include <cstring>
#include <iostream>

using namespace std;

class OurArray
{
public:
    // Resizes the given array to the new size
    template <typename T> void Resize(T *&source, int newSize)
    {
        if (newSize <= 0)
            return;
        if (source == nullptr)
            return;
        if (newSize == static_cast<int>(sizeof(source)))
            return;

        T *newArray = new T[newSize];
        memcpy(newArray, source, sizeof(T) * newSize);
        delete[] source;
        source = newArray;
    }
};

int main()
{

    //time complexity: O(n), space complexity: O(n)
    int *arr = new int[3] {4654, 921, 762};
    OurArray our;
    our.Resize<int>(arr, 5);
    for (int i = 0; i < 5; i++)
    {
        cout << arr[i] << " ";
    }
    cout << endl;

    delete[] arr;
    return 0;
}
