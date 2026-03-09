using System;
using System.Collections.Generic;
using System.Linq;

/* =====================================================
   CUSTOM EXCEPTION
===================================================== */

public class LibraryException : Exception
{
    public LibraryException(string msg) : base(msg) { }
}


/* =====================================================
   INTERFACE
===================================================== */

public interface IMember
{
    string MemberId { get; set; }
    string Name { get; set; }
    int BooksBorrowed { get; set; }
    int LateDays { get; set; }

    double CalculatePenalty();
    void Validate();
}


/* =====================================================
   ABSTRACT BASE CLASS
===================================================== */

public abstract class MemberBase : IMember
{
    public string MemberId { get; set; }
    public string Name { get; set; }
    public int BooksBorrowed { get; set; }
    public int LateDays { get; set; }

    // TODO: Implement common validation
    public virtual void Validate()
    {
        // throw LibraryException if:
        // ID or Name empty
        // BooksBorrowed < 0
        // LateDays < 0
        if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(MemberId) || BooksBorrowed<0 || LateDays < 0)
        {
            throw new LibraryException("Invalid Date");
        }

    }

    public abstract double CalculatePenalty();

    public override string ToString()
    {
        return $"{MemberId} - {Name} | Books:{BooksBorrowed} | Late:{LateDays}";
    }
}


/* =====================================================
   MEMBER TYPES
===================================================== */

class RegularMember : MemberBase
{
    // Borrow limit = 3

    public override double CalculatePenalty()
    {
        if (LateDays <= 5)
        {
            return LateDays * 10;
        }
        return LateDays * 20;
        
    }
}


class PremiumMember : MemberBase
{
    public double MembershipFee { get; set; }

    // Borrow limit = 7

    public override double CalculatePenalty()
    {
        if (LateDays > 7)
        {
            return LateDays * 15;
        }
        return 0;
    }
}


/* =====================================================
   ENGINE INTERFACE
===================================================== */

public interface ILibraryEngine
{
    void AddMember(IMember member);
    void BorrowBook(string id);
    void ReturnBook(string id, int lateDays);

    IMember GetMember(string id);

    int GetTotalMembers();
    double GetTotalPenalty();
    List<IMember> GetLateMembers();
    IMember GetHighestPenaltyMember();
    List<IMember> SortByBooksDesc();
}


/* =====================================================
   ENGINE IMPLEMENTATION
===================================================== */

class LibraryEngine : ILibraryEngine
{
    // MUST USE DICTIONARY
    private Dictionary<string, IMember> members =
        new Dictionary<string, IMember>();


    public void AddMember(IMember member)
    {

        member.Validate();
        if (members.ContainsKey(member.MemberId))
        {
            throw new LibraryException("Id already exists");
        }
        members.Add(member.MemberId, member);
        // TODO:
        // Validate member
        // Throw exception if duplicate ID
        // Add to dictionary
    }

    public void BorrowBook(string id)
    {
        // TODO:
        if (!members.ContainsKey(id))
        {
            throw new LibraryException("Id didnot exists");
        }
        var mem = members[id];
        int limit = mem is PremiumMember ? 7 : 3;
        if (members[id].BooksBorrowed < limit)
        {
            members[id].BooksBorrowed++;
        }
        
        // Check member exists
        // Check borrow limit
        // Increase BooksBorrowed
    }

    public void ReturnBook(string id, int lateDays)
    {
        if (!members.ContainsKey(id))
        {
            throw new LibraryException("Id does not exists");
        }
        if (lateDays < 0)
        {
            throw new LibraryException("Late Days cannot be negative");
        }
        members[id].LateDays += lateDays;
        members[id].BooksBorrowed--;


        // TODO:
        // Validate id
        // lateDays cannot be negative
        // Update LateDays
        // Decrease BooksBorrowed
    }

    public IMember GetMember(string id)
    {
        var student = members.Values.FirstOrDefault(x => x.MemberId.Equals(id, StringComparison.OrdinalIgnoreCase));
        if (student == null)
        {
            throw new LibraryException("No member exists");
        }
        // TODO:
        // Case-insensitive search
        // Throw exception if not found
        return student;
    }

    /* ================= LINQ METHODS ================= */

    public int GetTotalMembers()
    {
        // TODO
        return members.Values.Count;
    }

    public double GetTotalPenalty()
    {
        // TODO using LINQ Sum()
        return members.Values.Sum(c=>c.CalculatePenalty());
    }

