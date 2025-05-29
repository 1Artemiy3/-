/*
 Створити користувацький тип даних class, що має характеристики 
відповідно до індивідуального завдання. Створити масив екземплярів 
оголошеного класу. Серіалізувати та десериалізувати створений масив даних у 
різних форматах. Виконати роботу з об’єктами створеного типу даних 
відповідно до запиту, що описано в індивідуальному завданн
Визначити КЛАС «КНИГА» з полями: ПІБ автора; назва книги; рік 
видання; кількість екземплярів цієї книги в бібліотеці; кількість узятих 
екземплярів цієї книги. Створити масив об’єктів типу «КНИГА». Вивести на 
екран інформацію про книги, у назві яких існує введена послідовність слів, які 
можна узяти для читання, відсортовані у порядку зменшення кількості 
єкземплярів
 */
using System;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Book[] books = new Book[]
        {
            new Book("Іван Франко", "Захар Беркут", 1883, 15, 5),
            new Book("Леся Українка", "Лісова пісня", 1911, 20, 8),
            new Book("Михайло Коцюбинський", "Тіні забутих предків", 1912, 12, 4),
            new Book("Тарас Шевченко", "Кобзар", 1840, 25, 10),
            new Book("Іван Франко", "Мій змагання", 1890, 8, 2)
        };

        string jsonPath = "books.json";
        File.WriteAllText(jsonPath, JsonSerializer.Serialize(books));

        Book[] booksFromJson = JsonSerializer.Deserialize<Book[]>(File.ReadAllText(jsonPath));

       
        string xmlPath = "books.xml";
        using (var fs = new FileStream(xmlPath, FileMode.Create))
        {
            var xmlSer = new XmlSerializer(typeof(Book[]));
            xmlSer.Serialize(fs, books);
        }

        
        Book[] booksFromXml;
        using (var fs = new FileStream(xmlPath, FileMode.Open))
        {
            var xmlSer = new XmlSerializer(typeof(Book[]));
            booksFromXml = (Book[])xmlSer.Deserialize(fs);
        }

        
        Console.Write("Введіть назву: ");
        string search = Console.ReadLine()?.Trim() ?? "";

        
        var availableBooks = booksFromJson
            .Where(b => b.Title.Contains(search, StringComparison.OrdinalIgnoreCase) && b.AvailableCopies > 0)
            .OrderByDescending(b => b.AvailableCopies)
            .ToList();

        
        Console.WriteLine("\nКниги, доступні для читання:");
        foreach (var book in availableBooks)
        {
            Console.WriteLine($"Author: {book.AuthorFullName}, Title: {book.Title}, Year: {book.YearPublished}, Available: {book.AvailableCopies}");
        }
    }
}


