using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> _heap;

    public BinaryHeap()
    {
        this._heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return this._heap.Count;
        }
    }

    public void Insert(T item)
    {
        this._heap.Add(item);

        this.HeapifyUp(item, this._heap.Count - 1);

        //this.HeapifyUpInteractive(this._heap.Count - 1);
        
    }

    private void HeapifyUp(T item, int index)
    {
        int parentIndex = (index - 1) / 2;
        

        int compare = this._heap[parentIndex].CompareTo(this._heap[index]);

        //parenta e po - maluk ot childa, childa - trqbva da otide na mqstoto na parenta
        if (compare < 0)
        {
            this.Swap(parentIndex,index);

            this.HeapifyUp(this._heap[parentIndex],parentIndex);
        }
    }

    private void HeapifyUpInteractive(int index)
    {
        int childIndex = index;
        T element = this._heap[childIndex];
        int parentIndex = (childIndex - 1) / 2;
        int compareOutput = this._heap[parentIndex].CompareTo(element);

        while (parentIndex >= 0 && compareOutput < 0)
        {
            this.Swap(parentIndex, index);

            childIndex = parentIndex;

            parentIndex = (parentIndex - 1) / 2;

            compareOutput = this._heap[parentIndex].CompareTo(this._heap[index]);

            if (parentIndex == childIndex)
            {
                break;
            }
            

        }
    }

    private void Swap(int parent, int index)
    { 
        T temp = this._heap[parent];
        this._heap[parent] = this._heap[index];
        this._heap[index] = temp;
    }

    public T Peek()
    {
        if (this._heap.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return this._heap[0];
    }

    public T Pull()
    {
        if (this._heap.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T firstElement = this._heap[0];
        this.Swap(0,this._heap.Count - 1);
        this._heap.RemoveAt(this._heap.Count - 1);
        this.HeapifyDown(firstElement,0);

        return firstElement;
    }

    private void HeapifyDown(T element,int index)
    {
        int parentIndex = index;
       
        while (parentIndex < this.Count / 2)
        {
            int childIndex = (2 * parentIndex) + 1;

            if (childIndex + 1 < this.Count && IsGreater(childIndex, childIndex + 1))
            {
                //Rigth child
                childIndex += 1;
            }

            int compare = this._heap[parentIndex].CompareTo(this._heap[childIndex]);

            if (compare < 0 )
            {
                this.Swap(childIndex, parentIndex);
                parentIndex = childIndex;
            }

        }
        
    }

    private bool IsGreater(int left, int rigth)
    {
        return this._heap[left].CompareTo(this._heap[rigth]) < 0;
    }
}
