using Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BinartTree
{

    public class MyBinaryTree<Tdata> where Tdata : IComparable<Tdata>
    {

        TreeNode Root;
        public void Balance()
        {
            List<Tdata> nodes = new List<Tdata>();
            InOrderToArray(Root, nodes);
            Root = RecursiveBalance(0, nodes.Count - 1, nodes);
        }  
        void InOrderToArray(TreeNode node, List<Tdata> nodes)
        {
            if(node == null) return;
            InOrderToArray(node.Left, nodes);
            nodes.Add(node.data);
            InOrderToArray(node.Right, nodes);
        }
        TreeNode RecursiveBalance(int start, int end, List<Tdata> nodes)
        {
            if (start > end) return null;
            int mid = (start + end) / 2;
            TreeNode newNode = new TreeNode(nodes[mid]);
            //newNode.data = nodes[mid];
            newNode.Left = RecursiveBalance(start, mid - 1, nodes);
            newNode.Right = RecursiveBalance(mid + 1, end, nodes);
            return newNode;
        }
        public void Insert(Tdata _data)
        {
            TreeNode newNode = new TreeNode(_data);
            if(Root == null) {
                Root = newNode;
                return;
            }
            MyQueueLinkedList <TreeNode> q = new MyQueueLinkedList<TreeNode> (false);
            q.enqueue (Root);
            while (!q.isEmpty())
            {
                TreeNode CurrentNode = q.dequeue ();
                if(CurrentNode.Left == null)
                {
                    CurrentNode.Left = newNode;
                    break;
                }
                else
                {
                    q.enqueue (CurrentNode.Left);
                }
                if (CurrentNode.Right == null)
                {
                    CurrentNode.Right = newNode;
                    break;
                }
                else
                {
                    q.enqueue(CurrentNode.Right);
                }

            }
        }
        public void BSInsert(Tdata _data)
        {
            TreeNode newNode = new TreeNode(_data);
            if (Root == null)
            {
                Root = newNode;
                return;
            }
            TreeNode CurrentNode = Root;
            while(CurrentNode != null)
            {
                if(CurrentNode.data.CompareTo(_data) > 0)
                {
                    if (CurrentNode.Left == null)
                    {
                        CurrentNode.Left = newNode;
                        break;
                    }
                    else CurrentNode = CurrentNode.Left;
                }
                else
                {
                    if (CurrentNode.Right == null)
                    {
                        CurrentNode.Right = newNode;
                        break;
                    }
                    else CurrentNode = CurrentNode.Right;
                }

            }
        }
        public int Height()
        {
            return internalHeight(Root);
        }
        int internalHeight(TreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(internalHeight(node.Left), internalHeight(node.Right));

        }
        public void PreOrder()
        {
            internalPreOrder(Root);
            Console.WriteLine();
        }
        void internalPreOrder(TreeNode node)
        {
            if(node == null)
                return;
            Console.Write(node.data + " -> ");
            internalPreOrder(node.Left);
            internalPreOrder(node.Right);
        }
        public void InOreder()
        {
            internalInOrder(Root);
            Console.WriteLine();

        }
        void internalInOrder(TreeNode node)
        {
            if (node == null)
                return;
            internalInOrder(node.Left);
            Console.Write(node.data + " -> ");
            internalInOrder(node.Right);
        }
        public void PostOreder()
        {
            internalPostOrder(Root);
            Console.WriteLine();

        }
        void internalPostOrder(TreeNode node)
        {
            if (node == null)
                return;
            internalPostOrder(node.Left);
            internalPostOrder(node.Right);
            Console.Write(node.data + " -> ");
        }
        public bool find(Tdata _data)
        {
            return internalFind(Root, _data);
        }
        NodeAndParent FindNodeAndParent(Tdata _data)
        {
            TreeNode CurrentNode = Root;
            TreeNode Parent = null;
            NodeAndParent nodeAndParentInfo = null;
            bool left = false;
            while (CurrentNode != null)
            {
                if (CurrentNode.data.Equals(_data))
                {
                    nodeAndParentInfo = new NodeAndParent()
                    {
                        Node = CurrentNode,
                        Parent = Parent,
                        isLeft = left
                    };
                    break;
                }
                else if (CurrentNode.data.CompareTo(_data) > 0)
                {
                    Parent = CurrentNode;
                    left = true;
                    CurrentNode = CurrentNode.Left;
                }
                else
                {
                    Parent = CurrentNode;
                    left = false;
                    CurrentNode = CurrentNode.Right;
                }
            }
            return nodeAndParentInfo;
        }
        bool internalFind(TreeNode node, Tdata _data)
        {
            if (node == null)
                return false;
            if(node.data.Equals(_data))
                return true;
            internalFind(node.Left, _data);
            internalFind(node.Right, _data);
            return false;
        }
        public bool isExist(Tdata _date)
        {
            return BSfind(_date) != null;
        }
        TreeNode BSfind(Tdata _data)
        {
            TreeNode CurrentNode = Root;
            while (CurrentNode != null)
            {
                if (CurrentNode.data.Equals(_data))
                    return CurrentNode;
                else if (CurrentNode.data.CompareTo(_data) > 0)
                    CurrentNode = CurrentNode.Left;
                else
                    CurrentNode = CurrentNode.Right;
            }
            return null;
        }
        public void BSDelete(Tdata _data)
        {
            NodeAndParent NodeAndParentInfo = FindNodeAndParent(_data);
            if (NodeAndParentInfo.Node == null) return;
            if(NodeAndParentInfo.Node.Left != null && NodeAndParentInfo.Node.Right != null)
            {
                BSDelete_Has_Childs(NodeAndParentInfo.Node);
            }
            else if (NodeAndParentInfo.Node.Left != null ^ NodeAndParentInfo.Node.Right != null)
            {
                BSDelete_Has_One_Child(NodeAndParentInfo.Node);
            }
            else
            {
                BSDelete_Leaf(NodeAndParentInfo);
            }

        }
        void BSDelete_Leaf(NodeAndParent NodeAndParentInfo)
        {
            if (NodeAndParentInfo.Parent == null)
                Root = null;
            else
            {
                if (NodeAndParentInfo.isLeft)
                {
                    NodeAndParentInfo.Parent.Left = null;
                }
                else
                {
                    NodeAndParentInfo.Parent.Right = null;

                }
            }
        }
        void BSDelete_Has_One_Child(TreeNode NodeToDelete)
        {
            TreeNode NodeToReplace = null;
            if(NodeToDelete.Left != null)
                NodeToReplace = NodeToDelete.Left;
            else
                NodeToReplace = NodeToDelete.Right;
            NodeToDelete.data = NodeToReplace.data;
            NodeToDelete.Right = NodeToReplace.Right;
            NodeToDelete.Left = NodeToReplace.Left;


        }
        void BSDelete_Has_Childs(TreeNode NodeToDelete)
        {
            TreeNode CurrentNode = NodeToDelete.Right;
            TreeNode Parent = null;
            while(CurrentNode.Left != null)
            {
                Parent = CurrentNode;
                CurrentNode = CurrentNode.Left;
            }
            if(Parent != null)
            {
                Parent.Left = CurrentNode.Right;
            }
            else
            {
                NodeToDelete.Right = CurrentNode.Right;
            }
            NodeToDelete.data = CurrentNode.data;
        }
        class TreeNode
        {
            public Tdata data;
            public TreeNode Left = null;
            public TreeNode Right = null;
            public TreeNode(Tdata _data)
            {
                data = _data;
            }
        }
        class NodeAndParent
        {
            public TreeNode Parent;
            public TreeNode Node;
            public bool isLeft;
        }


        #region PrintTree
        class NodeInfo
        {
            public TreeNode Node;
            public string Text;
            public int StartPos;
            public int Size { get { return Text.Length; } }
            public int EndPos { get { return StartPos + Size; } set { StartPos = value - Size; } }
            public NodeInfo Parent, Left, Right;
        }
        public void Print(int topMargin = 2, int LeftMargin = 2)
        {
            if (this.Root == null) return;
            int rootTop = Console.CursorTop + topMargin;
            var last = new List<NodeInfo>();
            var next = this.Root;
            for (int level = 0; next != null; level++)
            {
                var item = new NodeInfo { Node = next, Text = next.data.ToString() };
                if (level < last.Count)
                {
                    item.StartPos = last[level].EndPos + 1;
                    last[level] = item;
                }
                else
                {
                    item.StartPos = LeftMargin;
                    last.Add(item);
                }
                if (level > 0)
                {
                    item.Parent = last[level - 1];
                    if (next == item.Parent.Node.Left)
                    {
                        item.Parent.Left = item;
                        item.EndPos = Math.Max(item.EndPos, item.Parent.StartPos);
                    }
                    else
                    {
                        item.Parent.Right = item;
                        item.StartPos = Math.Max(item.StartPos, item.Parent.EndPos);
                    }
                }
                next = next.Left ?? next.Right;
                for (; next == null; item = item.Parent)
                {
                    Print(item, rootTop + 2 * level);
                    if (--level < 0) break;
                    if (item == item.Parent.Left)
                    {
                        item.Parent.StartPos = item.EndPos;
                        next = item.Parent.Node.Right;
                    }
                    else
                    {
                        if (item.Parent.Left == null)
                            item.Parent.EndPos = item.StartPos;
                        else
                            item.Parent.StartPos += (item.StartPos - item.Parent.EndPos) / 2;
                    }
                }
            }
            Console.SetCursorPosition(0, rootTop + 2 * last.Count - 1);
        }
        private void Print(NodeInfo item, int top)
        {
            SwapColors();
            Print(item.Text, top, item.StartPos);
            SwapColors();
            if (item.Left != null)
                PrintLink(top + 1, "┌", "┘", item.Left.StartPos + item.Left.Size / 2, item.StartPos);
            if (item.Right != null)
                PrintLink(top + 1, "└", "┐", item.EndPos - 1, item.Right.StartPos + item.Right.Size / 2);
        }

        private void PrintLink(int top, string start, string end, int startPos, int endPos)
        {
            Print(start, top, startPos);
            Print("─", top, startPos + 1, endPos);
            Print(end, top, endPos);
        }

        private void Print(string s, int top, int Left, int Right = -1)
        {
            Console.SetCursorPosition(Left, top);
            if (Right < 0) Right = Left + s.Length;
            while (Console.CursorLeft < Right) Console.Write(s);
        }

        private void SwapColors()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
        }
        #endregion 

    }
}
