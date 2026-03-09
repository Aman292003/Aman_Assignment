using System;
using System.Collections.Generic;
using System.Linq;

/* =====================================================
   CUSTOM EXCEPTION
===================================================== */

public class WalletException : Exception
{
    public WalletException(string msg) : base(msg) { }
}

/* =====================================================
   INTERFACE
===================================================== */

public interface IWalletUser
{
    string UserId { get; set; }
    string Name { get; set; }
    double Balance { get; set; }
    bool IsBlocked { get; set; }

    void Validate();
    void AddMoney(double amount);
    void SpendMoney(double amount);
    double Cashback();
}

/* =====================================================
   ABSTRACT BASE CLASS
===================================================== */

public abstract class WalletUserBase : IWalletUser
{
    public string UserId { get; set; }
    public string Name { get; set; }
    public double Balance { get; set; }
    public bool IsBlocked { get; set; }

    // TODO:
    // id/name empty → exception
    // balance < 0 → exception
    public virtual void Validate()
    {
        if(String.IsNullOrEmpty(UserId)|| String.IsNullOrEmpty(Name)||Balance<0)
        {
            throw new WalletException("Invalid Data");
        }
    }

    // TODO:
    // amount > 0
    // blocked user cannot add money
    public virtual void AddMoney(double amount)
    {
        if (IsBlocked)
        {
            throw new WalletException("User is blocked");
        }
        if (amount < 0 )
        {
            throw new WalletException("Amount is negative");
        }
        Balance += amount;
    }

    // TODO:
    // blocked user cannot spend
    // insufficient balance check
    public virtual void SpendMoney(double amount)
    {
        if (IsBlocked)
        {
            throw new WalletException("User is blocked");
        }
        if (amount > Balance)
        {
            throw new WalletException("Insufficient Funds");
        }
        Balance -= amount;
    }

    public abstract double Cashback();
}

/* =====================================================
   USER TYPES
===================================================== */

class RegularUser : WalletUserBase
{
    // Cashback = 2%
    public override double Cashback()
    {

        return 0.02* Balance;
  }
}

class PremiumUser : WalletUserBase
{
    // Cashback = 5%
    // if balance < 100 → auto block
    public override double Cashback()
    {
        if (Balance < 100)
        {
            IsBlocked = true;
        }
        return 0.05 * Balance;
        
    }
}

/* =====================================================
   ENGINE
===================================================== */

public class WalletEngine
{
    private Dictionary<string, IWalletUser> users =
        new Dictionary<string, IWalletUser>(StringComparer.OrdinalIgnoreCase);

    // TODO: validate + duplicate check
    public void RegisterUser(IWalletUser user)
    {
        user.Validate();
        if (users.ContainsKey(user.UserId))
        {
            throw new WalletException("Id Already Exists");
        }
        users.Add(user.UserId, user);
    }

    // TODO: search user (case insensitive)
    public IWalletUser GetUser(string id)
    {
        var user = users.Values.FirstOrDefault(x => x.UserId.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (user == null)
        {
            throw new WalletException("No User is found");
        }
        return user;
    }

    // TODO: add money
    public void Credit(string id, double amount)
    {
        var user = users.Values.FirstOrDefault(x => x.UserId.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (user == null)
        {
            throw new WalletException("No User is found");
        }
        user.AddMoney(amount);
    }

    // TODO: spend money
    public void Debit(string id, double amount)
    {
        var user = users.Values.FirstOrDefault(x => x.UserId.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (user == null)
        {
            throw new WalletException("No User is found");
        }
        user.SpendMoney(amount);
    }

    /* ================= LINQ ================= */

    // total system balance
    public double GetTotalBalance()
    {
        return users.Values.Sum(x => x.Balance);
    }

    // richest user
    public IWalletUser GetRichestUser()
    {
        if (users.Count < 1)
        {
            throw new WalletException("No User is found");
        }
        return users.Values.OrderByDescending(x => x.Balance).First();
       
    }

    // blocked users
    public List<IWalletUser> GetBlockedUsers()
    {
        return users.Values.Where(x=>x.IsBlocked==true).ToList();
    }

    // users above given balance
    public List<IWalletUser> GetUsersAboveBalance(double amount)
    {
        return users.Values.Where(x=>x.Balance>amount).ToList();
    }

    // sort by cashback descending
    public List<IWalletUser> SortByCashback()
    {
        return users.Values.OrderByDescending(x => x.Cashback()).ToList();
    }
}

/* =====================================================
   MAIN FUNCTION (HARD TEST CASES)
===================================================== */

class Program
{
    static void Main()
    {
        WalletEngine engine = new WalletEngine();

        Console.WriteLine("===== TEST 1 : Registration =====");

        engine.RegisterUser(new RegularUser
        {
            UserId = "U1",
            Name = "Aman",
            Balance = 500
        });

        engine.RegisterUser(new PremiumUser
        {
            UserId = "P1",
            Name = "Riya",
            Balance = 1000
        });

        Console.WriteLine("Users Registered");


        /* ================= EDGE CASES ================= */

        Console.WriteLine("\nTEST 2 : Duplicate User");
        try
        {
            engine.RegisterUser(new RegularUser
            {
                UserId = "u1",
                Name = "Duplicate",
                Balance = 200
            });
        }
        catch (WalletException ex)
        {
            Console.WriteLine(ex.Message);
        }


        Console.WriteLine("\nTEST 3 : Credit & Debit");

        engine.Credit("U1", 300);
        engine.Debit("P1", 950); // premium rule trigger


        Console.WriteLine("\nTEST 4 : Insufficient Balance");
        try
        {
            engine.Debit("U1", 5000);
        }
        catch (WalletException ex)
        {
            Console.WriteLine(ex.Message);
        }


        Console.WriteLine("\nTEST 5 : Case Insensitive Search");
        Console.WriteLine(engine.GetUser("u1").Name);


        Console.WriteLine("\nTEST 6 : LINQ Analytics");

        Console.WriteLine("Total Balance:");
        Console.WriteLine(engine.GetTotalBalance());

        Console.WriteLine("\nRichest User:");
        Console.WriteLine(engine.GetRichestUser().Name);

        Console.WriteLine("\nBlocked Users:");
        foreach (var u in engine.GetBlockedUsers())
            Console.WriteLine(u.Name);

        Console.WriteLine("\nUsers Above Balance 200:");
        foreach (var u in engine.GetUsersAboveBalance(200))
            Console.WriteLine(u.Name);

        Console.WriteLine("\nSorted By Cashback:");
        foreach (var u in engine.SortByCashback())
            Console.WriteLine($"{u.Name} -> {u.Cashback()}");


        Console.WriteLine("\nTEST 7 : Unknown User");
        try
        {
            engine.Debit("XX", 100);
        }
        catch (WalletException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("\nALL TESTS COMPLETED ✅");
    }
}