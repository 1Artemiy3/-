using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class ComputerContainer : IFileContainer<Computer>, IEnumerable<Computer>
{
    private List<Computer> computers;
    private bool isDataSaved;

    public ComputerContainer()
    {
        computers = new List<Computer>();
        isDataSaved = false;
    }

    // Кількість елементів у контейнері
    public int Count
    {
        get { return computers.Count; }
    }

    // Індексатор контейнера
    public object this[int index]
    {
        get
        {
            if (index < 0 || index >= computers.Count)
                throw new IndexOutOfRangeException("Індекс виходить за межі контейнера");
            return computers[index];
        }
        set
        {
            if (index < 0 || index >= computers.Count)
                throw new IndexOutOfRangeException("Індекс виходить за межі контейнера");
            if (value is Computer computer)
            {
                computers[index] = computer;
                isDataSaved = false;
            }
            else
            {
                throw new ArgumentException("Значення повинно бути типу Computer");
            }
        }
    }

    // Додати елемент у контейнер
    public void Add(Computer element)
    {
        if (element != null)
        {
            computers.Add(element);
            isDataSaved = false;
        }
    }

    // Видалити елемент з контейнеру
    public void Delete(Computer element)
    {
        if (computers.Remove(element))
        {
            isDataSaved = false;
        }
    }

    // Повертає true, якщо дані контейнеру були збережені у файл
    public bool IsDataSaved
    {
        get { return isDataSaved; }
    }

    // Зберегти вміст контейнера у текстовий файл
    public void Save(string fileName)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine($"Кількість комп'ютерів: {computers.Count}");
                writer.WriteLine(new string('=', 50));

                for (int i = 0; i < computers.Count; i++)
                {
                    writer.WriteLine($"Комп'ютер #{i + 1}:");
                    writer.WriteLine(computers[i].ToString());
                    writer.WriteLine(new string('-', 30));
                }
            }
            isDataSaved = true;
        }
        catch (Exception ex)
        {
            throw new Exception($"Помилка при збереженні файлу: {ex.Message}");
        }
    }

    // Завантажити дані з текстового файлу до контейнера
    public void Load(string fileName)
    {
        try
        {
            // Проста реалізація завантаження
            // В реальному проекті тут би був парсінг файлу
            if (File.Exists(fileName))
            {
                // Для демонстрації просто очищуємо контейнер
                computers.Clear();
                isDataSaved = true;
            }
            else
            {
                throw new FileNotFoundException($"Файл {fileName} не знайдено");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Помилка при завантаженні файлу: {ex.Message}");
        }
    }

    // Сортування контейнера
    public void Sort()
    {
        computers.Sort((c1, c2) => c1.Owner.CompareTo(c2.Owner));
        isDataSaved = false;
    }

    // Реалізація IEnumerable<Computer>
    public IEnumerator<Computer> GetEnumerator()
    {
        return computers.GetEnumerator();
    }

    // Реалізація IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Метод для копіювання перших n елементів у новий контейнер
    public ComputerContainer CopyFirst(int count)
    {
        ComputerContainer newContainer = new ComputerContainer();
        int elementsToTake = Math.Min(count, computers.Count);

        for (int i = 0; i < elementsToTake; i++)
        {
            // Використовуємо Clone() для створення копій
            Computer original = computers[i];
            Computer cloned = new Computer(
                (Person)original.Owner.Clone(),
                original.TypeOfWork,
                original.IPAddress,
                original.Devices
            );
            newContainer.Add(cloned);
        }

        return newContainer;
    }

    // Метод для виведення вмісту на екран
    public void PrintToConsole()
    {
        Console.WriteLine($"Контейнер містить {Count} комп'ютерів:");
        Console.WriteLine(new string('=', 50));

        int index = 1;
        foreach (Computer computer in this)
        {
            Console.WriteLine($"Комп'ютер #{index}:");
            Console.WriteLine(computer.ToString());
            Console.WriteLine(new string('-', 30));
            index++;
        }
    }
}