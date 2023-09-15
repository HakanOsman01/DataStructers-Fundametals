namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
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

        public int Count  { get; private set; }

        public void Enqueue(T item)
        {
            var newNode=new Node(item);
            if(Count==0)
            {
                this.head= newNode;
            }
            else
            {
                var node = this.head;
                while (node.Next!= null)
                {
                    
                    node=node.Next; 
                }
                node.Next = newNode;
                
                
               
            }
            Count++;

        }

        public T Dequeue()
        {
            if(this.head== null)
            {
                throw new InvalidOperationException();
            }
            var oldHead = this.head;
            T value = oldHead.Element;
            this.head = oldHead.Next;
            oldHead.Next = null;  
            Count--;
            return value;
        }

        public T Peek()
        {
            if(Count==0)
            {
                throw new InvalidOperationException();
            }
            return this.head.Element;
        }

        public bool Contains(T item)
        {
            var currentNode=this.head;
            while(currentNode != null)
            {
                if (currentNode.Element.Equals(item))
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
           var currentNode=this.head;
            while(currentNode != null)
            {
                yield return currentNode.Element;
                currentNode=currentNode.Next;
               
            }
        }

        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();
       
    }
}