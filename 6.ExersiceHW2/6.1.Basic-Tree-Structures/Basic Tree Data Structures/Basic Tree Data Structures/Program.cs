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

            //Console.WriteLine("Root node: {0}", FindRootNode().Value);
            //PrintTree();
            //FindAllLeafNodes();
            FindMiddleNodes();
        }

        private static Tree<int> FindRootNode()
        {
            return tree.Values.Where(x => x.Parent == null).First();
        }

        private static void PrintTree()
        {
            Tree<int> root = FindRootNode();

            Print(root, 0);
        }

        private static void Print(Tree<int> node, int indent = 0)
        {
            Console.WriteLine(new string(' ',indent) + node.Value);
            foreach (var child in node.Children)
            {
                Print(child, indent + 2); 
            }

        }

        private static void FindAllLeafNodes()
        {
            List<int> saveLeafs = new List<int>();

            foreach (var leaf in tree.Values)
            {
                if (leaf.Children.Count == 0)
                {
                    saveLeafs.Add(leaf.Value);
                }                
            }

            saveLeafs.Sort();
            
            
                Console.Write("Leaf nodes: " + string.Join(" ", saveLeafs));
                Console.WriteLine();            
        }

        private static void FindMiddleNodes()
        {
            List<int> middleNodes = tree.Values
                                  .Where(x => x.Children.Count != 0 && x.Parent != null)
                                  .Select(x => x.Value)
                                  .OrderBy(x => x)
                                  .ToList();

            Console.WriteLine("Middle nodes: " + string.Join(" ", middleNodes));
        }
    }
}
