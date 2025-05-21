/* 
 Створіть лямбда-вирази:
− для підрахунку кількості чисел у масиві, кратних семи;
− для підрахунку кількості позитивних чисел у масиві;
− для перевірки, чи є заданий день днем програміста (256 день року);
− для перевірки тексту на наявність заданого слова/масиву слів.
Напишіть код для тестування роботи побудованих лямбд.
*/
using System;
using System.Linq;
using System.Collections.Generic;

namespace LB8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine("Лабораторна робота: Лямбда-вирази");
            Console.WriteLine("-----------------------------");

            // Масив для тестування
            int[] numbers = { -14, 7, 28, 0, -5, 21, 14, 35, 42, -21 };

            // 1. Підрахунок кількості чисел у масиві, кратних семи
            Func<int[], int> countDivisibleBySeven = arr => arr.Count(x => x % 7 == 0);

            // 2. Підрахунок кількості позитивних чисел у масиві
            Func<int[], int> countPositive = arr => arr.Count(x => x > 0);

            // 3. Перевірка, чи є заданий день днем програміста (256 день року)
            Func<DateTime, bool> isProgrammersDay = date => date.DayOfYear == 256;

            // 4. Перевірка тексту на наявність заданого слова/масиву слів
            Func<string, string, bool> containsWord = (text, word) =>
                text.ToLower().Split(new char[] { ' ', ',', '.', '!', '?', ':', ';', '-', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries)
                .Contains(word.ToLower());

            Func<string, string[], bool> containsAnyWord = (text, words) =>
                words.Any(word => containsWord(text, word));

            // Тестування лямбд
            Console.WriteLine("\nТестування лямбд:");

            // Тестування 1: підрахунок чисел, кратних 7
            Console.WriteLine($"Масив: {string.Join(", ", numbers)}");
            Console.WriteLine($"Кількість чисел, кратних 7: {countDivisibleBySeven(numbers)}");

            // Тестування 2: підрахунок позитивних чисел
            Console.WriteLine($"Кількість позитивних чисел: {countPositive(numbers)}");

            // Тестування 3: перевірка дня програміста
            DateTime programmersDay2023 = new DateTime(2025, 9, 13); 
            DateTime randomDay = new DateTime(2025, 10, 1);
            Console.WriteLine($"Чи є {programmersDay2023.ToShortDateString()} днем програміста? {isProgrammersDay(programmersDay2023)}");
            Console.WriteLine($"Чи є {randomDay.ToShortDateString()} днем програміста? {isProgrammersDay(randomDay)}");

            // Тестування 4: перевірка наявності слів у тексті
            string testText = "C# - це об'єктно-орієнтована мова програмування з безпечною системою типізації.";
            string word = "програмування";
            string[] wordsArray = { "Python", "мова", "Java" };

            Console.WriteLine($"\nТекст: \"{testText}\"");
            Console.WriteLine($"Чи містить текст слово \"{word}\"? {containsWord(testText, word)}");
            Console.WriteLine($"Чи містить текст будь-яке слово з масиву? {containsAnyWord(testText, wordsArray)}");

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}