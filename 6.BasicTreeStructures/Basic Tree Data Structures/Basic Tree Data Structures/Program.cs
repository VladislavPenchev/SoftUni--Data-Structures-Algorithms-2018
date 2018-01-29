namespace Basic_Tree_Data_Structures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T>
    {
        public Tree(T value, Tree<T> parent)
        {
            this.Value = value;
            this.Parent = parent;
            this.Children = new List<Tree<T>>();
        }

        public T Value { get; set; }
        public Tree<T> Parent { get; set;}
        public List<Tree<T>> Children { get; set; }
    }

    public class Program
    {
        public static Dictionary<int, Tree<int>> tree = new Dictionary<int, Tree<int>>();

        static void Main(string[] args)
        {
            int numberOfNodes = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                List<int> nodes = Console
                                    .ReadLine()
                                    .Split()
                                    .Select(int.Parse)
                                    .ToList();

                int parent = nodes[0];
                int child = nodes[1];
                if (!tree.ContainsKey(parent))
                {
                    tree.Add(parent,new Tree<int>(parent,null));
                }
                tree.Add(child, new Tree<int>(child, tree[parent]));
                tree[parent].Children.Add(tree[child]);
            }


        }
    }
}
