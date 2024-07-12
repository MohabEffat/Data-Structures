using Queue;
namespace BinartTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MyBinaryTree<char> myBinaryTree = new MyBinaryTree<char>();
            //myBinaryTree.Insert('A');
            //myBinaryTree.Insert('B');
            //myBinaryTree.Insert('C');

            //myBinaryTree.Insert('D');
            //myBinaryTree.Insert('E');
            //myBinaryTree.Insert('F');
            //myBinaryTree.Insert('G');

            //myBinaryTree.Insert('H');
            //myBinaryTree.Insert('I');
            //myBinaryTree.Print();
            //Console.WriteLine("Height is : " + myBinaryTree.Height());
            //myBinaryTree.PreOrder();
            //myBinaryTree.PostOreder();
            //myBinaryTree.InOreder();
            //Console.WriteLine(myBinaryTree.find('A'));
            MyBinaryTree<int> BST = new MyBinaryTree<int>();
            //BST.BSInsert(4);
            //BST.BSInsert(2);
            //BST.BSInsert(1);

            //BST.BSInsert(3);
            //BST.BSInsert(5);
            //BST.BSInsert(6);
            //BST.Print();
            //BST.BSDelete(4);
            //BST.Print();
            //BST.BSDelete(3);
            //BST.Print();
            BST.BSInsert(1);
            BST.BSInsert(2);
            BST.BSInsert(3);
            BST.BSInsert(3);

            BST.BSInsert(4);
            BST.BSInsert(5);
            BST.BSInsert(5);
            BST.BSInsert(6);
            BST.BSInsert(7);

            BST.Print();
            BST.Balance();
            BST.Print();



        }
    }
}
