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


class Program
{
    static void Main()
    {
        Book[] books = new Book[]
        {

            new Book("Іван Франко", "Захар Беркут", 1883, 15, 5),
            new Book("Леся Українка", "Лісова пісня", 1911, 20, 8),
            new Book("Михайло Коцюбинський", "Тіні забутих предків", 1912, 12, 4),
            new Book("Тарас Шевченко", "Кобзар", 1840, 25, 10),
            new Book("Іван Франко", "Мій змагання", 1890, 8, 2)
        };
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть послідовність слів для пошуку у назві книги: ");
        string searchQuery = Console.ReadLine().ToLower();

        var filteredBooks = books
            .Where(b => b.Title.ToLower().Contains(searchQuery))
            .OrderByDescending(b => b.TotalCopies);

        Console.WriteLine("\nРезультати пошуку (сортування за спаданням кількості екземплярів):");
        foreach (var book in filteredBooks)
        {
            Console.WriteLine($"Автор: {book.AuthorFullName}");
            Console.WriteLine($"Назва: {book.Title}");
            Console.WriteLine($"Рік видання: {book.PublicationYear}");
            Console.WriteLine($"Кількість екземплярів: {book.TotalCopies}");
            Console.WriteLine($"Кількість узятих екземплярів: {book.TakenCopies}");
            Console.WriteLine($"Можна взяти: {book.TotalCopies - book.TakenCopies}");
            Console.WriteLine("---------------------");
        }
    }
}
