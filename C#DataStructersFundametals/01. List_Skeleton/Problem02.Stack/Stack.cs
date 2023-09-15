namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> top;
        //private Node<T> tail;
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> currentNode = this.top;
            while (currentNode != null)
            {
                if (currentNode.Element.Equals(item))
                {
                    return true;
                }
                currentNode=currentNode.Next;
            }
            return false;
        }

        public T Peek()
        {
            if(this.top==null)
            {
                throw new InvalidOperationException("The stack is empty!!!");
            }
            T value = top.Element;
            return value;
        }

        public T Pop()
        {
            if (top==null)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            var oldTop = this.top;
            this.top = oldTop.Next;
            Count--;
            return oldTop.Element;


        }

        public void Push(T item)
        {
            var node = new Node<T>(item,this.top);
            //top.Next=newNode;
            top = node;
            Count++;    

        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> node = this.top;
            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() =>GetEnumerator();
           
    }
}