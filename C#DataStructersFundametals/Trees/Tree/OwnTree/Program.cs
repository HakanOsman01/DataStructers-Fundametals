using System.ComponentModel.Design;

namespace OwnTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Node<int> root = new Node<int>(7
              , new Node<int>(19,
              new Node<int>(1),
              new Node<int>(12),
              new Node<int>(31))
              , new Node<int>(21), new Node<int>(14, new Node<int>(23)
              , new Node<int>(6)));
            Console.WriteLine(root.Value);
            
            Tree<int>tree = new Tree<int>(root);
            List<Node<int>> bfs =tree.BFS();
            foreach (var children in bfs)
            {
                Console.Write($"{children.Value} ");
            }
            tree.DFS(tree.Root,0);


        }
    }
}