namespace Problem03.Queue
{
    public class Node<T>
    {
        public T Element { get; set; }
        public Node<T> Next { get; set; }
        public Node(T element) 
        {
            this.Element = element;
            //this.Next = next;

        }


    }
}