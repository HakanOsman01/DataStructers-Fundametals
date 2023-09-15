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
            items=new T[DEFAULT_CAPACITY];
        }

        public List(int capacity)
            
        {
            if(capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            items= new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (!IsIndexOutOfRange(index))
                {
                   throw new IndexOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (!IsIndexOutOfRange(index))
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == items.Length)
            {
                Grow();
            }
            items[Count]= item;
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


        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }


        public void Insert(int index, T item)
        {
            if (!IsIndexOutOfRange(index))
            {
                throw new IndexOutOfRangeException();
            }
           
            if (Count >= items.Length)
            {
                Grow();
            }

            for (int i = Count-1; i >=index ;i--)
            {
                items[i + 1] = items[i];
                
            }
            items[index] = item;
            Count++;

        }

        public bool Remove(T item)
        {
            if (Count <= items.Length / 4)
            {
                Shrink();
            }
            for (int i = 0; i < Count; i++)
            {
                if (items[i].Equals(item))
                {
                    for (int j = i; j < Count; j++)
                    {
                        items[j] = items[j + 1];

                    }
                    Count--;
                    return true;
                }
            }
            return false;
           
        }

        public void RemoveAt(int index)
        {
            if (!IsIndexOutOfRange(index))
            {
                throw new IndexOutOfRangeException("Invalid index given");
            }
            if (Count <= items.Length / 4)
            {
                Shrink();
            }
            for (int i = index; i < Count; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return items[i];
            }
        }
        private bool IsIndexOutOfRange(int index)
        {
            if(index<0 || index >= Count)
            {
                return false;
            }
            return true;
        }
        private void Grow()
        {
            T[]copy=new T[items.Length*2];
            for (int i = 0; i < items.Length; i++)
            {

                copy[i] = items[i];
            }
            items= copy;
        }
        private void Shrink()
        {
            T[] copy = new T[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }
            items= copy;
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
           
    }
}