namespace _02.BinarySearchTree
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class BinarySearchTree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T value)
            {

            }
            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
        private Node root;
        public BinarySearchTree() 
        {

        }

        public bool Contains(T element)
        {
            throw new NotImplementedException();
        }

        public void EachInOrder(Action<T> action)
        {
           this.EachInOrder(action,this.root);
        }

        public void Insert(T element)
        {
           
        }

        public IBinarySearchTree<T> Search(T element)
        {
            throw new NotImplementedException();
        }
        private void EachInOrder(Action<T>action,Node node)
        {

            if(node == null)
            {
                return;
            }
            this.EachInOrder(action, node.Left);
            action.Invoke(node.Value);
            this.EachInOrder(action,node.Right);
        }
    }
}
