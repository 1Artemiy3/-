
using LB7._2;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Аероклуб - Реєстр обладнання");
            Console.WriteLine("===========================");

            // Створюємо реєстр
            var registry = new Registry
            {
                new Airplane("Cessna 172", 1500, 4, 200, "Авіоніка Garmin", 1),
                new Airplane("Piper PA-28", 1200, 4, 230, "Навігація TKS", 1),
                new Helicopter("Robinson R44", 650, 4, 190, "GPS Garmin", 1),
                new Helicopter("Bell 407", 1400, 7, 240, "Радар Honeywell", 1),
                new HotAirBalloon("Kubicek BB22", 350, 4, "Нагрівач Kubicek", 0),
                new HotAirBalloon("Cameron Z-90", 280, 3, "Нагрівач Cameron", 0),
                new Deltaplane("Wills Wing T2", 35, 1, null, 0),
                new Deltaplane("Airborne Climax", 40, 1, null, 0),
                new FlyingCarpet("Арабська ніч", 20, 2, "Магічний камінь", 0),
                new FlyingCarpet("Східна казка", 15, 1, "Чарівний пил", 0)
            };

            // Показуємо меню
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nОберіть опцію:");
                Console.WriteLine("1 - Показати всі пристрої");
                Console.WriteLine("2 - Показати електронне обладнання");
                Console.WriteLine("3 - Показати обладнання без двигунів");
                Console.WriteLine("4 - Сортувати за назвою");
                Console.WriteLine("5 - Сортувати за вагою");
                Console.WriteLine("6 - Створити копію пристрою");
                Console.WriteLine("0 - Вихід");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\nВсі пристрої:");
                        registry.ShowAllDevices();
                        break;
                    case "2":
                        Console.WriteLine("\nЕлектронне обладнання:");
                        registry.ShowElectronicDevices();
                        break;
                    case "3":
                        Console.WriteLine("\nОбладнання без двигунів:");
                        registry.ShowDevicesWithoutEngines();
                        break;
                    case "4":
                        registry.SortByName();
                        Console.WriteLine("\nПристрої відсортовані за назвою");
                        registry.ShowAllDevices();
                        break;
                    case "5":
                        registry.SortByWeight();
                        Console.WriteLine("\nПристрої відсортовані за вагою");
                        registry.ShowAllDevices();
                        break;
                    case "6":
                        CloneDevice(registry);
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        // Метод для клонування пристрою
        static void CloneDevice(Registry registry)
        {
            Console.WriteLine("\nДоступні пристрої для клонування:");
            registry.ShowAllDevices();

            Console.WriteLine("\nВведіть індекс пристрою для клонування (0 для скасування):");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= registry.DevicesCount)
            {
                Device original = registry.GetDeviceByIndex(index - 1);
                Device clone = (Device)original.Clone();
                clone.Name += " (Копія)";
                registry.AddDevice(clone);
                Console.WriteLine($"Створено копію: {clone.Name}");
            }
            else if (index != 0)
            {
                Console.WriteLine("Невірний індекс пристрою.");
            }
        }
    }
