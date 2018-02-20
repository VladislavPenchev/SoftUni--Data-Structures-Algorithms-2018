namespace Hierarchy.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node _root;
        private Dictionary<T, Node> _nodesByValue;

        public Hierarchy(T root)
        {
            this._root = new Node(root);
            this._nodesByValue = new Dictionary<T, Node>
            {
                {root,this._root }
            };
        }

        public int Count
        {
            get
            {
                return this._nodesByValue.Count;
            }
        }

        public void Add(T parent, T child)
        {
            if (!this._nodesByValue.ContainsKey(parent))
            {
                throw new ArgumentException();
            }

            if (this._nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node parentNode = this._nodesByValue[parent];
            Node childNode = new Node(child, parentNode);

            parentNode.Children.Add(childNode);
            this._nodesByValue.Add(child, childNode);


        }

        public void Remove(T element)
        {
            if (!this._nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            Node current = this._nodesByValue[element];

            if (current.Parent == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var childNode in current.Children)
            {
                childNode.Parent = current.Parent;
                current.Parent.Children.Add(childNode);
            }

            current.Parent.Children.Remove(current);
            this._nodesByValue.Remove(element);

        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this._nodesByValue.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            var parentNode = this._nodesByValue[item];

            return parentNode.Children.Select(x => x.Value);
        }

        public T GetParent(T item)
        {
            if (!this._nodesByValue.ContainsKey(item))
            {
                throw new ArgumentException();
            }

            var childNode = this._nodesByValue[item];

            return childNode.Parent != null ? childNode.Parent.Value : default(T);
        }

        public bool Contains(T value)
        {
            return this._nodesByValue.ContainsKey(value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            List<T> collection = new List<T>();

            foreach (var kvp in this._nodesByValue)
            {
                if (other.Contains(kvp.Key))
                {
                    collection.Add(kvp.Key);
                }
            }

            return collection;
        } 

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node> queue = new Queue<Node>();

            Node current = this._root;
            queue.Enqueue(current);
            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                yield return current.Value;
                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Node
        {
            public Node(T value,Node parent = null)
            {
                this.Parent = parent;
                this.Value = value;
                this.Children = new List<Node>();
            }

            public Node Parent { get; set; }

            public T Value { get; set; }

            public List<Node> Children { get; set; }

        }
    }
}
