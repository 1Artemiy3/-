using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Book
{
    public string AuthorFullName { get; set; }
    public string Title { get; set; }
    public int PublicationYear { get; set; }
    public int TotalCopies { get; set; }
    public int TakenCopies { get; set; }

    public Book(string authorFullName, string title, int publicationYear, int totalCopies, int takenCopies)
    {
        AuthorFullName = authorFullName;
        Title = title;
        PublicationYear = publicationYear;
        TotalCopies = totalCopies;
        TakenCopies = takenCopies;
    }
}