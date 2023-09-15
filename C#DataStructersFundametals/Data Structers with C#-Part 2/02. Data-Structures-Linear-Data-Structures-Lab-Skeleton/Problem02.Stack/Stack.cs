namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
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
        private Node top;


        public int Count { get; private set; }

        public void Push(T item)
        {
            Node newNode = new Node(item);
            newNode.Next = this.top;
            this.top = newNode;

            this.Count++;
        }

        public T Pop()
        {
            if(this.top== null)
            {
                throw new InvalidOperationException();
            }
            var oldTop=this.top;
            this.top = oldTop.Next;
            oldTop.Next = null;
            Count--;
            return oldTop.Element;
        }


        public T Peek()
        {
            if(this.top== null)
            {
                throw new InvalidOperationException();
            }
            return this.top.Element;
        }

        public bool Contains(T item)
        {
            Node currentNode = this.top;
            while (currentNode != null)
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
            Node currentNode = this.top;
            while (currentNode != null)
            {
                yield return currentNode.Element;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();
       
    }
}