
namespace Tree
{
    public class Tree<T>
    {
        public Node<T> Root{ get; set; }
        public void DFS(Node<T>node,int level)
        {
            //Console.Write(new string(' ',level));
            foreach (var child in node.Children)
            {
                DFS(child,level+3);
            }
            Console.Write($"{node} ");
        }
        public List<Node<T>> BFS(Node<T>root)
        {
            List<Node<T>>list= new List<Node<T>>();

            Queue<Node<T>>queue= new Queue<Node<T>>();
            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();
                list.Add(node);
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
            return list;
        }

       

    }
}
