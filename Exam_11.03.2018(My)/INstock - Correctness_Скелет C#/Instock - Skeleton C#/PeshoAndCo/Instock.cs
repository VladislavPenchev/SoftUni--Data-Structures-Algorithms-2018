using System;
using System.Collections;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class Instock : IProductStock
{


    private MultiDictionary<string, Product> products = new MultiDictionary<string, Product>(true);
    private List<Product> productsByInsertion = new List<Product>();
    private OrderedDictionary<string, Product> productsByLabel =
        new OrderedDictionary<string, Product>();
    private OrderedDictionary<double, List<Product>> productsInRange =
    new OrderedDictionary<double, List<Product>>();


    public int Count => this.productsByLabel.Count;

    public void Add(Product product)
    {
        products.Add(product.Label, product);
        productsByInsertion.Add(product);
        
        productsByLabel[product.Label] = product;
        

        if (!productsInRange.ContainsKey(product.Price))
        {
            productsInRange.Add(product.Price, new List<Product>());
        }
        productsInRange[product.Price].Add(product);
    }
   
    public bool Contains(Product product)
    {
        if (products.ContainsKey(product.Label))
        {
            return products[product.Label].Contains(product);
        }
        return false;
    }

    public void ChangeQuantity(string product, int quantity)
    {        
        if (!products.ContainsKey(product))
        {
            throw new ArgumentException();
        }
        var producc = products[product];
        foreach (var item in producc)
        {
            item.Quantity = quantity;
        }
        
    }

    public Product Find(int index)
    {
        if (index < 0 || index > this.Count - 1)
        {
            throw new IndexOutOfRangeException();
        }
        return productsByInsertion[index];
    }

    public IEnumerable<Product> FindAllByPrice(double price)
    {
        if (productsInRange.ContainsKey(price))
        {
            return productsInRange[price];
        }
        return Enumerable.Empty<Product>();

        
    }

    public IEnumerable<Product> FindAllByQuantity(int quantity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> FindAllInRange(double lo, double hi)
    {
        //TODO:
        foreach (var kvp in productsInRange.Range(lo, false, hi, true))
        {
            foreach (var product in kvp.Value)
            {

                //if (product == null)
                //{
                //    yield return Enumerable.Empty<Product>();
                //}
                yield return product;                
                
            }
        }
    }

    public Product FindByLabel(string label)
    {
        if (!this.productsByLabel.ContainsKey(label))
        {
            throw new ArgumentException();
        }
        return this.productsByLabel[label];
    }
    

    public IEnumerable<Product> FindFirstByAlphabeticalOrder(int count)
    {
        //TODO: vrushta prazna IEnumerable
        return productsByInsertion.Take(count);
    }

    public IEnumerable<Product> FindFirstMostExpensiveProducts(int count)
    {
        if (productsInRange.Count < 0)
        {
            throw new ArgumentException();
        }
        return null;//productsInRange.Values.Take(count);
    }

    public IEnumerator<Product> GetEnumerator()
    {
        return this.productsByInsertion.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

}