    public List<IMember> GetLateMembers()
    {
       
        return members.Values.Where(c=>c.LateDays>0).ToList();
    }

    public IMember GetHighestPenaltyMember()
    {
        if (members.Count < 1)
        {
            return null;
        }
        var max = members.Values.Max(x => x.CalculatePenalty());
        return members.Values.First(x => x.CalculatePenalty().Equals(max));
    }

    public List<IMember> SortByBooksDesc()
    {
        
        return members.Values.OrderByDescending(x=>x.BooksBorrowed).ToList();
    }
}


/* =====================================================
   TEST DRIVER (DO NOT MODIFY MUCH)
===================================================== */

class Program
{
    static void Main()
    {
        ILibraryEngine engine = new LibraryEngine();

        Console.WriteLine("===== TEST 1 : Normal Add =====");

        engine.AddMember(new RegularMember
        {
            MemberId = "M1",
            Name = "Aman"
        });

        engine.AddMember(new PremiumMember
        {
            MemberId = "M2",
            Name = "Riya",
            MembershipFee = 10000
        });

        Console.WriteLine("Members added successfully");


        /* ================================================= */
        Console.WriteLine("\n===== TEST 2 : Duplicate ID (EDGE) =====");

        try
        {
            engine.AddMember(new RegularMember
            {
                MemberId = "M1",
                Name = "Duplicate"
            });
        }
        catch (LibraryException ex)
        {
            Console.WriteLine(ex.Message);
        }


        /* ================================================= */
        Console.WriteLine("\n===== TEST 3 : Empty Name (EDGE) =====");

        try
        {
            engine.AddMember(new RegularMember
            {
                MemberId = "M3",
                Name = ""      // ❌ invalid
            });
        }
        catch (LibraryException ex)
        {
            Console.WriteLine(ex.Message);
        }


        /* ================================================= */
        Console.WriteLine("\n===== TEST 4 : Borrow Limit Check =====");

        try
        {
            // Regular limit = 3
            engine.BorrowBook("M1");
            engine.BorrowBook("M1");
            engine.BorrowBook("M1");
            engine.BorrowBook("M1"); // ❌ should fail
        }
        catch (LibraryException ex)
        {
            Console.WriteLine(ex.Message);
        }


        /* ================================================= */
        Console.WriteLine("\n===== TEST 5 : Borrow Non-Existing Member =====");

        try
        {
            engine.BorrowBook("M99");
        }
        catch (LibraryException ex)
        {
            Console.WriteLine(ex.Message);
        }


        /* ================================================= */
        Console.WriteLine("\n===== TEST 6 : Return With Negative LateDays =====");

        try
        {
            engine.ReturnBook("M1", -5);
        }
        catch (LibraryException ex)
        {
            Console.WriteLine(ex.Message);
        }


        /* ================================================= */
        Console.WriteLine("\n===== TEST 7 : Case Insensitive Search =====");

        var member = engine.GetMember("m1"); // lowercase
        Console.WriteLine(member);


        /* ================================================= */
        Console.WriteLine("\n===== TEST 8 : Premium Free Late Window =====");

        engine.BorrowBook("M2");
        engine.ReturnBook("M2", 5); // should give 0 penalty

        Console.WriteLine("Penalty OK");


        /* ================================================= */
        Console.WriteLine("\n===== TEST 9 : LINQ Analytics =====");

        Console.WriteLine("Total Members:");
        Console.WriteLine(engine.GetTotalMembers());

        Console.WriteLine("\nTotal Penalty:");
        Console.WriteLine(engine.GetTotalPenalty());

        Console.WriteLine("\nLate Members:");
        foreach (var m in engine.GetLateMembers())
            Console.WriteLine(m.Name);


        /* ================================================= */
        Console.WriteLine("\n===== TEST 10 : Highest Penalty =====");

        var highest = engine.GetHighestPenaltyMember();
        Console.WriteLine(highest.Name);


        /* ================================================= */
        Console.WriteLine("\n===== TEST 11 : Sorting =====");

        foreach (var m in engine.SortByBooksDesc())
            Console.WriteLine($"{m.Name} -> {m.BooksBorrowed}");


        /* ================================================= */
        Console.WriteLine("\n===== TEST 12 : Empty Engine (HARDEST EDGE) =====");

        ILibraryEngine empty = new LibraryEngine();

        try
        {
            empty.GetHighestPenaltyMember();
        }
        catch
        {
            Console.WriteLine("Handled empty collection safely");
        }


        Console.WriteLine("\nALL EDGE TESTS COMPLETED ✅");
    }
}