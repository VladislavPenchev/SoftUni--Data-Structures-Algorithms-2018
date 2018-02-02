using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public void Insert(T item)
    {
        this.heap.Add(item);

        int lastIndex = this.heap.Count - 1;

        int parent = (lastIndex - 1) / 2;

        Swap(parent, lastIndex);
    }

    private void Swap(int parent, int child)
    {
        T parentTemp = this.heap[parent];
        this.heap[parent] = this.heap[child];
        this.heap[child] = parentTemp;
    }

    public T Peek()
    {
        if (this.heap.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return this.heap[0];
    }

    public T Pull()
    {
        throw new NotImplementedException();
    }
}
