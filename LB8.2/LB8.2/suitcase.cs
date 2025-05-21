using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB8._2
{
    public class Suitcase
    {
        // Характеристики валізи
        public string Color { get; private set; }
        public string Manufacturer { get; private set; }
        public double Weight { get; private set; }
        public double MaxVolume { get; private set; }

        // Список предметів у валізі
        private List<Item> contents;

        // Поточний заповнений об'єм
        public double CurrentVolume { get; private set; }

        // Залишковий об'єм
        public double RemainingVolume => MaxVolume - CurrentVolume;

        // Конструктор
        public Suitcase()
        {
            contents = new List<Item>();
            CurrentVolume = 0;
        }

        // Конструктор з параметрами
        public Suitcase(string color, string manufacturer, double weight, double maxVolume)
        {
            SetColor(color);
            SetManufacturer(manufacturer);
            SetWeight(weight);
            SetMaxVolume(maxVolume);
            contents = new List<Item>();
            CurrentVolume = 0;
        }

        // заповнення характеристик
        public void SetColor(string color)
        {
            if (string.IsNullOrEmpty(color))
                throw new ArgumentException("Колір не може бути порожнім");
            Color = color;
        }

        public void SetManufacturer(string manufacturer)
        {
            if (string.IsNullOrEmpty(manufacturer))
                throw new ArgumentException("Назва виробника не може бути порожньою");
            Manufacturer = manufacturer;
        }

        public void SetWeight(double weight)
        {
            if (weight <= 0)
                throw new ArgumentException("Вага повинна бути більше нуля");
            Weight = weight;
        }

        public void SetMaxVolume(double volume)
        {
            if (volume <= 0)
                throw new ArgumentException("Об'єм повинен бути більше нуля");
            MaxVolume = volume;
        }

        // отримання списку предметів у валізі
        public List<Item> GetContents()
        {
            return new List<Item>(contents);
        }

        // Подія, що виникає при додаванні предмета
        public event EventHandler<ItemAddedEventArgs> ItemAdded;

        //  додавання предмета з викликом події
        public void AddItem(Item item)
        {
            // Перевірка на переповнення валізи
            if (CurrentVolume + item.Volume > MaxVolume)
            {
                throw new SuitcaseOverflowException(
                    $"Неможливо додати \"{item.Name}\". Залишилось місця: {RemainingVolume} , а потрібно {item.Volume}.");
            }

            // Додаємо предмет
            contents.Add(item);
            CurrentVolume += item.Volume;

            // Викликаємо подію
            OnItemAdded(new ItemAddedEventArgs(item));
        }
        protected virtual void OnItemAdded(ItemAddedEventArgs e)
        {
            ItemAdded?.Invoke(this, e);
        }

        // виведення інформації про валізу
        public override string ToString()
        {
            return $"Валіза: {Color}, виробник: {Manufacturer}, вага: {Weight} кг, " +
                   $"максимальний об'єм: {MaxVolume}, заповнено: {CurrentVolume} , залишилось: {RemainingVolume} ";
        }
    }

    // Клас для передачі інформації про доданий предмет
    public class ItemAddedEventArgs : EventArgs
    {
        public Item AddedItem { get; private set; }

        public ItemAddedEventArgs(Item item)
        {
            AddedItem = item;
        }
    }
   
}
