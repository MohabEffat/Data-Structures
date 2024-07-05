import com.sun.source.tree.Tree;

public class Main {
    public static void main(String[] args) {
//        BinaryTree<Integer> tree = new BinaryTree<>();
//        tree.Insert(1);
//        tree.Insert(2);
//        tree.Insert(3);
//        tree.Insert(4);
//        tree.Insert(5);
//        tree.Insert(6);
//        tree.Insert(7);
//        tree.Insert(1);
//        tree.Insert(2);
//        tree.Insert(3);
//        tree.Insert(4);
//        tree.Insert(5);
//        tree.Insert(6);
//        tree.Insert(7);
//        tree.Insert(8);
//        tree.printTree();
//        System.out.println("Height is : " + tree.Height());
//        tree.PreOrder();
//        tree.InOrder();
//        tree.PostOrder();
        BinaryTree <Integer> BST = new BinaryTree<>();
//        BST.BSInsert(1);
//        BST.BSInsert(2);
//        BST.BSInsert(3);
//        BST.BSInsert(4);
//        BST.BSInsert(5);
//        BST.BSInsert(6);
//        BST.printTree();
        BST.BSInsert(4);
        BST.BSInsert(2);
        BST.BSInsert(1);
        BST.BSInsert(3);
        BST.BSInsert(5);
        BST.BSInsert(6);
        BST.printTree();
        System.out.println(BST.IsExist(7));
    }
}