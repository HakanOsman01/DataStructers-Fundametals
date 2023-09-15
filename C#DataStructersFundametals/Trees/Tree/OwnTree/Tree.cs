

namespace OwnTree
{
    public class Tree<T>
    {
        public Tree(Node<T>root)
        {
            this.Root = root;
            
        }
        public Node<T> Root { get; set; }
        public List<Node<T>> BFS()
        {
            List<Node<T>>list = new List<Node<T>>();
            Queue<Node<T>>queue=new Queue<Node<T>>();
            queue.Enqueue(Root);
            while (queue.Count>0)
            {
                Node<T> element = queue.Dequeue();
                list.Add(element);
                foreach (var node in element.Children)
                {
                    queue.Enqueue(node);
                }
               


            }
            return list;

        }
        public void DFS(Node<T> node, int level)
        {
            //Console.Write(new string(' ',level));
            foreach (var child in node.Children)
            {
                DFS(child, level + 3);
            }
            Console.Write($"{node} ");
        }
    }
}
