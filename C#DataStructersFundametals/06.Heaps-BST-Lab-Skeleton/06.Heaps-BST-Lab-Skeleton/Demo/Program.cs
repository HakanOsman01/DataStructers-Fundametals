using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Channels;
using _02.BinarySearchTree;
using _03.MaxHeap;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(4);
            binarySearchTree.Insert(2);
            binarySearchTree.Insert(6);
            binarySearchTree.EachInOrder(x=>Console.WriteLine(x));
        }
    }
}