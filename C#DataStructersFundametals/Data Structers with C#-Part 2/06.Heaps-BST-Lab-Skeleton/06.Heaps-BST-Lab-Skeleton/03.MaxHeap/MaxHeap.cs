namespace _03.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T> where T : IComparable<T>
    {
        private List<T> heap;
        public MaxHeap()
        {
           this.heap = new List<T>();
        }
        public int Size { get { return heap.Count; } }

        public void Add(T element)
        {
            this.heap.Add(element);
            this.HeapiFyUp(heap.Count-1);
        }

        private void HeapiFyUp(int index)
        {
            if (index == 0)
            {
                return;
            }
            int parentIndex = (index - 1) / 2;
            if (this.heap[index].CompareTo(this.heap[parentIndex])>0) 
            {
                this.Swap(index,parentIndex);
                this.HeapiFyUp(parentIndex);
            }

        }
        private void Swap(int firstIndex,int secondIndex)
        {
            T element = heap[firstIndex];
            heap[firstIndex] = heap[secondIndex];
            heap[secondIndex] = element;
        }

        public T ExtractMax()
        {
            if(this.heap.Count == 0)
            {
                throw new InvalidOperationException();
            }
            T maxElement = this.heap[0];
            this.Swap(0,this.heap.Count-1);
            this.heap.RemoveAt(this.heap.Count - 1);
            this.HeapiFyDown(0);
            return maxElement;
           
        }

        private void HeapiFyDown(int index)
        {
            var leftChildIndex= index *2 + 1;
            var rightChildIndex = index *2 + 2;
            var maxChildIndex = leftChildIndex;
            if (leftChildIndex >= heap.Count)
            {
                return;
            }
            if ( (rightChildIndex<heap.Count) &&
                heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
            {
                maxChildIndex = rightChildIndex;
            }
            if (this.heap[index].CompareTo(this.heap[maxChildIndex]) < 0)
            {
                this.Swap(index, maxChildIndex);
                this.HeapiFyDown(maxChildIndex);
            }
           
        }

        public T Peek()
        {
            if (this.heap.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return this.heap[0];
        }
    }
}
