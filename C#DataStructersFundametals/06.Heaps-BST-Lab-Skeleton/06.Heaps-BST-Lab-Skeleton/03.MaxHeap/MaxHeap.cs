namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> elements;
        public MaxHeap()
        {
            this.elements = new List<T>();
            
        }
        public int Size =>this.elements.Count;

        public void Add(T element)
        {
           this.elements.Add(element);
            this.HepyfiUp(this.elements.Count-1);
        }

        private void HepyfiUp(int index)
        {
            var parentIndex = (index - 1) / 2;
            while(index > 0 && 
                this.elements[index].CompareTo(this.elements[parentIndex])>0)
            {
                this.Swap(index, parentIndex);
                index=parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void Swap(int index, int parentIndex)
        {
           var swap = this.elements[index];
           this.elements[index] = this.elements[parentIndex];
           this.elements[parentIndex] = swap;
        }

        public T ExtractMax()
        {
            if (this.elements.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T element= this.elements[0];
            this.Swap(0,this.elements.Count-1);
            this.elements.RemoveAt(this.elements.Count - 1);
            this.HepyfiDown(0);
            return element;
        }

        private void HepyfiDown(int index)
        {
            var biggerChildIndex = this.GetBiggerChild(index);
            while (this.IsValidIndex(biggerChildIndex) 
                && this.elements[biggerChildIndex].CompareTo(this.elements[index])>0)
            {
                this.Swap(biggerChildIndex, index);
                
                index=biggerChildIndex;
                biggerChildIndex=this.GetBiggerChild(index);
            }
        }

        private int GetBiggerChild(int index)
        {
            var firstChildIndex = index * 2 + 1;
            var secondChildIndex=index*2 + 2;
            if (secondChildIndex < this.elements.Count)
            {
                if(this.elements[firstChildIndex]
                    .CompareTo(this.elements[secondChildIndex]) > 0)
                {
                    return firstChildIndex;
                }
                return secondChildIndex;
            }
            else if (firstChildIndex < this.elements.Count)
            {
                return firstChildIndex;

            }
            else
            {
                return -1;
            }
        }
        private bool IsValidIndex(int index)
        {
            return index>=0 && index<this.elements.Count;
        }

        public T Peek()
        {
            if (this.elements.Count==0)
            {
                throw new InvalidOperationException();
            }
           return this.elements[0]; 
        }
    }
}
