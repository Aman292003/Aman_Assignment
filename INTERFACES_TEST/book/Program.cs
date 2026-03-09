using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using static System.Net.WebRequestMethods;

#region Exception

public class LibraryException : Exception
{
    public LibraryException(string msg) : base(msg) { }
}

#endregion


#region Interfaces

public interface IBook
{
    string BookId { get; set; }
    string Title { get; set; }
    string Author { get; set; }
    bool IsBorrowed { get; set; }
    int BorrowCount { get; set; }

    void Validate();
}

public interface IMember
{
    string MemberId { get; set; }
    string Name { get; set; }
    int BorrowedBooks { get; set; }

    void Validate();
}

public interface ILibraryService
{
    void AddBook(IBook book);
    void RegisterMember(IMember member);

    void BorrowBook(string memberId, string bookId);
    void ReturnBook(string memberId, string bookId);

    List<IBook> GetMostPopularBooks(int n);

    List<IBook> FilterBooks(Predicate<IBook> condition);

    Dictionary<string, int> AuthorBorrowStats();

    IBook GetMostBorrowedBook();

    int TotalBorrowedBooks();
}

#endregion


#region Classes (YOU IMPLEMENT INTERFACES)

public class Book : IBook
{
    public string BookId { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsBorrowed { get; set; }
    public int BorrowCount { get; set; }

    public void Validate()
    {
        if (String.IsNullOrEmpty(BookId)|| String.IsNullOrEmpty(Title)||String.IsNullOrEmpty(Author)){
            throw new LibraryException("Incomplete Details");
        }
        if (BorrowCount < 0)
        {
            throw new LibraryException("minimum Value for borrow book is 0");
        }
    }
}

public class Member : IMember
{
    public string MemberId { get; set; }
    public string Name { get; set; }
    public int BorrowedBooks { get; set; }

    public void Validate()
    {
        if (String.IsNullOrEmpty(MemberId) || String.IsNullOrEmpty(Name) )
        {
            throw new LibraryException("Incomplete Details");
        }
    }
}

#endregion


#region Library Engine

public class Library : ILibraryService
{
    private Dictionary<string, IBook> books =
        new Dictionary<string, IBook>(StringComparer.OrdinalIgnoreCase);

    private Dictionary<string, IMember> members =
        new Dictionary<string, IMember>(StringComparer.OrdinalIgnoreCase);

   
    /* ===== Delegate & Event ===== */

    public delegate void LibraryNotification(string msg);

    public event LibraryNotification Notify;

    public void AddBook(IBook book)
    {
        
        book.Validate();
        if (books.ContainsKey(book.BookId))
        {
            throw new LibraryException("Book already exists");

        }
        books.Add(book.BookId, book);
        Notify?.Invoke(book.BookId + "is added");

    }

    public void RegisterMember(IMember member)
    {
        member.Validate();
        if (members.ContainsKey(member.MemberId))
        {
            throw new LibraryException("Book already exists");

        }
        members.Add(member.MemberId,member);
        Notify?.Invoke(member.MemberId + "is added");
    }

    public void BorrowBook(string memberId, string bookId)
    {
        if (!books.ContainsKey(bookId))
        {
            throw new LibraryException("Book doesnot exists");
        }
        if (!members.ContainsKey(memberId))
        {
            throw new LibraryException("member doesnot exists");
        }
        var book = books[bookId];
        var member = members[memberId];

        book.IsBorrowed = true;
        book.BorrowCount++;
        member.BorrowedBooks++;
        Notify?.Invoke(member.MemberId + "is taken  the" + book.BookId);
        
    }

    public void ReturnBook(string memberId, string bookId)
    {
        if (!books.ContainsKey(bookId))
        {
            throw new LibraryException("Book doesnot exists");
        }
        if (!members.ContainsKey(memberId))
        {
            throw new LibraryException("member doesnot exists");
        }
        var book = books[bookId];
        var member = members[memberId];
        if (!book.IsBorrowed)
        {
            throw new LibraryException("Book was not borrowed");
        }
        book.IsBorrowed = false;
        book.BorrowCount--;
        member.BorrowedBooks--;
        Notify?.Invoke(member.MemberId + "is returning the " + book.BookId);
    }

    public List<IBook> GetMostPopularBooks(int n)
    {
        // TODO
        return books.Values.OrderByDescending(x => x.BorrowCount).Take(n).ToList();
    }

    public List<IBook> FilterBooks(Predicate<IBook> condition)
    {
        // TODO
        return books.Values.Where(x=>condition(x)).ToList();
    }

    public Dictionary<string, int> AuthorBorrowStats()
    {
        // TODO
        return books.Values.GroupBy(x => x.Author).ToDictionary(x => x.Key, x => x.Count());
    }

    public IBook GetMostBorrowedBook()
    {
        return books.Values.OrderByDescending(x => x.BorrowCount).FirstOrDefault();
        

    }

    public int TotalBorrowedBooks()
    {
        // TODO
        return books.Values.Sum(X => X.BorrowCount);
    }
}

#endregion


#region MAIN (TEST CASES)

class Program
{
    static void Main()
    {
        Library lib = new Library();

        lib.Notify += msg => Console.WriteLine("EVENT: " + msg);

        try
        {
            lib.AddBook(new Book { BookId = "B1", Title = "AI", Author = "Andrew" });
            lib.AddBook(new Book { BookId = "B2", Title = "ML", Author = "Andrew" });
            lib.AddBook(new Book { BookId = "B3", Title = "C#", Author = "Microsoft" });

            lib.RegisterMember(new Member { MemberId = "M1", Name = "Aman" });
            lib.RegisterMember(new Member { MemberId = "M2", Name = "Riya" });

            lib.BorrowBook("M1", "B1");
            lib.BorrowBook("M1", "B2");

            lib.BorrowBook("M2", "B1"); // already borrowed

            lib.ReturnBook("M1", "B1");

            lib.BorrowBook("M2", "B1");

            Console.WriteLine("Most Borrowed Book:");
            Console.WriteLine(lib.GetMostBorrowedBook().Title);

            Console.WriteLine("Total Borrow Count:");
            Console.WriteLine(lib.TotalBorrowedBooks());

            Console.WriteLine("Popular Books:");
            foreach (var b in lib.GetMostPopularBooks(2))
                Console.WriteLine(b.Title);

            Console.WriteLine("Filter Books by Author Andrew:");
            foreach (var b in lib.FilterBooks(x => x.Author == "Andrew"))
                Console.WriteLine(b.Title);

            Console.WriteLine("Author Stats:");
            var stats = lib.AuthorBorrowStats();

            foreach (var s in stats)
                Console.WriteLine(s.Key + " -> " + s.Value);

        }
        catch (LibraryException ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
    }
}

#endregion