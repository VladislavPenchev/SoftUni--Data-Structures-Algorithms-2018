using System;

public class ArrayList<T>
{
    private T[] arr;

    public ArrayList(int capacity = 2)
    {
        this.arr = new T[Capacity]; //initialisation the array
    }

    public int Capacity { get; set; }

    public int Count { get; set; }

    public T this[int index]
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }

    public void Add(T item)
    {
        throw new NotImplementedException();
    }

    public T RemoveAt(int index)
    {
        throw new NotImplementedException();
    }
}
