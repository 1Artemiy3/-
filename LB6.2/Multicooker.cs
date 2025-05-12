



    // Клас "Мультиварка"
    public class Multicooker : HouseholdAppliance
    {
        // Додаткові поля
        private int volumeCapacity; // Об'єм в літрах
        private int numberOfPrograms; // Кількість програм приготування

        // Конструктор без параметрів
        public Multicooker() : base()
        {
            volumeCapacity = 0;
            numberOfPrograms = 0;
        }

        // Конструктор з двома параметрами
        public Multicooker(string name, double price) : base()
        {
            this.name = name;
            this.price = price;
            volumeCapacity = 5;
            numberOfPrograms = 10;
            weight = 3.5;
            manufacturer = "Philips";
        }

        // Конструктор з усіма параметрами
        public Multicooker(string name, double price, double weight, string manufacturer,
                          int volumeCapacity, int numberOfPrograms)
                          : base(name, price, weight, manufacturer)
        {
            this.volumeCapacity = volumeCapacity;
            this.numberOfPrograms = numberOfPrograms;
        }

        // Властивості
        public int VolumeCapacity
        {
            get { return volumeCapacity; }
            set { volumeCapacity = value; }
        }

        public int NumberOfPrograms
        {
            get { return numberOfPrograms; }
            set { numberOfPrograms = value; }
        }

        // Перевизначений метод для виконання дії
        public override void DoWork()
        {
            if (isOn)
            {
                Console.WriteLine(name + " готує їжу");
            }
            else
            {
                Console.WriteLine("Спочатку увімкніть мультиварку!");
            }
        }

        // Метод для вибору програми приготування
        public void SelectProgram(int programNumber)
        {
            if (programNumber > 0 && programNumber <= numberOfPrograms)
            {
                Console.WriteLine("Вибрано програму №" + programNumber);
            }
            else
            {
                Console.WriteLine("Такої програми не існує!");
            }
        }

        // Перевизначений метод ToString
        public override string ToString()
        {
            return base.ToString() +
                   ", Об'єм: " + volumeCapacity + " л" +
                   ", Кількість програм: " + numberOfPrograms;
        }
    }
