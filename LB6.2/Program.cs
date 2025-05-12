using System.Text;

class Program
    {
        static void Main(string[] args)
        {
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("Магазин побутової техніки");
            Console.WriteLine("========================");

            try
            {
                // Створюємо масив побутових пристроїв різних типів
                HouseholdAppliance[] appliances = new HouseholdAppliance[7];

                // Заповнюємо масив різними типами пристроїв
                // Використовуємо різні конструктори
                appliances[0] = new VacuumCleaner();
                appliances[1] = new VacuumCleaner("Samsung SC4520");
                appliances[2] = new VacuumCleaner("Dyson V11", 15000, 3.2, "Dyson", 650, 5);

                appliances[3] = new Multicooker();
                appliances[4] = new Multicooker("Redmond RMC-M90", 3200);

                appliances[5] = new FoodProcessor();
                appliances[6] = new FoodProcessor("Bosch MCM3501M", 4500, "Bosch");

                // Виводимо інформацію про всі пристрої
                Console.WriteLine("\nІнформація про всі пристрої:");
                Console.WriteLine("========================");

                for (int i = 0; i < appliances.Length; i++)
                {
                    Console.WriteLine("Пристрій #" + (i + 1) + ": " + appliances[i]);
                }

                // Розраховуємо загальну вагу всіх товарів
                double totalWeight = 0;

                for (int i = 0; i < appliances.Length; i++)
                {
                    totalWeight += appliances[i].Weight;
                }

                Console.WriteLine("\nЗагальна вага всіх товарів: " + totalWeight + " кг");

                // Знаходимо максимальну вагу серед всіх пристроїв
                double maxWeight = 0;

                for (int i = 0; i < appliances.Length; i++)
                {
                    if (appliances[i].Weight > maxWeight)
                    {
                        maxWeight = appliances[i].Weight;
                    }
                }

                // Виводимо інформацію про найважчі пристрої
                Console.WriteLine("\nНайважчі пристрої (вага = " + maxWeight + " кг):");
                Console.WriteLine("========================");

                bool found = false;

                for (int i = 0; i < appliances.Length; i++)
                {
                    if (appliances[i].Weight == maxWeight)
                    {
                        Console.WriteLine("Назва: " + appliances[i].Name);
                        Console.WriteLine("Детальний опис: " + appliances[i]);
                        Console.WriteLine();
                        found = true;
                    }
                }

                // Якщо найважчих пристроїв не знайдено (порожній результат)
                if (!found)
                {
                    Console.WriteLine("Найважчих пристроїв не знайдено.");
                }

                // Демонстрація роботи методів
                Console.WriteLine("\nДемонстрація роботи методів:");
                Console.WriteLine("========================");

                VacuumCleaner vacuum = new VacuumCleaner("Philips FC9732", 5000, 4.5, "Philips", 750, 3);
                vacuum.TurnOn();
                vacuum.DoWork();
                vacuum.CleanDustContainer();
                vacuum.TurnOff();

                Console.WriteLine();

                Multicooker cooker = new Multicooker("Tefal RK815", 2800, 5.0, "Tefal", 5, 12);
                cooker.TurnOn();
                cooker.SelectProgram(7);
                cooker.DoWork();
                cooker.TurnOff();

                Console.WriteLine();

                FoodProcessor processor = new FoodProcessor("Bosch MCM68840", 7500, 4.8, "Bosch", 7, 12);
                processor.TurnOn();
                processor.ChangeSpeed(3);
                processor.DoWork();
                processor.TurnOff();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Помилка: " + ex.Message);
            }

            Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }
    }
