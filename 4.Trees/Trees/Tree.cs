using System;
using System.Collections.Generic;

public class Tree<T>
{
    private List<Tree<T>> children;
    private T value;

    public Tree(T value, params Tree<T>[] children)
    {
        this.children = new List<Tree<T>>(children);
        this.value = value;
    }

    public void Print(int indent = 0)
    {
        var root = this;
        this.PrintTree(indent,this);
    }

    private void PrintTree(int indent,Tree<T> node)
    {
        Console.WriteLine("{0}{1}",new string(' ',indent),node.value);

        foreach (var child in node.children)
        {
            child.Print(indent + 1);
        }

    }

    public void Each(Action<T> action)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> OrderDFS()
    {
        List<T> result = new List<T>();

        this.DFS(this, result);

        return result;
    }

    private void DFS(Tree<T> node ,List<T> result)
    {
        foreach (var child in node.children)
        {
            this.DFS(child, result);
        }
        result.Add(node.value);
    }



    public IEnumerable<T> OrderBFS()
    {
        throw new NotImplementedException();
    }
}
