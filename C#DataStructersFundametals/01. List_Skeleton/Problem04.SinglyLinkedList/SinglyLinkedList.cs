namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;   

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> node = new Node<T>(item);
            if(Count == 0)
            {
                this.head = this.tail = node;
            }
            else
            {
                this.head.Next = node;
                this.head=node;
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
                //var oldTail = this.tail;
                tail.Next = node;
                this.tail=node;
            }
            Count++;
        }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("LinkedList emprty");
            }
            return this.head.Value;
        }

        public T GetLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("LinkedList emprty");
            }
            return this.tail.Value;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The LinkedList is empty");
            }
            var oldHead=this.head;
            this.head = oldHead.Next;
            Count--;
            return oldHead.Value;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The LinkedList is empty");
            }
            var oldTail = this.tail;
            this.tail = oldTail.Next;
            Count--;
            return oldTail.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentHead = this.head;
            while (currentHead != null)
            {
                yield return currentHead.Value;
                currentHead = currentHead.Next;
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}