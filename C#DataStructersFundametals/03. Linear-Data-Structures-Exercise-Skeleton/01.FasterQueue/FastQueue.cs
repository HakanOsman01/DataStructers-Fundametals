namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;
        
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public T Dequeue()
        {
           if (Count == 0)
           {
                throw new InvalidOperationException("Empty queue!!!");
            }
            else
            {
                Node<T>oldHead= head;
                T valueHead = oldHead.Item;
                head = oldHead.Next;
                oldHead.Previos = null;
                oldHead.Next = null;
                Count--;
                return valueHead;


            }

        }

        public void Enqueue(T item)
        {
            Node<T> node = new Node<T>(item);
            if (Count == 0)
            {
                head= node;
                tail= node;
            }
            else
            {
                head.Next = node;
                node.Previos= head;
                tail = node;
            }
            Count++;
        }

        public T Peek()=> this.head.Item;
      

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> cuurentNode = this.head;
            while (cuurentNode != null)
            {
                 yield return cuurentNode.Item;
                 this.Dequeue();
            }

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
    }
}