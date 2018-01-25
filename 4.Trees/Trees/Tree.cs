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
        this.PrintTree(indent,root);
    }

    private void PrintTree(int indent,Tree<T> node)
    {
        Console.WriteLine($"{new string(' ',indent)}{node.value}");

        foreach (Tree<T> child in node.children)
        {
            //child.Print(indent + 1);
            PrintTree(indent + 2,child);
        }

    }

    public void Each(Action<T> action)
    {
        action(this.value);
        foreach (var child in this.children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        //recursive implementation
        List<T> result = new List<T>();

        this.DFS(this, result);

        return result;


        //interactive implementation
        //List<T> result = new List<T>();
        //Stack<Tree<T>> stack = new Stack<Tree<T>>();

        //stack.Push(this);

        //while (stack.Count > 0)
        //{
        //    Tree<T> currentNode = stack.Pop();
        //    foreach (Tree<T> child in currentNode.children)
        //    {
        //        stack.Push(child);
        //    }
        //    result.Add(currentNode.value);
        //}

        //return result ;

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
        Queue<Tree<T>> queue = new Queue<Tree<T>>();
        List<T> result = new List<T>();

        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            Tree<T> current = queue.Dequeue();
            result.Add(current.value);

            foreach (Tree<T> child in current.children)
            {
                queue.Enqueue(child);
            }
        }

        return result;

    }
}
