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
                throw new InvalidOperationException();
            }

            if (this._nodesByValue.ContainsKey(child))
            {
                throw new InvalidOperationException();
            }

            Node parentNode = this._nodesByValue[parent];
            Node childNode = new Node(child, parentNode);

            parentNode.Children.Add(childNode);
            this._nodesByValue.Add(child, childNode);


        }

        public void Remove(T element)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetChildren(T item)
        {
            if (!this._nodesByValue.ContainsKey(item))
            {
                throw new InvalidOperationException();
            }

            var parentNode = this._nodesByValue[item];

            return parentNode.Children.Select(x => x.Value);
        }

        public T GetParent(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            throw new NotImplementedException();
        } 

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
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
