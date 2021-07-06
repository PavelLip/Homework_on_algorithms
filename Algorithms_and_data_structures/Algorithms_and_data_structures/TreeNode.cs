using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_data_structures
{
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
    }

    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }

    public class Tree : ITree
    {
        TreeNode root = new TreeNode();
        int countElements = 0;
        public TreeNode GetRoot() // корень дерева ??? 
        {
            return root;
        }

        public void AddItem(int value) // добавить узел
        {
            TreeNode TreeNode = new TreeNode();

            if (countElements == 0)
            {
                root.Value = value;
                root.LeftChild = null;
                root.RightChild = null;
                countElements = 1;
            }
            else
            {
                TreeNode treeNode = new TreeNode();
                treeNode = root;

                while (true)
                {
                    if (treeNode.Value >= value)
                    {

                        if (treeNode.LeftChild == null)
                        {
                            TreeNode newTtreeNode = new TreeNode();
                            newTtreeNode.Value = value;
                            treeNode.LeftChild = newTtreeNode;
                            newTtreeNode.LeftChild = null;
                            newTtreeNode.RightChild = null;
                            countElements += 1;
                            break;
                        }
                        else
                        {
                            treeNode = treeNode.LeftChild;
                        }
                    }
                    else
                    {
                        if (treeNode.RightChild == null)
                        {
                            TreeNode newTtreeNode = new TreeNode();
                            newTtreeNode.Value = value;
                            treeNode.RightChild = newTtreeNode;
                            newTtreeNode.LeftChild = null;
                            newTtreeNode.RightChild = null;
                            countElements += 1;
                            break;
                        }
                        else
                        {
                            treeNode = treeNode.RightChild;
                        }
                    }
                }
            }
        }

        public TreeNode GetNodeByValue(int value) //получить узел дерева по значению
        {
            TreeNode treeNode = new TreeNode();
            treeNode = root;

            for (int i = 0; i < countElements * 2; i++)
            {
                if (treeNode.Value == value)
                {
                    return treeNode;
                }
                else if (treeNode.Value >= value)
                    treeNode = treeNode.LeftChild;
                else
                    treeNode = treeNode.RightChild;
            }
            return null;
        }

        public void RemoveItem(int value) // удалить узел по значению
        {
            TreeNode treeNode = new TreeNode();
            TreeNode treeNodeParant = new TreeNode();
            treeNode = root;

            if (treeNode.Value != value)
            {
                for (int i = 0; i < countElements * 2; i++)
                {
                    if (treeNode.Value == value)
                        break;
                    else if (treeNode.Value >= value)
                    {
                        treeNodeParant = treeNode;
                        treeNode = treeNode.LeftChild;
                    }
                    else
                    {
                        treeNodeParant = treeNode;
                        treeNode = treeNode.RightChild;
                    }
                }

            }
            else if (treeNode.Value == value)
                treeNodeParant = null;
            else
                return;



            TreeNode newTreeNode = new TreeNode();
            TreeNode newTreeNodeParant = new TreeNode();

            if (treeNode.LeftChild == null && treeNode.RightChild == null) //только корень или лист
            {
                if (treeNodeParant.LeftChild.Value == value)
                    treeNodeParant.LeftChild = null;

                else
                    treeNodeParant.RightChild = null;

            }
            //если только один лист ветвления
            else if ((treeNode.LeftChild != null && treeNode.RightChild == null) || (treeNode.LeftChild == null && treeNode.RightChild != null))
            {
                treeNodeParant.LeftChild = treeNode.LeftChild;
                treeNodeParant.RightChild = treeNode.RightChild;
            }
            //корень но с двумя потомками
            else if (treeNode.LeftChild != null && treeNode.RightChild != null && treeNodeParant == null)
            {
                newTreeNode = root.LeftChild;
                for (int i = 0; i < countElements; i++)
                {
                    if (newTreeNode.RightChild == null)
                        break;
                    else
                    {
                        newTreeNodeParant = newTreeNode;
                        newTreeNode = newTreeNode.RightChild;
                    }
                }

                if (newTreeNode.LeftChild == null)
                    newTreeNodeParant.RightChild = null;
                else
                    newTreeNodeParant.RightChild = newTreeNode.LeftChild;

                newTreeNode.RightChild = root.RightChild;
                newTreeNode.LeftChild = root.LeftChild;
                root = newTreeNode;
            }
            //корень дерева с одним потомком
            else if ((treeNode.LeftChild != null && treeNode.RightChild == null && treeNodeParant == null) || (treeNode.LeftChild == null && treeNode.RightChild != null && treeNodeParant == null))
            {
                root = newTreeNode;
            }
            //ветвь дерева с предком и обоими потомками
            else
            {
                newTreeNode = treeNode.LeftChild;
                for (int i = 0; i < countElements; i++)
                {
                    if (newTreeNode.RightChild == null)
                        break;
                    else
                    {
                        newTreeNodeParant = newTreeNode;
                        newTreeNode = newTreeNode.RightChild;
                    }
                }

                if (newTreeNode.LeftChild == null)
                    newTreeNodeParant.RightChild = null;
                else
                    newTreeNodeParant.RightChild = newTreeNode.LeftChild;

                if (treeNodeParant.LeftChild.Value == value)
                    treeNodeParant.LeftChild = newTreeNode;
                else
                    treeNodeParant.RightChild = newTreeNode;


                newTreeNode.RightChild = treeNode.RightChild;
                newTreeNode.LeftChild = treeNode.LeftChild;

            }
        }

        public void PrintTree() //вывести дерево в консоль
        {
            Console.Clear();
            int count = countElements;
            countElements = countElements * countElements/10;
            var arrayPosition = ArrayTree();

            for (int i = 0; i < countElements; i++)
            {
                for (int j = 0; j < countElements; j++)
                {
                    if (arrayPosition[i, j] != 0)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.WriteLine(arrayPosition[i, j]);
                    }
                }
            }
            countElements = count;
        }

        private int[,] ArrayTree()
        {
            var array = new int[countElements, countElements];
            var queueTreeNode = new Queue<TreeNode>();
            var treeNode = new TreeNode();
            queueTreeNode.Enqueue(root);
            array[0, countElements / 2] = root.Value;
            do
            {
                treeNode = queueTreeNode.Dequeue();
                if (treeNode.LeftChild != null)
                {
                    array = AddArray(array, treeNode, treeNode.LeftChild);
                    queueTreeNode.Enqueue(treeNode.LeftChild);
                }
                if (treeNode.RightChild != null)
                {
                    array = AddArray(array, treeNode, treeNode.RightChild);
                    queueTreeNode.Enqueue(treeNode.RightChild);
                }
            } while (queueTreeNode.Count != 0);
            return array;
        }
        private int[,] AddArray(int[,] array, TreeNode treeNode, TreeNode newTreeNode)
        {
            int position;
            for (int i = 0; i < countElements; i++) // add array
            {
                for (int j = 0; j < countElements; j++)
                {
                    if (array[i, j] == treeNode.Value)
                    {
                        if (treeNode.RightChild == newTreeNode)
                        {
                            position = (int)(countElements / Math.Pow(2, i + 1));
                            array[i + 1, j + position / 2] = newTreeNode.Value;
                            return array;
                        }
                        else if (treeNode.LeftChild == newTreeNode)
                        {
                            position = (int)(countElements / Math.Pow(2, i + 1));
                            array[i + 1, j - position / 2] = newTreeNode.Value;
                            return array;
                        }
                    }
                }
            }
            return array;
        }
    }

    public static class TreeHelper
    {
        public static NodeInfo[] GetTreeInLine(ITree tree)
        {
            var bufer = new Queue<NodeInfo>();
            var returnArray = new List<NodeInfo>();
            var root = new NodeInfo() { Node = tree.GetRoot() };
            bufer.Enqueue(root);

            while (bufer.Count != 0)
            {
                var element = bufer.Dequeue();
                returnArray.Add(element);
                var depth = element.Depth + 1;

                if (element.Node.LeftChild != null)
                {
                    var left = new NodeInfo()
                    {
                        Node = element.Node.LeftChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(left);
                }
                if (element.Node.RightChild != null)
                {
                    var right = new NodeInfo()
                    {
                        Node = element.Node.RightChild,
                        Depth = depth,
                    };
                    bufer.Enqueue(right);
                }
            }
            return returnArray.ToArray();
        }
    }

    public class NodeInfo
    {
        public int Depth { get; set; }
        public TreeNode Node { get; set; }
    }
}