namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
            items = new T[DEFAULT_CAPACITY];
        }

        public List(int capacity)
        {
            if(capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (this.IsOutOfRange(index))
                {
                    throw new IndexOutOfRangeException();

                }
                return items[index];
            }
            set
            {
                if (this.IsOutOfRange(index))
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }

        public int Count { get; private set;}

        public void Add(T item)
        {
          
            if(this.Count == this.items.Length)
            {
                Grow();
            }
            this.items[Count] = item;
            Count++;
            
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {

                if (item.Equals(items[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (this.IsOutOfRange(index))
            {
                throw new IndexOutOfRangeException();
            }
           
            if (Count == items.Length)
            {
                Grow();
            }
            for (int i = Count; i > index; i--)
            {
                items[i] = items[i-1];
            }
            items[index] = item;
            this.Count++;   

           
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(items[i]))
                {
                    this.RemoveAt(i);
                   
                    return true;
                }

            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (this.IsOutOfRange(index))
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }

            Count--;
            if (this.Count <= items.Length / 4)
            {
                this.Shrink();
            }
           

        }

        IEnumerator IEnumerable.GetEnumerator()=>GetEnumerator();
        
        private bool IsOutOfRange(int index)
        {
            return index<0 || index >= Count;
        }
        private void Grow()
        {
            T[]copy=new T[items.Length*2];
            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }
            items = copy;

        }
        private void Shrink()
        {
            T[] itemsCopy = new T[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                itemsCopy[i] = items[i];
            }
            items = itemsCopy;
        }
    }
}