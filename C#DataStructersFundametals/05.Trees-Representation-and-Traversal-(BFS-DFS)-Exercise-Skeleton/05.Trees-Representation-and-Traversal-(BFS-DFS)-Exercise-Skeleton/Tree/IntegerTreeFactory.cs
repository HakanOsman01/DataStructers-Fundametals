namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (var inputLine in input)
            {
                int[] keys=inputLine.Split(' ').Select(int.Parse).ToArray();
                var parent = keys[0];
                var child = keys[1];
                this.AddEdge(parent, child);
            }
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            throw new NotImplementedException();
        }

        public void AddEdge(int parent, int child)
        {
            throw new NotImplementedException();
        }

        public IntegerTree GetRoot()
        {
            throw new NotImplementedException();
        }
    }
}
