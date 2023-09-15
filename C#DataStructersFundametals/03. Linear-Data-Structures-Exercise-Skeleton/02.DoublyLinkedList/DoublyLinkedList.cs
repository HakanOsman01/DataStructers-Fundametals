namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> node = new Node<T>(item);
            if (Count == 0)
            {
                this.head = this.tail = node;
            }
            else
            {
                this.head.Next = node;
                node.Previos = this.head;
                this.head = node;

            }
            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> node = new Node<T>(item);
            if (Count == 0)
            {
                this.head = this.tail = node;
            }
            else
            {
                this.tail.Next = node;
                node.Previos=this.tail;
                this.tail = node;

            }
            Count++;
        }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("DoubleLinkedList is Empty");
            }
            return this.head.Item;
        }

        public T GetLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("DoubleLinkedList is Empty");
            }
            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("DoubleLinkedList is Empty");
            }
            var oldHead = this.head;
            T OldHeadValue = oldHead.Item;
            this.head = head.Previos;
            this.head.Next = null;
            oldHead.Previos = null;
            Count--;
            return OldHeadValue;

        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("DoubleLinkedList is Empty");
            }
            var oldTail = this.tail;
            T oldTailValue=oldTail.Item;
            this.tail = oldTail.Previos;
            this.tail.Next = null;
            oldTail.Previos = null;
            
            Count--;
            return oldTailValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Item;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();
       
    }
}