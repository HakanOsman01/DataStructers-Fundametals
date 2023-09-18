namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        public Tree(T key, params Tree<T>[] children)
        {
            this.Key= key;
            this.children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.AddChild(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }
        private List<Tree<T>> children;

        public IReadOnlyCollection<Tree<T>> Children
            =>children.AsReadOnly();
        public void AddChild(Tree<T> child)
        {
            this.children.Add(child);
           
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent= parent;
          
        }

        public string AsString()
        {
            var sb = new StringBuilder();
            int indent = 0;
            this.Dfs(this, sb,indent);
            return sb.ToString().TrimEnd();
        }

        private void Dfs(Tree<T> tree, StringBuilder sb,int indent)
        {
            sb.Append(' ',indent)
                .AppendLine(tree.Key.ToString());
            foreach (var child in tree.children)
            {
                Dfs(child, sb, indent + 2);
            }

           
        }

        public IEnumerable<T> GetInternalKeys()
        {
           var list=new List<T>();
           this.DfsGetInternalNodes(this, list);
           return list;
        }

        private void DfsGetInternalNodes(Tree<T> tree, List<T> list)
        {
            if (tree.children.Count > 0 && tree.Parent!=null)
            {
                list.Add(tree.Key);
            }
            foreach (var child in tree.children)
            {
                DfsGetInternalNodes(child, list);

            }
        }

        public IEnumerable<T> GetLeafKeys()
        {
            return this.GetLeafsWithBfs(tree=>tree.children.Count==0)
                .Select(tree=>tree.Key);
            
        }
        private IEnumerable<Tree<T>> GetLeafsWithBfs(Predicate<Tree<T>>predicate)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<Tree<T>> leafs = new List<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (predicate.Invoke(currentNode))
                {
                    leafs.Add(currentNode);
                }
                foreach (var child in currentNode.children)
                {
                    queue.Enqueue(child);
                }
            }
            return leafs;
        }

        public T GetDeepestKey()
        {

          return this.GetDeepestNode().Key;

        }

        private Tree<T> GetDeepestNode()
        {
           var leafs=this.GetLeafsWithBfs(tree=>tree.children.Count==0);
            Tree<T> deepestNode = null;
            int maxDepth = 0;
            foreach (var leaf in leafs)
            {
                var depth = this.GetDepth(leaf);
                if (depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode= leaf;
                }
           
            }
            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            var tree = leaf;
            while(tree.Parent!=null)
            {
                depth++;
                tree= tree.Parent;
            }
            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            var leafs = this.GetLeafsWithBfs(tree=>tree.children.Count==0);
            int maxDepth = 0;
            IEnumerable<T>longestPath = new List<T>();
        
            foreach (var leaf in leafs)
            {
                List<Tree<T>> pathList = this.GetPathFromLeafToRoot(leaf);
                if(pathList.Count > maxDepth)
                {
                    maxDepth= pathList.Count;
                    longestPath = pathList.Select(p=>p.Key).Reverse();
                }


            }
            return longestPath;

        }

        private List<Tree<T>> GetPathFromLeafToRoot(Tree<T>leaf)
        {
            var tree=leaf;
            List<Tree<T>>path=new List<Tree<T>>();
            while (tree!= null)
            {
                path.Add(tree);
                tree= tree.Parent;
            }
            return path;
           
        }
    }
}
