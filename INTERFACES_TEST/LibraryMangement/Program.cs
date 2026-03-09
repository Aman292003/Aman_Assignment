using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

/* ================= INTERFACES ================= */

public interface IBook
{
    string Title { get; set; }
    string Author { get; set; }
    int CopiesAvailable { get; set; }
}

public interface ILibrary
{
    void AddBook(IBook book);
    void RemoveBook(string title);
    bool BorrowBook(string title);
    void ReturnBook(string title);
    List<IBook> GetAllBooks();
    List<IBook> SearchBooks(string query);
    int GetTotalAvailableCopies();
}



   class Book : IBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int CopiesAvailable { get; set; }

    public Book(string Title , String Author , int CopiesAvailable)
    {
        this.Title = Title;
        this.Author = Author;
        this.CopiesAvailable = CopiesAvailable;
    }
}
   class Library : ILibrary
{
    private List<IBook> list = new List<IBook>();
    public void AddBook(IBook book)
    {
        list.Add(book);
    }
    public void RemoveBook(string title)
    {
        list.RemoveAll(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
    public bool BorrowBook(string title)
    {
        var book = list
            .FirstOrDefault(x =>x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (book == null)
            return false;

        if (book.CopiesAvailable > 0)
        {
            book.CopiesAvailable--;
            return true;
        }

        return false;
    }
    public void ReturnBook(string title)
    {
        var book = list
            .FirstOrDefault(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));


        if (book != null)
        {
            book.CopiesAvailable++;
        }

    }
    public List<IBook> GetAllBooks()
    {
        return list;
    }
    public List<IBook> SearchBooks(string query)
    {
        return list.Where(x => x.Title.Contains(query, StringComparison.OrdinalIgnoreCase)
        || x.Author.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public int GetTotalAvailableCopies()
    {
        return list.Sum(x => x.CopiesAvailable);
    }
}


class Program
{
    static void Main()
    {
        ILibrary library = new Library();

        library.AddBook(new Book("Atomic Habits", "James Clear", 3));
        library.AddBook(new Book("Clean Code", "Robert Martin", 2));
        library.AddBook(new Book("Deep Work", "Cal Newport", 1));
        library.AddBook(new Book("The Alchemist", "Paulo Coelho", 4));

        Console.WriteLine("All Books:");
        foreach (var b in library.GetAllBooks())
        {
            Console.WriteLine($"{b.Title} - {b.Author} ({b.CopiesAvailable})");
        }

        Console.WriteLine("\nBorrowing Clean Code...");
        library.BorrowBook("Clean Code");

        Console.WriteLine("\nSearch Result (Code):");
        var results = library.SearchBooks("Code");
        foreach (var b in results)
        {
            Console.WriteLine(b.Title);
        }

        library.ReturnBook("Clean Code");
        library.RemoveBook("Deep Work");

        Console.WriteLine("\nAfter Updates:");
        foreach (var b in library.GetAllBooks())
        {
            Console.WriteLine(b.Title);
        }

        Console.WriteLine("\nTotal Available Copies:");
        Console.WriteLine(library.GetTotalAvailableCopies());
    }
}