/*
Створіть додаток «Цензор». Користувач уводить шляхи до 
двох файлів: з текстом та зі словами, що потрібно заштрихувати або видалити з 
тексту. Результатом роботи є текст, у якому усі небажані слова у тексті файлу
мають бути замінені на "*", кількість яких відповідає кількості символів у 
знайденому небезпечному слові.
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CensorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            Console.WriteLine("=== Додаток 'Цензор' ===");
            Console.WriteLine();

            try
            {
                // Отримуємо шляхи до файлів від користувача
                Console.Write("Введіть шлях до файлу з текстом: ");
                string textFilePath = Console.ReadLine();

                Console.Write("Введіть шлях до файлу зі словами для цензури: ");
                string wordsFilePath = Console.ReadLine();

                // Перевіряємо чи існують файли
                if (!File.Exists(textFilePath))
                {
                    Console.WriteLine($"Файл '{textFilePath}' не знайдено!");
                    return;
                }

                if (!File.Exists(wordsFilePath))
                {
                    Console.WriteLine($"Файл '{wordsFilePath}' не знайдено!");
                    return;
                }

                // Читаємо вміст файлів
                string originalText = File.ReadAllText(textFilePath);
                string[] forbiddenWords = File.ReadAllLines(wordsFilePath)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToArray();

                Console.WriteLine("\n--- Оригінальний текст ---");
                Console.WriteLine(originalText);

                // Виконуємо цензуру
                string censoredText = CensorText(originalText, forbiddenWords);

                Console.WriteLine("\n--- Зацензурований текст ---");
                Console.WriteLine(censoredText);

                // Зберігаємо результат у новий файл
                string outputPath = "censored_" + Path.GetFileName(textFilePath);
                File.WriteAllText(outputPath, censoredText);
                Console.WriteLine($"\nРезультат збережено у файл: {outputPath}");

                // Показуємо статистику
                ShowStatistics(originalText, censoredText, forbiddenWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }

        static string CensorText(string text, string[] forbiddenWords)
        {
            string result = text;

            foreach (string word in forbiddenWords)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                // Створюємо регулярний вираз для пошуку слова (ігноруємо регістр)
                string pattern = @"\b" + Regex.Escape(word.Trim()) + @"\b";

                // Замінюємо знайдені слова на зірочки
                result = Regex.Replace(result, pattern, match => new string('*', match.Value.Length),
                                     RegexOptions.IgnoreCase);
            }

            return result;
        }

        static void ShowStatistics(string originalText, string censoredText, string[] forbiddenWords)
        {
            Console.WriteLine("\n--- Статистика ---");

            int censoredWordsCount = 0;
            List<string> foundWords = new List<string>();

            foreach (string word in forbiddenWords)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;

                string pattern = @"\b" + Regex.Escape(word.Trim()) + @"\b";
                MatchCollection matches = Regex.Matches(originalText, pattern, RegexOptions.IgnoreCase);

                if (matches.Count > 0)
                {
                    censoredWordsCount += matches.Count;
                    foundWords.Add($"{word.Trim()} ({matches.Count} раз)");
                }
            }

            Console.WriteLine($"Загальна кількість зацензурованих слів: {censoredWordsCount}");
            Console.WriteLine($"Знайдені заборонені слова:");

            if (foundWords.Any())
            {
                foreach (string wordInfo in foundWords)
                {
                    Console.WriteLine($"  - {wordInfo}");
                }
            }
            else
            {
                Console.WriteLine("  Заборонених слів не знайдено");
            }
        }
    }
}