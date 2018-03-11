using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Chainblock : IChainblock
{
    private Dictionary<int, Transaction> transactions = new Dictionary<int, Transaction>();

    public int Count => this.transactions.Count;

    public void Add(Transaction tx)
    {
        transactions.Add(tx.Id, tx);
    }

    public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
    {
        if (!transactions.ContainsKey(id))
        {
            throw new ArgumentException();
        }
        ////vzemane na transakciq ot dic
        Transaction tran = transactions[id];
        tran.Status = newStatus;        
    }

    public void RemoveTransactionById(int id)
    {
        if (!transactions.ContainsKey(id))
        {
            throw new InvalidOperationException();
        }
        transactions.Remove(id);
    }

    public bool Contains(Transaction tx)
    {
        return transactions.ContainsKey(tx.Id);
    }

    public bool Contains(int id)
    {
        return transactions.ContainsKey(id);
    }

    public Transaction GetById(int id)
    {
        if (!transactions.TryGetValue(id, out Transaction tran))
        {
            throw new InvalidOperationException();
        }
        return tran;
    }

    public IEnumerable<Transaction> GetByTransactionStatus(TransactionStatus status)
    {
        if (!transactions.Values.Where(x => x.Status == status).Any())
        {
            throw new InvalidOperationException();
        }

        return transactions.Values
            .Where(x => x.Status == status)
            .OrderByDescending(x => x.Amount);
    }
    public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
    {
        SortedSet<Transaction> sender = new SortedSet<Transaction>();
        

        var result = transactions.Values.Where(x => x.Status == status).OrderBy(x => x.Amount);
        var result2 = sender.Where()

        return null;
    }

    //****

    public IEnumerable<Transaction> GetAllOrderedByAmountDescendingThenById()
    {
        var result = transactions.Values.OrderByDescending(x => x.Amount)
            .ThenBy(x => x.Id);
        return result;
    }

    public IEnumerable<Transaction> GetBySenderOrderedByAmountDescending(string sender)
    {
        var result = transactions.Values.Where(x => x.From == sender).OrderByDescending(x => x.Amount);
        if (!result.Any())
        {
            throw new InvalidOperationException();
        }
        return result;
    }
    public IEnumerable<Transaction> GetByReceiverOrderedByAmountThenById(string receiver)
    {
        var result = transactions.Values.OrderByDescending(x => x.Amount)
            .ThenBy(x => x.Id);
        if (!result.Any())
        {
            throw new InvalidOperationException();
        }
        return result;
    }
    

    public IEnumerable<Transaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
    {        
        if (!transactions.Values.Any())
        {
            return Enumerable.Empty<Transaction>();
        }
        var result = transactions.Values.Where(x => x.Status == status).OrderByDescending(x => x.Amount)
            .Where(x => amount >= x.Amount);
        return result;
    }

    public IEnumerable<Transaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
    {
        if (!transactions.Values.Any())
        {
            throw new InvalidOperationException();
        }
        var result = transactions.Values.Where(x => x.From == sender).OrderByDescending(x => x.Amount)
            .Where(x => amount <= x.Amount);
        return result;
    }

    public IEnumerable<Transaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
    {
        throw new NotImplementedException();
    }


    public IEnumerable<Transaction> GetAllInAmountRange(double lo, double hi)
    {
        //foreach (var kvp in transactions.Range(minLength, true, maxLength, true))
        //{
        //    foreach (var person in kvp.Value)
        //    {
        //        yield return person;
        //    }
        //}
        return null;
    }
    //------------------------


    public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
    {
        //var result = transactions.Values.Where()
        return null;
    }

        

    public IEnumerator<Transaction> GetEnumerator()
    {
        foreach (var kvp in transactions)
        {
            yield return kvp.Value;
        }
    }



    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

