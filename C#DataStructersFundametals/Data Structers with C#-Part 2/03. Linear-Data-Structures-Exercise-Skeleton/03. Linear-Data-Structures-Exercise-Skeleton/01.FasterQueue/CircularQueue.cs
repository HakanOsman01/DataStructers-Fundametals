namespace Problem01.CircularQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CircularQueue<T> : IAbstractQueue<T>
    {
        private T[] elements;
        private const int DEFAULT_CAPACITY = 4;
        private int startIndex;
        private int endIndex;
        public CircularQueue()
            :this(DEFAULT_CAPACITY)
        {
            this.elements = new T[DEFAULT_CAPACITY];
        }
        public CircularQueue(int capacity)
        {
            if(capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this.elements = new T[capacity];
        }
        public int Count { get;private set; }

        public T Dequeue()
        {
            throw new NotImplementedException();
            
        }

        public void Enqueue(T item)
        {
            if (this.Count >= this.elements.Length)
            {
                this.Grow();
            }
            this.elements[this.endIndex] = item;
            this.endIndex=(this.endIndex+1)%this.elements.Length;
            this.Count++;
        }

        private void Grow()
        {
            this.elements = this.CopyElements();
            this.startIndex = 0;
            this.endIndex = this.Count;
        }

        private T[] CopyElements()
        {
            var newArr= new T[this.elements.Length*2];
         
            for (int i = 0; i < this.Count; i++)
            {
                newArr[i] = this.elements[(this.startIndex+i)%this.elements.Length];
                
            }
            return newArr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                int index =(startIndex+i)%this.elements.Length;
                yield return this.elements[index];
            }   
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public T Peek()
        {
           if(this.Count == 0)
           {
                throw new InvalidOperationException();
           }
           return this.elements[this.startIndex];
        }

        public T[] ToArray()
        {
            throw new NotImplementedException();
        }

        
       
    }

}
