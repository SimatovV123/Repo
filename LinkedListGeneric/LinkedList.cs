using System;
using System.Collections.Generic;

namespace LinkedListGeneric
{
    public class LinkedList<T>
    {
        private Node<T> firstNode;
        private int count;
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

                for (int i = 1; i < list.Count; i++)
                {
                    newNode.ChildNode = new Node<T>();
                    newNode = newNode.ChildNode;
                    newNode.Item = list[i];
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

                for (int i = 1; i < number; i++)
                {
                    newNode.ChildNode = new Node<T>();
                    newNode = newNode.ChildNode;
                    newNode.Item = default(T);

                    count++;
                    
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
                if(index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                return GetNode(index).Item;
            }
        }
        /// <summary>
        /// Вставляет элемент в конец списка
        /// </summary>
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
        }
        /// <summary>
        /// Вставляет элемент в начало списка
        /// </summary>
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
        }
        /// <summary>
        /// Вставляет элемент в список на определенную позицию
        /// </summary>
        public void Insert(T item, int index)
        {
            if(index == 0)
            {
                Push(item);
                return;
            }
            else if(index == count)
            {
                Add(item);
                return;
            }
            else if(index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node<T> parentNode = GetNode(index - 1);
            Node<T> childNode = parentNode.ChildNode;

            Node<T> newNode = new Node<T>
            {
                Item = item,
                ChildNode = childNode
            };

            parentNode.ChildNode = newNode;
            count++;
        }

        /// <summary>
        /// Вставляет список элементов, начиная с определённой позиции
        /// </summary>
        public void InsertRange(List<T> list, int index)
        {
            if (index == 0)
            {
                PushRange(list);
                return;
            }
            else if (index == count)
            {
                AddRange(list);
                return;
            }
            else if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException();
            }

            Node<T> parentNode = GetNode(index - 1);
            Node<T> childNode = parentNode.ChildNode;

            LinkedList<T> subList = new LinkedList<T>(list);

            parentNode.ChildNode = subList.firstNode;
            subList.GetNode().ChildNode = childNode;
            count += subList.count;

        }
        /// <summary>
        /// Вставляет последовательность элементов в конец списка
        /// </summary>
        public void AddRange(List<T> list)
        {
            LinkedList<T> subList = new LinkedList<T>(list);

            if (firstNode == null)
            {
                firstNode = subList.firstNode;
            }
            else
            {
                Node<T> lastNode = GetNode();
                lastNode.ChildNode = subList.firstNode;
            }
            count += subList.Count;
        }
        /// <summary>
        /// Вставляет последовательность элементов в конец списка
        /// </summary>
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
        }

        public void RemoveAll()
        {
            if(firstNode != null)
            {
                NodeDisposer(firstNode);
            }
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

