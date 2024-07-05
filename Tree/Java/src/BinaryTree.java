import Helper.QueueList;
import com.sun.source.tree.Tree;

import java.util.ArrayList;
import java.util.List;

public class BinaryTree<Tdata extends Comparable<Tdata>> {

    private TreeNode Root;

    public void BSInsert(Tdata _data) {
        TreeNode newNode = new TreeNode(_data);
        if (Root == null){
            Root = newNode;
            return;
        }
        TreeNode CurrentNode = Root;
        while (CurrentNode != null){
            if(CurrentNode.Data.compareTo(_data) > 0){
                if (CurrentNode.Left == null){
                    CurrentNode.Left = newNode;
                    break;
                }
                else {
                    CurrentNode = CurrentNode.Left;
                }
            }
            else{
                if (CurrentNode.Right == null){
                    CurrentNode.Right = newNode;
                    break;
                }
                else {
                    CurrentNode = CurrentNode.Right;
                }
            }
        }
    }
    public boolean IsExist(Tdata _data){
        return BSFind(_data) != null;
    }
    private NodeAndParent FindNodeAndParent(Tdata _data){
        TreeNode CurrentNode = Root;
        TreeNode Parent = null;
        NodeAndParent NodeAndParentInfo = null;
        boolean left = false;
        while(CurrentNode != null){
            if(CurrentNode.Data.compareTo(_data) == 0){
                NodeAndParentInfo = new NodeAndParent(CurrentNode, Parent, left);
                break;
            } else if (CurrentNode.Data.compareTo(_data) > 0) {
                Parent = CurrentNode;
                left = true;
                CurrentNode = CurrentNode.Left;
            }
            else{
                Parent = CurrentNode;
                left = false;
                CurrentNode = CurrentNode.Right;
            }
        }
        return NodeAndParentInfo;
    }
    private TreeNode BSFind(Tdata _data){
        TreeNode CurrentNode = Root;
        while(CurrentNode != null){
            if(CurrentNode.Data.compareTo(_data) == 0){
                return CurrentNode;
            } else if (CurrentNode.Data.compareTo(_data) > 0) {
                CurrentNode = CurrentNode.Left;
            }
            else{
                CurrentNode = CurrentNode.Right;
            }
        }
        return null;
    }
    public void Insert(Tdata _data) {
        TreeNode newNode = new TreeNode(_data);
        if (Root == null){
            Root = newNode;
            return;
        }
        QueueList<TreeNode> q = new QueueList<>();
        q.enqueue(Root);
        while (q.hasData()) {
            TreeNode CurrentNode = q.dequeue();
            if (CurrentNode.Left == null){
                CurrentNode.Left = newNode;
                break;
            }
            else q.enqueue(CurrentNode.Left);

            if (CurrentNode.Right == null){
                CurrentNode.Right = newNode;
                break;
            }
            else q.enqueue(CurrentNode.Right);
        }
    }
    public int Height(){
        return internalHeight(Root);
    }
    private int internalHeight(TreeNode node){
        if(node == null) return 0;
        return 1+ Math.max(internalHeight(node.Left),internalHeight(node.Right));
    }
    public void PreOrder(){
        internalPreOrder(Root);
        System.out.println();
    }
    private void internalPreOrder(TreeNode node){
        if(node == null) return;
        System.out.print(node.Data + " -> ");
        internalPreOrder(node.Left);
        internalPreOrder(node.Right);
    }
    public void InOrder(){
        internalInOrder(Root);
        System.out.println();

    }
    private void internalInOrder(TreeNode node){
        if(node == null) return;
        internalInOrder(node.Left);
        System.out.print(node.Data + " -> ");
        internalInOrder(node.Right);
    }
    public void PostOrder(){
        internalPostOrder(Root);
        System.out.println();

    }
    private void internalPostOrder(TreeNode node){
        if(node == null) return;
        internalPostOrder(node.Left);
        internalPostOrder(node.Right);
        System.out.print(node.Data + " -> ");

    }

    class NodeAndParent{
        public TreeNode Node;
        public TreeNode Parent;
        public boolean isLeft;
        NodeAndParent(TreeNode Node, TreeNode Parent, boolean isLeft){
            this.Node = Node;
            this.Parent = Parent;
            this.isLeft = isLeft;
        }
    }
    class TreeNode {
        public Tdata Data;
        public TreeNode Left;
        public TreeNode Right;

        public TreeNode(Tdata _data) {
            this.Data = _data;
        }
    }


    public void printTree() {
        List<List<String>> lines = new ArrayList<>();
        List<TreeNode> level = new ArrayList<>();
        List<TreeNode> next = new ArrayList<>();

        level.add(Root);
        int nn = 1;

        int widest = 0;

        while (nn != 0) {
            List<String> line = new ArrayList<>();

            nn = 0;

            for (TreeNode n : level) {
                if (n == null) {
                    line.add(null);

                    next.add(null);
                    next.add(null);
                } else {
                    String aa = String.valueOf(n.Data);
                    line.add(aa);
                    if (aa.length() > widest) widest = aa.length();

                    next.add(n.Left);
                    next.add(n.Right);

                    if (n.Left != null) nn++;
                    if (n.Right != null) nn++;
                }
            }

            if (widest % 2 == 1) widest++;

            lines.add(line);

            List<TreeNode> tmp = level;
            level = next;
            next = tmp;
            next.clear();
        }

        int perpiece = lines.getLast().size() * (widest + 4);
        for (int i = 0; i < lines.size(); i++) {
            List<String> line = lines.get(i);
            int hpw = (int) Math.floor(perpiece / 2f) - 1;

            if (i > 0) {
                for (int j = 0; j < line.size(); j++) {
                    char c = ' ';
                    if (j % 2 == 1) {
                        if (line.get(j - 1) != null) {
                            c = (line.get(j) != null) ? '┴' : '┘';
                        } else {
                            if (line.get(j) != null) c = '└';
                        }
                    }
                    System.out.print(c);

                    if (line.get(j) == null) {
                        for (int k = 0; k < perpiece - 1; k++) {
                            System.out.print(" ");
                        }
                    } else {

                        for (int k = 0; k < hpw; k++) {
                            System.out.print(j % 2 == 0 ? " " : "─");
                        }
                        System.out.print(j % 2 == 0 ? "┌" : "┐");
                        for (int k = 0; k < hpw; k++) {
                            System.out.print(j % 2 == 0 ? "─" : " ");
                        }
                    }
                }
                System.out.println();
            }

            for (String f : line) {
                if (f == null) f = "";
                float a = perpiece / 2f - f.length() / 2f;
                int gap1 = (int) Math.ceil(a);
                int gap2 = (int) Math.floor(a);

                for (int k = 0; k < gap1; k++) {
                    System.out.print(" ");
                }
                System.out.print(f);
                for (int k = 0; k < gap2; k++) {
                    System.out.print(" ");
                }
            }
            System.out.println();

            perpiece /= 2;
        }

    }
}
