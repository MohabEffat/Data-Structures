#include <cstring>
#include <iostream>

using namespace std;

class OurArray {
public:
  template <typename T> T GetAt(T *source, int index, int sizeOf) {
    if (index < 0)
      return T();
    char *zeroAddr = reinterpret_cast<char *>(source);
    char *itemAddr = zeroAddr + (index * sizeOf);
    /* reinterpret_cast is used to cast the address of the memory location
     * pointed to by itemAddr to a pointer of type T*, and then dereference it
     * to get the value stored in that memory location.*/
    return *reinterpret_cast<T *>(itemAddr);
  }
};

int main() {

  int *arr = new int[3]{4654, 921, 762};
  OurArray our;

  int item = our.GetAt<int>(arr, 1, sizeof(int));
  cout << item << endl;
  cout << arr[1] << endl;

  delete[] arr;
  return 0;
}
