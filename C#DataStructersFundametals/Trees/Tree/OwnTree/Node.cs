using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnTree
{
    public class Node<T>
    {
        public Node(T item,params Node<T>[]elements)
        {
            this.Value = item;
            foreach (var element in elements)
            {
                this.Children.Add(element);
            }

        }
        public T Value { get; set; }
        public List<Node<T>> Children=new List<Node<T>>();
    }
}
