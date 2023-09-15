namespace Problem02.Stack
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Element { get; set; }
        public Node(T value,Node<T> next)
        {
            this.Element = value;
            this.Next = next;
        }
    }
}