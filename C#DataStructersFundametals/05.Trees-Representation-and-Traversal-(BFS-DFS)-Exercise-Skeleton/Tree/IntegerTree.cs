namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {

            var result = new List<List<int>>();
            var currentPath = new LinkedList<int>();
            currentPath.AddFirst(this.Key);
            int currentSum = this.Key;
            this.Dfs(this, result,  currentPath,ref currentSum,sum);
            return result;

        }

        private void Dfs(Tree<int> subTree
            , List<List<int>> result,
            LinkedList<int> currentPath
            ,ref int currentSum,int wantedSum)
        {

            foreach (var child in subTree.Children)
            {
                currentSum += child.Key;
                currentPath.AddLast(child.Key);
                this.Dfs(child, result, currentPath, ref currentSum, wantedSum);
            }
            if (currentSum == wantedSum)
            {
                result.Add(new List<int>(currentPath));
            }
            currentSum -=subTree.Key;
            currentPath.RemoveLast();
          

        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var resulset=new List<Tree<int>>();
            this.DfsSubtrees(this, sum,resulset);
            return resulset;
        }

        private void DfsSubtrees(Tree<int> subtree, int sum, 
             List<Tree<int>>resultset)
        {
            foreach (var child in subtree.Children)
            {
                
                DfsSubtrees(child, sum,resultset);
            }
            List<Tree<int>> result = (List<Tree<int>>)this.Bfs(subtree);
            if (result.Select(t=>t.Key).ToList().Sum()== sum)
            {
                resultset.AddRange(result);
            }


        }

        private IEnumerable<Tree<int>> Bfs(Tree<int> child)
        {
            Queue<Tree<int>>queue=new Queue<Tree<int>>();
            queue.Enqueue(child);
            List<Tree<int>>currentNodesValues=new List<Tree<int>>();
            while(queue.Count > 0)
            {
                Tree<int>currentNode= queue.Dequeue();
                currentNodesValues.Add(currentNode);
                foreach (var currSub in currentNode.Children)
                {
                    queue.Enqueue(currSub);
                }

            }
            return currentNodesValues;
           
        }
    }
}
