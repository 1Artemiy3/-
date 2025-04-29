

namespace LB3._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Оберіть варіант введення даних:");
            Console.WriteLine("1. Ввести з клавіатури");
            Console.WriteLine("2. Ввести з файлу");
            Console.WriteLine("3. Заповнити випадковими числами");

            int choice = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[10];

            switch (choice)
            {
                case 1:
                    FillArrayFromKeyboard(array);
                    break;
                case 2:
                    FillArrayFromFile(array);
                    break;
                case 3:
                    FillArrayWithRandomNumbers(array);
                    break;
                default:
                    Console.WriteLine("Невірний вибір");
                    return;
            }

            Console.WriteLine("Масив:");
            PrintArray(array);

            int maxIndex = FindMaxElementIndex(array);
            int positiveBeforeMax = CountPositiveBeforeMax(array, maxIndex);
            int positiveAfterMax = CountPositiveAfterMax(array, maxIndex);

            Console.WriteLine($"Кількість додатніх елементів до найбільшого: {positiveBeforeMax}");
            Console.WriteLine($"Кількість додатніх елементів після найбільшого: {positiveAfterMax}");

            Console.WriteLine("Вивести результат у файл? (yes/no)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "yes")
            {
                WriteResultToFile(array, maxIndex, positiveBeforeMax, positiveAfterMax);
            }

            Console.ReadKey();
        }

        static void FillArrayFromKeyboard(int[] array)
        {
            Console.WriteLine("Уведіть 10 елементів:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void FillArrayFromFile(int[] array)
        {
            using (StreamReader reader = new StreamReader("input.txt"))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    string line = reader.ReadLine();
                    if (line != null)
                    {
                        array[i] = Convert.ToInt32(line);
                    }
                    else
                    {
                        Console.WriteLine("Файл містить менше даних, ніж очікувалося.");
                        return;
                    }
                }
            }
        }

        static void FillArrayWithRandomNumbers(int[] array)
        {
            Random rnd = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(-100, 101); // Числа від -100 до 100
            }
        }

        static void PrintArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        static int FindMaxElementIndex(int[] array)
        {
            int maxIndex = 0;
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                    maxIndex = i;
                }
            }
            return maxIndex;
        }

        static int CountPositiveBeforeMax(int[] array, int maxIndex)
        {
            int count = 0;
            for (int i = 0; i < maxIndex; i++)
            {
                if (array[i] > 0)
                {
                    count++;
                }
            }
            return count;
        }

        static int CountPositiveAfterMax(int[] array, int maxIndex)
        {
            int count = 0;
            for (int i = maxIndex + 1; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    count++;
                }
            }
            return count;
        }

        static void WriteResultToFile(int[] array, int maxIndex, int positiveBeforeMax, int positiveAfterMax)
        {
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                writer.WriteLine("Масив:");
                foreach (var item in array)
                {
                    writer.Write(item + " ");
                }
                writer.WriteLine();
                writer.WriteLine($"Індекс найбільшого елемента: {maxIndex}");
                writer.WriteLine($"Кількість додатніх елементів до найбільшого: {positiveBeforeMax}");
                writer.WriteLine($"Кількість додатніх елементів після найбільшого: {positiveAfterMax}");
            }
            Console.WriteLine("Результат записано у файл output.txt");
        }
    }
}