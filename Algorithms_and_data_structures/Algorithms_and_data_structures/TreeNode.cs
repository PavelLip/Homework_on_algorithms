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
        TreeNode SearchDFS(int value); //получить узел дерева по значению
        TreeNode SearchBFS(int value); //получить узел дерева по значению
    }

    public class Tree : ITree
    {
        TreeNode root = new TreeNode();
        int countElements = 0;
        public TreeNode GetRoot() 
        {
            return root;
        }

        public void AddItem(int value) 
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

        public TreeNode SearchDFS(int value) // стек
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode treeNode = new TreeNode();
            Console.WriteLine($"Запущен поиск DFS");
            do
            {
                treeNode = stack.Pop();
                Console.WriteLine($"Достали из стека значение {treeNode.Value}");

                if (treeNode.Value == value)
                {
                    Console.WriteLine($"Искомое значение {value}, найденое значение {treeNode.Value}. Поиск окончен");
                    return treeNode;
                }
                else
                {
                    if (treeNode.RightChild != null)
                    {
                        Console.WriteLine($"Положили в стек правого потомка, его значение {treeNode.RightChild.Value}");
                        stack.Push(treeNode.RightChild);
                    }
                    if (treeNode.LeftChild != null)
                    {
                        Console.WriteLine($"Положили в стек левого потомка, его значение {treeNode.LeftChild.Value}");
                        stack.Push(treeNode.LeftChild);
                    }
                }
            } while (stack.Count != 0);

            Console.WriteLine($"Искомое значение - {value}, не найдено");
            return null;
        }

        public TreeNode SearchBFS(int value)//очередь
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            TreeNode treeNode = new TreeNode();
            Console.WriteLine($"Запущен поиск BFS");
            Console.WriteLine($"Положили в очередь корень дерева, его значение {root.Value}");
            do
            {
                treeNode = queue.Dequeue();
                Console.WriteLine($"Достали из очереди значение {treeNode.Value}");
                if (treeNode.Value == value)
                {
                    Console.WriteLine($"Искомое значение {value}, найденое значение {treeNode.Value}. Поиск окончен");
                    return treeNode;
                }

                else
                {
                    if (treeNode.LeftChild != null)
                    {
                        queue.Enqueue(treeNode.LeftChild);
                        Console.WriteLine($"Положили в очередь левого потомка, его значение {treeNode.LeftChild.Value}");
                    }
                    if (treeNode.RightChild != null)
                    {
                        queue.Enqueue(treeNode.RightChild);
                        Console.WriteLine($"Положили в очередь правого потомка, его значение {treeNode.RightChild.Value}");
                    }
                }
            } while (queue.Count != 0);

            Console.WriteLine($"Искомое значение - {value}, не найдено");
            return null;
        }
    }
}