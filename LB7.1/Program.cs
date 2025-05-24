/*
 За основу потрібно взяти класи з ЛР № 5, перші 2 класи (не 
містять масив об’єктів) потрібно оголосити нащадками інтерфейсів IComparable
та ICloneable, та реалізувати методи CompareTo() та Clone().
Для класу (третій класс 5 ЛР), що містить масив об’єктів з л.р. № 5, 
реалізувати наступні інтерфейси:
1. interface IContainer {
//Кількість елементів у контейнері.
int Count { get;}
// Індексатор контейнера.
Object this[ int index ] { get;set;}
// Додати елемент у контейнер.
void Add( TElement element );
// Видалити елемент з контейнеру.
void Delete( TElement element );
}
Якщо під час доступу до індексатора виконується звернення до 
неіснуючого елемента, згенерувати виключення IndexOutOfRangeException.
2. interface IFileContainer: IContainer{
// Зберегти вміст контейнера у текстовий файл.
void Save( String fileName );
// Завантажити дані з текстового файлу до контейнера.
void Load( String fileName );
// Повертає true, якщо дані контейнеру були збережені у файл.
// Повертає false, якщо дані контейнеру не були збережені у файл.
Boolean IsDataSaved {get;}
}
3. Cтандартні інтерфейси IEnumerable, IEnumerator для можливості 
використання циклу foreach для елементів колекції.
Створити декілька об’єктів класу та занести до контейнера. Відсортувати 
об’єкти створеної колекції за допомогою методу Sort(…). Роздрукувати вміст 
контейнеру на екран. Додати об’єкти до контейнеру. Результат зберегти у файл.
Створити новий контейнер, скопіювавши до нього перші 2 або 3 елементи 
відсортованого контейнера. Результат вивести на екран та у файл
*/


using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Демонстрація роботи з контейнером комп'ютерів ===\n");

            // Створюємо контейнер
            ComputerContainer container = new ComputerContainer();

            // Створюємо кілька об'єктів Person
            Person person1 = new Person("Іван", "Петренко", new DateTime(1990, 5, 15));
            Person person2 = new Person("Марія", "Коваленко", new DateTime(1995, 8, 22));
            Person person3 = new Person("Олександр", "Іваненко", new DateTime(1988, 12, 3));

            // Створюємо пристрої
            Device[] devices1 = {
                new Device("Клавіатура", 1500, new DateTime(2023, 1, 10)),
                new Device("Миша", 800, new DateTime(2023, 2, 15))
            };

            Device[] devices2 = {
                new Device("Монітор", 8000, new DateTime(2022, 11, 20)),
                new Device("Принтер", 3500, new DateTime(2023, 3, 5)),
                new Device("Сканер", 2200, new DateTime(2023, 1, 25))
            };

            Device[] devices3 = {
                new Device("Веб-камера", 1200, new DateTime(2023, 4, 10))
            };

            // Створюємо комп'ютери
            Computer comp1 = new Computer(person1, TypeOfWork.Home, "192.168.1.10", devices1);
            Computer comp2 = new Computer(person2, TypeOfWork.Business, "192.168.1.20", devices2);
            Computer comp3 = new Computer(person3, TypeOfWork.Server, "192.168.1.30", devices3);

            // Додаємо комп'ютери до контейнера
            container.Add(comp1);
            container.Add(comp2);
            container.Add(comp3);

            Console.WriteLine("Контейнер до сортування:");
            container.PrintToConsole();

            // Сортуємо контейнер
            container.Sort();
            Console.WriteLine("\nКонтейнер після сортування:");
            container.PrintToConsole();

            // Додаємо ще один комп'ютер
            Person person4 = new Person("Анна", "Сидоренко", new DateTime(1992, 7, 18));
            Device[] devices4 = {
                new Device("Навушники", 600, new DateTime(2023, 5, 12))
            };
            Computer comp4 = new Computer(person4, TypeOfWork.Home, "192.168.1.40", devices4);
            container.Add(comp4);

            Console.WriteLine("\nКонтейнер після додавання нового комп'ютера:");
            container.PrintToConsole();

            // Зберігаємо результат у файл
            string fileName = "computers.txt";
            container.Save(fileName);
            Console.WriteLine($"\nРезультат збережено у файл: {fileName}");
            Console.WriteLine($"Дані збережені: {container.IsDataSaved}");

            // Створюємо новий контейнер, копіюючи перші 2 елементи
            ComputerContainer newContainer = container.CopyFirst(2);
            Console.WriteLine("\nНовий контейнер з копіями перших 2 елементів:");
            newContainer.PrintToConsole();

            // Зберігаємо новий контейнер у файл
            string newFileName = "computers_copy.txt";
            newContainer.Save(newFileName);
            Console.WriteLine($"\nНовий контейнер збережено у файл: {newFileName}");

            
            Console.WriteLine("\nДемонстрація foreach:");
            foreach (Computer computer in container)
            {
                Console.WriteLine($"- {computer.Owner.ToShortString()} ({computer.TypeOfWork})");
            }

            // Демонстрація індексатора з помилкою
            Console.WriteLine("\nДемонстрація обробки помилки індексатора:");
            try
            {
                var wrongAccess = container[10];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Спіймано помилку: {ex.Message}");
            }

            // Демонстрація методів Clone та CompareTo
            Console.WriteLine("\nДемонстрація методів Clone та CompareTo:");
            Person originalPerson = new Person("Артем", "Вадимович", new DateTime(2000, 1, 1));
            Person clonedPerson = (Person)originalPerson.Clone();

            Console.WriteLine($"Оригінал: {originalPerson}");
            Console.WriteLine($"Клон: {clonedPerson}");
            Console.WriteLine($"Порівняння: {originalPerson.CompareTo(clonedPerson)}");

            Console.WriteLine("\n=== Програма завершила роботу ===");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }
}

