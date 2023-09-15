namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>>childrens;
        private T Value;
        private Tree<T> parent;
        public Tree(T value)
        {
            this.Value = value;
            this.childrens = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.childrens.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parentNode = this.FindParentKeyWithBFS(parentKey);
            if(parentNode !=null)
            {

                parentNode.childrens.Add(child);
                child.parent = parentNode;
            }
            else
            {
                throw new ArgumentNullException();
            }


        }

        private Tree<T> FindParentKeyWithBFS(T parentKey)
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {

                Tree<T> tree = queue.Dequeue();
                if (tree.Value.Equals(parentKey))
                {
                    return tree;
                }
                if (tree.childrens.Count == 0)
                {
                    continue;
                }
                foreach (var child in tree.childrens)
                {
                    queue.Enqueue(child);

                }
            }
            return null;
            
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            List<T>treeValues= new List<T>();
            treeValues.Add(Value);

            while (queue.Count > 0)
            {
               
                Tree<T> tree = queue.Dequeue();
                if(tree.childrens.Count == 0)
                {
                    continue;
                }

                
               
                foreach (var child in tree.childrens)
                {
                    queue.Enqueue(child);
                    treeValues.Add(child.Value);
                }
              


            }
            return treeValues;
        }

        public IEnumerable<T> OrderDfs()
        {
            var result=new Stack<T>();
            var stack=new Stack<Tree<T>>();
            stack.Push(this);
            while(stack.Count > 0)
            {
                var node=stack.Pop();
                foreach (var child in node.childrens)
                {
                    stack.Push(child);
                }
                result.Push(node.Value);
            }
         
            return result;

            
            
        }

        public void RemoveNode(T nodeKey)
        {
            if (this.Value.Equals(nodeKey))
            {
                throw new ArgumentException();

            }
            var searchNode=this.FindParentKeyWithBFS(nodeKey);
            if (searchNode == null)
            {
                throw new ArgumentNullException();

            }
            
            searchNode.childrens.Clear();
            this.childrens.Remove(searchNode);
            



        }

        public void Swap(T firstKey, T secondKey)
        {
            var searchFirstKey = this.FindParentKeyWithBFS(firstKey);
            var searchSecondKey = this.FindParentKeyWithBFS(secondKey);
            if (searchFirstKey is null || searchSecondKey is null)
            {
                throw new ArgumentNullException();
            }
            var firstParent = searchFirstKey.parent;
            var secondParent = searchSecondKey.parent;
            if(firstParent is null || secondParent is null)
            {
                throw new ArgumentException();
            }
            var indexOfFirstChildren = firstParent.childrens.IndexOf(searchFirstKey);

            var indeOfSecondClidren=searchFirstKey.childrens.IndexOf(searchSecondKey);

            firstParent.childrens[indexOfFirstChildren] = searchSecondKey;

            secondParent.parent= firstParent;

            secondParent.childrens[indeOfSecondClidren] = searchFirstKey;

            firstParent.parent=secondParent;

        }
    }
}
