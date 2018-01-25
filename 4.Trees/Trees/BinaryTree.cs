using System;

public class BinaryTree<T>
{

    public T Value { get; set; }

    public BinaryTree<T> Left { get; set; }

    public BinaryTree<T> Rigth { get; set; }

    public BinaryTree(T value, BinaryTree<T> leftChild = null, BinaryTree<T> rightChild = null)
    {
        this.Value = value;
        this.Left = leftChild;
        this.Rigth = rightChild;
    }

    public void PrintIndentedPreOrder(int indent = 0)
    {
        this.PrintIndentedPreOrder(this, indent);
    }

    private void PrintIndentedPreOrder(BinaryTree<T> node , int indent)
    {
        if (node == null)
        {
            return;
        }
        Console.WriteLine($"{new string(' ',indent)}{node.Value}");
        this.PrintIndentedPreOrder(node.Left,indent + 2);
        this.PrintIndentedPreOrder(node.Rigth, indent + 2);

    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrderRecursive(this, action);
    }

    private void EachInOrderRecursive(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrderRecursive(node.Left,action);
        action(node.Value);
        this.EachInOrderRecursive(node.Rigth, action);
    }
    

    public void EachPostOrder(Action<T> action)
    {
        this.EachPostOrder(this,action);
    }

    private void EachPostOrder(BinaryTree<T> node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachPostOrder(node.Left, action);
        this.EachPostOrder(node.Rigth, action);
        action(node.Value);
    }
}
