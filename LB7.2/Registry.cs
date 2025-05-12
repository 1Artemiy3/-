
using LB7._2;
using System;
using System.Collections.Generic;
using System.Linq;


    
    public class Registry : List<Device>
    {
        // Властивість для отримання кількості пристроїв
        public int DevicesCount => Count;

        // Метод для отримання пристрою за індексом
        public Device GetDeviceByIndex(int index)
        {
            if (index >= 0 && index < Count)
            {
                return this[index];
            }
            return null;
        }

        // Метод для виведення списку всього обладнання
        public void ShowAllDevices()
        {
            if (Count == 0)
            {
                Console.WriteLine("Реєстр порожній.");
                return;
            }

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"[{i + 1}]");
                this[i].DisplayInfo();
                Console.WriteLine();
            }
        }

        // Метод для виведення електронного обладнання
        public void ShowElectronicDevices()
        {
            var electronicDevices = this.Where(d => d.HasElectronics).ToList();

            if (electronicDevices.Count == 0)
            {
                Console.WriteLine("Електронне обладнання відсутнє.");
                return;
            }

            for (int i = 0; i < electronicDevices.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]");
                electronicDevices[i].DisplayInfo();
                Console.WriteLine();
            }
        }

        // Метод для виведення обладнання без двигунів
        public void ShowDevicesWithoutEngines()
        {
            var devicesWithoutEngines = this.Where(d => !d.HasEngine).ToList();

            if (devicesWithoutEngines.Count == 0)
            {
                Console.WriteLine("Обладнання без двигунів відсутнє.");
                return;
            }

            for (int i = 0; i < devicesWithoutEngines.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]");
                devicesWithoutEngines[i].DisplayInfo();
                Console.WriteLine();
            }
        }

        // Метод для сортування за назвою (перший критерій сортування)
        public void SortByName()
        {
            Sort((a, b) => a.Name.CompareTo(b.Name));
        }

        // Метод для сортування за вагою (другий критерій сортування)
        public void SortByWeight()
        {
            Sort((a, b) => a.Weight.CompareTo(b.Weight));
        }

    internal void AddDevice(Device clone)
    {
        throw new NotImplementedException();
    }
}
