namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
       

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode=this.head;
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

        public T Dequeue()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Empty Queue!!!");

            }
            var oldHead=this.head;
            this.head = oldHead.Next;
            Count--;
            return oldHead.Element;
        }

        public void Enqueue(T item)
        {
            //Node<T> node = new Node<T>(item);
            if (head == null)
            {
                this.head=new Node<T>(item);
                this.Count++;
                return;
            }
            else
            {
                var node = new Node<T>(item);
                this.head.Next = node;
                Count++;

            }
           
          
        }

        public T Peek()
        {
          if(head== null)
          {
                throw new InvalidOperationException("Empty Queue!!!");

          }
          var element= head.Element;
          return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode=this.head;
            while (head != null)
            {
                yield return currentNode.Element;
                currentNode = currentNode.Next;
            }
           
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}