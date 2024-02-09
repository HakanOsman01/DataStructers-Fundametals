namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;
        private T value;
        private Tree<T> parent;
        public Tree(T value)
        {
            this.value = value;
            this.children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindNodeWithBfs(parentKey);
            if (parentNode == null)
            {
                throw new ArgumentNullException();
            }
            parentNode.children.Add(child);
            child.parent = parentNode;
        }

        private Tree<T> FindNodeWithBfs(T parentKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (parentKey.Equals(subtree.value))
                {
                    return subtree;
                }
                result.Add(subtree.value);
                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return null;
            

        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                result.Add(subtree.value);
                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;


        }
        private void Dfs(Tree<T>node,ICollection<T>result)
        {
           
            foreach (var child in node.children)
            {
                this.Dfs(child, result);
            }
            result.Add(node.value);

        }
        public IEnumerable<T> OrderDfs()
        {
            var result = new List<T>();
            this.Dfs(this,result);
            return result;

        }
        //Solution with iteration
        //public IEnumerable<T> OrderDfs()
        //{
        //    var result = new Stack<T>();
        //    var stack = new Stack<Tree<T>>();
        //    stack.Push(this);
        //    while (stack.Count > 0)
        //    {
        //        var subtree = stack.Pop();
        //        foreach (var child in subtree.children)
        //        {
        //            stack.Push(child);
        //        }
        //        result.Push(subtree.Value);

        //    }
        //    return result;
        //}

        public void RemoveNode(T nodeKey)
        {
           var toBeDeletedNode=FindNodeWithBfs(nodeKey);
            if(toBeDeletedNode is null)
            {
                throw new ArgumentNullException();
            }

            var parentNode = toBeDeletedNode.parent;
            if(parentNode is null)
            {
                throw new ArgumentException();
            }
            parentNode.children.Remove(toBeDeletedNode);
            toBeDeletedNode.parent = null;

        }

        

        public void Swap(T firstKey, T secondKey)
        {
           var firstNode=FindNodeWithBfs(firstKey);
           var secondNode=FindNodeWithBfs(secondKey);
           if(firstNode is null || secondNode is null)
           {
                throw new ArgumentNullException();
           }
           var firstParentNode=firstNode.parent;
           var secondParentNode=secondNode.parent;
           
           if (firstParentNode is null || secondParentNode is null)
           {
                throw new ArgumentException();
           }
             
           var indexOfFirstChild=firstParentNode.children.IndexOf(firstNode);
           var indexOfSecondChild=secondParentNode.children.IndexOf(secondNode);
            firstParentNode.children[indexOfFirstChild] 
                = secondNode;
            secondNode.parent= firstParentNode;

            secondParentNode.children[indexOfSecondChild]=firstNode;
            firstNode.parent= secondParentNode;
        }
        public IEnumerable<T> GetLeafs()
        {

            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subtree = queue.Dequeue();
                if (subtree.children.Count == 0)
                {
                    result.Add(subtree.value);
                }
                foreach (var child in subtree.children)
                {
                    queue.Enqueue(child);
                }
            }
            return result;
        }
    }
}
