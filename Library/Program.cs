using System;
using System.Collections.Generic;

/* ================= INTERFACES ================= */

public interface IBook
{
    string Title { get; set; }
    string Author { get; set; }
    int Pages { get; set; }
}

public interface ILibrary
{
    void AddBook(IBook book);
    void RemoveBook(string title);
    List<IBook> GetAllBooks();
    List<IBook> SearchBooks(string keyword);
    int GetBookCount();
    int GetTotalPages();
}



class Book : IBook {
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }

    public Book(string Title, string Author , int Pages)
    {
        this.Title = Title;
        this.Author = Author;
        this.Pages = Pages;
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
        list.RemoveAll(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public List<IBook> GetAllBooks()
    {
        return list;
    }
    public List<IBook> SearchBooks(string keyword)
    {
        return list.Where(s => s.Title.Contains(keyword)||s.Author.Contains(keyword)).ToList();
    }
    public int GetBookCount()
    {
        return list.Count;
    }
    public int GetTotalPages()
    {
        return list.Sum(s => s.Pages);
    }
}


/* ================= MAIN FUNCTION ================= */

class Program
{
    static void Main(string[] args)
    {
        ILibrary library = new Library();

        library.AddBook(new Book("Atomic Habits", "James Clear", 320));
        library.AddBook(new Book("Clean Code", "Robert Martin", 450));
        library.AddBook(new Book("The Alchemist", "Paulo Coelho", 200));
        library.AddBook(new Book("Deep Work", "Cal Newport", 300));

        Console.WriteLine("Total Books:");
        Console.WriteLine(library.GetBookCount());

        Console.WriteLine("\nAll Books:");
        foreach (var b in library.GetAllBooks())
        {
            Console.WriteLine($"{b.Title} - {b.Author} ({b.Pages} pages)");
        }

        Console.WriteLine("\nSearch Result (Code):");
        var results = library.SearchBooks("Code");

        foreach (var b in results)
        {
            Console.WriteLine(b.Title);
        }

        library.RemoveBook("The Alchemist");

        Console.WriteLine("\nAfter Removing:");
        foreach (var b in library.GetAllBooks())
        {
            Console.WriteLine(b.Title);
        }

        Console.WriteLine("\nTotal Pages:");
        Console.WriteLine(library.GetTotalPages());
    }
}