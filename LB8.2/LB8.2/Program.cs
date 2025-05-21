/*
 Завдання 2. Створіть клас «Валіза». Характеристики валізи: колір; фірмавиробник; вага валізи; об’єм валізи; вміст валізи(список об’єктів, у кожного
об’єкта крім назви потрібно враховувати об’єм, що займає). Створіть методи 
заповнення характеристик. Створіть подію та її слухача, щоб додати об’єкт до 
валізи. Якщо при спробі додавання може бути перевищений обсяг валізи,
потрібно генерувати виняток*/

using LB8._2;
using System;

class program()
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("Програма для роботи з валізою");
                Console.WriteLine("------------------------------");

             
                Suitcase mySuitcase = new Suitcase("Синій", "SamsonTech", 2.5, 30.0);

                
                mySuitcase.ItemAdded += OnItemAddedToSuitcase;

                // Виводимо інформацію про валізу
                Console.WriteLine(mySuitcase);
                Console.WriteLine();

                // Додаємо  предмети
                Console.WriteLine("Додаємо речі до валізи:");
                mySuitcase.AddItem(new Item("Футболка", 0.5));
                mySuitcase.AddItem(new Item("Джинси", 1.2));
                mySuitcase.AddItem(new Item("Ноутбук", 3.0));
                mySuitcase.AddItem(new Item("Книги", 4.0));
                mySuitcase.AddItem(new Item("Зарядний пристрій", 0.3));

                //  оновлена інформація про валізу
                Console.WriteLine();
                Console.WriteLine(mySuitcase);

                //  список усіх предметів
                Console.WriteLine();
                Console.WriteLine("Всі предмети у валізі:");
                foreach (var item in mySuitcase.GetContents())
                {
                    Console.WriteLine($"- {item}");
                }

                // додаємо предмет який не поміститься
                Console.WriteLine();
                Console.WriteLine("Спроба додати великий предмет:");
                mySuitcase.AddItem(new Item("Намет", 25.0));
            }
            catch (SuitcaseOverflowException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Несподівана помилка: {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Натисніть будь-яку клавішу для завершення...");
            Console.ReadKey();
        }

        // Метод-обробник події додавання предмета
        static void OnItemAddedToSuitcase(object sender, ItemAddedEventArgs e)
        {
            Console.WriteLine($"Додано: {e.AddedItem.Name} з об'ємом {e.AddedItem.Volume} ");
        }
    }

}

