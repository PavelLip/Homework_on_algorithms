using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_and_data_structures
{
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }

    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке +
        void AddNode(int value);  // добавляет новый элемент списка 1
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента 2
        void RemoveNode(int index); // удаляет элемент по порядковому номеру  +
        void RemoveNode(Node node); // удаляет указанный элемент +
        Node FindNode(int searchValue); // ищет элемент по его значению +
    }

    public class LinkedList : ILinkedList
    {
        public Node head;
        public Node tail;
        public int count = 0;
        public Node PrevNodeElement;
        public Node NextNodeElement;
        public void AddNode(int value)
        {
            if (count == 0)
            {
                Node ls = new Node();
                ls.Value = value;
                ls.NextNode = null;
                ls.PrevNode = null;
                tail = ls;
                head = ls;
                count = 1;
                PrevNodeElement = ls;
            }
            else
            {
                Node ls = new Node();
                ls.Value = value;
                ls.NextNode = null;
                ls.PrevNode = PrevNodeElement;
                tail = ls;
                count++;
                PrevNodeElement.NextNode = ls;
                PrevNodeElement = ls;
            }
        }

        public void AddNodeAfter(Node node, int value)
        {
            
            Node ss = head;
            Node PrevNodeAddElement;
            Node NextNodeAddElement;

            for (int i = 0; i < count; i++)
            {
                if (ss == node)
                {
                    if (ss.NextNode == null)
                    {
                        AddNode(value);
                        return;
                    }
                    else
                    {
                        PrevNodeAddElement = ss;
                        NextNodeAddElement = ss.NextNode;

                        Node ls = new Node();
                        ls.Value = value;
                        ls.NextNode = NextNodeAddElement;
                        ls.PrevNode = PrevNodeAddElement;
                        ls.NextNode.PrevNode = ls;
                        ls.PrevNode.NextNode = ls;
                        count++;
                        NewTail(ss);
                        return;
                    }
                   
                }
                else
                {
                    ss = ss.NextNode;
                }
            }
        }

        public Node FindNode(int searchValue)
        {
            Node ss = head;
            for (int i = 0; i < count; i++)
            {
                if (ss.Value == searchValue)
                {
                    return ss;
                }
                else
                {

                    ss = ss.NextNode;
                }
            }
            return null;
        }

        public int GetCount()
        {
            return count;
        }
        public void RemoveNode(int index)
        {
            Node ss = head;
            Node PrevNodeDeleteElement;
            Node NextNodeDeleteElement;

            for (int i = 1; i <= count; i++)
            {
                if (i == index)
                {
                    if (ss.PrevNode == null && ss.NextNode == null)
                    {
                        count = 0;
                        tail = null;
                        head = null;
                        return;
                    }
                    else if (ss.PrevNode == null)
                    {
                        ss.NextNode.PrevNode = null;
                        count--;
                        NewTail(ss.NextNode);
                        head = ss.NextNode;
                        return;
                    }
                    else if (ss.NextNode == null)
                    {
                        ss.PrevNode.NextNode = null;
                        count--;
                        NewTail(ss.PrevNode);
                        return;
                    }
                    else
                    {
                        PrevNodeDeleteElement = ss.PrevNode;
                        PrevNodeDeleteElement.NextNode = ss.NextNode;

                        NextNodeDeleteElement = ss.NextNode;
                        NextNodeDeleteElement.PrevNode = PrevNodeDeleteElement;
                        count--;
                        NewTail(ss);
                        return;
                    }
                    
                }
                else
                {
                    ss = ss.NextNode;
                }
            }

        }
        public void RemoveNode(Node node)
        {
            Node ss = head;
            Node PrevNodeDeleteElement;
            Node NextNodeDeleteElement;

            for (int i = 0; i < count; i++)
            {
                if (ss == node)
                {
                    if (ss.PrevNode == null)
                    {
                        ss.NextNode.PrevNode = null;
                        count--;
                        NewTail(ss.NextNode);
                        head = ss.NextNode;
                        return;
                    }
                    else if (ss.NextNode == null)
                    {
                        ss.PrevNode.NextNode = null;
                        count--;
                        NewTail(ss.PrevNode);
                        return;
                    }
                    else
                    {
                        PrevNodeDeleteElement = ss.PrevNode;
                        PrevNodeDeleteElement.NextNode = ss.NextNode;

                        NextNodeDeleteElement = ss.NextNode;
                        NextNodeDeleteElement.PrevNode = PrevNodeDeleteElement;
                        count--;
                        NewTail(ss);
                        return;
                    }

                }
                else
                {

                    ss = ss.NextNode;
                }
            }

        }
        private void NewTail (Node start)
        {
            for (int i = 0; i < count; i++)
            {
                if (start.NextNode == null)
                {
                    tail = start;
                    return;
                }
                else
                {
                    start = start.NextNode;
                }
            }
        }
    }
}
