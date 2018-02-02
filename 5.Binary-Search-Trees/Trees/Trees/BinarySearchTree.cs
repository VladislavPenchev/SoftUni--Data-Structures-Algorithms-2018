using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    public Node root;

    public BinarySearchTree()
    {
        this.root = null;       
    }
    

    public void Insert(T value)
    {
        if (this.root == null)
        {
            this.root = new Node(value);
            return; // test without return
        }

        Node current = this.root;
        Node parent = null;

        while(current != null)
        {
            if (current.Value.CompareTo(value) > 0)
            {
                //current.Value > value
                //current.Value -> exist in tree
                //value -> element to insert

                parent = current;
                current = current.Left;
            }
            else if (current.Value.CompareTo(value) < 0)
            {
                parent = current;
                current = current.Right;
            }
            else
            {
                return;
            }
        }

        Node newNode = new Node(value);

        if (parent.Value.CompareTo(value) > 0)
        {
            parent.Left = newNode;
        }
        else if (parent.Value.CompareTo(value) < 0)
        {
            parent.Right = newNode;
        }



    }

    public bool Contains(T value)
    {
        throw new NotImplementedException();
    }

    public void DeleteMin()
    {
        throw new NotImplementedException();
    }

    public BinarySearchTree<T> Search(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        throw new NotImplementedException();
    }

    public void EachInOrder(Action<T> action)
    {
        throw new NotImplementedException();
    }

    public class Node
    {
               
        public Node(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public T Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }


    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
        BinarySearchTree<int> BST = new BinarySearchTree<int>();

        BST.Insert(5);
        BST.Insert(4);
        BST.Insert(6);
        BST.Insert(3);

    }
}
