/*
 Користувач уводить шлях до файлу та відображає 
статистичну інформацію про файл: кількість речень; кількість великих літер;
кількість маленьких літер; кількість голосних літер; кількість приголосних 
літер; кількість цифр.
*/

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть шлях до файлу:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не знайдено. Перевірте шлях і спробуйте ще раз.");
            return;
        }

        string content = File.ReadAllText(filePath);

        int sentenceCount = content.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        int uppercaseCount = content.Count(char.IsUpper);
        int lowercaseCount = content.Count(char.IsLower);
        int vowelCount = content.Count(c => "AEIOUaeiou".Contains(c));
        int consonantCount = content.Count(c => char.IsLetter(c) && !"AEIOUaeiou".Contains(c));
        int digitCount = content.Count(char.IsDigit);

        Console.WriteLine("Статистична інформація про файл:");
        Console.WriteLine($"Кількість речень: {sentenceCount}");
        Console.WriteLine($"Кількість великих літер: {uppercaseCount}");
        Console.WriteLine($"Кількість маленьких літер: {lowercaseCount}");
        Console.WriteLine($"Кількість голосних літер: {vowelCount}");
        Console.WriteLine($"Кількість приголосних літер: {consonantCount}");
        Console.WriteLine($"Кількість цифр: {digitCount}");
    }
}