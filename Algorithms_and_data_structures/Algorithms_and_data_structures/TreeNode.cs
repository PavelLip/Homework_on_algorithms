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
        public TreeNode Parent { get; set; }
        public int Position { get; set; }

        public override bool Equals(object obj)
        {
            var node = obj as TreeNode;

            if (node == null)
                return false;

            return node.Value == Value;
        }
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
        TreeNode treeNode = new TreeNode();
        TreeNode tTreeNode = new TreeNode();
        int countElements = 0;

        public void AddItem(int value) // добавить узел
        {
            TreeNode tTreeNode = new TreeNode();
            if (countElements == 0)
            {
                treeNode.Parent = null;
                treeNode.LeftChild = null;
                treeNode.RightChild = null;
                treeNode.Value = value;
                countElements = 1;
                //arrayHelp[0, 2] = 1;
            }
            else
            {

                tTreeNode = treeNode;
                for (int j = 0; j < countElements * 2; j++)
                {
                    if (tTreeNode.Value >= value)
                    {

                        if (tTreeNode.LeftChild == null)
                        {
                            TreeNode newTtreeNode = new TreeNode();
                            newTtreeNode.Value = value;
                            newTtreeNode.Parent = tTreeNode;
                            newTtreeNode.LeftChild = null;
                            newTtreeNode.RightChild = null;
                            tTreeNode.LeftChild = newTtreeNode;
                            countElements += 1;
                            return;
                        }
                        else
                        {
                            tTreeNode = tTreeNode.LeftChild;
                        }


                    }
                    else
                    {
                        if (tTreeNode.RightChild == null)
                        {
                            TreeNode newTtreeNode = new TreeNode();
                            newTtreeNode.Value = value;
                            newTtreeNode.Parent = tTreeNode;
                            newTtreeNode.LeftChild = null;
                            newTtreeNode.RightChild = null;
                            tTreeNode.RightChild = newTtreeNode;
                            countElements += 1;
                            return;
                        }
                        else
                        {
                            tTreeNode = tTreeNode.RightChild;
                        }
                    }
                }
            }
        }

        public TreeNode GetNodeByValue(int value) //получить узел дерева по значению
        {
            TreeNode tTreeNode = new TreeNode();
            tTreeNode = treeNode;
            for (int i = 0; i < countElements * 2; i++)
            {
                if (tTreeNode.Value == value)
                {
                    return tTreeNode;
                }
                else if (tTreeNode.Value >= value)
                    tTreeNode = tTreeNode.LeftChild;
                else
                    tTreeNode = tTreeNode.RightChild;
            }
            return null;
        }

        public TreeNode GetRoot() // корень дерева ??? 
        {
            return treeNode;
        }

        public void PrintTree() //вывести дерево в консоль
        {
            Console.Clear();

            PaymentPosition();



            Queue<TreeNode> elementTree = new Queue<TreeNode>();
            Queue<TreeNode> _elementTree = new Queue<TreeNode>();
            TreeNode _treeNode = new TreeNode();
            elementTree.Enqueue(treeNode);
            _elementTree.Enqueue(treeNode);
            int widthTree = 1;
            int countElementWidth = 0;

            //do
            //{

            //    _treeNode = elementTree.Dequeue();

            //    Console.SetCursorPosition(_treeNode.Position, widthTree);
            //    Console.WriteLine(_treeNode.Value);


            //    if (_treeNode.LeftChild != null)
            //    {
            //        _elementTree.Enqueue(_treeNode);
            //    }
            //        elementTree.Enqueue(_treeNode.LeftChild);

            //    if (_treeNode.RightChild != null)
            //    {
            //        _elementTree.Enqueue(_treeNode);
            //    }
            //        elementTree.Enqueue(_treeNode.RightChild);
            //    widthTree += 1;
            //} 
            //while (elementTree.Count() != 0);




            while (true)
            {

                countElementWidth = elementTree.Count();
                for (int i = 0; i < countElementWidth; i++)
                {
                    _treeNode = elementTree.Dequeue();

                    Console.SetCursorPosition(_treeNode.Position, widthTree);
                    Console.WriteLine(_treeNode.Value);

                    if (_treeNode.LeftChild != null)
                    {
                        elementTree.Enqueue(_treeNode.LeftChild);
                    }

                    if (_treeNode.RightChild != null)
                    {
                        elementTree.Enqueue(_treeNode.RightChild);
                    }



                }
                    
                    widthTree += 1;
                if (elementTree.Count() == 0)
                {
                    break;
                }
            }


            
        }

        private void PaymentPosition()
        {
            Queue<TreeNode> elementTree = new Queue<TreeNode>();
            elementTree.Enqueue(treeNode);

            TreeNode _treeNode = new TreeNode();
            _treeNode = treeNode;



            //_treeNode.Position = WidthTree(_treeNode.LeftChild)+120;

            int countLeftElement = WidthTree(_treeNode.LeftChild);
            int countRightElement = WidthTree(_treeNode.RightChild);
            _treeNode.Position = countLeftElement;
            //int countLeftElement = _treeNode.Position;
            //int countRightElement = _treeNode.Position;

            //if (countLeftElement < countRightElement)
            //    countLeftElement = countRightElement;
            //else
            //    countRightElement = countLeftElement;



            for (int i = 0; i < countElements; i++)
            {
                _treeNode = elementTree.Dequeue();

                if (_treeNode.LeftChild != null)
                {
                    if (_treeNode.Parent == null)
                    {
                        elementTree.Enqueue(_treeNode.LeftChild);
                        _treeNode.LeftChild.Position = _treeNode.Position / 2;
                    }
                    else
                    {
                        elementTree.Enqueue(_treeNode.LeftChild);

                        _treeNode.LeftChild.Position = PaymentLeft(_treeNode);
                        //_treeNode.LeftChild.Position = _treeNode.Position - (_treeNode.Parent.Position - _treeNode.Position) / 2;
                    }

                }
                if (_treeNode.RightChild != null)
                {
                    if (_treeNode.Parent == null)
                    {
                        elementTree.Enqueue(_treeNode.RightChild);

                        _treeNode.RightChild.Position = treeNode.Position + countRightElement / 2;
                    }
                    else
                    {
                        elementTree.Enqueue(_treeNode.RightChild);
                        _treeNode.RightChild.Position = PaymentRight(_treeNode);
                        //_treeNode.RightChild.Position = ((_treeNode.Position - _treeNode.Parent.Position) / 2) + _treeNode.Position;
                    }
                }

                if (elementTree.Count == 0)
                    break;
            }




            int PaymentLeft (TreeNode tree)
            {
                if (tree.Parent.Position > tree.Position)
                {
                    return _treeNode.Position - (_treeNode.Parent.Position - _treeNode.Position) / 2;
                }
                else 
                {
                    return _treeNode.Position - (_treeNode.Position - _treeNode.Parent.Position) / 2;
                }
            }
            int PaymentRight(TreeNode tree)
            {
                if (tree.Parent.Position > tree.Position)
                {
                    return ((_treeNode.Parent.Position - _treeNode.Position) / 2) + _treeNode.Position;
                }
                else
                {
                    return ((_treeNode.Position - _treeNode.Parent.Position) / 2) + _treeNode.Position;
                }
            }



        }




        //расстояние корня дерева от левой стороны
        private int WidthTree(TreeNode _TreeNode)
        {
            Queue<TreeNode> elementTree = new Queue<TreeNode>();
            elementTree.Enqueue(_TreeNode);
            TreeNode _treeNode = new TreeNode();
            _treeNode = _TreeNode;
            int countLeftElementsTree = 1;

            //кол-во элементов слева от корня дерева
            for (int i = 0; i < countElements; i++)
            {
                _treeNode = elementTree.Dequeue();
                if (_treeNode.LeftChild != null)
                {
                    elementTree.Enqueue(_treeNode.LeftChild);
                    countLeftElementsTree += 1;
                }
                if (_treeNode.RightChild != null)
                {
                    elementTree.Enqueue(_treeNode.RightChild);
                    countLeftElementsTree += 1;
                }

                if (elementTree.Count == 0)
                {
                    return countLeftElementsTree * MaxElementTree();
                }


            }

            return MaxElementTree()*10;
        }
        //кол-во элементов дерева слева от корня
        private int MaxElementTree()
        {
            TreeNode _treeNode = new TreeNode();
            _treeNode = treeNode;
            for (int j = 0; j < countElements; j++)
            {
                if (_treeNode.RightChild != null)
                {
                    _treeNode = _treeNode.RightChild;
                }
            }
            return _treeNode.Value.ToString().Length;
        }

















        public void RemoveItem(int value) // удалить узел по значению
        {
            TreeNode tTreeNode = new TreeNode();
            tTreeNode = treeNode;
            for (int i = 0; i < countElements * 2; i++)
            {
                if (tTreeNode.Value == value)
                {
                    if (tTreeNode.LeftChild == null && tTreeNode.RightChild == null)
                    {
                        if (tTreeNode.Parent == null)
                            treeNode = null;
                        else
                        {
                            if (tTreeNode.Parent.LeftChild == tTreeNode)
                                tTreeNode.Parent.LeftChild = null;
                            else

                                tTreeNode.Parent.RightChild = null;
                            return;
                        }
                    }
                    else if (tTreeNode.LeftChild == null || tTreeNode.RightChild == null)
                    {
                        if (tTreeNode.LeftChild == null && tTreeNode.RightChild != null)
                        {
                            if (tTreeNode.Value <= tTreeNode.Parent.Value)
                                tTreeNode.Parent.LeftChild = tTreeNode.RightChild;

                            else
                                tTreeNode.Parent.RightChild = tTreeNode.RightChild;
                        }
                        else
                        {
                            if (tTreeNode.Value <= tTreeNode.Parent.Value)
                                tTreeNode.Parent.LeftChild = tTreeNode.LeftChild;

                            else
                                tTreeNode.Parent.RightChild = tTreeNode.LeftChild;
                        }
                    }
                    else if (tTreeNode.Parent == null)
                    {
                        tTreeNode = SearcLeastElement(tTreeNode.RightChild);
                        if (tTreeNode.Parent == null && tTreeNode.LeftChild == null && tTreeNode.RightChild == null)
                        {
                            treeNode = null;
                            return;
                        }
                        else if (tTreeNode.RightChild == null)
                        {
                            treeNode.Value = tTreeNode.Value;
                            tTreeNode.Parent.LeftChild = null;
                            return;
                        }
                        else
                        {
                            treeNode.Value = tTreeNode.Value;
                            tTreeNode.Parent.LeftChild = tTreeNode.RightChild;
                            tTreeNode.RightChild.Parent = tTreeNode.Parent;
                            return;
                        }


                    }
                    else if (tTreeNode.Parent != null && tTreeNode.LeftChild != null && tTreeNode.RightChild != null)
                    {
                        TreeNode _tTreeNode = new TreeNode();
                        _tTreeNode = SearcGreatestElement(tTreeNode.LeftChild);
                        if (_tTreeNode.Parent.LeftChild == _tTreeNode)
                            _tTreeNode.Parent.LeftChild = null;
                        else
                            _tTreeNode.Parent.RightChild = null;
                        tTreeNode.Value = _tTreeNode.Value;
                        return;
                    }
                }
                else if (tTreeNode.Value >= value)
                    tTreeNode = tTreeNode.LeftChild;
                else
                    tTreeNode = tTreeNode.RightChild;
            }
        }

        private TreeNode SearcLeastElement(TreeNode _treeNode)
        {
            for (int i = 0; i < countElements; i++)
            {
                if (_treeNode.LeftChild == null)
                {
                    return _treeNode;
                }
                else
                    _treeNode = _treeNode.LeftChild;
            }
            return null;
        }
        private TreeNode SearcGreatestElement(TreeNode _treeNode)
        {
            for (int i = 0; i < countElements; i++)
            {
                if (_treeNode.RightChild == null)
                {
                    return _treeNode;
                }
                else
                    _treeNode = _treeNode.RightChild;
            }
            return null;
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
