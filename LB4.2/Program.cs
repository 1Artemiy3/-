

namespace LB4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Тестовий масив рядків довільної довжини
            string[] testLines = { "1","2","3","4","5","6" };

            // Запис тестового масиву у файл test1.txt за допомогою StreamWriter
            using (StreamWriter writer = new StreamWriter("test1.txt"))
            {
                foreach (string line in testLines)
                {
                    writer.WriteLine(line);
                }
            }

            // Зчитування тексту з файлу test1.txt за допомогою StreamReader
            string[] lines;
            using (StreamReader reader = new StreamReader("test1.txt"))
            {
                var linesList = new System.Collections.Generic.List<string>();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    linesList.Add(line);
                }
                lines = linesList.ToArray();
            }

            // Обчислення середньої довжини рядків
            int averageLength = (int)lines.Average(line => line.Length);

            // Створення нового масиву рядків однакової довжини
            string[] resultLines = lines.Select(line => AdjustLineLength(line, averageLength)).ToArray();

            // Виведення результату на екран
            Console.WriteLine("Результуючий масив рядків:");
            foreach (string line in resultLines)
            {
                Console.WriteLine(line);
            }

            // Запис результату у файл result.txt 
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                foreach (string line in resultLines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Результат збережено у файл result.txt.");
        }

        // Метод для зміни довжини рядка до заданої довжини
        static string AdjustLineLength(string line, int targetLength)
        {
            if (line.Length == targetLength)
            {
                return line;
            }
            else if (line.Length < targetLength)
            {
                // Доповнюємо рядок пробілами до потрібної довжини
                return line.PadRight(targetLength);
            }
            else
            {
                // Обрізаємо рядок до потрібної довжини
                return line.Substring(0, targetLength);
            }
        }
    }
}
