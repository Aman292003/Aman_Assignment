using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }


}

public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> list = new List<IFilm>();
    public void AddFilm(IFilm film)
    {
        list.Add(film);
    } 
    public void RemoveFilm(string title)
    {
        list.RemoveAll(x => x.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }
    public List<IFilm> GetFilms()
    {
        return list;
    }
    public List<IFilm> SearchFilms(string query)
    {
        return list.Where(x => x.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || x.Director.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    public int GetTotalFilmCount()
    {
        return list.Count;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        IFilmLibrary filmLibrary = new FilmLibrary();

        // Add films (hardcoded data)
        filmLibrary.AddFilm(new Film { Title = "Avatar", Director = "Cameron", Year = 2009 });
        filmLibrary.AddFilm(new Film { Title = "Inception", Director = "Nolan", Year = 2010 });
        filmLibrary.AddFilm(new Film { Title = "Titanic", Director = "Cameron", Year = 1997 });
        filmLibrary.AddFilm(new Film { Title = "Interstellar", Director = "Nolan", Year = 2014 });

        // Total count
        Console.WriteLine("Total Film Count: " +
                          filmLibrary.GetTotalFilmCount());

        // Search films
        string query = "Cameron";
        Console.WriteLine("\nSearch Results for " + query + ":");

        var searchResults = filmLibrary.SearchFilms(query);

        foreach (var film in searchResults)
        {
            Console.WriteLine($"{film.Title} ({film.Director}, {film.Year})");
        }

        // Remove film
        string title = "Avatar542q3";
        filmLibrary.RemoveFilm(title);

        Console.WriteLine($"\nRemoved Film: {title}");

        // Display all films
        Console.WriteLine("\nAll Films:");
        foreach (var film in filmLibrary.GetFilms())
        {
            Console.WriteLine($"{film.Title} ({film.Director}, {film.Year})");
        }
    }
}