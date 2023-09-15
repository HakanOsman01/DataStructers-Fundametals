namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Xml.Linq;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }
            public Node(T value)
            {
                this.Element = value;

            }
            public Node(T value, Node next)
                : this(value)
            {
                this.Next = next;
            }

        }
        private Node head;
        private Node tail;
        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode=new Node(item);
            if (Count == 0)
            {
                this.head =this.tail = newNode;
            }
            else
            {
                 newNode.Next= this.head;
                 this.head = newNode;

            }
          
            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);
            if (Count == 0)
            {
                this.head =this.tail=newNode;

            }
            else
            {
                var node = this.tail;
                node.Next = newNode;
                this.tail = newNode;
               
               
            }
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Element;
                currentNode = currentNode.Next;
            }
        }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.head.Element;

        }

        public T GetLast()
        {
           if(Count == 0)
           {
                throw new InvalidOperationException();
           }
            
            return this.tail.Element;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The linked list is empty");
            }
            T headValue = this.head.Element;
            var removed = this.head;
            this.head = removed.Next;
            removed.Next = null;
            Count--;
            return headValue;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The linked list is empty");
            }
            if (Count == 1)
            {
                var onlyValue= this.tail.Element;
                this.head =this.tail= null;
               
                Count--;
                return onlyValue;

            }
           
            var oldTail = this.tail;
            var removedValue = this.tail.Element;
            var currentNode = this.head;
            while (currentNode.Next!=oldTail)
            {
                currentNode = currentNode.Next;
            }
            currentNode.Next = null;
            this.tail = currentNode;
            Count--;
            return removedValue;
            
        }

        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();
        
    }
}