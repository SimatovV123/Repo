using System;
using System.Collections.Generic;

namespace LinkedListGeneric
{
    public class LinkedList<T>
    {
        private Node<T> firstNode;
        private int count = 0;
        public int Count
        {
            get { return count; }
        }
        public LinkedList() { }
        public LinkedList(List<T> list)
        {
            if (list != null)
            {
                firstNode = new Node<T>();
                Node<T> newNode = firstNode;
                newNode.Item = list[0];
                count++;
                Console.WriteLine($"Node created");


                for (int i = 1; i < list.Count; i++)
                {
                    newNode.ChildNode = new Node<T>();
                    newNode = newNode.ChildNode;
                    newNode.Item = list[i];
                    Console.WriteLine($"Node created");
                    count++;
                }
            }
        }

        public LinkedList(int number)
        {
            if (number > 0)
            {
                firstNode = new Node<T>();
                Node<T> newNode = firstNode;
                newNode.Item = default(T);
                count++;
                Console.WriteLine($"Node created");

                for (int i = 1; i < number; i++)
                {
                    newNode.ChildNode = new Node<T>();
                    newNode = newNode.ChildNode;
                    newNode.Item = default(T);
                    Console.WriteLine($"Empty node created");
                    this.count++;
                    
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = firstNode;
            for (int i = 0; i < count; i++)
            {
                yield return currentNode.Item;

                currentNode = currentNode.ChildNode;
            }
        }
        public T this[int index]
        {
            get
            {
                return GetNode(index).Item;
            }
        }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Item = item
            };
            if (firstNode == null)
            {
                firstNode = newNode;
            }
            else
            {
                Node<T> lastNode = GetNode();
                lastNode.ChildNode = newNode;
                count++;
            }
            Console.WriteLine($"Node added to the end");
        }
        public void Push(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Item = item
            };

            if (firstNode == null)
            {
                firstNode = newNode;
            }
            else
            {
                Node<T> secondNode = firstNode;
                firstNode = newNode;
                firstNode.ChildNode = secondNode;
                count++;

            }
            Console.WriteLine($"Node added to the beginning");
        }

        public void RemoveAll()
        {
            if(firstNode != null)
            {
                NodeDisposer(firstNode);
            }
        }

        public void AddRange(List<T> list)
        {
            LinkedList<T> subList = new LinkedList<T>(list);

            if(firstNode == null)
            {
                firstNode = subList.firstNode;
            }
            else
            {
                Node<T> lastNode = GetNode();
                lastNode.ChildNode = subList.firstNode;
            }
            count += subList.Count;
            Console.WriteLine($"{subList.Count} elements added to the end");
        }

        public void PushRange(List<T> list)
        {
            LinkedList<T> subList = new LinkedList<T>(list);

            if (firstNode == null)
            {
                firstNode = subList.firstNode;
            }
            else
            {
                Node<T> childNode = firstNode;

                firstNode = subList.firstNode;

                subList.GetNode().ChildNode = childNode;
            }
            count += subList.Count;
            Console.WriteLine($"{subList.Count} elements added to the beginning");
        }
        private Node<T> GetNode(int index)
        {
            Node<T> currentNode = firstNode;
            for (int i = 1; i <= index; i++)
            {
                currentNode = currentNode.ChildNode;
            }
            return currentNode;
        }

        private Node<T> GetNode()
        {
            Node<T> currentNode = firstNode;
            for (int i = 1; i < count; i++)
            {
                currentNode = currentNode.ChildNode;
            }
            return currentNode;
        }

        private void NodeDisposer(Node<T> parentNode)
        {
            Node<T> childNode = parentNode.ChildNode;

            parentNode.Dispose();
            
            if(childNode == null)
            {
                return;
            }

            NodeDisposer(childNode);
        }
    }

    internal class Node<T> : IDisposable
    {
        public T Item { get; set; }
        public Node<T> ChildNode { get; set; }

        public void Dispose()
        {
        }
    }
}

