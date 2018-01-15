namespace StartUp
{
    using System;
    using System.Collections.Generic;
    public class StartUpp
    {
        static void Main()
        {
            List<Node<int>> nodeSaves = new List<Node<int>>();

            Node<int> head = new Node<int>();
            Node<int> node1 = new Node<int>();
            Node<int> node2 = new Node<int>();

            head.Next = node1;
            head.Value = 1;
            head.Name = "Head";

            node1.Next = node2;
            node1.Value = 2;
            node1.Name = "Node1";

            node2.Next = null;
            node2.Value = 3;
            node2.Name = "Node2";


            nodeSaves.Add(head);
            nodeSaves.Add(node1);
            nodeSaves.Add(node2);

            foreach (var node in nodeSaves)
            {
                if (node2.Next == null)
                {
                    //Console.WriteLine(head.Next);
                    //Console.WriteLine(head.Value);

                    //Console.WriteLine(node1.Next);
                    //Console.WriteLine(node1.Value);

                    //Console.WriteLine(node2.Next);
                    //Console.WriteLine(node2.Value);

                    Console.WriteLine("Name  -> {2}               REferens-Code ->{0},ValueOfNode -> {1}",node.Next,node.Value,node.Name);
                }
            }

            head = head.Next;
            head.Value = node1.Value;

            nodeSaves.Remove(head);
            Console.WriteLine("-----------------------------------------------------------------");

            foreach (var node in nodeSaves)
            {
                if (node2.Next == null)
                {
                    //Console.WriteLine(head.Next);
                    //Console.WriteLine(head.Value);

                    //Console.WriteLine(node1.Next);
                    //Console.WriteLine(node1.Value);

                    //Console.WriteLine(node2.Next);
                    //Console.WriteLine(node2.Value);
                    Console.WriteLine("Name  -> {2}               REferens-Code ->{0},ValueOfNode -> {1}", node.Next, node.Value, node.Name);

                }
            }


            if (nodeSaves.Count == 2)
            {

            }
        }
    }
}

class Node<T>
{
    public string Name { get; set; }
    public T Value { get; set; }

    public Node<T> Next { get; set; }
}