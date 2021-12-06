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
                newNode.Id = count;
                count++;
                Console.WriteLine($"Node #{newNode.Id} created");


                for (int i = 1; i < list.Count; i++)
                {
                    newNode.ChildNode = new Node<T>();
                    newNode = newNode.ChildNode;
                    newNode.Item = list[i];
                    newNode.Id = count;
                    Console.WriteLine($"Node #{newNode.Id} created");
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
                newNode.Id = count;
                count++;
                Console.WriteLine($"Node #{newNode.Id} created");

                for (int i = 1; i < number; i++)
                {
                    newNode.ChildNode = new Node<T>();
                    newNode = newNode.ChildNode;
                    newNode.Item = default(T);
                    newNode.Id = count;
                    Console.WriteLine($"Empty node #{newNode.Id} created");
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
                return NodeCrawler(index).Item;
            }
        }

        public void Add(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Id = count,
                Item = item
            };
            if (firstNode == null)
            {
                firstNode = newNode;
            }
            else
            {
                Node<T> lastNode = NodeCrawler();
                lastNode.ChildNode = newNode;
            }
            Console.WriteLine($"Node #{newNode.Id} added to the end");
        }
        public void Push(T item)
        {
            Node<T> newNode = new Node<T>
            {
                Id = count + 1,
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
            }
            Console.WriteLine($"Node #{newNode.Id} added to the beginning");
        }
        private Node<T> NodeCrawler(int index)
        {

            Node<T> currentNode = firstNode;
            for (int i = 1; i < index; i++)
            {
                currentNode = currentNode.ChildNode;
            }
            return currentNode;
        }
        private Node<T> NodeCrawler()
        {
            Node<T> currentNode = firstNode;
            for(int i = 1; i < count; i++)
            {
                currentNode = currentNode.ChildNode;
            }
            return currentNode;
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
        }
        public void PushRange(List<T> list)
        {

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
        public int Id { get; set; }
        public T Item { get; set; }
        public Node<T> ChildNode { get; set; }

        public void Dispose()
        {
            Console.WriteLine($"Node #{this.Id} disposed");
        }
    }
}

