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
                this.Value = value;

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
            var searchNode = this.FindNode(element);
            if (searchNode == null)
            {
                return false;
            }
            return true;

        }

        public void EachInOrder(Action<T> action)
        {
           this.EachInOrder(action,this.root);
        }

        public void Insert(T element)
        {
            this.root=this.Insert(this.root,element);
           
        }

        private Node Insert(Node node, T element)
        {
           
               if (node == null)
               {
                  node = new Node(element);

               }
           
                if(element.CompareTo(node.Value) < 0)
                {
                    node.Left=this.Insert(node.Left,element);
                }
                if (element.CompareTo(node.Value) > 0)
                {
                    node.Right=this.Insert(node.Right,element);
                }
               
            return node;
        }

        private Node FindNode(T element)
        {
            var node= this.root;
            
            while (node != null)
            {
                if (element.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else if (element.CompareTo(node.Value) > 0)
                {
                    node = node.Right;
                }
                else
                {
                   
                    break;
                }


            }
            return node;
        }
        private BinarySearchTree(Node node)
        {
            this.PreOrderCopy(node);
        }

        private void PreOrderCopy(Node node)
        {
          if(node == null)
          {
                return;
          }
            this.Insert(node.Value);
            this.PreOrderCopy(node.Left);
            this.PreOrderCopy(node.Right);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            var node=this.FindNode(element);
            if (node == null)
            {
                return null;
            }
            return new BinarySearchTree<T>(node);

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
