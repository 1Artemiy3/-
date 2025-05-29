using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Book
{
    public string AuthorFullName { get; set; }
    public string Title { get; set; }
    public int YearPublished { get; set; }
    public int TotalCopies { get; set; }
    public int BorrowedCopies { get; set; }

    public Book() { }

    public Book(string authorFullName, string title, int yearPublished, int totalCopies, int borrowedCopies)
    {
        AuthorFullName = authorFullName;
        Title = title;
        YearPublished = yearPublished;
        TotalCopies = totalCopies;
        BorrowedCopies = borrowedCopies;
    }

    public int AvailableCopies => TotalCopies - BorrowedCopies;
}
