

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            // Створення об'єкту типу Computer
            Computer computer = new Computer();

            // Вивід скороченої інформації
            Console.WriteLine("===== Скорочена інформація про комп'ютер =====");
            Console.WriteLine(computer.ToShortString());

            // Вивід значень індексатора
            Console.WriteLine("\n===== Перевірка індексатора =====");
            Console.WriteLine($"TypeOfWork.Home: {computer[TypeOfWork.Home]}");
            Console.WriteLine($"TypeOfWork.Business: {computer[TypeOfWork.Business]}");
            Console.WriteLine($"TypeOfWork.Server: {computer[TypeOfWork.Server]}");

            // Присвоєння значень всім властивостям
            Console.WriteLine("\n===== Присвоєння нових значень =====");
            computer.Owner = new Person("Олександр", "Іваненко", new DateTime(1995, 5, 15));
            computer.TypeOfWork = TypeOfWork.Business;
            computer.IPAddress = "10.0.0.1";

            // Вивід повної інформації
            Console.WriteLine("\n===== Повна інформація про комп'ютер =====");
            Console.WriteLine(computer.ToString());

            // Додавання пристроїв
            Console.WriteLine("\n===== Додавання пристроїв =====");
            Device monitor = new Device("Монітор LG", 5500.50, new DateTime(2023, 3, 10));
            Device keyboard = new Device("Клавіатура Logitech", 1200.99, new DateTime(2023, 1, 15));
            Device mouse = new Device("Миша Logitech", 850.75, new DateTime(2023, 2, 5));

            computer.AddDevices(monitor, keyboard, mouse);

            // Вивід оновленої інформації
            Console.WriteLine("\n===== Оновлена інформація про комп'ютер =====");
            Console.WriteLine(computer.ToString());

            // Створення масиву комп'ютерів
            Console.WriteLine("\n===== Масив комп'ютерів =====");
            Computer[] computers = new Computer[5];

            // Заповнення масиву комп'ютерів
            computers[0] = computer;
            computers[1] = new Computer(
                new Person("Марія", "Петренко", new DateTime(1998, 7, 20)),
                TypeOfWork.Home,
                "192.168.1.1",
                new Device[] { new Device("Принтер HP", 3500.00, new DateTime(2022, 5, 10)) }
            );
            computers[2] = new Computer(
                new Person("Петро", "Сидоренко", new DateTime(1990, 12, 3)),
                TypeOfWork.Server,
                "10.0.1.5",
                new Device[] {
                    new Device("Сервер Dell", 25000.00, new DateTime(2022, 1, 15)),
                    new Device("UPS", 3000.00, new DateTime(2022, 2, 20)),
                    new Device("Сервер HP", 28000.00, new DateTime(2022, 3, 25)),
                    new Device("Мережевий комутатор", 5000.00, new DateTime(2022, 4, 10))
                }
            );
            computers[3] = new Computer(
                new Person("Ірина", "Коваленко", new DateTime(1992, 4, 15)),
                TypeOfWork.Business,
                "172.16.0.10",
                new Device[] {
                    new Device("Ноутбук Lenovo", 18000.00, new DateTime(2023, 1, 5)),
                    new Device("Зовнішній SSD", 2500.00, new DateTime(2023, 2, 10))
                }
            );
            computers[4] = new Computer(
                new Person("Василь", "Мельник", new DateTime(1985, 8, 25)),
                TypeOfWork.Home,
                "192.168.0.5",
                new Device[] {
                    new Device("Планшет Samsung", 8000.00, new DateTime(2022, 10, 15))
                }
            );

            // Вивід IP-адрес всіх комп'ютерів
            Console.WriteLine("\n===== IP-адреси всіх комп'ютерів =====");
            for (int i = 0; i < computers.Length; i++)
            {
                Console.WriteLine($"Комп'ютер {i + 1}: {computers[i].IPAddress}");
            }

            // Пошук комп'ютера з найбільшою кількістю пристроїв
            Console.WriteLine("\n===== Комп'ютери з найбільшою кількістю пристроїв =====");
            int maxDevices = computers.Max(c => c.Devices.Length);
            var computersWithMaxDevices = computers.Where(c => c.Devices.Length == maxDevices);

            foreach (var comp in computersWithMaxDevices)
            {
                Console.WriteLine(comp.ToShortString());
                Console.WriteLine($"Кількість пристроїв: {comp.Devices.Length}");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Виникла помилка: {ex.Message}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }
}