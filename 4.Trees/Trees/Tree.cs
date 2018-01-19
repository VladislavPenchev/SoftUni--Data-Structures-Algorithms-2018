using System;
using System.Collections.Generic;

public class Tree<T>
{
    private List<Tree<T>> children;
    private T value;

    public Tree(T value, params Tree<T>[] children)
    {
        this.children = new List<Tree<T>>();
        this.value = value;
    }

    public void Print(int indent = 0)
    {
        var root = this;
        this.PrintTree(indent,root);
    }

    private void PrintTree(int indent,Tree<T> node)
    {
        Console.WriteLine("{0}{1}",new string(' ',indent),node.value);
        foreach (var child in node.children)
        {
            PrintTree(indent + 1, child);
        }

    }

    public void Each(Action<T> action)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> OrderDFS()
    {
        throw new NotImplementedException();
    }




    public IEnumerable<T> OrderBFS()
    {
        throw new NotImplementedException();
    }
}
