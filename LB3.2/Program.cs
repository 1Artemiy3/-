namespace LB3._2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Введіть розмір матриці (n): ");
            int n = int.Parse(Console.ReadLine());

            // Ініціалізація прямокутного масиву
            int[,] matrix = new int[n, n];

            Console.WriteLine("Виберіть спосіб отримання початкових значень:");
            Console.WriteLine("1. Ввести з консолі");
            Console.WriteLine("2. Зчитати з файлу");
            Console.WriteLine("3. Згенерувати випадкові значення");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InputFromConsole(matrix);
                    break;
                case 2:
                    // Реалізувати зчитування з файлу
                    break;
                case 3:
                    GenerateRandom(matrix);
                    break;
                default:
                    Console.WriteLine("Невірний вибір");
                    return;
            }

            // Побудова результатів та сортування рядків матриці
            int[] results = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (matrix[i, i] != 0)
                {
                    // Сума елементів рядка
                    int sumRow = 0;
                    for (int j = 0; j < n; j++)
                    {
                        sumRow += matrix[i, j];
                    }
                    results[i] = sumRow;
                }
                else
                {
                    // Сума абсолютних величин стовпця
                    int sumCol = 0;
                    for (int j = 0; j < n; j++)
                    {
                        sumCol += Math.Abs(matrix[j, i]);
                    }
                    results[i] = sumCol;
                }
            }

            SortRows(matrix);

            // Виведення результатів
            Console.WriteLine("Матриця після сортування рядків:");
            PrintMatrix(matrix);
            Console.WriteLine("Результати:");
            PrintResults(results);
        }

        static void InputFromConsole(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine($"Введіть елементи {i + 1} рядка:");
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = int.Parse(input[j]);
                }
            }
        }

        static void GenerateRandom(int[,] matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rand.Next(-10, 11);
                }
            }
        }

        static void SortRows(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = new int[matrix.GetLength(1)];
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row[j] = matrix[i, j];
                }
                Array.Sort(row);
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        static void PrintResults(int[] results)
        {
            foreach (var item in results)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
 

