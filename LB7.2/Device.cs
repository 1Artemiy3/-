


using LB7._2;

public abstract class Device : IDevice, IEngine, ICloneable
    {
        // Реалізація IDevice
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Capacity { get; set; }
        public abstract string Description { get; }
        public abstract bool HasElectronics { get; }

        // Реалізація IEngine
        public int EngineCount { get; set; }
        public abstract string EngineType { get; }
        public bool HasEngine => EngineCount > 0;

        // Електронне обладнання (якщо є)
        protected string Electronics { get; set; }

        // Конструктор
        public Device(string name, double weight, int capacity, string electronics, int engineCount)
        {
            Name = name;
            Weight = weight;
            Capacity = capacity;
            Electronics = electronics;
            EngineCount = engineCount;
        }

        // Метод для відображення інформації про пристрій
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"--- {Name} ---");
            Console.WriteLine($"Тип: {Description}");
            Console.WriteLine($"Вага: {Weight} кг");
            Console.WriteLine($"Місткість: {Capacity} осіб");
            Console.WriteLine($"Двигуни: {(HasEngine ? $"{EngineCount} шт., {EngineType}" : "Немає")}");
            Console.WriteLine($"Електроніка: {(HasElectronics ? Electronics : "Немає")}");
        }

        // Клонування об'єкта (реалізація інтерфейсу ICloneable)
        public abstract object Clone();
    }
