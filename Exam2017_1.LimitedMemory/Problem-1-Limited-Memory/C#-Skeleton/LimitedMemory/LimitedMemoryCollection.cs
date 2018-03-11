using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;

namespace LimitedMemory
{
    public class LimitedMemoryCollection<K, V> : ILimitedMemoryCollection<K, V>
    {
        private LinkedList<Pair<K, V>> _priority;
        private Dictionary<K, LinkedListNode<Pair<K, V>>> _elements;
        

        public LimitedMemoryCollection(int capacity)
        {
            this.Capacity = capacity;
            this._priority = new LinkedList<Pair<K, V>>();
            this._elements = new Dictionary<K, LinkedListNode<Pair<K, V>>>();
        } 

        public int Capacity
        {
            get;
            private set;
        }

        public int Count
        {
            get
            {
                return this._elements.Count;
            }
        }

        public void Set(K key, V value)
        {
            if (!this._elements.ContainsKey(key))
            {
                if (this.Capacity <= this.Count)
                {
                    this.RemoveOldestElement();
                }
                this.AddElement(key,value);
            }
            else
            {
                var node = this._elements[key];
                this._priority.Remove(node);
                node.Value.Value = value;
                this._priority.AddFirst(node);
            }
        }
        
        private void AddElement(K key,V value)
        {
            LinkedListNode<Pair<K, V>> node = new LinkedListNode<Pair<K, V>>(new Pair<K, V>(key,value));
            this._elements.Add(key, node);
            this._priority.AddFirst(node);

        }

        private void RemoveOldestElement()
        {
            var node = this._priority.Last;
            this._elements.Remove(node.Value.Key);
            this._priority.RemoveLast();
        }

        public V Get(K key)
        {
            if (!this._elements.ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            var node = this._elements[key];

            this._priority.Remove(node);
            this._priority.AddFirst(node);
            return node.Value.Value;
            
        }

        public IEnumerator<Pair<K, V>> GetEnumerator()
        {
            foreach (var node in this._priority)
            {
                yield return node;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
